﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTRServices.Models.Banner
{
    public class EmployeeDTO
    {
        public int employee_key_id { get; set; }
        public string uni { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string position_number { get; set; }
        public string position_description { get; set; }
        public string position_suffix { get; set; }
        public string supervisor_uni { get; set; }
        public string supervisor { get; set; }
    }
}