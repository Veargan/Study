var canvas;
var context;
var isMouseDown;
var oX; 
var oY;
var x,y;

function drawCustomLine() {
	canvas = document.getElementById('placeToDraw');
	context = canvas.getContext('2d');
	isMouseDown = false;
	oX = canvas.offsetLeft;
	oY = canvas.offsetTop;
	canvas.addEventListener('mousedown', mouseDown);
	canvas.addEventListener('mousemove', mouseMove);
	canvas.addEventListener('mouseup', mouseUp);

	function mouseDown(e)
	{
		isMouseDown = true;
		x = e.x;
		y = e.y;

		context.beginPath();
		context.moveTo(x - oX, y - oY);
	}

	function mouseMove(e)
	{
	   if(isMouseDown)
	   {	   
	        context.lineTo(e.pageX - oX, e.pageY - oY);
		    context.stroke();
	   }
	}

	function mouseUp(e) {
		isMouseDown = false;
	}
}

function SetColor(color) {
	context.strokeStyle = color;
}

function SetWidth(width) {
	context.lineWidth = width;
}

function SaveFile() {
	var text = prompt("Enter file name", "image");
	var path = text + ".png";

	canvas.toBlob(function (blob) { saveAs(blob, path); });
}

function LoadFile() {
	var path = prompt("Set image path", "image.png");
	ImageCreation(path);
}

function ImageCreation(path)
{
    var image = new Image();
    image.src = path;
    image.onload = function () {
        context.drawImage(image, 0, 0, image.width, image.height);
    };
}