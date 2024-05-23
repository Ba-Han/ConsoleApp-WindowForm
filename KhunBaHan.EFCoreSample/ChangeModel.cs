using KhunBaHan.EFCoreSample.Models.CategoryRequestModel;
using KhunBaHan.EFCoreSample.Models.Entities;

namespace KhunBaHan.EFCoreSample
{
    public static class ChangeModel
    {
        public static Tbl_Category Change(this CategoryRequestModel requestModel)
        {
            return new Tbl_Category()
            {
                CategoryName = requestModel.CategoryName,
                IsActive = true
            };
        }
    }
}
