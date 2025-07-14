using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppDbFirstApproach.Models
{
    public class ProductImg
    {
        public int ProductImgId { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        

        [Required(ErrorMessage = "Please enter Image Path!")]
        public string ImgPath { get; set; } = string.Empty;
        [DefaultValue(false)]
        public int IsPrimary { get; set; }
        public string ImgDescription { get; set; } = string.Empty;
    }
}
