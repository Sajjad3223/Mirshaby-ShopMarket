using System;
using System.ComponentModel.DataAnnotations;

namespace ShopMarket.Domain.ShopEntities
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        [Display(Name = "*موضوع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Display(Name = "نام و نام خانوادگی*")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Display(Name = "ایمیل*")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "تلفن تماس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(11)]
        public string Phone { get; set; }

        [Display(Name = "پیام*")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        public bool IsSeen { get; set; } = false;

        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}