using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Identification Number")]
        [MaxLength(50)]
        [Required]
        public string IdentificationNumber { get; set; }


        public string FullName
        {
            get { return $@"{Name} {LastName}"; }
        }

    }
}
