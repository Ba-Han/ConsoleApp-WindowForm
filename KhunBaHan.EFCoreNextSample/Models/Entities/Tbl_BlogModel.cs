using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhunBaHan.EFCoreNextSample.Models.Entities
{
    [Table("Blog")]
    public class Tbl_BlogModel
    {
        [Key]
        public long BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogAuthor { get; set; }
        public string? BlogContent { get; set; }
    }
}
