using System;
using Lab4.Commands;
using Lab4.DataBase;
using Lab4.Game.Repo;
using Lab4.Game.Service;
using Lab4.GameAccount;

class Program
{
    static void Main(string[] args)
    {
        var dbContext = new DbContext(); 

        var accountRepository = new AccountRepository(dbContext);
        var gameRepository = new GameRepository(dbContext); 

        var gameService = new GameService(gameRepository, accountRepository); 
        var accountService = new AccountService(accountRepository); 
        
        // Створення об'єктів для команд
        var createPlayerCommand = new CreatePlayerCommand(accountService);
        var showAllPlayersCommand = new ShowPlayersCommand(accountService);
        var createGameCommand = new PlayGameCommand(accountService, gameService);
        var ShowPlayerGamesCommand = new ShowPlayerGamesCommand(gameService);
        var showAllGamesCommand = new ShowAllGamesCommand(gameService);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Game System!");
            Console.WriteLine("1. Create Player");
            Console.WriteLine("2. Show All Players");
            Console.WriteLine("3. Create Game");
            Console.WriteLine("4. Show Games of a Player");
            Console.WriteLine("5. Show All Games");
            Console.WriteLine("6. Exit");
            Console.Write("Please choose an option: ");
            
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    createPlayerCommand.Execute();
                    break;
                case "2":
                    showAllPlayersCommand.Execute();
                    break;
                case "3":
                    createGameCommand.Execute();
                    break;
                case "4":
                    ShowPlayerGamesCommand.Execute();
                    break;
                case "5":
                    showAllGamesCommand.Execute();
                    break;
                case "6":
                    Console.WriteLine("Exiting the application...");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
