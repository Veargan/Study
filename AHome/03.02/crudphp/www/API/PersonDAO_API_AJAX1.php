<?php
	require_once ('PersonDAO/PersonDAO_MySQL.php');
	require_once ('Serializer.php');
	
    $query = $_REQUEST["query"];
	$msg = json_decode($query);
	EventListener($msg->command, $msg);
    
	function EventListener($value, $message){
		$personDao = new PersonDAO_MySQL();
		//$personDao = implement($message->db);
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
	
	//function implement($db)
	//{
	//	switch($db)
	//	{
	//		case "PersonDAO_MySQL":
	//		return new PersonDAO_MySQL():
	//		break;
	//	}
	//}
	
	function setRead($type, $personDao){
		switch ($type){
			case "Html":
				$result_set = $personDao->Read();
				if (isset($result_set)){
					$personRows = "";
					foreach ( $result_set as $data ) {
						$personRows .= "<tr class=\"tableItem\">";
						$personRows .= "<td class=\"tableItem\">".$data->id."</td>";
						$personRows .= "<td class=\"tableItem\">".$data->firstName."</td>";
						$personRows .= "<td class=\"tableItem\">".$data->lastName."</td>";
						$personRows .= "<td class=\"tableItem\">".$data->age."</td>";
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
						$options = array(
										XML_SERIALIZER_OPTION_ROOT_NAME             => 'Persons',
										XML_SERIALIZER_OPTION_DEFAULT_TAG			  => 'Person'										  
									);
						
						$foo = $result_set;
							
						$serializer = &new XML_Serializer($options);
							
						$result = $serializer->serialize($foo);
						
						if ($result === true) {
						$xml = $serializer->getSerializedData();
						}

						echo $xml;
					}					
					else {
						throw new Exception("Error occured while reading");
					}				
			break;
			case "Json":
				$result_set = $personDao->Read();
				if (isset($result_set)){
					echo json_encode($result_set);
					 }
					 else {
						 throw new Exception("Error occured while reading");
					}
			break;
			case "Yaml":
				$result_set = $personDao->Read();
				 if (isset($result_set)){					
					echo yaml_emit($result_set);
					}
					else {
						 throw new Exception("Error occured while reading");
					}
			break;
			case "CSV":
				$result_set = $personDao->Read();
				if (isset($result_set)){
					$csv='';

					$csv .= 'id,firstName,lastName,age' . "\n";
					foreach ( $result_set as $row ) {
							$csv .= $row->id . ',';
							$csv .= $row->firstName . ',';
							$csv .= $row->lastName . ',';
							$csv .= $row->age . "\n";
					}
					echo $csv;
					}
					else {
						 throw new Exception("Error occured while reading");
					 }
			break;
			case "XmlXslt":
			$result_set = $personDao->Read();
					if (isset($result_set)){
						$options = array(
										XML_SERIALIZER_OPTION_ROOT_NAME             => 'Persons',
										XML_SERIALIZER_OPTION_DEFAULT_TAG			  => 'Person'										  
									);
						
						$foo = $result_set;
							
						$serializer = &new XML_Serializer($options);
							
						$result = $serializer->serialize($foo);
						
						if ($result === true) {
						$xml = $serializer->getSerializedData();
						}

						echo $xml;
					}					
					else {
						throw new Exception("Error occured while reading");
					}	
			break;
		}
	}
?>