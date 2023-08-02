using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Domain
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
