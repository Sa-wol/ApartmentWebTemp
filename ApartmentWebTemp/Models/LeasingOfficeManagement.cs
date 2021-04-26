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
        // Auto-increment unique id number
        [Key]
        public int UserId { get; set; }

        // User's first name
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        // User's last name
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        // User's phone number
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    /// <summary>
    /// Tenant's unit information
    /// </summary>
    public class UnitLease : LeasingOfficeManagement
    {
        // The unit number being occupied
        [Display(Name = "Unit Number")]
        public int UnitNumber { get; set;}

        // The floor number a unit is on
        [Display(Name = "Unit Floor")]
        public int UnitFloor { get; set; }

        // The monthly rent a tenant pays
        [Display(Name = "Monthly Rent")]
        public int MonthlyRent { get; set; }

        // Number of bedroom & bathroom that a unit has
        [Display(Name = "Unit Description")]
        public string UnitDescription { get; set; }

        // The starting lease date for a unit
        [Display(Name = "Lease Starting Date")]
        public DateTime LeaseStarting { get; set; }

        // The ending lease date for a unit
        [Display(Name = "Lease Ending Date")]
        public DateTime LeaseEnding { get; set; }
    }

    /// <summary>
    /// Creates new staff for record keeping
    /// </summary>
    public class Staff : LeasingOfficeManagement
    {
        // Unique ID related to Staff
        public int StaffId { get; set; }

        // Staff role within apartment complex
        [Display(Name = "Staff Role")]
        public string StaffRole { get; set; }

        // The starting employment date for staff
        [Display(Name = "Employment Starting Date")]
        public DateTime EmploymentStartDate { get; set; }

        // The ending employment date for staff
        [Display(Name = "Employment Ending Date")]
        public DateTime EmployemntEndDate { get; set; }

        // The wage staff is given bi-weekly
        [Display(Name = "Staff Wage")]
        public decimal StaffWage { get; set; }
    }
}