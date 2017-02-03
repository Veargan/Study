var player_list = document.getElementById("list_of_free_players");
var b_invite = document.getElementById("button_invite");
var statusbar = document.getElementById("statusbar");
var radiobutton = '<input onclick="GetSelectedName(name.value)" type="radio" name="list" id="name">';
var nickname;
var nameToPlayWith;
var timer;

window.onload = function(){
	var getlist = new XMLHttpRequest();
	getlist.open("GET", "../API/server.php?query=getname", false);
	getlist.send();
	
	if (getlist.readyState == 4 && getlist.status == 200) {
		var response = getlist.responseText.split(',');
		if (response[0] == "getname"){
			nickname = response[1];
			statusbar.innerHTML = nickname;
			timer = setInterval(OnTimer, 1000);
		}
	}
}

function OnTimer(){
	var getlist = new XMLHttpRequest();
	getlist.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			var names = this.responseText.split(',');
			if (names[0] == "getlist") {
				player_list.innerHTML = "";
				for	(var i = 1; i < names.length; i += 1){
					player_list.innerHTML += '<input onclick="GetSelectedName(' + names[i] + ')" type="radio" name="list" id="' + names[i] + '">' + names[i] + "<Br>";
				}
			}
		}
	};
	getlist.open("GET", "../API/server.php?query=getlist", true);
	getlist.send();
	
	var getinvite = new XMLHttpRequest();
	getinvite.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			var response = this.responseText.split(',');
			if (response[0] == "getinvite") {
				if (response[3] == 2){
					if (response[1] == nickname || response[2] == nickname){
						// request for game session
					}
					return;
				}
				else if (response[3] == 1 && response[2] == nickname){
					var result = confirm("Do you want to play in Tic Tac Toe with " + response[1] + "?");
					if (result){
						SendSuccess(response[1]);
					}
				}
			}
		}
	};
	getinvite.open("GET", "../API/server.php?query=getinvite&name=" + nickname, true);
	getinvite.send();
}

function SendSuccess(name1){
	var success = new XMLHttpRequest();
	success.open("GET", "../API/server.php?query=success&name1=" + name1 + "&name2=" + nickname, true);
	success.send();
}

b_invite.addEventListener("click", function() {
	var invite = new XMLHttpRequest();
	invite.open("GET", "../API/server.php?query=invite&name1=" + nameToPlayWith + "&name2=" + nickname, true);
	invite.send();
	timer = setInterval(OnTimer, 1000);
});

function GetSelectedName(name1){
	nameToPlayWith = name1.getAttribute('id');
	clearInterval(timer);
}