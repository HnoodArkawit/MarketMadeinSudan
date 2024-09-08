using MarketMadeinSudan.Domin;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarketMadeinSudan.Application.Features.FolderWatchesAndJewelry.Commands.CreateWatchesAndJewelry
{
    public class CreateWatchesAndJewelryCommand : IRequest<Guid>
    {
        [Display(Name = "الاسم"), MaxLength(30), MinLength(3)]
        public string WatchesAndJewelryName { get; set; }
        [Display(Name = "التفاصيل "), MinLength(3)]
        public string Description { get; set; }
        [Display(Name = "الكمية")]
        public int Quantity { get; set; }
        [Display(Name = "السعر")]
        public decimal Pirce { get; set; }
        [Display(Name = " البريد الالكتروني للشركة ")]
        public string EmailCompany { get; set; }
        [Display(Name = "وحدة القياس")]
        public string MeasruingUnit { get; set; }
        [Display(Name = " الصورة الاولي ")]
        public byte[] ImageUrl { get; set; }
        [Display(Name = " الصورة الثانية ")]
        public byte[] ImageProduct { get; set; }
        [Display(Name = " الصورة الثالثة ")]
        public byte[] PictureProduct { get; set; }
        [Display(Name = "اسم الشركة"), MinLength(3)]
        public string NameCompany { get; set; }
        [Display(Name = "تاريخ التاسيس")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfEstablishment { get; set; }
        [Display(Name = "الموقع الالكتروني "), Url]
        public string WebSite { get; set; }
        [Display(Name = "عنوان المؤسسة")]
        public string FounderAddress { get; set; }
        [Display(Name = "هاتف الشركة")]
        public int PhoneCompany { get; set; }

        [Display(Name = "التفاصيل "), MinLength(3)]
        public string DescriptionCompany { get; set; }
        public Guid PublishersId { get; set; }
        [ForeignKey("PublishersId")]
        public Publishers Publishers { get; set; }
        public string UserId { get; set; }
    }
}
