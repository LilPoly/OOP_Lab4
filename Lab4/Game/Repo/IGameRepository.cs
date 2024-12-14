namespace Lab4.Game.Repo;

public interface IGameRepository
{
    void CreateGame(Game game);  // Оновлений метод для створення гри
    List<Game> GetAllGames();
    Game GetGameById(int id);
    void UpdateGame(Game game);
    void DeleteGame(int id);
}

