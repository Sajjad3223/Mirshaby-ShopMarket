using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.ViewModels.ShopViewModels;
using ShopMarket.Core.ViewModels.UserViewModels;

namespace ShopMarket.ViewComponents
{
    public class CommentsViewComponent : ViewComponent
    {
        private readonly IProductCommentService _commentService;
        private readonly IUserService _userService;

        public CommentsViewComponent(IProductCommentService commentService, IUserService userService)
        {
            _commentService = commentService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            List<ProductCommentViewModel> comments = new List<ProductCommentViewModel>();
            var comms = _commentService.GetProductCommentsByProduct(productId).ToList();
            
            foreach (var comment in comms)
            {
                UserViewModel user = await _userService.GetUser(comment.UserId);
                
                comments.Add(new ProductCommentViewModel()
                {
                    FullName = user.FullName,
                    Score = comment.Score,
                    ProductId = comment.ProductId,
                    UserId = comment.UserId,
                    CreationDate = comment.CreationDate,
                    CommentId = comment.CommentId,
                    Text = comment.Text
                });
            }

            return View(comments);
        }
    }
}