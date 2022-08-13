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

        public async Task<TblOrders> Add(TblOrderDTO orderDTO, List<int> servicesIds)
        {
            _orders = _mapper.Map<TblOrders>(orderDTO);
            _orders.CreatedAt = UnixTimeStamp.Now();
            _orders.IsPaid = false;
            _dbContext.TblOrders.Add(_orders);
            await _dbContext.SaveChangesAsync();
            foreach(var serviceId in servicesIds)
            {
                var orderDetail = new TblOrderDetails
                {
                    ServiceId = serviceId,
                    OrderId = _orders.Id
                };
                _dbContext.TblOrderDetails.Add(orderDetail);
            }
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Set<TblOrders>()
                .AsQueryable()
                .Include(x => x.PaidType)
                .Include(x => x.TblOrderDetails)
                .ThenInclude(x => x.Service)
                .FirstAsync(x => x.Id == _orders.Id);
        }
        public async Task<List<TblOrders>> GetAll()
        { 
             return await _dbContext.Set<TblOrders>()
               .AsQueryable()
               .Include(x => x.PaidType)
               .Include(x => x.TblOrderDetails)
                .ThenInclude(x => x.Service)
               .ToListAsync();
        }
        public async Task<TblOrders> Get(int id)
        {
            return await _dbContext.Set<TblOrders>()
                .AsQueryable()
                .Include(x=>x.PaidType)
                .Include(x => x.TblOrderDetails)
                .ThenInclude(x => x.Service)
                .FirstAsync(x => x.Id == id);
        }
    }
}
