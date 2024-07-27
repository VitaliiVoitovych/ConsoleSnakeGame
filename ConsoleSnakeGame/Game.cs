namespace ConsoleSnakeGame;

public class Game
{
    private GameField _gameField;
    public static ConsoleKey PressedKey;
    public static bool IsGameOver = false;

    public Game()
    {
        _gameField = new();
    }

    public void Start()
    {
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
        Console.ReadKey();
    }
}
