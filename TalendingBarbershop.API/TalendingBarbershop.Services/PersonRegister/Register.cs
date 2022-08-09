using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TalendingBarbershop.Data.DTOs;
using TalendingBarbershop.Data.Models;
using TalendingBarbershop.Data.Responses;
using Microsoft.EntityFrameworkCore;
using TalendingBarbershop.Data.Security;

namespace TalendingBarbershop.Services.PersonRegister
{
    public class Register : IRegister
    {
        private IMapper _mapper;
        private RequestResult _requestResult;
        private TblUsers _user;
        private DbTalendigBarbershopContext _dbContext;
        private Encrypt _encrypt;

        public Register(IMapper mapper)
        {
            //...
            _mapper = mapper;
            _requestResult = new RequestResult();
            _user = new TblUsers();
            _dbContext = new DbTalendigBarbershopContext();
            _encrypt = new Encrypt();
        }
        public async Task<RequestResult> AddPerson(TblUsersDTO person)
        {
            try
            {
                _user = _mapper.Map<TblUsers>(person);
                _user.Password = _encrypt.EncriptingPassword(person.Password);
                _user.CreatedAt = DateTime.Now;
                await _dbContext.TblUsers.AddAsync(_user);
                await _dbContext.SaveChangesAsync();

                _requestResult.Message = "Exito";
                _requestResult.Data = "El usuario fue agregado con exito.";
                _requestResult.Response = true;
            }
            catch (Exception e)
            {
                _requestResult.Message = e.Message;
                _requestResult.Data = null;
                _requestResult.Response = false;
            }
            return _requestResult;
        }

        public async Task<RequestResult> EditPerson(TblUsersDTO person)
        {
            try
            {
                _user = _mapper.Map<TblUsers>(person);
                _user.UpdatedAt = DateTime.Now;
                _dbContext.Entry(_user).State = EntityState.Modified;
                //await _dbContext.SaveChangesAsync();

                _requestResult.Message = "Exito";
                _requestResult.Data = "Datos modficado con exito.";
                _requestResult.Response = true;
            }
            catch (Exception e)
            {
                _requestResult.Message = e.Message;
                _requestResult.Data = null;
                _requestResult.Response = false;
            }
            return _requestResult;
        }
    }
}
