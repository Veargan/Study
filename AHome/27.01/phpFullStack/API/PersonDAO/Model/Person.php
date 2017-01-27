<?php
	class Person {
       
       public function __construct($id, $firstName, $lastName, $age){
            $this->id = $id;
            $this->firstName = $firstName;
            $this->lastName = $lastName;
            $this->age = $age;
       }
       
	   public $id;
       public $firstName;
       public $lastName;
       public $age;
    }
?>