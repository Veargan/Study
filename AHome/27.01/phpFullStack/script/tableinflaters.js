function xmltableInflator(response){
	var xmlParser = new DOMParser();
	var doc = xmlParser.parseFromString(response, "text/xml");
	var root = doc.firstChild;
	

	var persons = new Array();
	for(i = 0; i < root.children.length; i++)
	{
		persons.push(new Person(root.children[i].children[0].innerHTML, root.children[i].children[1].innerHTML, root.children[i].children[2].innerHTML, root.children[i].children[3].innerHTML));
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

function Parse(response)
{
	var persons = new Array();
	var res = response.split('\n')																			;
	for (var i = 1; i < res.length-1; i += 1)
	{
		var items = res[i].split(',');
		persons.push(new Person(items[0], items[1], items[2], items[3]));
	}
	return persons;
}

function csvtableInflator(response){

	var persons = Parse(response);
	var personRows = "";
	for (var i = 0; i < persons.length-1; i += 1) {
		personRows += "<tr class=\"tableItem\">";
		personRows += "<td class=\"tableItem\">" + persons[i].id + "</td>";
		personRows += "<td class=\"tableItem\">" + persons[i].fName + "</td>";
		personRows += "<td class=\"tableItem\">" + persons[i].lName + "</td>";
		personRows += "<td class=\"tableItem\">" + persons[i].age + "</td>";
		personRows += "</tr>";
	}
	
	return personRows;
}

function yamltableInflator(response)
{
	var str=response.split('-');

	var persons = new Array();

	for (var i = 4; i < str.length; i += 1)
	{
		var tmp_str = str[i].replace(' Id:', '').replace(' fname:', '').replace(' lname:', '').replace(' age:', '').replace(/"/g, '').replace('.', '').replace('.', '').replace('.', '');
		var tmp_str_arr=tmp_str.split(' ');
		persons.push(new Person(tmp_str_arr[1], tmp_str_arr[3], tmp_str_arr[5], tmp_str_arr[7]));
	}
	
	var personRows = "";
	for (var i = 0; i < persons.length; i += 1)
	{
		personRows += persons[i].ToHtml();
	}
	
	return personRows;
}

function xslttableInflator(response)
{

	var xmlParser = new DOMParser();
	var xmll = xmlParser.parseFromString(response, "text/xml");
	var xsl = loadXMLDoc("person.xslt");
	var xsltProcessor = new XSLTProcessor();
	xsltProcessor.importStylesheet(xsl);
	var resultDocument = xsltProcessor.transformToFragment(xmll, document);
	return resultDocument.childNodes[0].innerHTML;	  
}

function jsontableInflator(response){
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

function loadXMLDoc(filename)
{
	xhttp = new XMLHttpRequest();

	xhttp.open("GET", filename, false);
	try {xhttp.responseType = "msxml-document"} catch(err) {} // Helping IE11
	xhttp.send("");
	return xhttp.responseXML;
}
