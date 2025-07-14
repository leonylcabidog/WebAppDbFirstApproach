using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppDbFirstApproach.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public int CostumerId { get; set; }
        public string OrderInstruction { get; set; } = string.Empty;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Status { get; set; }
    }
}
