<?php
    require_once ('Model/Person.php');

	class Config {
	   
       public function __construct(){
            $this->DB_NAME = "streetdb";
            $this->DB_HOST = "localhost";
            $this->DB_USER = "root";
            $this->DB_PASS = "";
       }
       
	   public $DB_NAME;
       public $DB_HOST;
       public $DB_USER;
       public $DB_PASS;
       
       public function Insert($person){
            $query = "INSERT INTO `person` (`FirstName`, `LastName`, `Age`, `Id_Street`) VALUES ("
                    ."'".$person->firstName."', '".$person->lastName."', '".$person->age."', '0')";
            return $query;
       }
       
       public function Select(){
            $query = "SELECT `Id`, `FirstName`, `LastName`, `Age` FROM `person`";
            return $query;
       }
       
       public function Update($person){
            $query = "UPDATE `person` SET "
                    ."`FirstName` = '".$person->firstName."', `LastName` = '".$person->lastName."', `Age` = '".$person->age."' "
                    ."WHERE `id` = '".$person->id."'";
            return $query;
       }
       
       public function Delete($person){
            $query = "DELETE FROM `person` WHERE `id` = '".$person->id."'";
            return $query;
       }
    }
?>