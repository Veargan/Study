<?php

function calculate($a, $b, $op)
{
    $result = 0;

    switch($op)
    {
        case '+':
        $result = $a + $b;
        break;

        case '-':
        $result = $a - $b;
        break;

        case '*':
        $result = $a * $b;
        break;

        case '/':
        if ($result === false) throw new Exception("Divided by zero");

        $result = $a / $b;
        break;

        default:
        break;
    } 

    return $result;  
}

function showResult() {
    $result = calculate($_POST['n1'], $_POST['n2'], $_POST['op']);
    echo $result;
}

?>