using Lab4.Game;
using Lab4.GameAccount;

namespace Lab4.DataBase;

public class DbContext
{
    public List<GameAccount.Account> Accounts { get; set; }
    public List<Game.Game> Games { get; set; }

    public DbContext()
    {
        Accounts = new List<GameAccount.Account>();
        Games = new List<Game.Game>();
    }
}
