namespace ConsoleSnakeGame;

public class Apple
{
    private readonly char _texture = '●';

    public Position Position { get; private set; }

    public Apple()
    {

    }

    public void Draw()
    {
        Console.SetCursorPosition(Position.Left, Position.Top);
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write(_texture);
    }

    public void ChangePosition(Snake snake)
    {
        do
        {
            Position = new Position(Random.Shared.Next(0, GameField.ROWS),
            Random.Shared.Next(0, GameField.COLUMNS));
        } while (snake.Body.Any(e => e == Position));
    }
}
