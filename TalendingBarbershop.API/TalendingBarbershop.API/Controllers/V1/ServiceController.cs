using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TalendingBarbershop.Data.DTOs;
using TalendingBarbershop.Data.Models;
using TalendingBarbershop.Data.Responses;
using TalendingBarbershop.Services.Orders;
using TalendingBarbershop.Services.ServicesOffered;

namespace TalendingBarbershop.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private IMapper _mapper;
        public ServiceController(IMapper mapper)
        {
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<ActionResult<RequestResult>> Get()
        {
            var servicesOffered = new ServicesOffered(_mapper);
            var services = await servicesOffered.GetAll();
            return new RequestResult
            {
                Message = "Ok",
                Data = services,
                Response = true
            };


        }

        [HttpPut("{id}")]
        public async Task<dynamic> Put(int id, [FromBody] TblServicesDTO tblServicesDTO)
        {
            var servicesOffered = new ServicesOffered(_mapper);
            var service = await servicesOffered.Edit(id, tblServicesDTO);
            if (service == null)
            {
                return NotFound(new RequestResult
                {
                    Message = "Not Found",
                    Data = null,
                    Response = false
                });
            }

            return new RequestResult
            {
                Message = "Modified",
                Data = service,
                Response = true
            };
        }

        [HttpPost]
        public async Task<ActionResult<RequestResult>> Post([FromBody] TblServicesDTO tblServicesDTO)
        {
            var servicesOffered = new ServicesOffered(_mapper);
            var service = await servicesOffered.Add(tblServicesDTO);
            return CreatedAtAction("Get", new RequestResult
            {
                Message = "Created",
                Data = service,
                Response = true
            });

        }
    }
}
