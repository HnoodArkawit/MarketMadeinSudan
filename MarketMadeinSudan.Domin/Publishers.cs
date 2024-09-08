using System.ComponentModel.DataAnnotations;

namespace MarketMadeinSudan.Domin
{
    public class Publishers
    {
        [System.ComponentModel.DataAnnotations.Key]
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
        [Display(Name = "الهاتف")]
        public int Phone { get; set; }
        [Display(Name = "لوغو الشركة")]
        public byte[] ImageCompany { get; set; }

        [Display(Name = "ملف السجل التجاري")]
        public byte[] PdfFile { get; set; }
        [Display(Name = "ملف السجل الضريبي")]
        public byte[] FilePdf { get; set; }

        public string UserId { get; set; }
    }
}
