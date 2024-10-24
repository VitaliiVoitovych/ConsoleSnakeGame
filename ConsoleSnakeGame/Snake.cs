namespace ConsoleSnakeGame;

public class Snake
{
    private List<Position> _body;
    private Position? _lastTileOldPosition;

    private readonly char _texture = '■';
    private Direction _currentDirection = Direction.Right;

    public Position Head
    {
        get => _body[0];
        private set => _body[0] = value;
    }

    public IEnumerable<Position> Body => _body[1..];
    public bool IsDead { get; private set; } = false;

    public Snake()
    {
        _body = [new Position(12, 14), new Position(12, 13), new Position(12, 12)];
    }

    public void Draw()
    {
        if (_lastTileOldPosition.HasValue)
        {
            Console.SetCursorPosition(_lastTileOldPosition.Value.Left, _lastTileOldPosition.Value.Top);
            Console.Write(" ");
        }

        foreach (var position in _body)
        {
            Console.SetCursorPosition(position.Left, position.Top);
            Console.ForegroundColor = position == Head ? ConsoleColor.Green : ConsoleColor.DarkGreen;
            Console.Write(_texture);
        }
    }

    private void ChangeDirection()
    {
        _currentDirection = Game.PressedKey switch
        {
            ConsoleKey.UpArrow when _currentDirection != Direction.Down => Direction.Up,
            ConsoleKey.DownArrow when _currentDirection != Direction.Up => Direction.Down,
            ConsoleKey.LeftArrow when _currentDirection != Direction.Right => Direction.Left,
            ConsoleKey.RightArrow when _currentDirection != Direction.Left => Direction.Right,
            _ => _currentDirection,
        };
    }

    public void Move()
    {
        ChangeDirection();
        _lastTileOldPosition = _body[^1];

        var newHeadPosition = GetNewHeadPosition(_currentDirection, Head);

        for (int i = _body.Count - 1; i > 0; i--)
        {
            _body[i] = _body[i - 1];
        }

        _body.RemoveAt(0);
        _body.Insert(0, newHeadPosition);

        WrapAround();
        
        if (Body.Any(e => e == Head)) IsDead = true;
    }

    private void WrapAround()
    {
        if (Head.Top < 0) Head = new Position(GameField.ROWS, Head.Left);
        else if (Head.Top > GameField.ROWS) Head = new Position(0, Head.Left);
        else if (Head.Left < 0) Head = new Position(Head.Top, GameField.COLUMNS);
        else if (Head.Left > GameField.COLUMNS) Head = new Position(Head.Top, 0);
    }

    public void Grow()
    {
        var tail = _body[^1];
        _body.Add(new Position(tail.Top, tail.Left));
    }

    private Position GetNewHeadPosition(Direction direction, Position _oldPosition)
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
