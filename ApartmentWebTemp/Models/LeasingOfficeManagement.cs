using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentWebTemp.Models
{
    /// <summary>
    /// Leasing office management information
    /// Landlord has direct access to all information
    /// </summary>
    public abstract class LeasingOfficeManagement
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }

    /// <summary>
    /// Tenant's unit information
    /// </summary>
    public class UnitLease : LeasingOfficeManagement
    {
        // The unit number being occupied
        public int UnitNumber { get; set;}

        // The floor number a unit is on
        public int UnitFloor { get; set; }

        // The monthly rent a tenant pays
        public int MonthlyRent { get; set; }

        // Number of bedroom & bathroom that a unit has
        public string UnitDescription { get; set; }

        // The starting lease date for a unit
        public DateTime LeaseStarting { get; set; }

        // The ending lease date for a unit
        public DateTime LeaseEnding { get; set; }
    }
}
