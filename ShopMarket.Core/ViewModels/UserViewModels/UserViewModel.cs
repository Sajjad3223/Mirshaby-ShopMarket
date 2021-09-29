using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ShopMarket.Core.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "شماره تلفن همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "کد ملی")]
        [StringLength(10)]
        public string? NationalCode { get; set; }

        public string ActiveCode { get; set; }

        [Display(Name = "تصویر کاربری")]
        public string UserAvatar { get; set; }

        public IFormFile AvatarFile { get; set; }

        [Display(Name = "دریافت خبرنامه")]
        public bool ReceiveNews { get; set; } = false;
        
        public bool IsEmailVerified { get; set; } = false;

        public DateTime RegisterDate { get; set; }
    }
}
