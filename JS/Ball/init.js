var canvas;
var context;
var timerId;
var BallList = null;

window.onload = function() {
	canvas = document.getElementById('canvas');
	context = canvas.getContext('2d'); 
	BallList = new BallList();
	canvas.addEventListener('mousedown', mouseDown);
	timerId = setTimeout(animation, 20);
};

function mouseDown(e)
{
	var ball = new Ball(e.x - canvas.offsetLeft, e.y - canvas.offsetTop);
	BallList.add(ball);
}

function animation() {
	context.clearRect(0, 0, canvas.width, canvas.height);
	BallList.update(context);
	clearTimeout(timerId);
	timerId = setTimeout(animation, 20);
}