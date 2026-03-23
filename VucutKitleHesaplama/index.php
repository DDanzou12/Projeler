<?php
$result = "";
$category = "";

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $height = $_POST["height"] / 100; // cm to meters
    $weight = $_POST["weight"];

    if ($height > 0 && $weight > 0) {
        $bmi = $weight / ($height * $height);
        $result = round($bmi, 2);

        if ($bmi < 18.5) {
            $category = "Zayıf";
        } elseif ($bmi >= 18.5 && $bmi < 25) {
            $category = "Normal";
        } else {
            $category = "Kilolu";
        }
    } else {
        $result = "Geçersiz değer!";
    }
}
?>

<!DOCTYPE html>
<html lang="tr">
<head>
    <meta charset="UTF-8">
    <title>BMI Hesaplayıcı</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <div class="container">
        <h1>BMI Hesaplayıcı</h1>

        <form method="POST">
            <label>Boy (cm):</label>
            <input type="number" name="height" required>

            <label>Kilo (kg):</label>
            <input type="number" name="weight" required>

            <button type="submit">Hesapla</button>
        </form>

        <?php if ($result): ?>
            <div class="result">
                <p><strong>BMI:</strong> <?php echo $result; ?></p>
                <p><strong>Durum:</strong> <?php echo $category; ?></p>
            </div>
        <?php endif; ?>
    </div>
</body>
</html>
