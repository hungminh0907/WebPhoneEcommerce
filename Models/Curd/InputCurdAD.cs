namespace WebPhoneEcommerce.Models.Curd
{
    public class InputCurdAD
    {
        //[Required(ErrorMessage = "Không được phép để trống!")]
        public string ProductId { get; set; }
        //[Required(ErrorMessage = "Không được phép để trống!")]
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public string? UnitPrice { get; set; }
        public IFormFileCollection Images { get; set; }
    }
}
