var x = document.getElementById("mytable").insertRow(0);
var y = x.insertCell(0);
var z = x.insertCell(1);
x.addEventListener("click", addStart);

function addStart() {
	y.innerHTML="newRow";
	z.innerHTML="новая ячейка 2";  	
}