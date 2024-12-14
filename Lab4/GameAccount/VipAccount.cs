using Lab4.Game;

namespace Lab4.GameAccount;

public class VipAccount: Account
{
    public VipAccount(string userName) : base(userName, AccountType.Vip)
    {
    }

    public override void WinGame(string typeGame, GameHistory game, Account player)
    {
        var beforeRating = CurrentRating;
        CurrentRating += game.Rating * 2;

        Results.Add(new PlayerHistory(typeGame,game.Rating, WinLose.Win, player, beforeRating, CurrentRating, game.Rating));
    }

    public override void LoseGame(string typeGame, GameHistory game, Account player)
    {
        var bonus = 0;
        
        var beforeRating = CurrentRating;
        CurrentRating -= game.Rating / 2;
        Results.Add(new PlayerHistory(typeGame,game.Rating, WinLose.Lose, player, beforeRating, CurrentRating, bonus));
    }
}