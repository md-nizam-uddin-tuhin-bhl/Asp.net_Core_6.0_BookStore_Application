using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Domain
{
    public class Author
    {
        
        public int Id { get; set; }
        [Required]
        public string AuthorName { get; set; }
    }
}
