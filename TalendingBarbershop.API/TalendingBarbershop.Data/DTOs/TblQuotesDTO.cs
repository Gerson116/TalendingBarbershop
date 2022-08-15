using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TalendingBarbershop.Data.DTOs
{
    public class TblQuotesDTO
    {
        public int Id { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
