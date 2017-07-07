using BTRServices.DAL;
using BTRServices.Model;
using BTRServices.Repository;
using System.Linq;

namespace BTRServices.Controllers
{
    internal class OneTimePaymentRepository : HrRepository<OneTimePaymentDTO>
    {
        private HrDbContext dbCxt;

        public OneTimePaymentRepository(HrDbContext context) : base(context)
        {
        }

        public OneTimePaymentDTO GetItem(int one_time_payment_key)
        {
            throw new System.Exception("function not implemented");
            //return (from a in _context.tc_otp_payment
            //        where a.otp_trns_payment_key_id == one_time_payment_key
            //        select new OneTimePaymentDTO
            //        {
            //            otp_trns_key_id = a.otp_trns_key_id,
            //            otp_trns_payment_amount = a.otp_trns_payment_amount,
            //            otp_trns_payment_index_number = a.otp_trns_payment_index_number,
            //            otp_trns_payment_account_number = a.otp_trns_payment_account_number,
            //            otp_trns_payment_percentage = a.otp_trns_payment_percentage
            //        }).FirstOrDefault();
        }
        public OneTimePaymentDTO CreateItem(OneTimePaymentDTO record)
        {
            throw new System.Exception("function not implemented"); //the datasource is currently SharePoint
            //return (from a in _context.otp_payment_create(record.otp_trns_key_id, record.otp_trns_payment_index_number, record.otp_trns_payment_account_number, record.otp_trns_payment_percentage, record.otp_trns_payment_amount)
            //        select new OneTimePaymentDTO
            //        {
            //            otp_trns_key_id = a.otp_trns_key_id,
            //            otp_trns_payment_index_number = a.otp_trns_payment_index_number,
            //            otp_trns_payment_account_number = a.otp_trns_payment_account_number,
            //            otp_trns_payment_key_id = a.otp_trns_payment_key_id,
            //            otp_trns_payment_percentage = a.otp_trns_payment_percentage,
            //            otp_trns_payment_amount = a.otp_trns_payment_amount
            //        }).ToList().FirstOrDefault();
        }

        public OneTimePaymentDTO UpdateItem(OneTimePaymentDTO record)
        {
            throw new System.Exception("function not implemented"); //the datasource is currently SharePoint            return (from a in _context.otp_payment_update(record.otp_trns_payment_key_id, record.otp_trns_key_id, record.otp_trns_payment_index_number, record.otp_trns_payment_account_number, record.otp_trns_payment_percentage, record.otp_trns_payment_amount)
            //select new OneTimePaymentDTO
            //        {
            //            otp_trns_key_id = a.otp_trns_key_id,
            //            otp_trns_payment_index_number = a.otp_trns_payment_index_number,
            //            otp_trns_payment_account_number = a.otp_trns_payment_account_number,
            //            otp_trns_payment_key_id = a.otp_trns_payment_key_id,
            //            otp_trns_payment_percentage = a.otp_trns_payment_percentage,
            //            otp_trns_payment_amount = a.otp_trns_payment_amount
            //        }).ToList().FirstOrDefault();
        }
        public void DeleteItem(int one_time_payment_key)
        {
            throw new System.Exception("function not implemented"); //the datasource is currently SharePoint
            //_context.otp_payment_delete_all(one_time_payment_key);

         }

    }
}