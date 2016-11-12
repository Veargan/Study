function calculate(a, b, op) {
	var oc = document.getElementById("oc");
	
	switch (op) {
		case "+":
		oc.value = a + b;
		break;
		case "-":
		oc.value = a - b;
		break;
		case "*":
		oc.value = a * b;
		break;
		case "/":
		oc.value = a / b;
		break;
	}

	return oc.value;
}