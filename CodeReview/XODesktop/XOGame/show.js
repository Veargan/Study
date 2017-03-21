function showChange() 
	{
		document.getElementById("login").style.visibility = "hidden";
		document.getElementById("changePas").style.visibility = "visible";
	}

function showSend() 
	{
		document.getElementById("login").style.visibility = "hidden";
		document.getElementById("forgotPas").style.visibility = "visible";
	}

function clearField() 
	{
		for(i = 0; i < 9; i++)
		{	var id = i.toString()
			document.getElementById(id).value = "";
			document.getElementById(id).disabled = false;
		}
	}
	
function showReg() 
	{
		document.getElementById("login").style.visibility = "hidden";
		document.getElementById("register").style.visibility = "visible";
	}
	
function back(field) 
	{
		document.getElementById(field).style.visibility = "hidden";
		document.getElementById("login").style.visibility = "visible";
	}