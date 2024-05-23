using KhunBaHan.EFCoreNextSample.Models.BlogRequestModel;
using KhunBaHan.EFCoreNextSample.Models.Entities;

namespace KhunBaHan.EFCoreNextSample
{
    public static class ChangeModel
    {
        public static Tbl_BlogModel Change(this BlogRequestModel requestModel)
        {
            return new Tbl_BlogModel()
            {
                BlogTitle = requestModel.BlogTitle,
                BlogAuthor = requestModel.BlogAuthor,
                BlogContent = requestModel.BlogContent
            };
        }
    }
}
