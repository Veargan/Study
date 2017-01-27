<?php
	require_once ('PersonDAO/PersonDAO_MySQL.php');
	require_once ('Serializer.php');
	
    $query = $_REQUEST["query"];
	$msg = json_decode($query);
	EventListener($msg->command, $msg);
    
	function EventListener($value, $message){
		$personDao = new PersonDAO_MySQL();

		switch ($value){
			case "create":
				$personDao->Create(new Person($message->person->id, $message->person->firstName, 
											  $message->person->lastName, $message->person->age));
				break;

			case "read":
				setRead($message->type, $personDao);
				break;

			case "update":
				$personDao->Update(new Person($message->person->id, $message->person->firstName, 
											  $message->person->lastName, $message->person->age));
				break;

			case "delete":
				$personDao->Delete(new Person($message->person->id,"", "", ""));
				break;

			default:
				throw new Exception("Wrong argument(s)!");
		}
	}
	
	function setRead($type, $personDao){
		switch ($type){
			case "Html":
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
			case "Xml":
				$result_set = $personDao->Read();
				if (isset($result_set)){
					$persons = array();
					$personRows = "";
					while (($row = $result_set->fetch_assoc()) != false) {						
						$persons[] = new Person($row['Id'], $row['FirstName'], $row['LastName'], $row['Age']);
						}
					 $options = array(
										XML_SERIALIZER_OPTION_ROOT_NAME             => 'Persons',
										XML_SERIALIZER_OPTION_DEFAULT_TAG			  => 'Person'										  
									);
						
					$foo = $persons;
						
					$serializer = &new XML_Serializer($options);
						
					$result = $serializer->serialize($foo);
						
					if ($result === true) {
						$xml = $serializer->getSerializedData();
					}

					echo $xml;					 }
					else {
						 throw new Exception("Error occured while reading");
					 }
			break;
			case "Json":
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
			case "Yaml":
				$result_set = $personDao->Read();
				 if (isset($result_set)){
					$persons = array();
					$personRows = "";
					while (($row = $result_set->fetch_assoc()) != false)
					{							
						$persons[] = array("Id"=>$row['Id'], "fname"=>$row['FirstName'], "lname"=>$row['LastName'], "age"=>$row['Age'],);
					}
					echo yaml_emit($persons);
					}
					else {
						 throw new Exception("Error occured while reading");
					}
			break;
			case "CSV":
				$result_set = $personDao->Read();
				if (isset($result_set)){
					$persons = array();
					while (($row = $result_set->fetch_assoc()) != false) {
						$persons[] = new Person($row['Id'], $row['FirstName'], $row['LastName'], $row['Age']);
					}
					echo str_putcsv($persons);
					}
					else {
						 throw new Exception("Error occured while reading");
					 }
			break;
			case "XmlXslt":
			$result_set = $personDao->Read();
				if (isset($result_set)){
					$persons = array();
					$personRows = "";
					while (($row = $result_set->fetch_assoc()) != false) {						
						$persons[] = new Person($row['Id'], $row['FirstName'], $row['LastName'], $row['Age']);
						}
					 $options = array(
										XML_SERIALIZER_OPTION_ROOT_NAME             => 'Persons',
										XML_SERIALIZER_OPTION_DEFAULT_TAG			  => 'Person'										  
									);
						
					$foo = $persons;
						
					$serializer = &new XML_Serializer($options);
						
					$result = $serializer->serialize($foo);
						
					if ($result === true) {
						$xml = $serializer->getSerializedData();
					}

					echo $xml;					 }
					else {
						 throw new Exception("Error occured while reading");
					 }
			break;
		}
	}
	
	function str_putcsv($data) {

		$csv='';

		$csv .= 'id,firstName,lastName,age' . "\n";
        foreach ( $data as $row ) {
                $csv .= $row->id . ',';
				$csv .= $row->firstName . ',';
				$csv .= $row->lastName . ',';
				$csv .= $row->age . "\n";
		}

        return $csv;
	}
?>