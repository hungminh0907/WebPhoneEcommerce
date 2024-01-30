using System.ComponentModel.DataAnnotations;

namespace WebPhoneEcommerce.Models.Curd
{
    public class OutputCurd
    {
        public string Id { get; set; } = null!;

        [StringLength(20)]
        public string? ProductId { get; set; }

        public string? Description { get; set; }
        [StringLength(100)]
        public string? ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        public string? Urlimg { get; set; }
    }
}

