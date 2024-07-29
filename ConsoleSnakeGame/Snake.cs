namespace ConsoleSnakeGame;

public class Snake
{
    private List<Position> _body;

    private readonly char _texture = '■';
    private Direction _oldDirection = Direction.Right;
    private Direction _currentDirection = Direction.Right;

    public Position Head => _body[0];
    public IEnumerable<Position> Body => _body[1..];
    public bool IsDead { get; private set; } = false;

    public Snake()
    {
        _body = [new Position(12, 14), new Position(12, 13), new Position(12, 12)];
    }

    public void Draw()
    {
        foreach (var position in _body)
        {
            Console.SetCursorPosition(position.Left, position.Top);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(_texture);
        }
    }

    private void ChangeDirection()
    {
        _oldDirection = _currentDirection;

        _currentDirection = Game.PressedKey switch
        {
            ConsoleKey.UpArrow => Direction.Up,
            ConsoleKey.DownArrow => Direction.Down,
            ConsoleKey.LeftArrow => Direction.Left,
            ConsoleKey.RightArrow => Direction.Right,
            _ => _oldDirection,
        };
    }

    public void Move()
    {
        ChangeDirection();

        var newHead = GetNewPosition(_currentDirection, Head);

        for (int i = _body.Count - 1; i > 0; i--)
        {
            _body[i] = _body[i - 1];
        }

        _body.RemoveAt(0);
        _body.Insert(0, newHead);

        WrapAround();

        if (Body.Any(e => e == Head)) IsDead = true;
    }

    private void WrapAround()
    {
        if (Head.Top < 0) _body[0] = new Position(GameField.ROWS, _body[0].Left);
        else if (Head.Top > GameField.ROWS) _body[0] = new Position(0, _body[0].Left);
        else if (Head.Left < 0) _body[0] = new Position(_body[0].Top, GameField.COLUMNS);
        else if (Head.Left > GameField.COLUMNS) _body[0] = new Position(_body[0].Top, 0);
    }

    public void Grow()
    {
        var tail = _body[^1];
        _body.Add(new Position(tail.Top, tail.Left));
    }

    private Position GetNewPosition(Direction direction, Position _oldPosition)
    {
        return direction switch
        {
            Direction.Up => _oldPosition.MoveUp(),
            Direction.Down => _oldPosition.MoveDown(),
            Direction.Left => _oldPosition.MoveLeft(),
            Direction.Right => _oldPosition.MoveRight(),
            _ => throw new NotImplementedException(),
        };
    }
}
