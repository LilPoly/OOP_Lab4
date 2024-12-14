namespace Lab4.Game.Service
{
}

namespace Lab3.Game.Service
{
    public interface IGameService
    {
        void CreateGame(int player1Id, int player2Id, string gameType, int rating);
        List<Lab4.Game.Game> GetAllGames();
        void UpdateGame(Lab4.Game.Game game);
        void DeleteGame(int gameId);
        
        List<Lab4.Game.Game> GetGamesByPlayerId(int playerId);

    }
}

