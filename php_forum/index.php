<?php
require __DIR__ . '/init.php';

$errors = [];

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $title = trim($_POST['title'] ?? '');
    $author = trim($_POST['author'] ?? '');
    $message = trim($_POST['message'] ?? '');

    if ($title === '') {
        $errors[] = 'Konu başlığı boş bırakılamaz.';
    }
    if ($author === '') {
        $errors[] = 'Kullanıcı adı boş bırakılamaz.';
    }
    if ($message === '') {
        $errors[] = 'Mesaj boş bırakılamaz.';
    }

    if (!$errors) {
        $pdo->beginTransaction();

        $topicStmt = $pdo->prepare('INSERT INTO topics (title, author) VALUES (:title, :author)');
        $topicStmt->execute([
            ':title' => $title,
            ':author' => $author,
        ]);

        $topicId = (int) $pdo->lastInsertId();

        $messageStmt = $pdo->prepare('INSERT INTO messages (topic_id, author, content) VALUES (:topic_id, :author, :content)');
        $messageStmt->execute([
            ':topic_id' => $topicId,
            ':author' => $author,
            ':content' => $message,
        ]);

        $pdo->commit();

        header('Location: topic.php?id=' . $topicId);
        exit;
    }
}

$topics = $pdo->query(
    'SELECT t.id, t.title, t.author, t.created_at,
            (SELECT COUNT(*) FROM messages m WHERE m.topic_id = t.id) AS reply_count,
            (SELECT MAX(created_at) FROM messages m2 WHERE m2.topic_id = t.id) AS last_message_at
     FROM topics t
     ORDER BY t.created_at DESC'
)->fetchAll();
?>
<!DOCTYPE html>
<html lang="tr">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Basit Forum Sistemi</title>
    <link rel="stylesheet" href="assets/style.css">
</head>
<body>
<div class="container">
    <header class="hero">
        <div>
            <p class="badge">PHP + SQLite</p>
            <h1>Basit Forum Sistemi</h1>
            <p class="subtitle">Kullanıcılar konu açabilir, mesaj yazabilir ve tüm tartışmaları görüntüleyebilir.</p>
        </div>
    </header>

    <div class="grid">
        <section class="card">
            <h2>Yeni Konu Oluştur</h2>

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
                    <input type="text" name="author" placeholder="Örn: Ahmet" value="<?= e($_POST['author'] ?? '') ?>">
                </label>

                <label>
                    Konu Başlığı
                    <input type="text" name="title" placeholder="Örn: PHP öğrenmeye nasıl başlanır?" value="<?= e($_POST['title'] ?? '') ?>">
                </label>

                <label>
                    İlk Mesaj
                    <textarea name="message" rows="6" placeholder="Mesajınızı buraya yazın..."><?= e($_POST['message'] ?? '') ?></textarea>
                </label>

                <button type="submit">Konuyu Yayınla</button>
            </form>
        </section>

        <section class="card">
            <div class="section-head">
                <h2>Forum Konuları</h2>
                <span><?= count($topics) ?> konu</span>
            </div>

            <?php if (!$topics): ?>
                <div class="empty-state">
                    <p>Henüz hiç konu açılmadı. İlk konuyu sen oluştur.</p>
                </div>
            <?php else: ?>
                <div class="topic-list">
                    <?php foreach ($topics as $topic): ?>
                        <a class="topic-item" href="topic.php?id=<?= (int) $topic['id'] ?>">
                            <div>
                                <h3><?= e($topic['title']) ?></h3>
                                <p>
                                    Açan: <strong><?= e($topic['author']) ?></strong>
                                    • <?= e($topic['created_at']) ?>
                                </p>
                            </div>
                            <div class="topic-meta">
                                <span><?= (int) $topic['reply_count'] ?> mesaj</span>
                                <small>Son aktiflik: <?= e($topic['last_message_at'] ?? $topic['created_at']) ?></small>
                            </div>
                        </a>
                    <?php endforeach; ?>
                </div>
            <?php endif; ?>
        </section>
    </div>
</div>
</body>
</html>
