using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.netCore_project.Models
{
    public class items
    {
        [Key]
       public int Id { get; set; }

        [Required]
       public string Name { get; set; }
        [Required]
        [DisplayName("السعر")]
        [Range(20,1000,ErrorMessage =" السعر خارج النطاق غير مقبول")]
        public decimal Price { get; set; }

        public DateTime CeratedDate { get; set; } = DateTime.Now;

        [Required]
        [DisplayName("التصنيف")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public string? imagePath {  get; set; }

        [NotMapped]
        public IFormFile clintfile { get; set; }


        public Category? Category { get; set; }

    }
}
