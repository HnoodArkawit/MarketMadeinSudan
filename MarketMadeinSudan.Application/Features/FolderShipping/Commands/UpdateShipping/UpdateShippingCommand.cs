using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MarketMadeinSudan.Application.Features.FolderShipping.Commands.UpdateShipping
{
    public class UpdateShippingCommand : IRequest
    {
        public Guid ShippingId { get; set; }
        [Display(Name = " اسم الشركة الشحن")]
        public string NameShipping { get; set; }
        public Guid PublishersId { get; set; }

        [Display(Name = "العنوان شركة الشحن")]
        public string AddressShipping { get; set; }

        [Display(Name = "بريد شركة الشحن")]
        public string EmailShipping { get; set; }

        [Display(Name = "هاتف شركة الشحن ")]
        public int PhoneShipping { get; set; }

        [Display(Name = "تفاصيل شركة الشحن")]
        public string DescriptionShipping { get; set; }

        [Display(Name = "اسم العميل")]
        public string firstNameCustoer { get; set; }
        [Display(Name = " الحاله ")]
        public string Status { get; set; }

        [Display(Name = "بلد العميل")]
        public string CountryCustoer { get; set; }

        [Display(Name = "عنوان العميل")]
        public string AddressCustoer { get; set; }

        [Display(Name = "بريد العميل ")]
        public string EmailCustoer { get; set; }

        [Display(Name = "هاتف العميل")]
        public int PhoneCustomer { get; set; }

        [Display(Name = "اسم المنتج")]
        public string ProductName { get; set; }

        [Display(Name = "كمية الممنتج ")]
        public int Count { get; set; }

        [Display(Name = "اسم الشركة المصدرة")]
        public string NameCompany { get; set; }

        [Display(Name = "بريد الشركة المصدرة")]
        public string EmailCompany { get; set; }

        [Display(Name = "عنوان الشركة المصدرة")]
        public string AddressCompany { get; set; }

        [Display(Name = "هاتف الشركة المصدرة")]
        public int PhoneCompany { get; set; }
        public string UserId { get; set; }

    }
}
