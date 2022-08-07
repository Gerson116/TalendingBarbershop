using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TalendingBarbershop.Data.DTOs;
using TalendingBarbershop.Data.Models;
using TalendingBarbershop.Data.Responses;

namespace TalendingBarbershop.Services.Orders
{
    public interface IOrders
    {
        Task<TblOrders> Add(TblOrderDTO orderDTO);
        Task<List<TblOrders>> GetAll();
        Task<TblOrders> Get(int id);
   }
}
