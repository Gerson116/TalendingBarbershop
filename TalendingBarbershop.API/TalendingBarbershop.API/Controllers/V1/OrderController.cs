using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TalendingBarbershop.Data.DTOs;
using TalendingBarbershop.Data.Responses;
using TalendingBarbershop.Services.Orders;

namespace TalendingBarbershop.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IMapper _mapper;
        public OrderController(IMapper mapper)
        {
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<ActionResult<RequestResult>> Get()
        {
            var orderServices = new Orders(_mapper);
            var orders = await orderServices.GetAll();
            return new RequestResult
            {
                Message = "Ok",
                Data = orders,
                Response = true
            };


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RequestResult>> Get(int id)
        {
            var orderServices = new Orders(_mapper);
            var order = await orderServices.Get(id);

            if (order == null)
            {
                return NotFound( new RequestResult
                {
                    Message = "Not Found",
                    Data = null,
                    Response = false
                });
            }

            return new RequestResult
            {
                Message = "Ok",
                Data = order,
                Response = true
            };
        }

        [HttpPost]
        public async Task<ActionResult<RequestResult>> Post([FromBody] TblOrderDTO orderDTO)
        {
            var orderServices = new Orders(_mapper);
            var order = await orderServices.Add(orderDTO, orderDTO.ServicesIds);
            return new RequestResult
            {
                Message = "Created",
                Data = order,
                Response = true
            };

        }
    }
}
