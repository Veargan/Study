<?php
	require_once ('PersonDAO/PersonDAO_MySQL.php');
    
    class EventHandler {
        
        public function __construct(){
             $this->personDao = new PersonDAO_MySQL();
        }
        
        private $personDao;
        private $result_set;
        
        public function EventListener(){
            if (isset($_POST["read"])){
                $this->result_set = $this->personDao->Read();
            }
            elseif (isset($_POST["create"])){
                $this->personDao->Create(new Person($_POST['id'], $_POST['firstName'], $_POST['lastName'], $_POST['age']));
            }
            elseif (isset($_POST["update"])){
                $this->personDao->Update(new Person($_POST['id'], $_POST['firstName'], $_POST['lastName'], $_POST['age']));
            }
            elseif (isset($_POST["delete"])){
                $this->personDao->Delete(new Person($_POST['id'], $_POST['firstName'], $_POST['lastName'], $_POST['age']));
            }
        }
        
        public function UpdateTable(){
            if (isset($this->result_set)){
                $personRows = "";
                while (($row = $this->result_set->fetch_assoc()) != false) {
        			$personRows .= "<tr class=\"tableItem\">";
                    $personRows .= "<td class=\"tableItem\">".$row['Id']."</td>";
                    $personRows .= "<td class=\"tableItem\">".$row['FirstName']."</td>";
                    $personRows .= "<td class=\"tableItem\">".$row['LastName']."</td>";
                    $personRows .= "<td class=\"tableItem\">".$row['Age']."</td>";
                    $personRows .= "</tr>";
        		}
                echo $personRows;
            }
        }    
    }
    
?>