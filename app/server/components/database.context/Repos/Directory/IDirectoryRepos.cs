using database.context.Models.Data;
using database.context.Models.Data.Account;

namespace database.context.Repos.Directory
{
    /// <summary>
    /// Взаимодействие с таблицей валют в базе данных
    /// </summary>
    public interface IDirectoryRepos
    {


        #region Add-методы для добавления объектов в БД

        public void AddCurrency(CurrencyModel currency);

        public void AddCondition(ConditionModel condition);

        public void AddAccountType(AccountTypeModel accountType);

        public void AddBotType(BotTypeModel botType);

        #endregion


        #region Get-методы для получения объектов из БД

        public IEnumerable<CurrencyModel> GetCurrencies();

        public IEnumerable<ConditionModel> GetConditions();

        public IEnumerable<AccountTypeModel> GetAccountTypes();

        public IEnumerable<BotTypeModel> GetBotTypes();

        public IEnumerable<OperationModel> GetOperations();

        public IEnumerable<FundModel> GetFunds();

        #endregion


        #region Update-методы для обновления данных об объектах БД

        public void UpdateCurrency(int currencyId, string title, string short_title);

        public void UpdateCondition(int conditionId, string title, decimal value, string description);

        public void UpdateAccountType(int accountTypeId, string title, string description);

        public void UpdateBotType(int botTypeId, string title, string description);

        #endregion


        #region Delete-методы для удаления объектов из БД

        public void DeleteCurrency(int currencyId);

        public void DeleteCondition(int conditionId);

        public void DeleteAccountType(int accountTypeId);

        public void DeleteBotType(int botTypeId);

        #endregion


        #region Проверка существования объектов в БД

        public bool IsCurrencyExists(int currencyId);

        public bool IsConditionExists(int conditionId);

        public bool IsAccountTypeExists(int accountTypeId);

        public bool IsBotTypeExists(int botTypeId);

        #endregion


    }
}