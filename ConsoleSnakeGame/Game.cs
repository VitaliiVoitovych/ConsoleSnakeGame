namespace ConsoleSnakeGame;

public class Game
{
    private GameField _gameField;

    private bool _isRestarted = false;

    public static ConsoleKey PressedKey;
    public static bool IsGameOver = false;

    public Game()
    {
        _gameField = new();
    }

    private void Reset()
    {
        Console.Clear();
        _gameField = new GameField();
        IsGameOver = false;
        _isRestarted = false;
    }

    private void ShowRestartMessage()
    {
        Console.SetCursorPosition(GameField.COLUMNS + 4, 2);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Restart the game press R:");
    }

    public void Start()
    {
        ConsoleKey key;
        do
        {
            if (_isRestarted) Reset();
            while (!IsGameOver)
            {
                if (Console.KeyAvailable)
                {
                    PressedKey = Console.ReadKey(true).Key;
                }

                _gameField.Draw();
                _gameField.Update();
                Thread.Sleep(150);
            }

            ShowRestartMessage();
            key = Console.ReadKey(true).Key;
            _isRestarted = key == ConsoleKey.R;
        }
        while (_isRestarted);
    }
}
