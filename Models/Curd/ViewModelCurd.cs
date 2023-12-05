namespace WebPhoneEcommerce.Models.Curd
{
    public class ViewModelCurd
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; }

        public List<ResultApiImg> Urlimg { get; set; }
    }
}
