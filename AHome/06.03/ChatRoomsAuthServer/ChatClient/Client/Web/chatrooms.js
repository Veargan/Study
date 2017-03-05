var ws;
var login;
var password;
var roomlist;
var clientlist;
var msglist;
var roomname;
var activeRoom;
var oldpassword;
var newpassword;
var str;
var loginforgot;
var emailforgot;
var online;
var authorization;
var fblogin;
var fbid;
var gllogin;
var glid;

window.onload = function () {
    login = document.getElementById("login");
    password = document.getElementById("password");
    roomlist = document.getElementById("roomlist");
    clientlist = document.getElementById("clientlist");
    msglist = document.getElementById("msglist");
    roomname = document.getElementById("newroom");
    activeRoom = "";
    oldpassword = document.getElementById("oldpassword");
    newpassword = document.getElementById("newpassword");
    str = "";
    loginforgot = document.getElementById("loginforgot");
    emailforgot = document.getElementById("emailforgot");
    fblogin = "";
    fbid = 0;
    gllogin = "";
    glid = 0;
    online = false;
    authorization = false;
};
////////////////////////////////////////////////////////////////////////////

function handleClientLoad() {
    gapi.load('client:auth2', initClient);
}

function initClient() {
    gapi.client.init({
        apiKey: 'AIzaSyBnEOIaggPsxnknr0iO-x-8moUZEMP0Wbc',
        //apiKey: 'AIzaSyC0Coo32xSm5dIhISGUt-4ToLpPUdCtWqg',
        discoveryDocs: ["https://people.googleapis.com/$discovery/rest?version=v1"],
        clientId: '793463381786-9jcm91mf2np712dombqduu8mu05h5lnp.apps.googleusercontent.com',
        //clientId: '752325618450-0bgiqri82atavrgbja9djkoci1u0l9qp.apps.googleusercontent.com',
        scope: 'profile'
    }).then(function () {
        // Listen for sign-in state changes.
        gapi.auth2.getAuthInstance().isSignedIn.listen(updateSigninStatus);

        // Handle the initial sign-in state.
        updateSigninStatus(gapi.auth2.getAuthInstance().isSignedIn.get());
    });
}

function updateSigninStatus(isSignedIn) {
    // When signin status changes, this function is called.
    // If the signin status is changed to signedIn, we make an API call.
    if (isSignedIn) {
        makeApiCall();
    }
}

function handleSignInClick(event) {
    // Ideally the button should only show up after gapi.client.init finishes, so that this
    // handler won't be called before OAuth is initialized.
    gapi.auth2.getAuthInstance().signIn();
}

function handleSignOutClick(event) {
    var message = "logout";
    ws.send(message);
    setTimeout(function () {
        ws.close();
    }, 2000);
    showAuthPage();
    gapi.auth2.getAuthInstance().signOut();
    console.log('User signed out.');
}

function makeApiCall() {
    // Make an API call to the People API, and print the user's given name.
    gapi.client.people.people.get({
        resourceName: 'people/me'
    }).then(function (response) {
        console.log('Hello, ' + response.result.names[0].givenName);
        console.log('Email: ' + response.result.emailAddresses[0].value);
        console.log('People: ' + response.result.resourceName)
        gllogin = response.result.names[0].givenName
        var output = response.result.resourceName.split('/');
        glid = output[1];
        connect("reggl");
        setTimeout(function () {
        }, 5000);
    }, function (reason) {
        console.log('Error: ' + reason.result.error.message);
    });
}

///////////////////////////////////////////////////////////////////////////

function statusChangeCallback(response) {
    console.log('statusChangeCallback');
    console.log(response);
    if (response.status === 'connected') {
        regfb();
    } else if (response.status === 'not_authorized') {
        document.getElementById('status').innerHTML = 'Please log ' +
          'into this app.';
    } else {
        document.getElementById('status').innerHTML = 'Please log ' +
          'into Facebook.';
    }
}

function checkLoginState() {
    FB.getLoginStatus(function (response) {
        statusChangeCallback(response);
    });
}

window.fbAsyncInit = function () {
    FB.init({
        appId: '{782180468606086}',
        cookie: true,  // enable cookies to allow the server to access 
        // the session
        xfbml: true,  // parse social plugins on this page
        version: 'v2.8' // use graph api version 2.8
    });

    //FB.getLoginStatus(function (response) {
    //    statusChangeCallback(response);
    //});
};

