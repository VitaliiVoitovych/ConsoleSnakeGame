namespace ConsoleSnakeGame;

public readonly record struct Position(int Top, int Left)
{
    public Position MoveLeft() => new(Top, Left - 1);
    public Position MoveRight() => new(Top, Left + 1);
    public Position MoveUp() => new(Top - 1, Left);
    public Position MoveDown() => new(Top + 1, Left);
}