namespace Lab4.GameAccount
{
    public class PlayerHistory
    {
        // Лічильник ID для PlayerHistory
        private static int _nextId = 1;
        
        public string TypeGame { get; }

        public int Rating { get; }
        public WinLose WinLoseRes { get; }
        public Account Oponent { get; }
        public int BeforeRating { get; }
        public int AfterRating { get; }
        public int Bonus { get; }

        public PlayerHistory(string typeGame, int rating, WinLose winLoseRes,
            Account oponent, int beforeRating, int afterRating, int bonus)
        {
            TypeGame = typeGame;
            Rating = rating;
            WinLoseRes = winLoseRes;
            Oponent = oponent;
            BeforeRating = beforeRating;
            AfterRating = afterRating;
            Bonus = bonus;
        }
    }
}