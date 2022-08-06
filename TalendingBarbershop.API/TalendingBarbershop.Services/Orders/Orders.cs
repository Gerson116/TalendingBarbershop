using System;
using System.Collections.Generic;
using System.Text;
using TalendingBarbershop.Data.Responses;

namespace TalendingBarbershop.Services.Orders
{
    public class Orders
    {
        public static async RequestResult Get() { 
            RequestResult result = new RequestResult();
            result.Data = new Dictionary<string, object>();
            result.Response = true;
            result.Message = "Lista completa";

            return result;
        }
    }
}
