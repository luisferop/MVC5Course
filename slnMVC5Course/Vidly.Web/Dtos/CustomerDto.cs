using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}