function ReceiveGameData(output)
        {
			var msg = output.split(',');
			if(msg[1] === "victory")
			{
				alert("Won");
				ws.send("list,");
				clearField();
				GameisFinished();				
				return;
			}
			else if(msg[1] === "fail")
			{
				alert("Lost");
				ws.send("list,");
				clearField();
				GameisFinished();				
				return;
			}
			else if(msg[1] === "standoff")
			{
				alert("Draw");
				ws.send("list,");
				clearField();
				GameisFinished();				
				return;
			}
			if(msg[1] === "yourturn")
			{
				document.getElementById("lbl_turn").innerHTML = "Your turn";
				return;
			}
			if(msg[1] === "notyourturn")
			{
				document.getElementById("lbl_turn").innerHTML = "Not your turn";
				return;
			}
			
			document.getElementById(msg[1]).value = msg[2];
			document.getElementById(msg[1]).disabled = true;			
		}
		
function listener(msg)
        {
			var tmp = msg.split(',');
			switch(tmp[0])
			{
			    case "login":
			        if (tmp[1] === "Y") {
			            document.getElementById("lbl_Name").innerHTML = getValue("txt_login1");

			            //document.getElementById("login").style.visibility = "hidden";
			            clearValue("txt_login1");
			            clearValue("txt_password");
						hideShow("login", "playerList");
			            //document.getElementById("playerList").style.visibility = "visible";						
			            break;
			        }
			        else
			        {
			            if (tmp[3] === "1")
			                alert("User with name \"" + getValue("txt_login1") + "\" isn't registed yet!");

			            else
			                alert("User with name \"" + getValue("txt_login1") + "\" is already in the game!");
			        }
			        break;

			    case "reg":
			        if (tmp[1] === "Y") 
			        {
			            document.getElementById("lbl_Name").innerHTML = getValue("txt_login2");
			            alert(getValue("txt_login2") + ", you are successfully registed!");

			            //document.getElementById("register").style.visibility = "hidden";			            
			            clearValue("txt_login2");
			            clearValue("txt_password1");
			            clearValue("txt_password2");
						hideShow("register", "playerList");
			            //document.getElementById("playerList").style.visibility = "visible";
			            break;
			        }
			        else 
			            alert("User with name \"" + getValue("txt_login2") + "\" already excists!");
			        break;
                    
                case "change":
                	if (tmp[1] === "Y")
                	{
                		alert("Your password was successfully changed!");
                    	//document.getElementById("changePas").style.visibility = "hidden";
                    	clearValue("txt_login3");
						clearValue("txt_oldPas");
						clearValue("txt_newPas");
                    	ws.close();
						hideShow("changePas", "login");
                    	//document.getElementById("login").style.visibility = "visible";  
                	}
                	else
                	{
                		alert("Failed to change your password. Check whether login and old password are correct!");    
                    	ws.close();
                	}
                	break;

                case "send":
                	if (tmp[1] === "Y")
                	{
                		alert("Password was sent to your Email.");
                    	//document.getElementById("forgotPas").style.visibility = "hidden";
                    	clearValue("txt_login4");
						clearValue("txt_email");                    
                    	ws.close();
						hideShow("forgotPas", "login");
                    	//document.getElementById("login").style.visibility = "visible";  
                	}
                	else
                	{
                		alert("Failed to send your password. Check whether login is correct!");    
                    	ws.close();
                	}
                	break;

				case "list":
					document.getElementById("lstPlayers").innerHTML = "123";
					for (var j = 1; j < tmp.length; j++)
					{
						var statuscont = tmp[j].split('#');
						if(statuscont[1]!="1")
						{
							var opt = document.createElement('option');
    						opt.value = statuscont[0];
    						opt.innerHTML = statuscont[0];
    						document.getElementById("lstPlayers").appendChild(opt);
							//AddOpt = new Option(statuscont[0], statuscont[0]);
							//document.getElementById("lstPlayers").options[i++] = AddOpt;
						}
					}
					break;
                    
				case "invite":
					if(tmp[1] === "XO")
					{
						var ask;
						if(confirm("Player " + tmp[2] + " invites you to play XO game. Accept an invitation?"))
							ask = "Yes";						
						else
							ask = "No";

						ws.send("games,ask," + ask + "," + tmp[3] + "," + tmp[2] + ",XO");						
					}
					break;
				case "ask":
					if(tmp[1] === "XO")
					{
						//document.getElementById("playerList").style.visibility = "hidden";
						//document.getElementById("gameField").style.visibility = "visible";
						hideShow("playerList", "gameField");
					}
                    
				case "gamexo":
					ReceiveGameData(msg);
					break;
            }
		}