using database.context.Models.Data;
namespace database.context.Repos.Directory
{
    public interface IDirectoryRepos
    {
        public void AddCurrency(CurrencyModel currency);

        public void AddCondition(ConditionModel condition);

        public void AddAccountType(AccountTypeModel accountType);

        public void AddBotType(BotTypeModel botType);

        public IEnumerable<CurrencyModel> GetCurrencies();

        public IEnumerable<ConditionModel> GetConditions();

        public IEnumerable<AccountTypeModel> GetAccountTypes();

        public IEnumerable<BotTypeModel> GetBotTypes();

        public IEnumerable<OperationModel> GetOperations();

        public IEnumerable<FundModel> GetFunds();

        public void UpdateCurrency(int currencyId, string title, string short_title);

        public void UpdateCondition(int conditionId, string title, decimal value, string description);

        public void UpdateAccountType(int accountTypeId, string title, string description);

        public void UpdateBotType(int botTypeId, string title, string description);

        public void DeleteCurrency(int currencyId);

        public void DeleteCondition(int conditionId);

        public void DeleteAccountType(int accountTypeId);

        public void DeleteBotType(int botTypeId);

        public bool IsCurrencyExists(int currencyId);

        public bool IsConditionExists(int conditionId);

        public bool IsAccountTypeExists(int accountTypeId);

        public bool IsBotTypeExists(int botTypeId);

    }
}