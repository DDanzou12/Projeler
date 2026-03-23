using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SnakeGameDesktop;

public class SnakeForm : Form
{
    private const int CellSize = 20;
    private const int GridWidth = 28;
    private const int GridHeight = 22;
    private const int HeaderHeight = 40;

    private readonly System.Windows.Forms.Timer gameTimer;
    private readonly Random random = new();
    private readonly List<Point> snake = new();

    private Point food;
    private Direction currentDirection = Direction.Right;
    private Direction nextDirection = Direction.Right;
    private bool isGameOver;
    private int score;

    public SnakeForm()
    {
        DoubleBuffered = true;
        KeyPreview = true;
        Text = "Klasik Yılan Oyunu";
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(GridWidth * CellSize, GridHeight * CellSize + HeaderHeight);
        BackColor = Color.FromArgb(22, 22, 22);

        gameTimer = new System.Windows.Forms.Timer { Interval = 110 };
        gameTimer.Tick += (_, _) => UpdateGame();

        KeyDown += OnGameKeyDown;

        StartNewGame();
    }

    private void StartNewGame()
    {
        snake.Clear();
        snake.Add(new Point(5, 10));
        snake.Add(new Point(4, 10));
        snake.Add(new Point(3, 10));

        currentDirection = Direction.Right;
        nextDirection = Direction.Right;
        score = 0;
        isGameOver = false;
        SpawnFood();
        gameTimer.Start();
        Invalidate();
    }

    private void SpawnFood()
    {
        do
        {
            food = new Point(random.Next(0, GridWidth), random.Next(0, GridHeight));
        }
        while (snake.Contains(food));
    }

    private void OnGameKeyDown(object? sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Up or Keys.W when currentDirection != Direction.Down:
                nextDirection = Direction.Up;
                break;
            case Keys.Down or Keys.S when currentDirection != Direction.Up:
                nextDirection = Direction.Down;
                break;
            case Keys.Left or Keys.A when currentDirection != Direction.Right:
                nextDirection = Direction.Left;
                break;
            case Keys.Right or Keys.D when currentDirection != Direction.Left:
                nextDirection = Direction.Right;
                break;
            case Keys.Enter when isGameOver:
                StartNewGame();
                break;
            case Keys.Escape:
                Close();
                break;
        }
    }

    private void UpdateGame()
    {
        if (isGameOver)
        {
            return;
        }

        currentDirection = nextDirection;
        Point head = snake[0];
        Point newHead = currentDirection switch
        {
            Direction.Up => new Point(head.X, head.Y - 1),
            Direction.Down => new Point(head.X, head.Y + 1),
            Direction.Left => new Point(head.X - 1, head.Y),
            _ => new Point(head.X + 1, head.Y)
        };

        bool hitWall = newHead.X < 0 || newHead.Y < 0 || newHead.X >= GridWidth || newHead.Y >= GridHeight;
        bool hitSelf = snake.Take(snake.Count - 1).Contains(newHead);

        if (hitWall || hitSelf)
        {
            isGameOver = true;
            gameTimer.Stop();
            Invalidate();
            return;
        }

        snake.Insert(0, newHead);

        if (newHead == food)
        {
            score += 10;
            SpawnFood();
        }
        else
        {
            snake.RemoveAt(snake.Count - 1);
        }

        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        g.Clear(BackColor);

        DrawHeader(g);
        DrawGrid(g);
        DrawFood(g);
        DrawSnake(g);

        if (isGameOver)
        {
            DrawGameOver(g);
        }
    }

    private void DrawHeader(Graphics g)
    {
        using var font = new Font("Segoe UI", 12, FontStyle.Bold);
        using var brush = new SolidBrush(Color.WhiteSmoke);
        g.DrawString($"Skor: {score}    Yön tuşları / WASD    Yeniden başlat: Enter    Çıkış: Esc", font, brush, 10, 8);
    }

    private void DrawGrid(Graphics g)
    {
        using var pen = new Pen(Color.FromArgb(45, 45, 45));
        int offsetY = HeaderHeight;

        for (int x = 0; x <= GridWidth; x++)
        {
            g.DrawLine(pen, x * CellSize, offsetY, x * CellSize, offsetY + GridHeight * CellSize);
        }

        for (int y = 0; y <= GridHeight; y++)
        {
            g.DrawLine(pen, 0, offsetY + y * CellSize, GridWidth * CellSize, offsetY + y * CellSize);
        }
    }

    private void DrawSnake(Graphics g)
    {
        int offsetY = HeaderHeight;

        for (int i = 0; i < snake.Count; i++)
        {
            Rectangle rect = new(snake[i].X * CellSize + 1, snake[i].Y * CellSize + offsetY + 1, CellSize - 2, CellSize - 2);
            using var brush = new SolidBrush(i == 0 ? Color.LimeGreen : Color.ForestGreen);
            g.FillRectangle(brush, rect);
        }
    }

    private void DrawFood(Graphics g)
    {
        int offsetY = HeaderHeight;
        Rectangle rect = new(food.X * CellSize + 2, food.Y * CellSize + offsetY + 2, CellSize - 4, CellSize - 4);
        using var brush = new SolidBrush(Color.OrangeRed);
        g.FillEllipse(brush, rect);
    }

    private void DrawGameOver(Graphics g)
    {
        Rectangle overlay = new(40, HeaderHeight + 80, ClientSize.Width - 80, 140);
        using var bg = new SolidBrush(Color.FromArgb(200, 0, 0, 0));
        using var border = new Pen(Color.WhiteSmoke, 2);
        using var titleFont = new Font("Segoe UI", 18, FontStyle.Bold);
        using var textFont = new Font("Segoe UI", 11, FontStyle.Regular);
        using var brush = new SolidBrush(Color.WhiteSmoke);
        using var centerFormat = new StringFormat { Alignment = StringAlignment.Center };

        g.FillRectangle(bg, overlay);
        g.DrawRectangle(border, overlay);
        g.DrawString("Oyun Bitti", titleFont, brush, overlay.Left + overlay.Width / 2, overlay.Top + 20, centerFormat);
        g.DrawString($"Skorun: {score}", textFont, brush, overlay.Left + overlay.Width / 2, overlay.Top + 65, centerFormat);
        g.DrawString("Tekrar oynamak için Enter'a bas", textFont, brush, overlay.Left + overlay.Width / 2, overlay.Top + 95, centerFormat);
    }

    private enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
