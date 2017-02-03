<?php  
require_once('/Model/Model.php');
    $query = $_REQUEST["query"];
	switch($query){
		case 'getname':
			GetName();
			break;
		case 'auth':
			Auth();
			break;
		case 'getlist':
			GetList();
			break;
		case 'invite':
			Invite();
			break;
		case 'succes':
			Accept();
			break;
	}
function GetName(){
	$str = file_get_contents('names.json');
	$json = json_decode($str, true);
	echo 'getname,' . end($json);
}
function Auth(){
	$name = $_REQUEST['name'];
	$str = file_get_contents('names.json');
	$json = json_decode($str, true);
	$json[] = $name;
	$json = json_encode($json);
	file_put_contents('names.json', $json);
}
function GetList(){
	$str = file_get_contents('names.json');
	$json = json_decode($str, true);
	$strNames='';
	for ($i=0; $i < count($json); $i++) { 
		$strNames .= $json[$i] . ',';
	}
	$strNames = rtrim($strNames, ",");
	echo 'getlist,' . $strNames;
}
function Invite(){
	$name1 = $_REQUEST['name1'];
	$name2 = $_REQUEST['name2'];
	echo 'getinvite,' . $name1 . ',' . $name2 . ',' . '1';

}
function Accept(){
	$name1 = $_REQUEST['name1'];
	$name2 = $_REQUEST['name2'];
	echo 'succes,' . $name1 . ',' . $name2 . ',' . '2';
}
?>