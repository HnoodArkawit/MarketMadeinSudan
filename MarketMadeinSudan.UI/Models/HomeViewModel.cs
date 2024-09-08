using MarketMadeinSudan.Domin;

namespace MarketMadeinSudan.UI.Models
{
    public class HomeViewModel
    {
        public List<Accessories> Accessories { get; set; }
        public List<AgriculturalCrops> AgriculturalCrops { get; set; }
        public List<Aspires> Aspires { get; set; }
        public List<ElectricalAndElctronic> ElectricalAndElctronic { get; set; }
        public List<Fabrics> Fabrics { get; set; }
        public List<Food> Food { get; set; }
        public List<HouseholdProducts> HouseholdProducts { get; set; }
        public List<Other> Other { get; set; }
        public List<SportAndEntertainment> SportAndEntertainment { get; set; }
        public List<WatchesAndJewelry> WatchesAndJewelry { get; set; }
        public List<Cart> Cart { get; set; }
        public List<Publishers> Publisherss { get; internal set; }
        public List<Advertisements> Advertisementss { get; internal set; }
        public List<Shipping> Shipping { get; internal set; }
        public List<OrderDetails> OrderDetails { get; internal set; }

    }
}
