using System.ComponentModel.DataAnnotations;

namespace ClubSystemsTest.Models
{
    public class UserDetails
    {
        [Key]
        public int PersonID { get; set; }

        [Required(ErrorMessage = "First Name Type is required")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string Forename { get; set; }

        [Required(ErrorMessage = "Last Name Type is required")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string EmailAddress { get; set; }

        public List<MembershipDetails> Memberships { get; set; }
    }
}
