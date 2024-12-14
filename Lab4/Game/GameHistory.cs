using Lab4.GameAccount;

namespace Lab4.Game;

public class GameHistory
{
    public GameAccount.Account Player1 { get; }
    public GameAccount.Account Player2 { get; }
    public int Rating { get; set; }
    public WinLose WinLoseRes { get; }

    public GameHistory(GameAccount.Account player1, GameAccount.Account player2, int rating, WinLose winLoseRes)
    {
        Player1 = player1;
        Player2 = player2;
        Rating = rating;
        WinLoseRes = WinLoseRes;
    }
    
    public override string ToString()
    {
        string result;

        if (WinLoseRes == WinLose.Win)
        {
            result = $"Winner: {Player1.UserName}, Loser: {Player2.UserName}";
        }
        else
        {
            result = $"Winner: {Player2.UserName}, Lose: {Player1.UserName}";
        }

        return $"{result}, Rating: {Rating}";
    }

    
}