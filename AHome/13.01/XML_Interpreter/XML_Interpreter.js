
function MarkupParser(xmlText){
	
	this.xmlText = xmlText;
	this.currentControl;
	this.ownerControl;
	this.depthLevel = 0;
	this.elementStack = null;
	this.ownerList = [];
	
	this.getMemento = function (){
		
		return currentControl;
	}
	
	this.loop = function (ownerId){
		
		var strings = this.xmlText.split("\n");
		this.ownerList.push(document.getElementById(ownerId));
		
		for (var i = 0; i < strings.length; i++){
			
			var currentLine = strings[i];
			currentLine = currentLine.trim();
			
			if (currentLine == "")
            {
                continue;
            }
			
			if (currentLine.charAt(currentLine.indexOf("<") + 1) != '/' && currentLine.indexOf("<") == currentLine.lastIndexOf("<") )
            {
                this.SAX_Parser_ElementStart(currentLine);
            }
		    else if (currentLine.startsWith("</") && currentLine.indexOf("</") == currentLine.lastIndexOf("</"))
            {
                this.SAX_Parser_ElementEnd(currentLine);
            }
            else
            {
                this.SAX_Parser_ElementContext(currentLine);
            }
			
		}
		
	}
	
	this.SAX_Parser_ElementStart = function(e)
	{
		var line = e.replace("<", "").replace(">", "");
		
		if (line == "velement" && this.elementStack != null)
		{
			this.currentControl = Fabrica.createElement(this.elementStack);
			this.ownerList[this.depthLevel - 1].innerHTML += this.currentControl;
			this.ownerList[this.depthLevel] = document.getElementById(this.elementStack.id);
		}
		
		if (line == "list")
		{
			this.depthLevel += 1;
			this.ownerList.push(null);
		}
	}

    this.SAX_Parser_ElementContext = function(e)
    {
    	var tag = e.substring(0, e.indexOf(">")).replace("<", "");
    	var innerText = e.substring(e.indexOf(">") + 1);
    	innerText = innerText.substring(0, innerText.indexOf("</"));

        if (tag == "")
        {
            return;
        }
        else
        {
			switch (tag){
				case "type":
				{
					this.elementStack = new Velement();
					this.elementStack.type = innerText;
					break;
				}
				case "id":
				{
					this.elementStack.id = innerText;
					break;
				}
				case "value":
				{
					this.elementStack.value = innerText;
					break;
				}
				case "x":
				{
					this.elementStack.x = innerText;
					break;
				}
				case "y":
				{
					this.elementStack.y = innerText;
					break;
				}
				case "width":
				{
					this.elementStack.width = innerText;
					break;
				}
				case "height":
				{
					this.elementStack.height = innerText;
					break;
				}
			}
        }
    }

    this.SAX_Parser_ElementEnd = function(e)
    {
    	var line = e.replace("</", "").replace(">", "");

		if (line == "list" )
        {
			this.currentControl = Fabrica.createElement(this.elementStack);
			this.ownerList[this.depthLevel - 1].innerHTML += this.currentControl;
			this.ownerList[this.depthLevel] = document.getElementById(this.elementStack.id);
			
            this.depthLevel--;
        }
    }
}


function Fabrica(){}

Fabrica.createElement = function(e){
	
	
	var type = e.type;
	var id = e.id;
	var value = e.value;
	var x = e.x;
	var y = e.y;	
	var width = e.width;	
	var height = e.height;
	
	var element = null;
	switch (type) {

		case "Panel":
			element = "<div id='" + id + "'width='" + width + "'height='" + height
				+ "' style='margin-left: " + x + "px; margin-top: " + y + "px;' >";
			break;
		case "Button":
			element = "<input type='button' id='" + id + "'value='" + value + "'width='" + width + "'height='" + height
				+ "' style='margin-left: " + x + "px; margin-top: " + y + "px;' >";
			break;
		case "TextBox":
			element = "<input type='text' id='" + id + "'value='" + value + "'width='" + width + "'height='" + height
				+ "' style='margin-left: " + x + "px; margin-top: " + y + "px;' >";
			break;
	}
	
	return element;
}
