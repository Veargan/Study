<?php
	interface IPersonDAO
	{
		public function Create($person);
		public function Read();
		public function Update($person);
		public function Delete($person);
	}
?>