var nickname = document.getElementById("nickname");
var b_submit = document.getElementById("submit");

b_submit.addEventListener("click", function() {
	var xmlhttp = new XMLHttpRequest();
	xmlhttp.open("GET", "../API/server.php?query=auth&name=" + nickname.value, false);
	xmlhttp.send();
});