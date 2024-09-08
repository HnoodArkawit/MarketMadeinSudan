using MarketMadeinSudan.Domin;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MarketMadeinSudan.Application.Features.FolderOrderDetails.Queries.GetOrderDetailsList;
namespace MarketMadeinSudan.Application.Features.FolderOrderDetails.Queries.GetOrderDetailsDetail
{
    public class GetOrderDetailsDetailViewModel
    {
        public Guid OrderDetailsId { get; set; }
        [Display(Name = "الاسم الاول")]
        public string firstName { get; set; }

        [DataType(DataType.EmailAddress), Display(Name = "البريد الالكتروني")]
        public string Email { get; set; }
        [Display(Name = "هاتف العميل")]
        public int PhoneCompany { get; set; }
        [Display(Name = "عنوان الشركة")]
        public string AddressCompany { get; set; }

        [Display(Name = "العنوان")]
        public string Address { get; set; }

        [Display(Name = "مكان الاقامة")]
        public string Country { get; set; }
        [Display(Name = "الشركة المصنعة "), MinLength(3)]
        public string NameCompany { get; set; }

        [Display(Name = " البريد الالكتروني للشركة ")]
        public string EmailCompany { get; set; }

        [Display(Name = "الهاتف")]
        public int Phone { get; set; }

        [Display(Name = "اسم المنتج "), MinLength(3)]
        public string ProductName { get; set; }
        [Display(Name = "السعر ")]
        public int Count { get; set; }
    }
}
