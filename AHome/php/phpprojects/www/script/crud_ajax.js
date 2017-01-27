var create = document.getElementById("create");
var read = document.getElementById("read");
var update = document.getElementById("update");
var del = document.getElementById("delete");
var tableHeader = "<tr class=\"tableItem\">"
			+ "<td class=\"tableItem\">Id</td>"
			+ "<td class=\"tableItem\">First Name</td>"
			+ "<td class=\"tableItem\">Last Name</td>"
			+ "<td class=\"tableItem\">Age</td>"
			+ "</tr>";

create.addEventListener("click", oncreate);
read.addEventListener("click", onread);
update.addEventListener("click", onupdate);
del.addEventListener("click", ondelete);

function oncreate() {
	var xmlhttp = new XMLHttpRequest();
	xmlhttp.open("GET", "../API/PersonDAO_API_AJAX.php?query=create&id=" + i_id.value +
		"&firstName=" + i_firstName.value + "&lastName=" + i_lastName.value + "&age=" + i_age.value, true);
	xmlhttp.send();
}

function onread() {
	var xmlhttp = new XMLHttpRequest();
	xmlhttp.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			document.getElementById("daoTable").innerHTML = tableHeader;
			document.getElementById("daoTable").innerHTML += this.responseText;
		}
	};
	xmlhttp.open("GET", "../API/PersonDAO_API_AJAX.php?query=read", true);
	xmlhttp.send();
}

function onupdate() {
	var xmlhttp = new XMLHttpRequest();
	xmlhttp.open("GET", "../API/PersonDAO_API_AJAX.php?query=update&id=" + i_id.value +
		"&firstName=" + i_firstName.value + "&lastName=" + i_lastName.value + "&age=" + i_age.value, true);
	xmlhttp.send();
}

function ondelete() {
	var xmlhttp = new XMLHttpRequest();
	xmlhttp.open("GET", "../API/PersonDAO_API_AJAX.php?query=delete&id=" + i_id.value, true);
	xmlhttp.send();
}