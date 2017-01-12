var canvas; 
var path;
var isMouseDown;
var mouseX;
var mouseY;

function drawCustomLine() {
	canvas = document.getElementById("svg");
	path = document.getElementById("path");
	isMouseDown = false;
	oX = canvas.offsetLeft;
	oY = canvas.offsetTop;
	canvas.addEventListener('mousedown', mouseDown);
	canvas.addEventListener('mousemove', mouseMove);
	canvas.addEventListener('mouseup', mouseUp);

	function mouseDown(e)
	{
		isMouseDown = true;
		mouseX = e.offsetX;
		mouseY = e.offsetY;

		path.setAttribute("d", path.getAttribute("d") + "M" + mouseX + "," + mouseY);	}

	function mouseMove(e)
	{
	   if(isMouseDown)
	   {	   
	   		mouseX = e.offsetX;
			mouseY = e.offsetY;
	        path.setAttribute("d", path.getAttribute("d") + "L" + mouseX + "," + mouseY);
	   }
	}

	function mouseUp(e) {
		isMouseDown = false;
	}
}

function SetColor(color) {
	path.setAttribute("stroke", color);
}

function SetWidth(width) {
	path.setAttribute("stroke-width", width);
}

function SaveFile() {
	var result = prompt("Set image name", "image");
    var imgName = result + ".svg";
    saveAs(new Blob([canvas.innerHTML], { type: "application/svg+xml" }), imgName);
}

document.getElementById('Load').addEventListener('change', readSingleFile, false);
function readSingleFile(evt) {
    var f = evt.target.files[0];

    if (f) {
        var r = new FileReader();
        r.onload = function (e) {
            var contents = e.target.result;
            canvas.innerHTML = contents;
        };
        r.readAsText(f);
    } else {
        alert("Failed to load file");
    }
}

function ImageCreation(path)
{
    var image = new Image();
    image.src = path;
    image.onload = function () {
        context.drawImage(image, 0, 0, image.width, image.height);
    };
}