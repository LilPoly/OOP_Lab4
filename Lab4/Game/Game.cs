using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lab4.GameAccount;

namespace Lab4.Game;

public abstract class Game
{
    public string TypeGame { get; set; }
    protected List<GameHistory> Results { get; }

    public int Id { get; set; }

    protected readonly Random Random;
    public List<int> PlayerIds { get; }

    protected Game()
    {
        Results = new List<GameHistory>();
        Random = new Random();
        PlayerIds = new List<int>();
    }
    
    public void AddPlayers(int player1Id, int player2Id)
    {
        PlayerIds.Add(player1Id);
        PlayerIds.Add(player2Id);
    }
    
    public abstract void PlayGame(GameAccount.Account player1, GameAccount.Account player2, int rating);
    
    public GameHistory GetLastResult()
    {
        return Results.LastOrDefault();
    }
}