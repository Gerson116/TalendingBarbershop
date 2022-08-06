using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TalendingBarbershop.Data.Models
{
    public partial class TblPaidTypes
    {
        public TblPaidTypes()
        {
            TblOrders = new HashSet<TblOrders>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TblOrders> TblOrders { get; set; }
    }
}
