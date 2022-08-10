using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TalendingBarbershop.Data.DTOs;
using TalendingBarbershop.Data.Responses;
using TalendingBarbershop.Services.Quotes;

namespace TalendingBarbershop.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : Controller
    {
        private IQuotes _quote;
        private RequestResult _requestResult;

        [HttpPost("new-quote")]
        public async Task<ActionResult<RequestResult>> AddQuote([FromBody] TblQuotesDTO quote)
        {
            _requestResult = await _quote.AddQuote(quote);
            return _requestResult;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("edit-quote")]
        public async Task<ActionResult<RequestResult>> EditUser([FromBody]int id, TblQuotesDTO quote)
        {
            _requestResult = await _quote.EditQuote(id, quote);
            return _requestResult;
        }
    }
}
