namespace ConsoleSnakeGame;

public class GameField
{
    
    public const int ROWS = 20, COLUMNS = 40;
    private readonly Snake _snake;
    private readonly Apple _apple;
    private int _score = 0;

    public GameField()
    {
        _snake = new Snake();
        _apple = new Apple();
    }


    public void Draw()
    {
        Console.Clear();
        _snake.Draw();
        _apple.Draw();

        Console.Title = $"Your Score: {_score}";
    }

    public void Update()
    {
        _snake.Move();
        if (_snake.Head == _apple.Position)
        {
            _apple.ChangePosition(_snake);
            _snake.Grow();
            _score++;
        }
        if (_snake.IsDead)
        {
            Game.IsGameOver = true;
            Console.SetCursorPosition(0, ROWS + 1);
            Console.WriteLine("Game Over");
        }
    }
}
