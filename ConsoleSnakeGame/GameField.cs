﻿namespace ConsoleSnakeGame;

public class GameField
{
    public const int ROWS = 20, COLUMNS = 40;
    private readonly Snake _snake;
    private Apple _apple;
    private int _score = 0;

    public GameField()
    {
        DrawBorders();
        UpdateScore();

        _snake = new Snake();
        _apple = GenerateFood();
    }


    public void Draw()
    {
        _snake.Draw();
        _apple.Draw();
    }

    public void Update()
    {
        _snake.Move();

        CheckAppleCollision();

        if (_snake.IsDead)
        {
            EndGame();
        }
    }

    private void DrawBorders()
    {
        for (int i = 0; i < COLUMNS + 1; i++)
        {
            Console.SetCursorPosition(i, ROWS + 1);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("█");
        }

        for (int i = 0; i < ROWS + 2; i++)
        {
            Console.SetCursorPosition(COLUMNS + 1, i);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("██");
        }
    }

    private Apple GenerateFood()
    {
        Position position;
        do
        {
            position = new Position(
                Random.Shared.Next(0, ROWS), Random.Shared.Next(0, COLUMNS));
        } while (_snake.Body.Any(e => e == position) || _snake.Head == position);

        return new Apple(position);
    }

    private void CheckAppleCollision()
    {
        if (_snake.Head.Equals(_apple.Position))
        {
            _apple = GenerateFood();
            _snake.Grow();
            _score++;
            UpdateScore();
        }
    }

    private void EndGame()
    {
        Game.IsGameOver = true;
        Console.SetCursorPosition(COLUMNS + 4, 1);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Game Over");
    }

    private void UpdateScore()
    {
        Console.SetCursorPosition(COLUMNS + 4, 0);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"Your score: {_score}");
    }
}
