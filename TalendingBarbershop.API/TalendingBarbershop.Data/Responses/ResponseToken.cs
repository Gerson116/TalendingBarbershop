using System;
using System.Collections.Generic;
using System.Text;

namespace TalendingBarbershop.Data.Responses
{
    public class ResponseToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int ? RolPerson { get; set; }
    }
}
