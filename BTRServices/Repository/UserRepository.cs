using BTRServices.DAL;
using BTRServices.Model;
using BTRServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BTRServices.Repository
{
    public class UserRepository : Repository<UserDTO>
    {
        public UserRepository(BtrDbContext context) : base(context)
        {
        }

        internal UserDTO ByUni(string uni)
        {
            return (from a in _context.users
                    where a.uni_code == uni
                    select new UserDTO
                    {
                        uni_code = a.uni_code,
                        uni_email = a.uni_email,
                        uni_first_name = a.uni_first_name,
                        uni_last_name = a.uni_last_name,
                        uni_name = a.uni_name,
                        uni_key = a.uni_key

                    }).FirstOrDefault();
       }

        internal UserDTO ByEmail(string email)
        {
            return (from a in _context.users
                    where a.uni_code == email
                    select new UserDTO
                    {
                        uni_code = a.uni_code,
                        uni_email = a.uni_email,
                        uni_first_name = a.uni_first_name,
                        uni_last_name = a.uni_last_name,
                        uni_name = a.uni_name,
                        uni_key = a.uni_key
                    }).FirstOrDefault();
        }

    }
}