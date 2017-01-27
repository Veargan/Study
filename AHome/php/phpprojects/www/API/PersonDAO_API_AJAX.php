<?php
	require_once ('PersonDAO/PersonDAO_MySQL.php');
	
    $query = $_REQUEST["query"];
	EventListener($query);
    
	function EventListener($value){
		$personDao = new PersonDAO_MySQL();

		switch ($value){
			case "create":
				$personDao->Create(new Person($_REQUEST['id'], $_REQUEST['firstName'], 
											  $_REQUEST['lastName'], $_REQUEST['age']));
				break;

			case "read":
				$result_set = $personDao->Read();
				if (isset($result_set)){
					$personRows = "";
					while (($row = $result_set->fetch_assoc()) != false) {
						$personRows .= "<tr class=\"tableItem\">";
						$personRows .= "<td class=\"tableItem\">".$row['Id']."</td>";
						$personRows .= "<td class=\"tableItem\">".$row['FirstName']."</td>";
						$personRows .= "<td class=\"tableItem\">".$row['LastName']."</td>";
						$personRows .= "<td class=\"tableItem\">".$row['Age']."</td>";
						$personRows .= "</tr>";
					}
					echo $personRows;
				}
				else {
					throw new Exception("Error occured while reading");
				}
				break;

			case "update":
				$personDao->Update(new Person($_REQUEST['id'], $_REQUEST['firstName'], 
											  $_REQUEST['lastName'], $_REQUEST['age']));
				break;

			case "delete":
				$personDao->Delete(new Person($_REQUEST['id'],"", "", ""));
				break;

			default:
				throw new Exception("Wrong argument(s)!");
		}
	}
?>