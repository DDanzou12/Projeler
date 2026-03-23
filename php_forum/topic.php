<?php
require __DIR__ . '/init.php';

$topicId = (int) ($_GET['id'] ?? 0);
if ($topicId <= 0) {
    http_response_code(404);
    exit('Geçersiz konu.');
}

$topicStmt = $pdo->prepare('SELECT * FROM topics WHERE id = :id');
$topicStmt->execute([':id' => $topicId]);
$topic = $topicStmt->fetch();

if (!$topic) {
    http_response_code(404);
    exit('Konu bulunamadı.');
}

$errors = [];
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $author = trim($_POST['author'] ?? '');
    $content = trim($_POST['content'] ?? '');

    if ($author === '') {
        $errors[] = 'Kullanıcı adı boş bırakılamaz.';
    }
    if ($content === '') {
        $errors[] = 'Mesaj boş bırakılamaz.';
    }

    if (!$errors) {
        $stmt = $pdo->prepare('INSERT INTO messages (topic_id, author, content) VALUES (:topic_id, :author, :content)');
        $stmt->execute([
            ':topic_id' => $topicId,
            ':author' => $author,
            ':content' => $content,
        ]);

        header('Location: topic.php?id=' . $topicId);
        exit;
    }
}

$messageStmt = $pdo->prepare('SELECT * FROM messages WHERE topic_id = :topic_id ORDER BY created_at ASC, id ASC');
$messageStmt->execute([':topic_id' => $topicId]);
$messages = $messageStmt->fetchAll();
?>
<!DOCTYPE html>
<html lang="tr">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title><?= e($topic['title']) ?> - Forum</title>
    <link rel="stylesheet" href="assets/style.css">
</head>
<body>
<div class="container narrow">
    <header class="hero small">
        <div>
            <p class="badge">Konu Detayı</p>
            <h1><?= e($topic['title']) ?></h1>
            <p class="subtitle">Açan kullanıcı: <strong><?= e($topic['author']) ?></strong> • <?= e($topic['created_at']) ?></p>
        </div>
        <a class="back-link" href="index.php">← Ana sayfaya dön</a>
    </header>

    <section class="card">
        <div class="section-head">
            <h2>Mesajlar</h2>
            <span><?= count($messages) ?> kayıt</span>
        </div>

        <div class="message-list">
            <?php foreach ($messages as $message): ?>
                <article class="message-item">
                    <div class="message-head">
                        <strong><?= e($message['author']) ?></strong>
                        <span><?= e($message['created_at']) ?></span>
                    </div>
                    <p><?= nl2br(e($message['content'])) ?></p>
                </article>
            <?php endforeach; ?>
        </div>
    </section>

    <section class="card">
        <h2>Cevap Yaz</h2>

        <?php if ($errors): ?>
            <div class="alert error">
                <ul>
                    <?php foreach ($errors as $error): ?>
                        <li><?= e($error) ?></li>
                    <?php endforeach; ?>
                </ul>
            </div>
        <?php endif; ?>

        <form method="post" class="forum-form">
            <label>
                Kullanıcı Adı
                <input type="text" name="author" placeholder="Örn: Zeynep" value="<?= e($_POST['author'] ?? '') ?>">
            </label>

            <label>
                Mesaj
                <textarea name="content" rows="5" placeholder="Cevabınızı yazın..."><?= e($_POST['content'] ?? '') ?></textarea>
            </label>

            <button type="submit">Mesaj Gönder</button>
        </form>
    </section>
</div>
</body>
</html>
