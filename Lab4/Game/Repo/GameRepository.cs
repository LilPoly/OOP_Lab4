using Lab4.DataBase;
using Lab4.Game;
using Lab4.Game.Repo;

public class GameRepository : IGameRepository
{
    private readonly DbContext _dbContext;

    public GameRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateGame(Game game)
    {
        _dbContext.Games.Add(game);  
    }

    public List<Game> GetAllGames()
    {
        return _dbContext.Games.ToList();  
    }

    public Game GetGameById(int id)
    {
        return _dbContext.Games.FirstOrDefault(g => g.Id == id);  
    }

    public void UpdateGame(Game game)
    {
        var existingGame = _dbContext.Games.FirstOrDefault(g => g.Id == game.Id);
        if (existingGame != null)
        {
            _dbContext.Games.Remove(existingGame);  
            _dbContext.Games.Add(game);  
        }
        else
        {
            throw new Exception($"Game with ID {game.Id} not found!");
        }
    }

    public void DeleteGame(int id)
    {
        var game = _dbContext.Games.FirstOrDefault(g => g.Id == id);
        if (game != null)
        {
            _dbContext.Games.Remove(game);  
        }
        else
        {
            throw new Exception($"Game with ID {id} not found.");
        }
    }

    public List<Game> GetGamesByPlayerId(int playerId)
    {
        return _dbContext.Games
            .Where(game => game.PlayerIds.Contains(playerId))  
            .ToList();
    }
}


