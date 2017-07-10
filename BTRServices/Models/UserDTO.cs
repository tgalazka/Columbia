using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTRServices.Models
{
    public class UserDTO
    {
        public int uni_key { get; set; }
        public string uni_name { get; set; }
        public string uni_first_name { get; set; }
        public string uni_last_name { get; set; }
        public string uni_email { get; set; }
        public string uni_code { get; set; }

    }
}