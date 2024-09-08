using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MarketMadeinSudan.Application.Features.FolderAdvertisements.Commands.UpdateAdvertisements
{
    public class UpdateAdvertisementsCommand : IRequest
    {
        public Guid AdvertisementId { get; set; }
        [Display(Name = "الاسم"), MaxLength(30), MinLength(3)]
        public string ProductName { get; set; }
        [Display(Name = "التفاصيل "), MinLength(3)]
        public string Description { get; set; }
        [Display(Name = "اسم الشركة"), MinLength(3)]
        public string NameCompany { get; set; }
        [Display(Name = "الكمية")]
        public int Quantity { get; set; }
        [Display(Name = "السعر القديم")]
        public decimal PirceGo { get; set; }
        [Display(Name = "السعر الجديد")]
        public decimal PirceEnd { get; set; }
        [Display(Name = "صورة المنتج")]
        public byte[] ImageUrl { get; set; }
        public string UserId { get; set; }

    }
}
