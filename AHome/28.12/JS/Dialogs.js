	document.getElementById("bAlert").onclick = function(){
		alert("Hello!");
	}
	
	document.getElementById("bPrompt").onclick = function(){
		var result = prompt("Hello! Your name is:", "");
	}
	
	document.getElementById("bConfirm").onclick = function(){
		var result = confirm("Are you ok?");
	}