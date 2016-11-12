function drawCustomLine() {
	var size = prompt('enter ur brush size');
	var md = false;
	var canvas = document.getElementById('placeToDraw');

	canvas.addEventListener('mousedown', mouseDown);
	canvas.addEventListener('mouseup', mouseUp);
	canvas.addEventListener('mousemove', mouseMove);

	function mouseDown() {
		md = true;
	}

	function mouseUp() {
		md = false;
	}

	function mouseMove(evt) {
		var mousePos = getMousePos(canvas, evt);
		var posx = mousePos.x;
		var posy = mousePos.y;

		draw(canvas, posx, posy);
	}
		
	function getMousePos(canvas, evt) {
		var rect = canvas.getBoundingClientRect();
		
		return {
			x:evt.clientX - rect.left,
			y:evt.clientY - rect.top
		};
	}

	function draw(canvas, posx, posy) {
		var context = canvas.getContext('2d');

		if (md) {
			context.fillRect(posx, posy, size, size);
		}
	}
}