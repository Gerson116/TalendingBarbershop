using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalendingBarbershop.Data.DTOs;
using TalendingBarbershop.Data.Responses;
using TalendingBarbershop.Services.PersonRegister;

namespace TalendingBarbershop.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RegisterPersonController : ControllerBase
    {
        private IRegister _register;
        private RequestResult _requestResult;

        public RegisterPersonController(IRegister register)
        {
            //...
            _register = register;
            _requestResult = new RequestResult();
        }

        [HttpPost("new-user")]
        public async Task<ActionResult<RequestResult>> AddUser([FromBody] TblUsersDTO user)
        {
            _requestResult = await _register.AddPerson(user);
            return _requestResult;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("edit-user")]
        public async Task<ActionResult<RequestResult>> EditUser([FromBody] TblUsersDTO user)
        {
            _requestResult = await _register.EditPerson(user);
            return _requestResult;
        }
    }
}
