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
            return (from a in _context.tc_otp_payment
                    where a.otp_trns_payment_key_id == one_time_payment_key
                    select new OneTimePaymentDTO
                    {
                        otp_trns_key_id = a.otp_trns_key_id,
                        otp_trns_payment_amount = a.otp_trns_payment_amount,
                        otp_trns_payment_index_number = a.otp_trns_payment_index_number,
                        otp_trns_payment_account_number = a.otp_trns_payment_account_number,
                        otp_trns_payment_percentage = a.otp_trns_payment_percentage
                    }).FirstOrDefault();
        }
        public OneTimePaymentDTO CreateItem(OneTimePaymentDTO record)
        {
            return (from a in _context.otp_payment_create(record.otp_trns_key_id, record.otp_trns_payment_index_number, record.otp_trns_payment_account_number, record.otp_trns_payment_percentage, record.otp_trns_payment_amount)
                    select new OneTimePaymentDTO
                    {
                        otp_trns_key_id = a.otp_trns_key_id,
                        otp_trns_payment_index_number = a.otp_trns_payment_index_number,
                        otp_trns_payment_account_number = a.otp_trns_payment_account_number,
                        otp_trns_payment_key_id = a.otp_trns_payment_key_id,
                        otp_trns_payment_percentage = a.otp_trns_payment_percentage,
                        otp_trns_payment_amount = a.otp_trns_payment_amount
                    }).ToList().FirstOrDefault();
        }

        public OneTimePaymentDTO UpdateItem(OneTimePaymentDTO record)
        {
            return (from a in _context.otp_payment_update(record.otp_trns_payment_key_id, record.otp_trns_key_id, record.otp_trns_payment_index_number, record.otp_trns_payment_account_number, record.otp_trns_payment_percentage, record.otp_trns_payment_amount)
                    select new OneTimePaymentDTO
                    {
                        otp_trns_key_id = a.otp_trns_key_id,
                        otp_trns_payment_index_number = a.otp_trns_payment_index_number,
                        otp_trns_payment_account_number = a.otp_trns_payment_account_number,
                        otp_trns_payment_key_id = a.otp_trns_payment_key_id,
                        otp_trns_payment_percentage = a.otp_trns_payment_percentage,
                        otp_trns_payment_amount = a.otp_trns_payment_amount
                    }).ToList().FirstOrDefault();
        }
        public void DeleteItem(int one_time_payment_key)
        {
            _context.otp_payment_delete_all(one_time_payment_key);
         }

        /*
        employee_key = a.,
        account_key = a.account_key,
        approval_status_key = a.approval_status_key,
        comment = a.comment,
        created = a.created,
        created_by = a.created_by,
        current_position = a.current_position,
        current_position_key = a.current_position_key,
        department_description = a.department_description,
        department_number = a.department_number,
        dept_key = a.dept_key,
        effective_date = a.effective_date,
        employee_name = a.employee_name,
        factor = a.factor,
        fund = a.fund,
        hours_per_pay_period = a.hours_per_pay_period,
        index_key = a.index_key,
        job_change_reason = a.job_change_reason,
        job_change_reason_key = a.job_change_reason_key,
        job_change_reason_other = "<None>",
        job_status = a.job_status,
        modified = a.modified,
        modified_by = a.modified_by,
        payroll_key = a.payroll_key,
        percent = a.percent,
        personnel_date = a.personnel_date,
        position = a.position,
        position_key = a.position_key,
        rate = a.rate,
        salary = a.salary,
        suffix = a.suffix,
        supervisor_name = a.supervisor_name
        */
    }
}