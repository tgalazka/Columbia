using BTRServices.DAL;
using BTRServices.Model;
using System.Collections.Generic;
using System.Linq;

namespace BTRServices.Repository
{
    public class AccountRepository : Repository<account>
    {
        public AccountRepository(BtrDbContext context) : base(context)
        {
        }
        public IEnumerable<AccountDTO> GetAccounts()
        {
            return (from a in _context.accounts_all()
                    select new AccountDTO
                    {
                        index_key = a.index_key,
                        account_balance = a.account_balance,
                        account_description = a.account_description,
                        account_number_description = a.account_number_description,
                        account_key = a.account_key,
                        account_number = a.account_number
                    }).ToList();
        }

        internal IEnumerable<AccountDTO> GetAccountsByIndex(int index_key)
        {
            var x = _context.account_byIndex(index_key);
            foreach(account_byIndex_Result y in x)
            {
                var g = y;
            }
            return (from a in _context.account_byIndex(index_key)
                    select new AccountDTO
                    {
                        index_key = a.index_key,
                        account_balance = a.account_balance,
                        account_description = a.account_description,
                        account_number_description = a.account_number_description,
                        account_key = a.account_key,
                        account_number = a.account_number
                    }).ToList();
            
        }

        internal IEnumerable<AccountDTO> GetAccountBalance(int index_key)
        {
            return (from a in _context.accountbalance_byaccountkey(index_key)
                    select new AccountDTO
                    {
                        index_key = a.index_key,
                        account_balance = a.account_balance,
                        account_description = a.account_description,
                        account_number_description = a.account_number_description,
                        account_key = a.account_key,
                        account_number = a.account_number
                    }).ToList();
        }

        internal IEnumerable<AccountDTO> GetAccountBalances(int[] iKeys)
        {
            string ikValues = string.Join(",", iKeys);
            
            return (from a in _context.accountbalances_byindexkeys(ikValues)
                select new AccountDTO
                    {
                        account_balance = a.account_balance,
                        account_description = a.account_description,
                        account_number_description = a.account_number_description,
                        index_key = a.index_key,
                        account_key = a.account_key,
                        account_number = a.account_number
                    }).ToList();
        }

        //public IEnumerable<Account> GetAccounts()
        //{

        //    var vAccunts = from a in _context.accounts
        //                   orderby a.index_key, a.account_number_description
        //                   select a;
        //    return vAccunts.ToList<Account>();
        //}

        //public IEnumerable<Account> GetAccountsByIndex(int index_key)
        //{

        //    var vAccunts = from a in _context.accounts
        //                   where a.index_key == index_key
        //                   orderby a.account_number_description
        //                   select a;
        //    return vAccunts.ToList<Account>();
        //}

        //public Account GetAccountBalance(int iKey)
        //{
        //    var vAccunt = from a in _context.A
        //                   where a.account_key == iKey
        //                   select a;
        //    return vAccunt.FirstOrDefault<Account>();
        //}

        //public IEnumerable<Account> GetAccountBalances(int[] iKeys)
        //{
        //    var vAccunt = from a in _context.accounts
        //                  where iKeys.Contains(a.index_key)
        //                  select a;
        //    return vAccunt.ToList<Account>();
        //}

    }
}