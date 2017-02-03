var Proto = {
	
	create: function(id,fname,lname,age){
		var xmlhttp = new XMLHttpRequest();
		var message = new Message("create","",new Person(id,fname,lname,age));
		var msg = JSON.stringify(message);
		xmlhttp.open("GET", "../API/PersonDAO_API_AJAX1.php?query=" + msg, true);
		xmlhttp.send();
	},
	
	update: function(id,fname,lname,age){
		var xmlhttp = new XMLHttpRequest();
		var message = new Message("update","",new Person(id,fname,lname,age));
		var msg = JSON.stringify(message);
		xmlhttp.open("GET", "../API/PersonDAO_API_AJAX1.php?query=" + msg, true);
		xmlhttp.send();
	},
	
	del: function(id,fname,lname,age){
		var xmlhttp = new XMLHttpRequest();
		var message = new Message("delete","",new Person(id,fname,lname,age));
		var msg = JSON.stringify(message);
		xmlhttp.open("GET", "../API/PersonDAO_API_AJAX1.php?query=" + msg, true);
		xmlhttp.send();
	}
	
}

function PD_Html(){
	
	this.__proto__ = Proto;
	
	this.read = function() {
	var xmlhttp = new XMLHttpRequest();
	xmlhttp.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			document.getElementById("daoTable").innerHTML = tableHeader;
			document.getElementById("daoTable").innerHTML += this.responseText;
		}
	};
	var message = new Message("read","Html","");
	var msg = JSON.stringify(message);
	xmlhttp.open("GET", "../API/PersonDAO_API_AJAX1.php?query=" + msg, true);
	xmlhttp.send();
	}		
}

function PD_Xml(){
	
	this.__proto__ = Proto;
	
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
		personRows += persons[i].ToHtml();
	}
	
	return personRows;
	}
	
	this.read = function() {
	var xmlhttp = new XMLHttpRequest();
	xmlhttp.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			var result = xmltableInflator(this.responseText);

			document.getElementById("daoTable").innerHTML = tableHeader;
			document.getElementById("daoTable").innerHTML += result;
		}
	};
	var message = new Message("read","Xml","");
	var msg = JSON.stringify(message);
	xmlhttp.open("GET", "../API/PersonDAO_API_AJAX1.php?query=" + msg, true);
	xmlhttp.send();
	}		
		
}

function PD_CSV(){
	
	this.__proto__ = Proto;
	
	function csvtableInflator(response){

		var persons = new Array();
		var res = response.split('\n')																			;
		for (var i = 1; i < res.length-1; i += 1)
		{
			var items = res[i].split(',');
			persons.push(new Person(items[0], items[1], items[2], items[3]));
		}
		var personRows = "";
		for (var i = 0; i < persons.length-1; i += 1) {
			personRows += persons[i].ToHtml();
		}
		
		return personRows;
	}
	
	this.read = function() {
	var xmlhttp = new XMLHttpRequest();
	xmlhttp.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			var result = csvtableInflator(this.responseText);

			document.getElementById("daoTable").innerHTML = tableHeader;
			document.getElementById("daoTable").innerHTML += result;
		}
	};
	var message = new Message("read","CSV","");
	var msg = JSON.stringify(message);
	xmlhttp.open("GET", "../API/PersonDAO_API_AJAX1.php?query=" + msg, true);
	xmlhttp.send();
	}		
}

function PD_Yaml(){
	
	this.__proto__ = Proto;
	
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
	
	this.read = function() {
	var xmlhttp = new XMLHttpRequest();
	xmlhttp.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			var result = yamltableInflator(this.responseText);

			document.getElementById("daoTable").innerHTML = tableHeader;
			document.getElementById("daoTable").innerHTML += result;
		}
	};
	var message = new Message("read","Yaml","");
	var msg = JSON.stringify(message);
	xmlhttp.open("GET", "../API/PersonDAO_API_AJAX1.php?query=" + msg, true);
	xmlhttp.send();
	}		
}

function PD_Json(){
	
	this.__proto__ = Proto;
	
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
			personRows += persons[i].ToHtml();
		}
		
		return personRows;
	}
	
	this.read = function() {
	var xmlhttp = new XMLHttpRequest();
	xmlhttp.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			var result = jsontableInflator(this.responseText);

			document.getElementById("daoTable").innerHTML = tableHeader;
			document.getElementById("daoTable").innerHTML += result;
		}
	};
	var message = new Message("read","Json","");
	var msg = JSON.stringify(message);
	xmlhttp.open("GET", "../API/PersonDAO_API_AJAX1.php?query=" + msg, true);
	xmlhttp.send();
	}		
}

function PD_XmlXslt(){
	
	this.__proto__ = Proto;
	
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
	
	function loadXMLDoc(filename)
	{
		xhttp = new XMLHttpRequest();

		xhttp.open("GET", filename, false);
		try {xhttp.responseType = "msxml-document"} catch(err) {} // Helping IE11
		xhttp.send("");
		return xhttp.responseXML;
	}
	
	this.read = function() {
	var xmlhttp = new XMLHttpRequest();
	xmlhttp.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			var result = xslttableInflator(this.responseText);

			document.getElementById("daoTable").innerHTML = tableHeader;
			document.getElementById("daoTable").innerHTML += result;
		}
	};
	var message = new Message("read","XmlXslt","");
	var msg = JSON.stringify(message);
	xmlhttp.open("GET", "../API/PersonDAO_API_AJAX1.php?query=" + msg, true);
	xmlhttp.send();
	}		
}

function Message(command,type,person) {
	
    this.command = command;
	this.type = type;
	this.person = person;
	//this.db = db;
}

function Person(id, fName, lName, age){
	
	this.id = id;
	this.fName = fName;
	this.lName = lName;
	this.age = age;
	this.ToHtml = function()
	{
		var ret = "<tr class=\"tableItem\">"
		   		+ "<td class=\"tableItem\">" + this.id + "</td>"
		   		+ "<td class=\"tableItem\">" + this.fName + "</td>"
		   		+ "<td class=\"tableItem\">" + this.lName + "</td>"
		   		+ "<td class=\"tableItem\">" + this.age + "</td>"
		   		+"</tr>";
		return ret;
	};
}

