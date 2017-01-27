function drawCustomLine() {
	var canvas = document.getElementById('placeToDraw');
	var context = canvas.getContext('2d');
	var color = document.getElementById("color");
	var brushSize = document.getElementById("width");
	var oX = canvas.offsetLeft;
	var oY = canvas.offsetTop;
	var x,y;

	canvas.addEventListener('mousedown', mouseDown);
	canvas.addEventListener('mousemove', mouseMove);

	function mouseDown(e)
	{
		context.strokeStyle = color.options[color.selectedIndex].value;
		context.lineWidth = Number(width.options[width.selectedIndex].value);

		x = e.x;
		y = e.y;

		context.beginPath();
		context.moveTo(x - oX, y - oY);
	}

	function mouseMove(e)
	{
	   if(e.which  == 1)
	   {	   
	        context.lineTo(e.pageX - oX, e.pageY - oY);
		    context.stroke();
	   }
	}
}