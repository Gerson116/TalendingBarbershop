using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TalendingBarbershop.Data.Models
{
    public partial class TblOrders
    {
        public TblOrders()
        {
            TblOrderDetails = new HashSet<TblOrderDetails>();
        }

        public int Id { get; set; }
        public int? CreatedAt { get; set; }
        public bool? IsPaid { get; set; }
        public int? PaidTypeId { get; set; }

        public virtual TblPaidTypes PaidType { get; set; }
        public virtual ICollection<TblOrderDetails> TblOrderDetails { get; set; }
    }
}
