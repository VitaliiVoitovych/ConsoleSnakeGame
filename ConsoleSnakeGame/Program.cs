using ConsoleSnakeGame;

Console.CursorVisible = false;
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.SetWindowSize(GameField.COLUMNS + 1, GameField.ROWS + 2);
Console.SetBufferSize(GameField.COLUMNS + 1, GameField.ROWS + 2); // WINDOWS

var game = new Game();
game.Start();