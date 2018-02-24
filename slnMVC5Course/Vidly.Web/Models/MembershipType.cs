using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [Required]
        public short SignUpFree { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set;}
        [StringLength(255)]
        public string Name { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 0;
    }
}