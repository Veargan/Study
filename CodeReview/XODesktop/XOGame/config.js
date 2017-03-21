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
        };