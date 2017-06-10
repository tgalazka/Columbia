using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTRServices.Models
{
    public class Error
    {

        public Error(int code, string message, string area)
        {
            Code = code;
            Message = message;
            Area = area; 
        }
        public int Code { get; set; } 
        public string Message { get; set; }
        public string Area { get; set; }
        public override string ToString()
        {
            string sError = string.Format("code:{0},message:{1},area:{2}", new string[] { Code.ToString(), Message, Area });
            return "{error:{" + sError + "}}";
        }
    }
}