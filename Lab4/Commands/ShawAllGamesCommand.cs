using Lab4.Game.Service;

namespace Lab4.Commands;

public class ShowAllGamesCommand : ICommand
{
    private readonly GameService _gameService;

    // Ініціалізація сервісу
    public ShowAllGamesCommand(GameService gameService)
    {
        _gameService = gameService;
    }

    // Реалізація методу Execute для виведення всіх ігор
    public void Execute()
    {
        try
        {
            // Отримуємо всі ігри з сервісу
            var games = _gameService.GetAllGames();

            // Виводимо інформацію про кожну гру
            Console.WriteLine($"Total games played: {games.Count}");
            foreach (var game in games)
            {
                Console.WriteLine($"Game ID: {game.Id}, Players: {game.PlayerIds[0]} vs {game.PlayerIds[1]}, Type of game: {game.TypeGame}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
}
