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
    online = false;
}

function connect(command) {
    try 
    {
        ws = new WebSocket("ws://localhost:8888");
    }
    finally
    {
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
    };

    ws.onmessage = function (evt) {
        //alert("About to receive data");
        var received_msg = evt.data;
        //alert("Message received = " + received_msg);
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

function showAuthPage(){
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
}

function checkRoom(roomName) {

    if (roomName.length == 0) {
        alert('Please enter the room name');
        return false;
    }
    else if (roomName.length > 20) {
        alert('Very long room name! Enter room name till 20 symbols.');
        return false
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
		showChatPage()
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
    showRoomPage()
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
	showAuthPage()
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
            showRoomPage()
            if (login.value === "admin")
                showAdminTools();
            break;

        case "authfail":
            alert("Invalid login or password");
            break;

        case "regfail":
            alert("This username already exists. Choose another name!");
            break;

        case "alreadyinside":
            Alert("This user already in the chat. Don't distract him!");
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
            showRoomPage()
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
            }, 10000);
			showAuthPage()
            break;

        case "restorefail":
            alert("Invalid data");
            setTimeout(function () {
                ws.close();
            }, 10000);
            break;
    }
}