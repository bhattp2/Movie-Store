using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }

     //   [Min18IfAMember]
        public Nullable<DateTime> BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipTypeDto membershipType { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}