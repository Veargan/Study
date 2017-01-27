function drawCustomLine() {
	var canvas = document.getElementById('placeToDraw');
	var context = canvas.getContext('2d');
	// color = document.getElementById("color");
	var brushSize = document.getElementById("width");
	var oX = canvas.offsetLeft;
	var oY = canvas.offsetTop;
	var x,y;

	var elem = document.querySelector('.color-input');
	var hueb = new Huebee(elem, {
		setBGColor: true,
		saturations: 2,
	});

	hueb = new Huebee( '.color-input');
	canvas.addEventListener('mousedown', mouseDown);
	canvas.addEventListener('mousemove', mouseMove);

	function mouseDown(e)
	{
		
		hueb.on('change', function( color ) {
			context.strokeStyle = color;
		});
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