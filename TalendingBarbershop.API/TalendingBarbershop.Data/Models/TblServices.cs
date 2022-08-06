using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TalendingBarbershop.Data.Models
{
    public partial class TblServices
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
}
