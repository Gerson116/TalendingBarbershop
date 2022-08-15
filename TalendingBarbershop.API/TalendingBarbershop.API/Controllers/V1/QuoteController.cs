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

        [HttpGet("list-quote")]
        public async Task<IActionResult> ListQuote()
        {
            _requestResult = await _quote.ListQuote();
            if (!_requestResult.Response)
            {
                return BadRequest(_requestResult);
            }
            return Ok(_requestResult);
        }

        [HttpGet("get-quote/{quoteId}")]
        public async Task<IActionResult> GetQuote(int quoteId)
        {
            _requestResult = await _quote.GetQuotesAsync(quoteId);
            if (!_requestResult.Response)
            {
                return BadRequest(_requestResult);
            }
            return Ok(_requestResult);
        }

        [HttpPost("new-quote")]
        public async Task<ActionResult<RequestResult>> AddQuote([FromBody] TblQuotesDTO quote)
        {
            _requestResult = await _quote.AddQuote(quote);
            if (!_requestResult.Response)
            {
                return BadRequest(_requestResult);
            }
            return Ok(_requestResult);
        }

        [HttpPut("edit-quote")]
        public async Task<ActionResult<RequestResult>> EditUser([FromBody]TblQuotesDTO quote)
        {
            _requestResult = await _quote.EditQuote(quote);
            if (!_requestResult.Response)
            {
                return BadRequest(_requestResult);
            }
            return Ok(_requestResult);
        }

        [HttpDelete("delete-quote/{quoteId}")]
        public async Task<ActionResult<RequestResult>> DeleteUser(int quoteId)
        {
            _requestResult = await _quote.DeleteQuote(quoteId);
            if (!_requestResult.Response)
            {
                return BadRequest(_requestResult);
            }
            return Ok(_requestResult);
        }
    }
}
