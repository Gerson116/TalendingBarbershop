using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TalendingBarbershop.Data.DTOs;
using TalendingBarbershop.Data.Models;
using TalendingBarbershop.Data.Responses;

namespace TalendingBarbershop.Services.Quotes
{
    public interface IQuotes
    {
        Task<TblQuotes> GetQuotesAsync(int id);
        Task<RequestResult> AddQuote(TblQuotesDTO quote);
        Task<RequestResult> EditQuote(TblQuotesDTO quote);
        Task<RequestResult> DeleteQuote(int id);
    }
}
