var ws;
var login;
var password;
var roomlist;
var clientlist;
var msglist;
var roomname;

window.onload = function () {
    login = document.getElementById("login");
    password = document.getElementById("password");
    roomlist = document.getElementById("roomlist");
    clientlist = document.getElementById("clientlist");
    msglist = document.getElementById("msglist");
    roomname = document.getElementById("newroom");
}

function connect() {
    ws = new WebSocket("ws://localhost:8888");

    ws.onopen = function () {
        message = login.value + "^" + password.value + "^0^auth";
        ws.send(message);
    };

    ws.onmessage = function (evt) {
        alert("About to receive data");
        var received_msg = evt.data;
        alert("Message received = " + received_msg);
        listener(received_msg);
    };
    ws.onclose = function () {
        alert("Connection is closed...");
    };
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
        ws.send(message);
    }
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
    for (var i = 0; i < msgs.length - 1; i++) {
        var j = 0;
        var optionElement = new Option(msgs[i] + ": ", msgs[++i]);
        msglist.options[j++] = optionElement;
    }
}

function listener(output) {
    var msg = output.split('^');

    switch (msg[0])
    {
        case "list":
            while (roomlist.length > 0) {
                roomlist.remove(roomlist.length - 1);
            }

            for (var i = 1; i < msg.length; i++) {
                if (msg[i] != "") {
                    var j = 0;
                    var optionElement = new Option(msg[i], msg[i]);
                    roomlist.options[j++] = optionElement;
                }
            }
            break;

        case "clientlist":
            while (clientlist.length > 0) {
                clientlist.remove(clientlist.length - 1);
            }

            for (var i = 1; i < msg.length; i++) {
                if (msg[i] != "") {
                    var j = 0;
                    var optionElement = new Option(msg[i], msg[i]);
                    clientlist.options[j++] = optionElement;
                }
            }
            break;

        case "message":
            break;

        case "pmessage":
            var userMsg = msg[2].split(':');
            alert("New private message from " + userMsg[0] + ": " + userMsg[1]);
            break;

        case "notification":
            break;

        case "history":
            setHistory(msg[1], msg[2]);
            break;

        case "fail":
            alert("This username already exists. Choose another name!");
            break;

        case "success":  
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
    }
}