
using System.ComponentModel.DataAnnotations;

namespace InterviewTask.Domain
{
    public class CountryModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
