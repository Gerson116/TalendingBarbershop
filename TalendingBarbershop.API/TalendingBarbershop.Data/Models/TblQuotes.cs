using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TalendingBarbershop.Data.Models
{
    public partial class TblQuotes
    {
        public int Id { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public int UserId { get; set; }

        public virtual TblUsers User { get; set; }
    }
}
