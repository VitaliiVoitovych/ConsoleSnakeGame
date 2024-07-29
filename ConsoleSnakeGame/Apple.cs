namespace ConsoleSnakeGame;

public class Apple
{
    private readonly char _texture = '●';

    public Position Position { get; }

    public Apple(Position position)
    {
        Position = position;
    }

    public void Draw()
    {
        Console.SetCursorPosition(Position.Left, Position.Top);
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write(_texture);
    }
}
