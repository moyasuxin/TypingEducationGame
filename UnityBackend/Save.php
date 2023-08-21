<?php
// connect to the database
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unity";

$conn = new mysqli($servername, $username, $password, $dbname);

// check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// get the values passed from Unity
$userName = $_POST['UserName'];
$score = $_POST['Score'];
$accuracy = $_POST['Accuracy'];

echo "Creating Record....";
    //Insert the user and password into database
    $sql = "INSERT INTO `scores`(`ScoreID`, `UserName`, `GamesID`, `Score`, `Accuracy`) 
    VALUES (NULL, '". $userName ."','4','". $score ."','". $accuracy ."')";
    if($conn->query($sql) == TRUE)
    {
        echo "New record created successfully";
    }
    else
    {
        echo "Error: " . $sql . "<br>" . $conn->error;
    }

// close the connection
$conn->close();
?>