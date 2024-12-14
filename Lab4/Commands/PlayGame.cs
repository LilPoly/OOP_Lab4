using Lab4.Game.Service;

namespace Lab4.Commands;

public class PlayGameCommand : ICommand
{
    private readonly AccountService _accountService;
    private readonly GameService _gameService;

    // Ініціалізація сервісів
    public PlayGameCommand(AccountService accountService, GameService gameService)
    {
        _accountService = accountService;
        _gameService = gameService;
    }

    // Реалізація методу Execute для запуску гри
    public void Execute()
    {
        Console.WriteLine("Enter player 1 ID:");
        int player1Id = int.Parse(Console.ReadLine());  // Отримуємо ID першого гравця

        Console.WriteLine("Enter player 2 ID:");
        int player2Id = int.Parse(Console.ReadLine());  // Отримуємо ID другого гравця

        Console.WriteLine("Enter game type (e.g., 'Classic', 'Training'):");
        string gameType = Console.ReadLine();  // Отримуємо тип гри

        Console.WriteLine("Enter rating for the game:");
        int rating = int.Parse(Console.ReadLine());  // Отримуємо рейтинг гри

        try
        {
            // Викликаємо метод для створення та гри
            _gameService.CreateGame(player1Id, player2Id, gameType, rating);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
}
