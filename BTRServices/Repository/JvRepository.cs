using BTRServices.DAL;
using BTRServices.Models;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System;
using System.Threading.Tasks;

namespace BTRServices.Repository
{
    public class JvRepository: Repository<JvDocDTO>
    {
        public JvRepository(BtrDbContext context) : base(context)
        {

        }
        public void CreateJV(int btr_key)
        {
            ObjectParameter p_jv_doc_id = new ObjectParameter("jv_doc_id","0");
            ObjectParameter p_status_ind = new ObjectParameter("p_status_ind", "0");
            ObjectParameter p_status_message = new ObjectParameter("p_status_message", "0");
            int? btr_key_sql = btr_key;
            //due to the complexity of the SP checking the output parameters is useless
            _context.Create_JV(btr_key_sql, p_jv_doc_id, p_status_ind, p_status_message);
            //will just have to check for exceptions for errors
        }

        internal void GetStatus(int btr_key)
        {
            throw new NotImplementedException();
        }
    }
}