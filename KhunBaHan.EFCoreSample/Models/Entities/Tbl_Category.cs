using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KhunBaHan.EFCoreSample.Models.Entities
{
    [Table("Category")]
    public class Tbl_Category
    {
        [Key]
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
