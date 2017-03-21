var ws		
		
function logout() 
        {        	
        	ws.send("logout,");
        }
		
function login() 
        {
        	if(getValue("txt_login1"))
        	connect();
        	ws.onopen = function()
        		{ws.send("login," + getValue("txt_login1") + "," + getValue("txt_password"));};
        }
		

		
function connect() 
        {
        	if(ws !== undefined)
        		logout();
            ws = new WebSocket("ws://localhost:8888");
        
        	ws.onmessage = function (tmp) {
        		//alert("About to receive data");
        		var received_msg = tmp.data;				
        		//alert("Message received = " + received_msg);
        		listener(received_msg);
        	};
        	ws.onclose = function () {
        		// websocket is closed.
        		alert("Connection is closed...");
        		location.reload();
        	};
			return ws;
        };		
		
function register() 
		{
			ws = connect(ws);
			ws.onopen = function()
				{
					if(getValue("txt_password1") !== getValue("txt_password2"))
					{
		    			alert("Passwords are not equal!");
		        		clearValue("txt_password1");
						clearValue("txt_password2");   
		        		return;
		    		}
		    		ws.send("reg," + getValue("txt_login2") + "," +getValue("txt_password2"));
				};
		}
		
function changePas() 
        {           
        	connect();
        	ws.onopen = function()
        		{
            		ws.send("change," + getValue("txt_login3") + "," + 
            		getValue("txt_oldPas") + "," + getValue("txt_newPas"));
            	};
        }   
        
function sendPas() 
        {            
        	connect();
        	ws.onopen = function()
        		{
            		ws.send("forgot," + getValue("txt_login4") + "," + getValue("txt_email"));
            	};
        }        
			
function Invite()
		{
		 	if (document.getElementById("lstPlayers").selectedIndex == -1) 
			{
				alert("Please select any item from the ListBox");
		 	}
         	var Index = document.getElementById("lstPlayers").selectedIndex;
        	var partner = document.getElementById("lstPlayers").options[Index].value;
        	SendInvite(partner);
        }		 	
        
function SendInvite(partner)
        {
        	ws.send("lobby,invite," + name() + "," + partner + ",XO");
        }
        
function SendInfo(btn)
        {
        	ws.send("games,gamexo," + name() + "," + btn);
        }

function send(msg) 
        {        	
        	ws.send(msg);
        }
		
function beforeUnload() 
		{
    		if(ws !== undefined)
    		{
    			ws.send("games,gamexo," + name() + ",StopGame");
    			ws.send("logout,");
    		}
    	}

function name()
		{
			return document.getElementById("lbl_Name").innerHTML;
		}
		
function getValue(elem)
		{
			return document.getElementById(elem).value;
		}
		
function clearValue(elem)
		{
			document.getElementById(elem).value = "";
		}
		
function clearField() 
        {
			var i;
        	for(i = 0; i < 9; i++)
        	{	var id = i.toString()
        		clearValue(id);
        		document.getElementById(id).disabled = false;
			}
        } 

function hideShow(id_1, id_2)
		{
			document.getElementById(id_1).style.visibility = "hidden";
			document.getElementById(id_2).style.visibility = "visible";	
		}
		
window.onbeforeunload = function () 
		{
    		if(ws !== undefined)
    		{
    			ws.send("games,gamexo," + name() + ",StopGame");
    			ws.send("logout,");
    		}
    	}
		
      