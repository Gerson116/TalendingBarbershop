using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TalendingBarbershop.Data.DTOs
{
    public class TblOrderDTO
    {
        public int Id { get; set; }
        public int CreatedAt { get; set; }
        public bool IsPaid { get; set; }
        [Required]
        public int PaidTypeId { get; set; }
    }
}
