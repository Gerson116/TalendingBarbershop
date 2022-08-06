using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TalendingBarbershop.Data.Models
{
    public partial class TblUsers
    {
        public TblUsers()
        {
            TblQuotes = new HashSet<TblQuotes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual TblRoles Role { get; set; }
        public virtual ICollection<TblQuotes> TblQuotes { get; set; }
    }
}
