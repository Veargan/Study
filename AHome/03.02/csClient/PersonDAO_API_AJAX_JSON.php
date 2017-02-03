<?php
	require_once ('PersonDAO/PersonDAO_MySQL.php');
	
    $query = $_REQUEST["query"];
	
	EventListener($query);
    
         function EventListener($value){
			 
			 $personDao = new PersonDAO_MySQL();
			 
			 switch ($value){
				 
				 case "create":{
					 
					 $personDao->Create(new Person($_REQUEST['Id'], $_REQUEST['FirstName'], $_REQUEST['LastName'], $_REQUEST['Age']));
					 break;
				 }
				 case "read":{
					 $result_set = $personDao->Read();
					 if (isset($result_set)){
						 $persons = array();
						 $personRows = "";
						 while (($row = $result_set->fetch_assoc()) != false) {
							$persons[] = new Person($row['Id'], $row['FirstName'], $row['LastName'], $row['Age']);
						}
						echo json_encode($persons);
					 }
					 else {
						 throw new Exception("Error occured while reading");
					 }
					break;
				 }
				 case "update":{
					 $personDao->Update(new Person($_REQUEST['id'], $_REQUEST['FirstName'], $_REQUEST['LastName'], $_REQUEST['Age']));
					 break;
				 }
				 case "delete":{
					 $personDao->Delete(new Person($_REQUEST['id'],"", "", ""));
					 break;
				 }
				 default:
					  
					 break;
				 
				 			 
			 }
        }
    
?>