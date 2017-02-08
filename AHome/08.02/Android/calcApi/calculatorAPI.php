<?php
	$value1 = $_GET["value1"];
	$value2 = $_GET["value2"];
	$operation = $_GET["operation"];
	
	calculate($value1, $value2, $operation);

	function calculate($value1, $value2, $operation){
		switch ($operation) {
		
			case "+":
				$result = $value1 + $value2;
				break;
				
			case "-":
				$result = $value1 - $value2;
				break;
				
			case "*":
				$result = $value1 * $value2;
				break;
				
			case "/":
				$result = $value1 / $value2;
				if ($result === false) {
					throw new Exception("Деление на ноль!");
				}
				break;
				
			default:
				throw new Exception("Неизвестная операция");
		}
		
		echo $result;
	}
?>