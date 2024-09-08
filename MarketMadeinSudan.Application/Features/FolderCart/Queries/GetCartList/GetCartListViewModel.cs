﻿using System.ComponentModel.DataAnnotations;

namespace MarketMadeinSudan.Application.Features.FolderCart.Queries.GetCartList
{
    public class GetCartListViewModel
    {
        public Guid ProductId { get; set; }
        [Display(Name = "اسم المنتج "), MinLength(3)]
        public string ProductName { get; set; }
        [Display(Name = "السعر ")]
        public decimal Price { get; set; }
        [Display(Name = "الشركة المصنعة "), MinLength(3)]
        public string NameCompany { get; set; }
        public Guid PublishersId { get; set; }
        [Display(Name = "وحدة القياس")]
        public string MeasruingUnit { get; set; }
        [Display(Name = "هاتف الشركة")]
        public int PhoneCompany { get; set; }
        [Display(Name = "عنوان الشركة")]
        public string AddressCompany { get; set; }

        [Display(Name = " البريد الالكتروني للشركة ")]
        public string EmailCompany { get; set; }

        public int Count { get; set; }
        public string UserId { get; set; }
    }
}
