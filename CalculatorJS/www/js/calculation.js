function calculate() {

			var a = Number(document.getElementById("a").value);
			var b = Number(document.getElementById("b").value);
			var oc = document.getElementById("oc");
			var op = document.getElementById("operations").value;
			
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
		}