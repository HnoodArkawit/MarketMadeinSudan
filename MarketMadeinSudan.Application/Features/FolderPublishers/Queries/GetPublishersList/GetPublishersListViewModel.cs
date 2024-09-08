using MarketMadeinSudan.Domin;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MarketMadeinSudan.Application.Features.FolderPublishers.Queries.GetPublishersList
{
    public class GetPublishersListViewModel
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
        [Display(Name = "الهاتف")]
        public int Phone { get; set; }
        [Display(Name = "لوغو الشركة")]
        public byte[] ImageCompany { get; set; }
        [Display(Name = " ملف 1 ")]
        public byte[] PdfFile { get; set; }
        [Display(Name = " ملف 2 ")]
        public byte[] FilePdf { get; set; }
        public string UserId { get; set; }
        public CategoryDto Category { get; set; }

    }
}
