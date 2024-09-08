using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarketMadeinSudan.Domin
{
    public class SportAndEntertainment
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid SportAndEntertainmentId { get; set; }
        [Display(Name = "الاسم"), MaxLength(30), MinLength(3)]
        public string SportAndEntertainmentName { get; set; }
        [Display(Name = "التفاصيل "), MinLength(3)]
        public string Description { get; set; }
        [Display(Name = "الكمية")]
        public int Quantity { get; set; }
        [Display(Name = "السعر")]
        public decimal Pirce { get; set; }
        [Display(Name = " الصورة الاولي ")]
        public byte[] ImageUrl { get; set; }
        [Display(Name = " الصورة الثانية ")]
        public byte[] ImageProduct { get; set; }
        [Display(Name = " الصورة الثالثة ")]
        public byte[] PictureProduct { get; set; }
        [Display(Name = "اسم الشركة"), MinLength(3)]
        public string NameCompany { get; set; }
        [Display(Name = " البريد الالكتروني للشركة ")]
        public string EmailCompany { get; set; }
        [Display(Name = "وحدة القياس")]
        public string MeasruingUnit { get; set; }
        [Display(Name = "هاتف الشركة")]
        public int PhoneCompany { get; set; }

        [Display(Name = "تاريخ التاسيس")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfEstablishment { get; set; }
        [Display(Name = "الموقع الالكتروني ")]
        public string WebSite { get; set; }
        [Display(Name = "عنوان المؤسسة")]
        public string FounderAddress { get; set; }
        [Display(Name = "التفاصيل "), MinLength(3)]
        public string DescriptionCompany { get; set; }
        public string UserId { get; set; }

        public Guid PublishersId { get; set; }
        [ForeignKey("PublishersId")]
        public Publishers Publishers { get; set; }

        [Range(1, 1000, ErrorMessage = "رجاء ادخل كمية اكثر من 1 واقل من 1000")]
        public int Count { get; set; }

        [NotMapped]
        public decimal Price { get; set; }

    }
}
