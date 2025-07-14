using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppDbFirstApproach.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter product name!")]
        public string ProductName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter product price!")]
        public double Price { get; set; }
        public string size { get; set; } = string.Empty;
        public string color { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter product stock count!")]
        public int StockCount { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter product status!")]
        public string Status { get; set; } = string.Empty;
        public Boolean IsNew { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public List<ProductImg> Images { get; set; }
    }
}
