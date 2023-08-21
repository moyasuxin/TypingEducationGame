<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unity";

//variables submitted by user
$loginUser = $_POST["UserName"];
$loginPass = $_POST["UserPassword"];

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
  // output data of each row
  while($row = $result->fetch_assoc()) {
    if($row["UserPassword"] == $loginPass)
    {
        echo "Login Success.";
        //Get user's data here
    }
    else
    {
        echo "Wrong Credentials."; 
    }
  }
} 
else 
{
  echo "User does not exist";
}
$conn->close();
?>