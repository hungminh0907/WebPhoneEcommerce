using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebPhoneEcommerce.Models.Curd
{
    public class ResultApi
    {
        [StringLength(100)]
        public string Id { get; set; } = null!;

        [StringLength(20)]
        public string? ProductId { get; set; }

        [StringLength(100)]
        public string? ProductName { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        [Column(TypeName = "numeric(28, 8)")]
        public decimal? UnitPrice { get; set; }

        [StringLength(255)]
        public string? Filter { get; set; }
        //public List<ResultApiImg> Urlimg { get; set; }
        public string Urlimg { get; set; }
    }

    public class ResultApiImg
    {
        public string Urlimg { get; set; }

        public int Postion { get; set; }
    }
}
