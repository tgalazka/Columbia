//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BTRServices.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class BtrDTO
    {
        public int btr_key { get; set; }
        public Guid btr_guid { get; set; }
        public int requestor_uni_key { get; set; }
        public string budget_type { get; set; }
        public string life_cycle { get; set; }
        public int life_cycle_key { get; set; }
        public string requestor_uni_code { get; set; }
        public string explanation { get; set; }

        public Nullable<decimal> total_amount { get; set; }
        public bool priority_flag { get; set; }
        public DateTime created { get;  set; }
        public int modified_by { get;  set; }
        public int created_by { get;  set; }
        public string created_by_name { get;  set; }
        public string title { get; set; }
        public string transfer_type { get;  set; }
        public int transfer_type_key { get;  set; }
        public DateTime modified { get;  set; }
        public string internal_state { get;  set; }
        public int internal_state_key { get;  set; }
        public string modified_by_name { get;  set; }
        public int budget_type_key { get;  set; }
        public string jv_doc_id { get; set; }
        public string jv_status_code { get; set; }
    }
}