function fbLogout() {
    FB.getLoginStatus(function (response) {
        if (response.status === 'connected') {
            FB.logout(function (response) {
                var message = "logout";
                ws.send(message);
                setTimeout(function () {
                    ws.close();
                }, 2000);
                showAuthPage();
            });
        }
        else {
            var message = "logout";
            ws.send(message);
            setTimeout(function () {
                ws.close();
            }, 2000);
            showAuthPage();
            gapi.auth2.getAuthInstance().signOut();
            console.log('User signed out.');
        }
    });
}

function regfb() {
    console.log('Welcome!  Fetching your information.... ');
    FB.api('/me', { fields: 'name, email, first_name, last_name' }, function (response) {
        document.getElementById('status').innerHTML = 'name = ' + response.name + ' email = ' + response.email + '. Fn: ' + response.first_name + ', Ln: ' + response.last_name + '. Username: ' + response.username + '. ID: ' + response.id;
        fblogin = response.first_name;
        fbid = response.id;
        connect("regfb");
        setTimeout(function () {
        }, 5000);
    });
}

function connect(command) {
    try {
        if (ws === undefined) {
            ws = new WebSocket("ws://localhost:8080");
        }
        else 
            ws = new WebSocket("ws://localhost:8888");
    }
    finally {
        str = "Server is not available";
    }

    ws.onopen = function () {
        if (command == "auth") {
            message = login.value + "^" + password.value + "^0^auth";
            ws.send(message);
        }
        else if (command == "reg") {
            message = login.value + "^" + password.value + "^0^reg";
            ws.send(message);
        }
        else if (command == "restore") {
            message = "restore^" + loginforgot.value + "^" + emailforgot.value;
            ws.send(message);
        }
        else if (command == "authfb") {
            message = fblogin + "^" + fbid + "^0^authfb";
            ws.send(message);
        }
        else if (command == "regfb") {
            message = fblogin + "^" + fbid + "^0^regfb";
            ws.send(message);
        }
        else if (command == "authgl") {
            message = gllogin + "^" + glid + "^0^authgl";
            ws.send(message);
        }
        else if (command == "reggl") {
            message = gllogin + "^" + glid + "^0^reggl";
            ws.send(message);
        }
    };

    ws.onmessage = function (evt) {
        var received_msg = evt.data;
        listener(received_msg);
    };

    ws.onclose = function () {
        var c = "Connection is closed...";
        if (str != "") {
            c = str;
            str = "";
        }
    };
}

function onAuthorization() {
    if (checkRA())
        connect("auth");
}

function onRegistration() {
    if (checkRA())
        connect("reg");
}

function onForgotPass() {
    if (checkForgot())
        connect("restore");
}

function showAuthPage() {
    document.getElementById("authentication").style.display = 'flex';
    document.getElementById("room").style.display = 'none';
    document.getElementById("chat").style.display = 'none';
    document.getElementById("changepass").style.display = 'none';
    document.getElementById("forgotpass").style.display = 'none';
    document.getElementById("admintools").style.display = 'none';
}

function showForgotPassPage() {
    document.getElementById("authentication").style.display = 'none';
    document.getElementById("room").style.display = 'none';
    document.getElementById("chat").style.display = 'none';
    document.getElementById("changepass").style.display = 'none';
    document.getElementById("forgotpass").style.display = 'flex';
    document.getElementById("admintools").style.display = 'none';
}

function showChangePassPage() {
    document.getElementById("authentication").style.display = 'none';
    document.getElementById("room").style.display = 'none';
    document.getElementById("chat").style.display = 'none';
    document.getElementById("changepass").style.display = 'flex';
    document.getElementById("forgotpass").style.display = 'none';
    document.getElementById("admintools").style.display = 'none';
}

function showAdminTools() {
    document.getElementById("authentication").style.display = 'none';
    document.getElementById("room").style.display = 'flex';
    document.getElementById("chat").style.display = 'none';
    document.getElementById("changepass").style.display = 'none';
    document.getElementById("forgotpass").style.display = 'none';
    document.getElementById("admintools").style.display = 'flex';
}

function showRoomPage() {
    document.getElementById("authentication").style.display = 'none';
    document.getElementById("room").style.display = 'flex';
    document.getElementById("chat").style.display = 'none';
    document.getElementById("changepass").style.display = 'none';
    document.getElementById("forgotpass").style.display = 'none';
    document.getElementById("admintools").style.display = 'none';
}

