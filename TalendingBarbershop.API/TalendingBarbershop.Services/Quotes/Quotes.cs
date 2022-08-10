using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TalendingBarbershop.Data.DTOs;
using TalendingBarbershop.Data.Models;
using TalendingBarbershop.Data.Responses;
using TalendingBarbershop.Data.Security;

namespace TalendingBarbershop.Services.Quotes
{
    public class Quotes : IQuotes
    {
        private IMapper _mapper;
        private RequestResult _requestResult;
        private TblQuotes _quotes;
        private DbTalendigBarbershopContext _dbContext;

        public Quotes(IMapper mapper)
        {
            _mapper = mapper;
            _requestResult = new RequestResult();
            _dbContext = new DbTalendigBarbershopContext();
            _quotes = new TblQuotes();
        }

        public async Task<RequestResult> AddQuote(TblQuotesDTO quote)
        {
            try 
            { 
                _quotes = _mapper.Map<TblQuotes>(quote);
                await _dbContext.TblQuotes.AddAsync(_quotes);
                await _dbContext.SaveChangesAsync();

                _requestResult.Message = "Exito";
                _requestResult.Data = "La cita fue agregado con exito.";
                _requestResult.Response = true;

            } catch(Exception ex) 
            {
                _requestResult.Message = ex.Message;
                _requestResult.Data = null;
                _requestResult.Response = false;
            }

            return _requestResult;
        }

        public async Task<RequestResult> EditQuote(int id,TblQuotesDTO quote)
        {
            
            _quotes = _mapper.Map<TblQuotes>(quote);
            _quotes.Id = id;
            _dbContext.Entry(_quotes).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
                _requestResult.Message = "Exito";
                _requestResult.Data = "La cita fue modificada con exito.";
                _requestResult.Response = true;
            }
            catch (Exception ex)
            {
                _requestResult.Message = ex.Message;
                _requestResult.Data = null;
                _requestResult.Response = false;
            }

            return _requestResult;
        }

       public Task<RequestResult> DeleteQuote(int id)
       {
            try
            {
                if ()
                {

                }
            } catch(Exception ex)
            {

            }
            return null;
       }
    }
}
