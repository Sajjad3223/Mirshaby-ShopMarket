using System;
using System.ComponentModel.DataAnnotations;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Core.ViewModels.ShopViewModels
{
    public class ProductCommentViewModel
    {
        public int CommentId { get; set; }

        public int ProductId { get; set; }
        
        public int UserId { get; set; }

        public string FullName { get; set; }

        [Required]
        [MaxLength(600)]
        public string Text { get; set; }

        [Required]
        public int Score { get; set; }

        public DateTime CreationDate { get; set; }
    }
}