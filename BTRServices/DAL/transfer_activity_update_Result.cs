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
    
    public partial class transfer_activity_update_Result
    {
        public int transfer_activity_key { get; set; }
        public int btr_key { get; set; }
        public int index_key { get; set; }
        public string index_description { get; set; }
        public string index_number_description { get; set; }
        public int account_key { get; set; }
        public string account_description { get; set; }
        public string account_number_description { get; set; }
        public decimal amount { get; set; }
        public string jv_doc_id { get; set; }
        public Nullable<bool> jv_complete { get; set; }
        public string create_jv_error_message { get; set; }
        public string complete_jv_status_message { get; set; }
        public Nullable<decimal> account_balance { get; set; }
        public int position_type_key { get; set; }
        public string position_type { get; set; }
        public Nullable<int> approval_status_key { get; set; }
        public System.DateTime created { get; set; }
        public int created_by { get; set; }
        public string created_uni_code { get; set; }
        public string created_email { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public int modified_by { get; set; }
        public string modified_uni_code { get; set; }
        public string modified_email { get; set; }
        public string approval_status_code { get; set; }
        public string approval_status_description { get; set; }
    }
}
