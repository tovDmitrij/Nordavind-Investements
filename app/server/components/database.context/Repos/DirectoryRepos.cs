using database.context.Models.Data;
using misc.security;

namespace database.context.Repos
{
    public sealed class DirectoryRepos : IDirectoryRepos
    {
        private readonly DataContext _db;

        public DirectoryRepos(DataContext db) => _db = db;

        public void AddCurrency(CurrencyModel currency)
        {
            _db.TableCurrencies.Add(currency);
            _db.SaveChanges();
        }

        public void AddCondition(ConditionModel condition)
        {
            _db.TableConditions.Add(condition);
            _db.SaveChanges();
        }

        public void AddAccountType(AccountTypeModel accountType)
        {
            _db.TableAccountTypes.Add(accountType);
            _db.SaveChanges();
        }

        public void AddBotType(BotTypeModel botType)
        {
            _db.TableBotTypes.Add(botType);
            _db.SaveChanges();
        }

        public IEnumerable<CurrencyModel> GetCurrencies() => _db.TableCurrencies.ToList();

        public IEnumerable<ConditionModel> GetConditions() => _db.TableConditions.ToList();

        public IEnumerable<AccountTypeModel> GetAccountTypes() => _db.TableAccountTypes.ToList();

        public IEnumerable<BotTypeModel> GetBotTypes() => _db.TableBotTypes.ToList();

        public IEnumerable<OperationModel> GetOperations() => _db.TableOperations.ToList();

        public IEnumerable<FundModel> GetFunds() => _db.TableFunds.ToList();

        public void UpdateCurrency(int currencyId, string title, string short_title)
        {
            var currency = _db.TableCurrencies.Single(currency => currency.ID == currencyId);
            currency.Title = title;
            currency.ShortTitle = short_title;
            _db.Update(currency);
            _db.SaveChanges();
        }

        public void UpdateCondition(int conditionId, string title, decimal value, string description)
        {
            var condition = _db.TableConditions.Single(condition => condition.ID == conditionId);
            condition.Title = title;
            condition.Value = value;
            condition.Description = description;
            _db.Update(condition);
            _db.SaveChanges();
        }

        public void UpdateAccountType(int accountTypeId, string title, string description)
        {
            var accountType = _db.TableAccountTypes.Single(accountType => accountType.ID == accountTypeId);
            accountType.Title = title;
            accountType.Description = description;
            _db.Update(accountType);
            _db.SaveChanges();
        }

        public void UpdateBotType(int botTypeId, string title, string description)
        {
            var botType = _db.TableBotTypes.Single(botType => botType.ID == botTypeId);
            botType.Title = title;
            botType.Description = description;
            _db.Update(botType);
            _db.SaveChanges();
        }

        public void DeleteCurrency(int currencyId)
        {
            var currency = _db.TableCurrencies.Single(currency => currency.ID == currencyId);
            _db.TableCurrencies.Remove(currency);
            _db.SaveChanges();
        }

        public void DeleteCondition(int conditionId)
        {
            var condition = _db.TableConditions.Single(condition => condition.ID == conditionId);
            _db.TableConditions.Remove(condition);
            _db.SaveChanges();
        }

        public void DeleteAccountType(int accountTypeId)
        {
            var accountType = _db.TableAccountTypes.Single(accountType => accountType.ID == accountTypeId);
            _db.TableAccountTypes.Remove(accountType);
            _db.SaveChanges();
        }

        public void DeleteBotType(int botTypeId)
        {
            var botType = _db.TableBotTypes.Single(botType => botType.ID == botTypeId);
            _db.TableBotTypes.Remove(botType);
            _db.SaveChanges();
        }
        public bool IsCurrencyExists(int currencyId) => _db.TableCurrencies
            .Any(currency => currency.ID == currencyId);

        public bool IsConditionExists(int conditionId) => _db.TableConditions
            .Any(condition => condition.ID == conditionId);

        public bool IsAccountTypeExists(int accountTypeId) => _db.TableAccountTypes
            .Any(accountType => accountType.ID == accountTypeId);

        public bool IsBotTypeExists(int botTypeId) => _db.TableBotTypes
            .Any(botType => botType.ID == botTypeId);

    }
}