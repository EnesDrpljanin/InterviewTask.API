using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace InterviewTask.Data.Entities
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual Company Company { get; set; }

        public virtual Country Country { get; set; }
    }
}
