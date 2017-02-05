using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BTRServices;
using BTRServices.Repository;

namespace BTRServices.Repository
{
    public class IndexRepository : Repository<Indices>
    {
        public IndexRepository(BTRDbContext context) : base(context)
        {
        }

        public IEnumerable<Indices> GetIndices_ByOwner(string uni)
        {
            return _context.indices_byowner(uni).ToList<Indices>();
        }
        public IEnumerable<Indices> GetIndicesOwned_ByDept(string uni, int dept_key)
        {
            return _context.indices_owned_bydept(dept_key,uni).ToList<Indices>();
        }
        public IEnumerable<Indices> GetIndices_ByDept(int dept_key)
        {
            if (dept_key == null)
            {
                return (from i in _context.Indices select i).ToList();
            }
            return _context.indices_bydept(dept_key).ToList<Indices>();
        }

        public IEnumerable<Indices> GetIndices()
        {
             return (from i in _context.Indices select i).ToList();
        }

    }
}