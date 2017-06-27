using BTRServices.DAL;
using BTRServices.Models.Banner;
using System.Linq;

namespace BTRServices.Repository.Banner
{
    internal class EmployeeRepository : HrRepository<EmployeeDTO>
    {
        private HrDbContext dbCxt;

        public EmployeeRepository(HrDbContext context) : base(context)
        {
        }

        public EmployeeDTO GetItem(string uni)
        {
            return (from a in _context.sp_GET_Employee_By_Uni(uni)
                    select new EmployeeDTO
                    {
                        first_name = a.first_name,
                        last_name = a.last_name,
                        position_description = a.position_description,
                        position_number = a.position_number,
                        position_suffix = a.position_suffix,
                        uni = a.uni
                    }).FirstOrDefault();
        }
    }
}