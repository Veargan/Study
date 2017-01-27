<?php
	function calculate($value1, $value2, $operation){
		if (isset($_POST["calc"])) {

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
			
			return $result;
		}
	}
?>