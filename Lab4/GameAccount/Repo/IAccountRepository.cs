namespace Lab4.GameAccount;

public interface IAccountRepository
{
    void CreateAccount(Account account); 
    List<Account> GetAllAccounts();
    Account ReadAccountById(int id);
    void UpdateAccount(Account account);
    void DeleteAccount(int id);
}
