using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubSystemsTest.Models
{
    public class MembershipDetails
    {
        [Key]
        public int MemebershipID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = " Membership Type is required")]
        public string Type { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal AccountBalance { get; set; }

        [Required(ErrorMessage = "PersonID is required")]
        public int PersonID { get; set; }

        [ForeignKey("PersonID")]
        public virtual UserDetails UserDetails { get; set; }
    }
}
