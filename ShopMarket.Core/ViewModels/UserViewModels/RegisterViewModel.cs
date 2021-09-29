using System.Collections;
using System.ComponentModel.DataAnnotations;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Core.ViewModels.UserViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "ایمیل")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "شماره تلفن همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "تکرار کلمه عبور با کلمه عبور وارد شده مغایرت دارد")]
        public string RePassword { get; set; }
    }
}