using System.ComponentModel.DataAnnotations;

namespace asp.netCore_project.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public ICollection<items>? items { get; set; }
    }
}
