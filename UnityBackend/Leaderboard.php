<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unity";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

// Retrieve the top 10 scores
$sql = "SELECT `UserName`, `Score` FROM `scores` ORDER BY `Score` DESC LIMIT 10";
$result = $conn->query($sql);

$highscores = array();
if ($result->num_rows > 0) {
  // Output data of each row
  while($row = $result->fetch_assoc()) {
    $highscores[] = $row;
  }
} else {
  echo "0 results";
}

$conn->close();

header('Content-Type: application/json');
echo json_encode(array('scores' => $highscores));
?>