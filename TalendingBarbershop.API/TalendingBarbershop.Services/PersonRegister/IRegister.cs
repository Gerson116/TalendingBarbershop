using System;
using System.Collections.Generic;
using System.Text;
using TalendingBarbershop.Data.DTOs;
using TalendingBarbershop.Data.Responses;

namespace TalendingBarbershop.Services.PersonRegister
{
    public interface IRegister
    {
        RequestResult AddPerson(TblUsersDTO person);
        RequestResult EditPerson(TblUsersDTO person);
    }
}
