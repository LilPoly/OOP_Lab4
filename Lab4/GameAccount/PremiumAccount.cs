using Lab4.Game;

namespace Lab4.GameAccount;

public class PremiumAccount: Account
{
    public PremiumAccount(string userName) : base(userName, AccountType.Premium)
    {
    }

    public override void WinGame(string typeGame, GameHistory game, Account player)
    {
        var beforeRating = CurrentRating;
        var bonus = 0;

        if (HasStreak(3))
        {
            CurrentRating += (int)(game.Rating * 1.5);
            bonus = (int)(game.Rating * 1.5) - game.Rating;
        }
        else
        {
            CurrentRating += game.Rating;
        }
        
        Results.Add(new PlayerHistory(typeGame, game.Rating, WinLose.Win, player, beforeRating, CurrentRating, bonus));

    }

    private bool HasStreak(int count)
    {
        if (Results.Count < count) return false;

        for (var i = Results.Count - 1; i >= Results.Count - count; i--)
        {
            if (Results[i].WinLoseRes != WinLose.Win)
            {
                return false;
            }
        }

        return true;
    }
}