function showChatPage() {
    document.getElementById("authentication").style.display = 'none';
    document.getElementById("room").style.display = 'none';
    document.getElementById("chat").style.display = 'flex';
    document.getElementById("changepass").style.display = 'none';
    document.getElementById("forgotpass").style.display = 'none';
    document.getElementById("admintools").style.display = 'none';
}

function onChangePass() {
    if (checkPass())
        ws.send("changepass^" + oldpassword.value + "^" + newpassword.value);
}

function checkRA() {
    if (login.value == "" || password.value == "") {
        alert("Empty username or password");
        return false;
    }
    else if (/^[a-zA-Z1-9]+$/.test(login.value) === false && /^[a-zA-Z1-9]+$/.test(password.value) === false) {
        alert('Invalid login or pass');
        return false;
    }
    if (login.value.length > 15) {
        alert('Very long username! Enter username till 15 symbols.');
        return false;
    }

    return true;
}

function checkForgot() {
    if (loginforgot.value == "" || emailforgot.value == "") {
        alert("Empty username or password");
        return false;
    }
    else if (/^[a-zA-Z1-9]+$/.test(loginforgot.value) === false) {
        alert('Invalid login or pass');
        return false;
    }
    if (loginforgot.value.length > 15) {
        alert('Very long username! Enter username till 15 symbols.');
        return false;
    }

    return true;
}

function checkPass() {
    if (oldpassword.value == "" || newpassword.value == "") {
        alert("Empty username or password");
        return false;
    }
    else if (/^[a-zA-Z1-9]+$/.test(oldpassword.value) === false && /^[a-zA-Z1-9]+$/.test(newpassword.value) === false) {
        alert('Invalid login or pass');
        return false;
    }
    if (login.value.length > 15) {
        alert('Very long username! Enter username till 15 symbols.');
        return false;
    }

    return true;
}

function createRoom(roomName) {
    if (roomName != null && checkRoom(roomName)) {
        var message = "new^" + roomName;
        ws.send(message);
    }
    document.getElementById('roomname').value = "";
}

function checkRoom(roomName) {
    for (var i = 0; i < roomlist.length; i++) {
        if (roomlist.options[i].value == roomName) {
            alert("This room already exists. Choouse another room name!");
            return false;
        }
    }
    if (roomName.length == 0) {
        alert('Please enter the room name');
        return false;
    }
    else if (roomName.length > 20) {
        alert('Very long room name! Enter room name till 20 symbols.');
        return false;
    }
    return true;
}

function connectToRoom() {
    if (roomlist.selectedIndex == -1) {
        alert("Please select room");
    }
    else {
        index = roomlist.selectedIndex;
        var roomName = roomlist.options[index].value.split(' ');
        var message = "connect^" + roomName;
        activeRoom = roomName;
        ws.send(message);
        showChatPage();
    }
}

function unsubscribe() {
    if (roomlist.selectedIndex == -1) {
        alert("Please select room");
    }
    else {
        index = roomlist.selectedIndex;
        var roomName = roomlist.options[index].value.split(' ');
        var message = "unsubscribe^" + roomName;
        ws.send(message);
    }
}

function exitRoom() {
    var message = "exit^" + activeRoom + "^";
    activeRoom = "";
    ws.send(message);
    showRoomPage();
    if (login.value == "admin")
        showAdminTools();
}

function sendMsgInRoom(msg) {
    if (msg.length > 500) {
        alert('Please enter message lesser than 500 symbols.')
    }
    else if (msg === "") {
        alert('Please enter message.');
    } else {
        var message = "message^" + activeRoom + "^" + msg;
        ws.send(message);
        document.getElementById("roommsg").value = "";
    }
}

function ban(time) {
    if (clientlist.selectedIndex == -1) {
        alert("Please select user for ban.");
    } else {
        index = clientlist.selectedIndex;
        var clientNameForBan = clientlist.options[index].value.split(' ');
        var message = "ban^" + time + "^" + clientNameForBan;
        ws.send(message);
        document.getElementById("bantime").value = "";
    }
}

function unban() {
    if (clientlist.selectedIndex == -1) {
        alert("Please select user for unban.");
    } else {
        index = clientlist.selectedIndex;
        var clientNameForBan = clientlist.options[index].value.split(' ');
        var message = "unban^" + clientNameForBan;
        ws.send(message);
    }
}

