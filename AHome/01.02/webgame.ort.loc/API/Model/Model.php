<?php
	class Message {
       
       public function __construct($command, $data,$name1, $name2){
            $this->command = $command;
            $this->data = $data;
            $this->name1 = $name1;
            $this->name2 = $name2;
       }
       
	   public $data;
       public $command;
       public $name1;
       public $name2;
    }
?>