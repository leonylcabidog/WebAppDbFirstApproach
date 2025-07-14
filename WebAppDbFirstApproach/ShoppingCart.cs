using WebAppDbFirstApproach.Models;

namespace WebAppDbFirstApproach
{
    public class ShoppingCart
    {
        private List<CartItem> items = new List<CartItem>();

        public IEnumerable<CartItem> Items => items;

        public void AddToCart(Product product, int quantity)
        {
            var item = items.FirstOrDefault(i => i.Product.ProductId == product.ProductId);
            if (item == null)
            {
                items.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void RemoveFromCart(int productId)
        {
            var item = items.FirstOrDefault(i => i.Product.ProductId == productId);
            if (item != null)
                items.Remove(item);
        }

        public decimal GetTotal()
        {
            return Convert.ToDecimal(items.Sum(i => i.Product.Price * i.Quantity));
        }
    }
}
