namespace Lab4.Commands;

public class ShowPlayersCommand:ICommand
{
    private readonly AccountService _accountService;

    // Ініціалізація сервісу для отримання акаунтів
    public ShowPlayersCommand(AccountService accountService)
    {
        _accountService = accountService;
    }

    // Реалізація методу Execute для відображення всіх гравців
    public void Execute()
    {
        _accountService.GetAllAccounts();  // Викликаємо метод, що виводить акаунтів
    }
}