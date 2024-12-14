using Lab3.Game.Service;
using Lab4.Game.Repo;
using Lab4.GameAccount;

namespace Lab4.Game.Service;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    private readonly IAccountRepository _accountRepository; 
    private int _lastGameId = 0;

    public GameService(IGameRepository gameRepository, IAccountRepository accountRepository)
    {
        _gameRepository = gameRepository;
        _accountRepository = accountRepository;
    }

    public void CreateGame(int player1Id, int player2Id, string gameType, int rating)
    {
        var gameFactory = new FabricGame();
        var game = gameFactory.CreateGame(gameType);
        game.Id = ++_lastGameId; 
        var player1 = _accountRepository.ReadAccountById(player1Id);
        var player2 = _accountRepository.ReadAccountById(player2Id);

        if (player1 == null || player2 == null)
        {
            throw new Exception("Not found");
        }

        game.PlayerIds.Add(player1.Id);
        game.PlayerIds.Add(player2.Id);

        game.PlayGame(player1, player2, rating);
        
        Console.WriteLine($"Game between {player1.UserName} and {player2.UserName} created! Type: {gameType}");
        
        var lastResult = game.GetLastResult();  
        Console.WriteLine(lastResult != null
            ? $"Game`s over: {lastResult}"
            : "Результат гри недоступний.");
        
        Console.WriteLine($"Rating after game: {player1.UserName} - {player1.CurrentRating}, {player2.UserName} - {player2.CurrentRating}");
        _gameRepository.CreateGame(game);

    }
    
    public List<Game> GetAllGames()
    {
        var games = _gameRepository.GetAllGames();
        Console.WriteLine($"Player played {games.Count} games.");

        foreach (var game in games)
        {
       
            Console.WriteLine($"Game ID: {game.Id}");
            Console.WriteLine($"Game Type: {game.TypeGame}");

          
            var player1 = _accountRepository.ReadAccountById(game.PlayerIds[0]); 
            var player2 = _accountRepository.ReadAccountById(game.PlayerIds[1]);

            Console.WriteLine($"Player 1: {player1.UserName}, Rating: {player1.CurrentRating}");
            Console.WriteLine($"Player 2: {player2.UserName}, Rating: {player2.CurrentRating}");
        
       
            var lastResult = game.GetLastResult();
            Console.WriteLine(lastResult != null
                ? $"Game Result: {lastResult}"
                : "Game Result: Not available");

            Console.WriteLine(); 
        }

        return games;
    }

    public void UpdateGame(Game game)
    {
        try
        {
            _gameRepository.UpdateGame(game);
            Console.WriteLine($"Game with ID {game.Id} updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void DeleteGame(int gameId)
    {
        try
        {
            _gameRepository.DeleteGame(gameId);
            Console.WriteLine($"Game with ID {gameId} delete.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    public List<Game> GetGamesByPlayerId(int playerId)
    {
        var games = _gameRepository.GetAllGames();

        var playerGames = games.Where(game => game.PlayerIds.Contains(playerId)).ToList();

        Console.WriteLine($"Player with ID {playerId} played {playerGames.Count} games");

        foreach (var game in playerGames)
        {
            Console.WriteLine($"Game ID: {game.Id}, Players: {game.PlayerIds[0]} vs {game.PlayerIds[1]}, Type of game: {game.TypeGame}");
        }

        return playerGames;
    }
}