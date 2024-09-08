using MarketMadeinSudan.Application.Features.FolderAdvertisements.Queries.GetAdvertisementsList;
using System.ComponentModel.DataAnnotations;

namespace MarketMadeinSudan.Application.Features.FolderAdvertisements.Queries.GetAdvertisementsDetail
{
    public class GetAdvertisementsDetailViewModel
    {
        public Guid AdvertisementId { get; set; }
        [Display(Name = "الاسم"), MaxLength(30), MinLength(3)]
        public string ProductName { get; set; }
        [Display(Name = "التفاصيل "), MinLength(3)]
        public string Description { get; set; }
        [Display(Name = "الكمية")]
        public int Quantity { get; set; }
        [Display(Name = "السعر القديم")]
        public decimal PirceGo { get; set; }
        [Display(Name = "السعر الجديد")]
        public decimal PirceEnd { get; set; }
        [Display(Name = "صورة المنتج")]
        public byte[] ImageUrl { get; set; }
        [Display(Name = "اسم الشركة"), MinLength(3)]
        public string NameCompany { get; set; }
        public CategoryDto Category { get; set; }
        public string UserId { get; set; }

    }
}
