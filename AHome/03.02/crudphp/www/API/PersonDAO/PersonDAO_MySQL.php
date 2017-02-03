<?php
    require_once ('Model/Person.php');
    require_once ('Config.php');
    require_once ('IPersonDAO.php');
	
    class PersonDAO_MySQL implements IPersonDAO{
        
        public function __construct(){
            $this->config = new Config();
        }
        
        private $mysqli;
        private $config;
        
        private function CreateConnection(){
            $this->mysqli = new mysqli($this->config->DB_HOST, $this->config->DB_USER, $this->config->DB_PASS, $this->config->DB_NAME);
            $this->mysqli->query("SET NAME 'utf8'");
        }
        
        private function CloseConnection(){
            $this->mysqli->close();
        }
        
        public function Create($person){
            $this->CreateConnection();
            $success = $this->mysqli->query($this->config->Insert($person));
            $this->CloseConnection();
        }
        
        public function Read(){
            $this->CreateConnection();
            $result_set = $this->mysqli->query($this->config->Select());
			$persons = array();
			while (($row = $result_set->fetch_assoc()) != false) {						
						$persons[] = new Person($row['Id'], $row['FirstName'], $row['LastName'], $row['Age']);
						}
            $this->CloseConnection();
            return $persons;
        }
        
        public function Update($person){
            $this->CreateConnection();
            $this->mysqli->query($this->config->Update($person));
            $this->CloseConnection();
        }
        
        public function Delete($person){
            $this->CreateConnection();
            $this->mysqli->query($this->config->Delete($person));
            $this->CloseConnection();
        }
    }
?>