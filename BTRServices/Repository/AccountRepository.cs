using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BTRServices.Repository
{
    public class AccountRepository : Repository<Accounts>
    {
        public AccountRepository(BTRDbContext context) : base(context)
        {
        }

        public IEnumerable<Accounts> GetAccounts()
        {

            var vAccunts = from a in _context.Accounts
                           orderby a.index_key, a.account_number_description
                           select a;
            return vAccunts.ToList<Accounts>();
        }
        public IEnumerable<Accounts> GetAccountsByIndex(int index_key)
        {

            var vAccunts = from a in _context.Accounts
                           where a.index_key == index_key
                           orderby a.account_number_description
                           select a;
            return vAccunts.ToList<Accounts>();
        }

        public Accounts GetAccountBalance(int iKey)
        {
            var vAccunt = from a in _context.Accounts
                           where a.account_key == iKey
                           select a;
            return vAccunt.FirstOrDefault<Accounts>();
        }

        public IEnumerable<Accounts> GetAccountBalances(int[] iKeys)
        {
            var vAccunt = from a in _context.Accounts
                          where iKeys.Contains(a.index_key)
                          select a;
            return vAccunt.ToList<Accounts>();
        }

    }
}