using System;
using System.Collections.Generic;
using System.Text;
using TalendingBarbershop.Data.DTOs;
using TalendingBarbershop.Data.Responses;

namespace TalendingBarbershop.Services.Login
{
    public interface ILogin
    {
        ResponseToken BuilderToken(LoginPerson loginPerson);
    }
}
