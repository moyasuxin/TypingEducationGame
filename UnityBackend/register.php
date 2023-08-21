<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unity";

//variables submitted by user
$loginUser = $_POST["UserName"];
$loginPass = $_POST["UserPassword"];
$loginEmail = $_POST["UserEmail"];
$loginPhone = $_POST["UserPhone"];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) 
{
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT UserPassword FROM users WHERE UserName = '" . $loginUser . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) 
{
    //Tell user that name already taken
    echo "Username is already taken.";
} 
else 
{
    echo "Creating user....";
    //Insert the user and password into database
    $sql2 = "INSERT INTO `users`(`UserID`, `UserName`, `UserEmail`, `UserPassword`, `Userphone`) 
    VALUES (NULL, '". $loginUser ."', '". $loginEmail ."','". $loginPass ."', '". $loginPhone ."')";
    if($conn->query($sql2) == TRUE)
    {
        echo "New record created successfully";
    }
    else
    {
        echo "Error: " . $sql2 . "<br>" . $conn->error;
    }
}
$conn->close();
?>