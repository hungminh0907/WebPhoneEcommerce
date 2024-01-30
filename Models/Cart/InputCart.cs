using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebPhoneEcommerce.Models.Cart
{
    public class InputCart
    {

        [StringLength(20)]
        public string? ProductId { get; set; }
        //public string? ProductName { get; set; }


        [Column(TypeName = "numeric(28, 8)")]
        public int? Quantity { get; set; }

        [Column(TypeName = "numeric(28, 8)")]
        public int? UnitPrice { get; set; }

        public string? ProductName { get; set; }

        public int Sum => (int)(UnitPrice * Quantity);

        public IFormFileCollection Urlimg { get; set; }
    }
}
