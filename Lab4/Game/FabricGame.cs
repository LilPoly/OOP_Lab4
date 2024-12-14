namespace Lab4.Game;

public class FabricGame
{
    public Game CreateGame(string gameType)
    {
        if (gameType == "Classic")
        {
            return new ClassicGame();
        }
        else if (gameType == "Training")
        {
            return new TrainingGame();
        }
        else
        {
            throw new ArgumentException("Unknown game type");
        }
    }
}