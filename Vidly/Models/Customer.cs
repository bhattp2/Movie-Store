using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id{ get; set; }

        [Required]
        [StringLength(255)]
        public String Name{ get; set; }

        [Display(Name ="Date of Birth")]
        [Min18IfAMember]
        public Nullable<DateTime> BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType membershipType { get; set; }

        [Display(Name ="Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}