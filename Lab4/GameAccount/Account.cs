using Lab4.DataBase;
using Lab4.Game;

namespace Lab4.GameAccount
{
    public class Account
    {
        public string UserName { get; set; }
        private int _currentRating = 1;
        public int Id { get; set; }

        // Статичний лічильник ID для всіх акаунтів
        private static int _nextId = 1;

        public int CurrentRating
        {
            get => _currentRating;
            set => _currentRating = value < 1 ? 1 : value;
        }

        protected List<PlayerHistory> Results { get; }
        public AccountType AccountType { get; set; }

        public Account(string username, AccountType accountType)
        {
            // Ініціалізуємо ID
            Id = _nextId++;
            UserName = username;
            AccountType = accountType;
            Results = new List<PlayerHistory>();
        }

        // public void GetStats()
        // {
        //     Console.ForegroundColor = ConsoleColor.Red;
        //     Console.WriteLine($"\n\t\t{"Stats about",65} " + UserName);
        //     Console.ForegroundColor = ConsoleColor.Cyan;
        //     Console.WriteLine(
        //         "________________________________________________________________________________________________________________________________________________________________\n" +
        //         "| ID |       | Type game  |        |RATING GAME|       |     RESULT     |       |CHANGE|       |RATING|       |BONUS|\n" +
        //         "----------------------------------------------------------------------------------------------------------------------------------------------------------------");
        //
        //     foreach (var result in Results)
        //     {
        //         Console.WriteLine(
        //             $"|{result.Id,2} |  -->  |{result.TypeGame,-12}|  -->  |     " +
        //             $"{result.Rating}     |  -->  |{UserName,5} {result.WinLoseRes,-4} {result.Oponent.UserName,-5}|" +
        //             $"  -->  |{result.BeforeRating,2} {(result.WinLoseRes == WinLose.Lose ? $"-{result.BeforeRating - result.AfterRating,2}" : $"+{result.AfterRating - result.BeforeRating,2}")}|" +
        //             $"  -->  |  {result.AfterRating,2}  |  -->  | +{result.Bonus}  |");
        //     }
        //
        //     Console.WriteLine(
        //         "----------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
        //     Console.ResetColor();
        // }

        public virtual void WinGame(string typeGame, GameHistory game, Account player)
        {
            var beforeRating = CurrentRating;
            CurrentRating += game.Rating;
            Results.Add(new PlayerHistory(typeGame,  game.Rating, WinLose.Win, player, beforeRating, CurrentRating, 0)); 
        }

        public virtual void LoseGame(string typeGame, GameHistory game, Account player)
        {
            var beforeRating = CurrentRating;
            CurrentRating -= game.Rating;
            Results.Add(new PlayerHistory(typeGame, game.Rating, WinLose.Lose, player, beforeRating, CurrentRating, 0)); 
        }
    }
}
