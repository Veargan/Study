<?php
	require_once "../API/calculatorAPI.php";
?>
<head>
    <title>Calculator</title>
</head>
<body>
	<form name="myForm" action="calculatorUI.php" method="post">
		<p>
			First Operand: 
			<input type="text" name="value1"/>
			<br />
			Operation: 
			<input type="text" name="operation"/>
			<br />
			Second Operand: 
			<input type="text" name="value2"/>
			<br />
			<input type="submit" name="calc" value="Calculate" />
			<br />
			Result: 
			<input type="text" name="result" value=
                "<?php
                    $result = calculate($_POST["value1"], $_POST["value2"], $_POST["operation"]);
                    if (isset($result)) echo $result; 
                ?>"
            />
		</p>
	</form>
</body>