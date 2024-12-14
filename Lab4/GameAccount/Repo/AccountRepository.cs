using Lab4.DataBase;

namespace Lab4.GameAccount
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DbContext _dbContext;
        private static int _nextId = 1;  

        public AccountRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateAccount(Account account)
        {
            if (account.Id == 0)
            {
                account.Id = _nextId++;
            }

            _dbContext.Accounts.Add(account);
        }

        public List<Account> GetAllAccounts()
        {
            return _dbContext.Accounts;
        }

        public Account ReadAccountById(int id)
        {
            var account = _dbContext.Accounts.FirstOrDefault(a => a.Id == id);
            return account;
        }

        public void UpdateAccount(Account account)
        {
            var existingAccount = _dbContext.Accounts.FirstOrDefault(a => a.Id == account.Id);
            if (existingAccount != null)
            {
                existingAccount.UserName = account.UserName;
            }
        }

        public void DeleteAccount(int id)
        {
            var account = _dbContext.Accounts.FirstOrDefault(a => a.Id == id);
            if (account != null)
            {
                _dbContext.Accounts.Remove(account);
            }
        }
    }
}