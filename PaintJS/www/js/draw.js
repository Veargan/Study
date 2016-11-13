function drawCustomLine() {
	var canvas = document.getElementById('placeToDraw');
	var context = canvas.getContext('2d');
	var x,y;

	canvas.addEventListener('mousedown', mouseDown);
	canvas.addEventListener('mousemove', mouseMove);

	function mouseDown(e)
	{
		x = e.x;
		y = e.y;
		context.moveTo(x, y);
	}

	function mouseMove(e)
	{
	   if(e.which  == 1)
	   {	   
	        context.lineTo(e.pageX, e.pageY);
		    context.stroke();
	   }
	}
}