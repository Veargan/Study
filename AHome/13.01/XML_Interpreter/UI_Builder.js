
var xmlText = null;
var markupParser = null;

window.onload = function () {

    var doc = document.getElementById("files");
    doc.addEventListener("change", handleFileSelect, false);
}

function create() {

	markupParser = new MarkupParser(xmlText);
	markupParser.loop("main");
}

function handleFileSelect(evt) {
    var f = evt.target.files[0];

    if (f) {
        var r = new FileReader();
        r.onload = function (e) {
            xmlText = e.target.result;
        }
        r.readAsText(f);
    } else {
        alert("Faileed!");
    }
}
