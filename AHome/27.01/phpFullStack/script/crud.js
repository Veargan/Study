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
var format;
				
create.addEventListener("click", function() {
	setFormat();
	format.create(i_id.value, i_firstName.value, i_lastName.value, i_age.value);
});

read.addEventListener("click", function() {
	setFormat();
	format.read();
});

update.addEventListener("click", function() {
	setFormat();
	format.update(i_id.value, i_firstName.value, i_lastName.value, i_age.value);
});

del.addEventListener("click", function() {
	setFormat();
	format.del(i_id.value, i_firstName.value, i_lastName.value, i_age.value);
});


function setFormat(){
	var ft = document.getElementById("fm");
	switch(ft.options[ft.options.selectedIndex].innerText)
	{
		case "Html":
		format = new PD_Html();
		break;
		case "Xml":
		format = new PD_Xml();
		break;
		case "Json":
		format = new PD_Json();
		break;
		case "CSV":
		format = new PD_CSV();
		break;
		case "Yaml":
		format = new PD_Yaml();
		break;
		case "XmlXslt":
		format = new PD_XmlXslt();
		break;
	}
}