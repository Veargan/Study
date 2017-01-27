<?php require "../php/index.php"; ?>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>PHP Calculator</title>
	<link href="../css/style.css" rel="stylesheet">	
</head>
<body>
	<form name="calculatorForm" action="UI.php" method="post" class="calc-container">
		<input type="text" name="n1"> <br>
		<input type="text" name="op"> <br>
		<input type="text" name="n2"> <br>
		<input type="text" name="res" class="num" value="<?php if(isset($_POST["submit"])) showResult() ?>"> <br>
		<input type="submit" name="submit" value="Calculate">
	</form>
</body>
</html>