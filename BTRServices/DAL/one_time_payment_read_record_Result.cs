//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BTRServices.DAL
{
    using System;
    
    public partial class one_time_payment_read_record_Result
    {
        public int employee_key { get; set; }
        public string employee_name { get; set; }
        public int current_position_key { get; set; }
        public string current_position { get; set; }
        public int position_key { get; set; }
        public string position { get; set; }
        public string suffix { get; set; }
        public string job_status { get; set; }
        public Nullable<System.DateTime> effective_date { get; set; }
        public Nullable<int> job_change_reason_key { get; set; }
        public string job_change_reason { get; set; }
        public string job_change_reason_other { get; set; }
        public Nullable<System.DateTime> personnel_date { get; set; }
        public Nullable<decimal> salary { get; set; }
        public int rate { get; set; }
        public int hours_per_pay_period { get; set; }
        public int factor { get; set; }
        public int index_key { get; set; }
        public int account_key { get; set; }
        public string fund { get; set; }
        public Nullable<decimal> percent { get; set; }
        public System.DateTime created { get; set; }
        public int created_by { get; set; }
        public System.DateTime modified { get; set; }
        public int modified_by { get; set; }
        public string comment { get; set; }
        public string supervisor_name { get; set; }
        public Nullable<int> payroll_key { get; set; }
        public Nullable<int> dept_key { get; set; }
        public string department_number { get; set; }
        public string department_description { get; set; }
        public Nullable<int> approval_status_key { get; set; }
    }
}
