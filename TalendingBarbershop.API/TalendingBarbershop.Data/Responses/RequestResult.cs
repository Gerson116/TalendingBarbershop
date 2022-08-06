using System;
using System.Collections.Generic;
using System.Text;

namespace TalendingBarbershop.Data.Responses
{
    public class RequestResult
    {
        public string Message { get; set; }
        public dynamic Data { get; set; }
        public bool Response { get; set; }
    }
}
