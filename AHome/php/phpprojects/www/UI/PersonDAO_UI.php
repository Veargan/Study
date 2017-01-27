<?php
	require_once "../API/PersonDAO_API.php";
	$eventHandler = new EventHandler();
    $eventHandler->EventListener();
?>
<head>
    <title>PersonDAO</title>
    <link rel="stylesheet" type="text/css" href="../CSS/styles.css" />
</head>
<body>
	<form name="myForm" action="PersonDAO_UI.php" method="post">
		<table class="tableItem">
          <tr class="tableItem">
            <td class="tableItem">Id</td>
            <td class="tableItem">First Name</td>
            <td class="tableItem">Last Name</td>
            <td class="tableItem">Age</td>
          </tr>
          <?php
         	  $eventHandler->UpdateTable();
          ?>
        </table>
        <span>
            <p class="personDataHeader">Id:</p>
            <p id="firstName" class="personDataHeader">First name:</p>
            <p id="lastName" class="personDataHeader">Last name:</p>
            <p id="age" class="personDataHeader">Age:</p>
        </span>
        <p>
            <input class="personData" type="text" name="id" />
            <input class="personData" type="text" name="firstName" />
            <input class="personData" type="text" name="lastName" />
            <input class="personData" type="text" name="age" />
        </p>
		<p>
            <input class="crudButton" type="submit" name="create" value="Create" />
            <input class="crudButton" type="submit" name="read" value="Read" />
            <input class="crudButton" type="submit" name="update" value="Update" />
            <input class="crudButton" type="submit" name="delete" value="Delete" />
        </p>
	</form>
</body>