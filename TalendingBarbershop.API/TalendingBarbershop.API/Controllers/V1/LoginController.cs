using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TalendingBarbershop.Data.DTOs;
using TalendingBarbershop.Data.Responses;
using TalendingBarbershop.Services.Login;

namespace TalendingBarbershop.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILogin _login;
        private ResponseToken _responseToken;
        private RequestResult _requestResult;
        public LoginController(ILogin login)
        {
            //...
            _login = login;
            _responseToken = new ResponseToken();
            _requestResult = new RequestResult();
        }
        ///<summary>
        /// Aquí van los comentarios
        ///</summary>
        [HttpPost("iniciar-sesion")]
        public ActionResult<RequestResult> LogIn([FromBody] LoginPerson login)
        {
            //... This method is use for valid user and access.
            _responseToken = _login.BuilderToken(login);
            if(_responseToken.Token == string.Empty)
            {
                _requestResult.Message = "Ocurrio un error";
                _requestResult.Data = "El favor validar los datos con los que intenta iniciar sesion";
                _requestResult.Response = false;
                return BadRequest(_requestResult);
            }

            _requestResult.Message = "Exito";
            _requestResult.Data = _responseToken;
            _requestResult.Response = true;
            return Ok(_requestResult);
        }
    }
}
