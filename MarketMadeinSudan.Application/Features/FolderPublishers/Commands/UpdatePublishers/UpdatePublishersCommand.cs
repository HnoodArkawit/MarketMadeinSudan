using MarketMadeinSudan.Domin;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MarketMadeinSudan.Application.Features.FolderPublishers.Commands.UpdatePublishers
{
    public class UpdatePublishersCommand : IRequest
    {
        public Guid PublishersId { get; set; }
        [Display(Name = "اسم الشركة"), MinLength(3)]
        public string NameCompany { get; set; }
        [Display(Name = "التفاصيل "), MinLength(3)]
        public string DescriptionCompany { get; set; }
        [Display(Name = "عنوان المؤسسة")]
        public string FounderAddress { get; set; }
        [Display(Name = "تاريخ التاسيس")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfEstablishment { get; set; }
        [Display(Name = "الموقع الالكتروني ")]
        public string WebSite { get; set; }
        [Display(Name = "البريد الالكتروني")]
        public string Email { get; set; }
        [Display(Name = "مجال العمل ")]
        public string Employment { get; set; }
        [Display(Name = " ملف 1 ")]
        public byte[] PdfFile { get; set; }
        [Display(Name = " ملف 2 ")]
        public byte[] FilePdf { get; set; }
        [Display(Name = "الهاتف")]
        public int Phone { get; set; }
        [Display(Name = "لوغو الشركة")]
        public byte[] ImageCompany { get; set; }
        public string UserId { get; set; }
    }
}
