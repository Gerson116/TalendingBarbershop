using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TalendingBarbershop.Data.Models
{
    public partial class TblOrderDetails
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public int? OrderId { get; set; }

        public virtual TblOrders Order { get; set; }
        public TblServices Service { get; set; }
    }
}
