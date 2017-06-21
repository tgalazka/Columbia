using BTRServices.DAL;
using BTRServices.Model;
using BTRServices.Repository;
using System.Linq;

namespace BTRServices.Controllers
{
    internal class OneTimePaymentRepository : Repository<OneTimePaymentDTO>
    {
        private BtrDbContext dbCxt;

        public OneTimePaymentRepository(BtrDbContext context) : base(context)
        {
        }
        public bool CreateItem(OneTimePaymentDTO record)
        {
            return true;
        }

        public OneTimePaymentDTO GetItem(int one_time_payment_key)
        {
            return (from a in _context.one_time_payment_read_record(one_time_payment_key)
                    select new OneTimePaymentDTO
                    {
                        employee_key = a.employee_key,
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
                    }).FirstOrDefault();
        }
        public bool UpdateItem(OneTimePaymentDTO record)
        {
            return true;
        }
        public bool DeleteItem(int one_time_payment_key)
        {
            return true;
        }
    }
}