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
    using System.Collections.Generic;
    
    public partial class Audit
    {
        public int audit_key { get; set; }
        public string audit_data { get; set; }
        public string audit_action { get; set; }
        public string audit_user_uni_code { get; set; }
        public int audit_user_uni_key { get; set; }
        public string audit_data_element { get; set; }
    }
}