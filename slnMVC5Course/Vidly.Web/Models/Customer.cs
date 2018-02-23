using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }
        [Required]
        [Display(Name ="Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name ="Date of Birth:")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}