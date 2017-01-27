class Proto {
	
	create(id,fname,lname,age){
		var xmlhttp = new XMLHttpRequest();
		var message = new Message("create","",new Person(id,fname,lname,age));
		var msg = JSON.stringify(message);
		xmlhttp.open("GET", "../API/PersonDAO_API_AJAX1.php?query=" + msg, true);
		xmlhttp.send();
	}
	
	update(id,fname,lname,age){
		var xmlhttp = new XMLHttpRequest();
		var message = new Message("update","",new Person(id,fname,lname,age));
		var msg = JSON.stringify(message);
		xmlhttp.open("GET", "../API/PersonDAO_API_AJAX1.php?query=" + msg, true);
		xmlhttp.send();
	}
	
	del(id,fname,lname,age){
		var xmlhttp = new XMLHttpRequest();
		var message = new Message("delete","",new Person(id,fname,lname,age));
		var msg = JSON.stringify(message);
		xmlhttp.open("GET", "../API/PersonDAO_API_AJAX1.php?query=" + msg, true);
		xmlhttp.send();
	}
	
}

class PD_Html extends Proto{
	
	read() {
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

class PD_Xml extends Proto{
	
	read() {
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

class PD_CSV extends Proto{
	
	read(message) {
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

class PD_Yaml extends Proto{
	
	read(message) {
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

class PD_Json extends Proto{
	
	read() {
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

class PD_XmlXslt extends Proto{
	
	read(message) {
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

class Message {
	
	constructor(command,type,person) {
    this.command = command;
	this.type = type;
	this.person = person;
  }
}