function logout() {
    var message = "logout";
    ws.send(message);
    setTimeout(function () {
        ws.close();
    }, 2000);
    showAuthPage();
}

function sendPrivateMsg(msg) {
    if (msg.length > 500) {
        alert('Please enter message lesser then 500 symbols.');
    }
    else if (msg === "") {
        alert('Please enter message.');
    }
    else if (clientlist.selectedIndex == -1) {
        alert("Please select user");
    }
    else {
        index = clientlist.selectedIndex;
        var whom = clientlist.options[index].value.split(' ');
        var message = "pmessage^" + whom + "^" + msg;
        ws.send(message);
        document.getElementById("privatemsg").value = "";
    }
}

function setHistory(roomName, history) {
    var msgs = history.split('~');
    var j = 0;
    for (var i = 0; i < msgs.length - 1; i++) {
        document.getElementById("txt_chat").innerHTML += msgs[i] + "\n";
        //var optionElement = new Option(msgs[i] + ": ", msgs[++i]);
        //msglist.options[j++] = optionElement;
    }
}

function listener(output) {
    var msg = output.split('^');

    switch (msg[0]) {
        case "list":
            while (roomlist.length > 0) {
                roomlist.remove(roomlist.length - 1);
            }
            var j = 0;
            for (var i = 1; i < msg.length; i++) {
                if (msg[i] != "") {
                    var optionElement = new Option(msg[i], msg[i]);
                    optionElement.id = msg[i];
                    roomlist.options[j++] = optionElement;
                }
            }
            break;

        case "clientlist":
            while (clientlist.length > 0) {
                clientlist.remove(clientlist.length - 1);
            }
            var j = 0;
            for (var i = 1; i < msg.length; i++) {
                if (msg[i] != "" && msg[i] != "admin") {
                    var optionElement = new Option(msg[i], msg[i]);
                    optionElement.id = msg[i];
                    clientlist.options[j++] = optionElement;
                }
            }
            break;

        case "message":
            document.getElementById("txt_chat").innerHTML += msg[2] + "\n";
            break;

        case "pmessage":
            var userMsg = msg[2].split(':');
            alert("New private message from " + userMsg[0] + ": " + userMsg[1]);
            break;

        case "notification":
            alert("У ВАС НОТИФИКАЦИЯ!!! АХТУНГ" + userMsg[1]);
            break;

        case "history":
            setHistory(msg[1], msg[2]);
            break;

        case "success":
            online = true;
            // setTimeout(function () {
            //     ws.CLOSED = true;
            // }, 5000);
            showRoomPage();
            document.getElementById('username').innerHTML = login.value;
            if (login.value === "admin")
                showAdminTools();
            connect(msg[2]);
            break;

        case "authfail":
            alert("Invalid login or password");
            break;

        case "regfail":
            alert("This username already exists. Choose another name!");
            break;

        case "authfailfb":
            authorization = false;
            alert("Invalid login or password");
            break;

        case "regfailfb":
            authorization = true;
            setTimeout(function () {
                ws.CLOSED = true;
            }, 5000);

            connect("authfb");
            break;

        case "authfailgl":
            authorization = false;
            alert("Invalid login or password");
            break;

        case "regfailgl":
            authorization = true;
            setTimeout(function () {
                ws.CLOSED = true;
            }, 5000);

            connect("authgl");
            setTimeout(function () {
                ws.CLOSED = true;
            }, 5000);
            break;

        case "alreadyinside":
            alert("This user already in the chat. Don't distract him!");
            break;

        case "banstill":
            alert("You have been banned! Action is not allowed!");
            break;

        case "banover":
            alert("Your ban time is over!");
            break;

        case "ban":
            alert("You have been banned " + msg[1]);
            break;

        case "unban":
            alert("You have been unbanned!");
            break;

        case "changepasssuccess":
            alert("With God help. Password has been successfully changed");
            showRoomPage();
            if (login.value === "admin")
                showAdminTools();
            break;

        case "changepassfail":
            alert("Unfortunately. You are dumb ass shit");
            break;

        case "restoresuccess":
            alert("Password was sent to your email");
            setTimeout(function () {
                ws.close();
            }, 1000);
            showAuthPage();
            break;

        case "restorefail":
            alert("Invalid data");
            setTimeout(function () {
                ws.close();
            }, 1000);
            break;
    }
}