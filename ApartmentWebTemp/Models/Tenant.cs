using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentWebTemp.Models
{
    /// <summary>
    /// Generic tenant information that Landlord can add to database
    /// </summary>
    public abstract class Tenant
    {
        [Key]
        public int TenantId { get; set; }

        public string TenantName { get; set; }

        public string TenantPhoneNumber { get; set; }

        public int UnitNumber { get; set; }

        public int RentAmount { get; set; }
    }
}
