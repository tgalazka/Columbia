namespace BTRServices.Models
{
    using System;
    using System.Collections.Generic;
    
    public class IndexDTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        public int index_key { get; set; }
        public string index_coas_code { get; set; }
        public string index_fund_code { get; set; }
        public string index_orgn_code { get; set; }
        public string index_prog_code { get; set; }
        public string index_acct_code { get; set; }
        public string index_actv_code { get; set; }
        public string index_locn_code { get; set; }
        public string index_number { get; set; }
        public string index_description { get; set; }
        public string index_number_description { get; set; }
        public string index_status { get; set; }
    }
}
