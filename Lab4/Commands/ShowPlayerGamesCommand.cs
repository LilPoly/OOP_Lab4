using Lab4.Game.Service;

namespace Lab4.Commands;

public class ShowPlayerGamesCommand : ICommand
{
    private readonly GameService _gameService;

    public ShowPlayerGamesCommand(GameService gameService)
    {
        _gameService = gameService;
    }

    public void Execute()
    {
        Console.WriteLine("Enter player ID to show their games:");
        int playerId = int.Parse(Console.ReadLine());  

        try
        {
            _gameService.GetGamesByPlayerId(playerId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
}
