namespace KhunBaHan.SampleRestApi.Models
{
    public class CategoryModel
    {
        public long? CategoryId { get; set; }
        public  string CategoryName { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
    }
}
