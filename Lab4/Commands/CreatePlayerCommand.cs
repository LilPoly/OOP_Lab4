using Lab4.GameAccount;

namespace Lab4.Commands;

public class CreatePlayerCommand: ICommand
{
    private readonly AccountService _accountService;

    public CreatePlayerCommand(AccountService accountService)
    {
        _accountService = accountService;
    }

    public void Execute()
    {
        Console.WriteLine("Enter username for the new player:");
        string username = Console.ReadLine();
        
        Console.WriteLine("Select account type: ");
        Console.WriteLine("1 - Standart");
        Console.WriteLine("2 - Premium");
        
        Console.WriteLine("3 - VIP");

        string accountChoice = Console.ReadLine();
        AccountType accountType;

        switch (accountChoice)
        {
            case "1":
                accountType = AccountType.Standard;
                break;
            case "2":
                accountType = AccountType.Premium;
                break;
            case "3":
                accountType = AccountType.Vip;
                break;
            default:
                Console.WriteLine("Invalid choice, setting to Standard.");
                accountType = AccountType.Standard;
                break;
        }

        // Create the account
        _accountService.CreateAccount(username, accountType);
    }
    }