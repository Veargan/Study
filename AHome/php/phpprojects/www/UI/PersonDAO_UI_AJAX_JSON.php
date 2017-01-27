<html>
  <head>
    <title>PersonDAO AJAX JSON</title>
    <link rel="stylesheet" type="text/css" href="../CSS/styles.css" />
		  
	  
  </head>
  <body>
      <table class="tableItem" id="daoTable">
        <tr class="tableItem">
          <td class="tableItem">Id</td>
          <td class="tableItem">First Name</td>
          <td class="tableItem">Last Name</td>
          <td class="tableItem">Age</td>
        </tr>
      </table>
      <span>
        <p class="personDataHeader">Id:</p>
        <p id="firstName" class="personDataHeader">First name:</p>
        <p id="lastName" class="personDataHeader">Last name:</p>
        <p id="age" class="personDataHeader">Age:</p>
      </span>
      <p>
        <input class="personData" type="text" id="i_id" name="id" />
        <input class="personData" type="text" id="i_firstName" name="firstName" />
        <input class="personData" type="text" id="i_lastName" name="lastName" />
        <input class="personData" type="text" id="i_age" name="age" />
      </p>
      <p>
        <input class="crudButton" id="create" type="button" name="create" value="Create" />
        <input class="crudButton" id="read" type="button" name="read" value="Read" />
        <input class="crudButton" id="update" type="button" name="update" value="Update" />
        <input class="crudButton" id="delete" type="button" name="delete" value="Delete" />
      </p>
	
	
		<script src="../script/crud_ajax_json.js"></script>
  </body>
</html>