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
	xmlhttp.open("GET", "../API/PersonDAO_API_AJAX_JSON.php?query=create&id=" + i_id.value +
	"&firstName=" + i_firstName.value + "&lastName=" + i_lastName.value + "&age=" + i_age.value, true);
	xmlhttp.send();
}

function onread() {
	var xmlhttp = new XMLHttpRequest();
	xmlhttp.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			var result = tableInflator(this.responseText);

			document.getElementById("daoTable").innerHTML = tableHeader;
			document.getElementById("daoTable").innerHTML += result;
		}
	};
	xmlhttp.open("GET", "../API/PersonDAO_API_AJAX_JSON.php?query=read", true);
	xmlhttp.send();
}

function onupdate() {
	var xmlhttp = new XMLHttpRequest();
	xmlhttp.open("GET", "../API/PersonDAO_API_AJAX_JSON.php?query=update&id=" + i_id.value +
	"&firstName=" + i_firstName.value + "&lastName=" + i_lastName.value + "&age=" + i_age.value, true);
	xmlhttp.send();
}

function ondelete() {
	var xmlhttp = new XMLHttpRequest();
	xmlhttp.open("GET", "../API/PersonDAO_API_AJAX_JSON.php?query=delete&id=" + i_id.value, true);
	xmlhttp.send();
}

function tableInflator(response){
	var result = JSON.parse(response, function(k, v) {
		return v;
	});

	var persons = new Array();
	for (var i = 0; i < result.length; i += 1){
		persons.push(new Person(result[i].id, result[i].firstName, result[i].lastName, result[i].age));
	}
	
	var personRows = "";
	for (var i = 0; i < persons.length; i += 1) {
		personRows += "<tr class=\"tableItem\">";
		personRows += "<td class=\"tableItem\">" + persons[i].id + "</td>";
		personRows += "<td class=\"tableItem\">" + persons[i].fName + "</td>";
		personRows += "<td class=\"tableItem\">" + persons[i].lName + "</td>";
		personRows += "<td class=\"tableItem\">" + persons[i].age + "</td>";
		personRows += "</tr>";
	}
	
	return personRows;
}

function Person(id, fName, lName, age){
	this.id = id;
	this.fName = fName;
	this.lName = lName;
	this.age = age;
}