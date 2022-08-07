using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TalendingBarbershop.Data.DTOs;
using TalendingBarbershop.Data.Models;
using TalendingBarbershop.Data.Responses;
using TalendingBarbershop.Services.Utils;

namespace TalendingBarbershop.Services.Orders
{
    public class Orders : IOrders
    {
        private DbTalendigBarbershopContext _dbContext;
        private IMapper _mapper;
        private TblOrders _orders;
        public Orders(IMapper mapper)
        {
            _dbContext = new DbTalendigBarbershopContext();
            _mapper = mapper;
        }

        public async Task<TblOrders> Add(TblOrderDTO orderDTO)
        {
            _orders = _mapper.Map<TblOrders>(orderDTO);
            _orders.CreatedAt = UnixTimeStamp.Now();
            _orders.IsPaid = false;
            _orders.PaidType = await _dbContext.TblPaidTypes.FindAsync(_orders.PaidTypeId);
            _dbContext.TblOrders.Add(_orders);
            await _dbContext.SaveChangesAsync();
            return _orders;
        }
        public async Task<List<TblOrders>> GetAll()
        { 
             return await _dbContext.Set<TblOrders>()
               .AsQueryable()
               .Include(x => x.PaidType)
               .ToListAsync();
        }
        public async Task<TblOrders> Get(int id)
        {
            return await _dbContext.Set<TblOrders>()
                .AsQueryable()
                .Include(x=>x.PaidType)
                .FirstAsync(x => x.Id == id);
        }
    }
}
