using System.ComponentModel.DataAnnotations;

namespace MarketMadeinSudan.UI.ViewModels
{
    public class RoleFormViewModel
    {
        [Required, StringLength(256)]
        public string Name { get; set; }
    }
}