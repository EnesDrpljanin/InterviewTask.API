using System.ComponentModel.DataAnnotations;

namespace InterviewTask.Domain
{
    public class CompanyModel
    {
        public int Id { get; set; } 

        [Required]
        public string Name { get; set; }
    }
}
