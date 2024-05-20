using System.ComponentModel.DataAnnotations;

namespace KhunBaHan.EFCoreSample.Models.Entities
{
    public class CategoryModel
    {
        [Key]
        public long? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public bool? IsActive { get; set; }
    }
}
