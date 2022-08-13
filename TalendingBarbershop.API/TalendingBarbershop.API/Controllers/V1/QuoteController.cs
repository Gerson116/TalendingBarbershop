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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class QuoteController : ControllerBase
    {
        private IQuotes _quote;
        private RequestResult _requestResult;
        public QuoteController(IQuotes quotes)
        {
            //...
            _quote = quotes;
        }

        [HttpPost("new-quote")]
        public async Task<ActionResult<RequestResult>> AddQuote([FromBody] TblQuotesDTO quote)
        {
            _requestResult = await _quote.AddQuote(quote);
            return _requestResult;
        }

        [HttpPut("edit-quote")]
        public async Task<ActionResult<RequestResult>> EditUser([FromBody]TblQuotesDTO quote)
        {
            _requestResult = await _quote.EditQuote(quote);
            return _requestResult;
        }
    }
}
