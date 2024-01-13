namespace Exam1.Web.Areas.Admin.Models
{
    public class ProductSearchModel
    {
        public string ProductName { get; set; }
        public uint ProductPriceFrom { get; set; } = 0;
        public uint ProductPriceTo { get; set; } = 0;
    }
}
