using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BTRServices;
using BTRServices.Repository;
using BTRServices.DAL;
using BTRServices.Models;

namespace BTRServices.Repository
{
    public class IndexRepository : Repository<indices_all_Result>
    {
        public IndexRepository(BtrDbContext context) : base(context)
        {
        }

        public IEnumerable<IndexDTO> GetIndices_ByOwner(string uni)
        {
            // return _context.indices_byowner(uni).
            return (from a in _context.indices_byowner(uni)
                    select new IndexDTO
                    {
                        index_key = a.index_key,
                        index_orgn_code = a.index_orgn_code,
                        index_prog_code = a.index_prog_code,
                        index_number_description = a.index_number_description,
                        index_description = a.index_description

                    }).ToList();
        }
        public IEnumerable<IndexDTO> GetIndicesOwned_ByDept(string uni, int dept_key)
        {
            return (from a in _context.indices_owned_bydept(dept_key, uni)
                    select new IndexDTO
                    {
                        index_key = a.index_key,
                        index_orgn_code = a.index_orgn_code,
                        index_prog_code = a.index_prog_code,
                        index_number_description = a.index_number_description,
                        index_description = a.index_description

                    }).ToList();

        }
        public IEnumerable<IndexDTO> GetIndices_ByDept(int dept_key)
        {
            return (from a in _context.indices_bydept(dept_key)
                    select new IndexDTO
                    {
                        index_key = a.index_key,
                        index_orgn_code = a.index_orgn_code,
                        index_prog_code = a.index_prog_code,
                        index_number_description = a.index_number_description,
                        index_description = a.index_description

                    }).ToList();
        }

        public IEnumerable<IndexDTO> GetIndices()
        {
            //return (from i in _context.indices select i).ToList();
            return (from a in _context.indices
                    select new IndexDTO
                    {
                        index_key = a.index_key,
                        index_orgn_code = a.index_orgn_code,
                        index_prog_code = a.index_prog_code,
                        index_number_description = a.index_number_description,
                        index_description = a.index_description

                    }).ToList();
        }
    }
}