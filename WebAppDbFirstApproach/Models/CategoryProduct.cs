namespace WebAppDbFirstApproach.Models
{
    public class CategoryProduct
    {
        public Product Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}
