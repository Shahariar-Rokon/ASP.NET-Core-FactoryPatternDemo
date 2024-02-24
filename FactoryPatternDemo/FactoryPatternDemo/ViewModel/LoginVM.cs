using System.ComponentModel.DataAnnotations;

namespace FactoryPatternDemo.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Give me a userName")]
        public string? UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Give me a Password")]
        public string? Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
