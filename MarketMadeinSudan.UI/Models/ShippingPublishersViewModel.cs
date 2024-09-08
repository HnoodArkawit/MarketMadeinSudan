using MarketMadeinSudan.Domin;

namespace MarketMadeinSudan.UI.Models
{
    public class ShippingPublishersViewModel
    {
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
        public IEnumerable<Publishers> Publishers { get; set; }
    }
}
