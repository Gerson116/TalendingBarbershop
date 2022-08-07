using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TalendingBarbershop.Data.DTOs;
using TalendingBarbershop.Data.Models;
using TalendingBarbershop.Data.Responses;

namespace TalendingBarbershop.Services.ServicesOffered
{
    public interface IServicesOffered
    {
        Task<TblServices> Add(TblServicesDTO tblServicesDTO);
        Task<TblServices> Edit(int id, TblServicesDTO tblServicesDTO);
        Task<List<TblServices>> GetAll();
    }
}
