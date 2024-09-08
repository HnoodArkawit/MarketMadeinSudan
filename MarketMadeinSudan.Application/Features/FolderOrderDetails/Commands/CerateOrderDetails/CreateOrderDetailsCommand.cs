using MarketMadeinSudan.Domin;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketMadeinSudan.Application.Features.FolderOrderDetails.Commands.CreateOrderDetails
{
    public class CreateOrderDetailsCommand : IRequest<Guid>
    {
        [Display(Name = "الاسم الاول")]
        public string firstName { get; set; }

        [Display(Name = "اسم العائلة")]
        public string lastName { get; set; }

        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress), Display(Name = "البريد الالكتروني")]
        public string Email { get; set; }
        [Display(Name = " الحاله ")]
        public string Status { get; set; }
        [Display(Name = "وحدة القياس")]
        public string MeasruingUnit { get; set; }
        [Display(Name = "هاتف العميل")]
        public int PhoneCompany { get; set; }
        [Display(Name = "عنوان الشركة")]
        public string AddressCompany { get; set; }

        [Display(Name = "العنوان")]
        public string Address { get; set; }

        [Display(Name = "مكان الاقامة")]
        public string Country { get; set; }
        public Guid PublishersId { get; set; }

        [Display(Name = "الهاتف")]
        public int Phone { get; set; }
        [Display(Name = "الشركة المصنعة "), MinLength(3)]
        public string NameCompany { get; set; }

        [Display(Name = " البريد الالكتروني للشركة ")]
        public string EmailCompany { get; set; }

        [Display(Name = "تاريخ الدفع")]
        public DateTime DatePay { get; set; }

        [Display(Name = "ترميز البلد")]
        public int Zip { get; set; }
        public string UserId { get; set; }

        [Display(Name = "اسم المنتج "), MinLength(3)]
        public string ProductName { get; set; }
        [Display(Name = "السعر ")]
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal Total { get; set; }

    }
}
