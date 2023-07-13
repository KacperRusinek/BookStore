using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class RoleDto
    {
        [Required]
        public string Name { get; set; }
    }
}
