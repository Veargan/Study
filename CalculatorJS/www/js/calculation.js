function calculate(a, b, op) {
	var oc;
	a = parseInt(a);
	b = parseInt(b);
	
	switch (op) {
		case "+":
		oc = a + b;
		break;
		case "-":
		oc= a - b;
		break;
		case "*":
		oc= a * b;
		break;
		case "/":
		oc = a / b;
		break;
	}

	return oc;
}