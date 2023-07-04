using System.ComponentModel.DataAnnotations;

namespace BookStore.Data
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
