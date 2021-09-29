using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using ShopMarket.Core.Interfaces;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.Utilities.Convertors;
using ShopMarket.Core.Utilities.Sernders;
using ShopMarket.Core.ViewModels.ShopViewModels.OrderViewModels;
using ShopMarket.Core.ViewModels.UserViewModels;
using ShopMarket.Domain.Interfaces.ShopInterfaces.OrderInterfaces;
using ShopMarket.Domain.ShopEntities.OrderEntities;

namespace ShopMarket.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly ILikedProductService _likedService;
        private readonly IRecentVisitService _recentService;
        private readonly IProductImageService _imageService;
        private readonly IProductCommentService _commentService;
        private readonly IUserAddressService _addressService;
        private readonly IViewRenderService _renderService;
        private readonly IEmailSender _emailSender;

        public HomeController(IUserService userService, IOrderService orderService, ILikedProductService likedService, IRecentVisitService recentService, IProductCommentService commentService, IUserAddressService addressService, IProductImageService imageService, IViewRenderService renderService, IEmailSender emailSender)
        {
            _userService = userService;
            _orderService = orderService;
            _likedService = likedService;
            _recentService = recentService;
            _commentService = commentService;
            _addressService = addressService;
            _imageService = imageService;
            _renderService = renderService;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Index()
        {
            int userId = User.GetUserId();
            var user = await _userService.GetUser(userId);

            var userOrders = _orderService.GetUserOrders(userId).Take(7);

            var userLikes = _likedService.GetUserLikedProducts(userId).Take(3);

            if (userLikes.Any())
            {
                foreach (var like in userLikes)
                {
                    like.MainImageName = (await _imageService.GetMainImage(like.ProductId)).ImageName;
                }
            }

            UserPanelViewModel userPanel = new UserPanelViewModel()
            {
                User = user,
                Orders = userOrders,
                LikedProducts = userLikes
            };

            return View(userPanel);
        }

        [Route("/userpanel/orders")]
        public IActionResult UserOrders()
        {
            int userId = User.GetUserId();
            var userOrders = _orderService.GetUserOrders(userId).ToList();

            UserOrdersViewModel orders = new UserOrdersViewModel();

            if (userOrders.Any())
            {
                orders.NotPaidOrders = userOrders.Where(o => o.OrderStatus == EOrderStatus.NotPaid);
                orders.PaidOrders = userOrders.Where(o => o.OrderStatus == EOrderStatus.Paid);
                orders.IsSendingOrders = userOrders.Where(o => o.OrderStatus == EOrderStatus.IsSending);
                orders.DeliveredOrders = userOrders.Where(o => o.OrderStatus == EOrderStatus.Delivered);
            }

            if (!orders.NotPaidOrders.Any()) orders.NotPaidOrders = new List<OrderViewModel>();
            if (!orders.PaidOrders.Any()) orders.PaidOrders = new List<OrderViewModel>();
            if (!orders.IsSendingOrders.Any()) orders.IsSendingOrders = new List<OrderViewModel>();
            if (!orders.DeliveredOrders.Any()) orders.DeliveredOrders = new List<OrderViewModel>();


            ViewData["selected"] = "orders";

            return View(orders);
        }

        public async Task<IActionResult> OrderDetails(int orderId)
        {
            FullOrderDetailsViewModel orderDetails = new FullOrderDetailsViewModel();
            var order = await _orderService.GetOrder(orderId);
            orderDetails.OrderId = order.OrderId;
            orderDetails.UserId = order.UserId;
            orderDetails.OrderStatus = order.OrderStatus;
            orderDetails.CreationDate = order.CreationDate;
            orderDetails.Discount = order.Discount;
            orderDetails.FinalPrice = order.FinalPrice;
            orderDetails.Address = await _addressService.Get(order.ReceiverAddressId.Value);
            orderDetails.RefId = order.RefId;

            return View(orderDetails);
        }


        [Route("/userpanel/likes")]
        public async Task<IActionResult> UserLikes()
        {
            int userId = User.GetUserId();

            var userLikes = _likedService.GetUserLikedProducts(userId).ToList();
            if (userLikes.Any())
            {
                foreach (var like in userLikes)
                {
                    like.MainImageName = (await _imageService.GetMainImage(like.ProductId)).ImageName;
                }
            }
            ViewData["selected"] = "likes";

            return View(userLikes);
        }

        [Route("/userpanel/comments")]
        public IActionResult UserComments()
        {
            int userId = User.GetUserId();

            var userComments = _commentService.GetProductCommentsByUser(userId);

            ViewData["selected"] = "comments";

            return View(userComments);
        }

        #region Address

        [Route("/userpanel/addresses")]
        public IActionResult UserAddresses()
        {
            int userId = User.GetUserId();
            
            ViewData["selected"] = "addresses";

            return View(userId);
        }

        [Route("/userpanel/addresses/set-active-address/{addressId}")]
        public async Task<IActionResult> SetActiveAddress(int addressId)
        {
            var address = await _addressService.Get(addressId);
            if (address == null)
                return null;
            if (address.UserId != User.GetUserId())
                return null;
            var activeAddress = await _addressService.GetUserActiveAddress(User.GetUserId());
            if(activeAddress != null)
                if (activeAddress.AddressId == addressId)
                    return null;

            _addressService.ChangeActiveAddress(addressId,User.GetUserId());

            return Redirect("/userpanel/addresses");
        }

        [Route("/userpanel/addresses/edit-address/{addressId}")]
        public async Task<IActionResult> EditAddress(int addressId)
        {
            var userAddress = await _addressService.Get(addressId);

            return PartialView("_EditAddress", userAddress);
        }

        [HttpPost("/userpanel/addresses/edit-address/{addressId}")]
        public async Task<IActionResult> EditAddress(int addressId,UserAddressViewModel addressViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Result = OperationResultStatus.Error;
                return Redirect("/userpanel/addresses");
            }

            var address = await _addressService.Get(addressViewModel.AddressId);
            if (address == null)
            {
                ViewBag.Result = OperationResultStatus.Error;
                return Redirect("/userpanel/addresses");
            }

            if (address.UserId != User.GetUserId())
            {
                ViewBag.Result = OperationResultStatus.Error;
                return Redirect("/userpanel/addresses");
            }

            int userId = User.GetUserId();
            addressViewModel.UserId = userId;

            var result = _addressService.Update(addressViewModel).Status;

            TempData["Result"] = (result == OperationResultStatus.Success) ? "success" : "fail";

            return Redirect("/userpanel/addresses");
        }

        [Route("/userpanel/addresses/add-address")]
        public IActionResult AddAddress()
        {
            return PartialView("_AddAddress");
        }

        [HttpPost("/userpanel/addresses/add-address")]
        public IActionResult AddAddress(UserAddressViewModel addressViewModel)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Result = OperationResultStatus.Error;
                return Redirect("/userpanel/addresses");
            }

            int userId = User.GetUserId();
            addressViewModel.UserId = userId;

            var result = _addressService.Insert(addressViewModel).Status;
            TempData["Result"] = (result == OperationResultStatus.Success) ? "success" : "fail";

            return Redirect("/userpanel/addresses");
        }

        #endregion
        
        [Route("/userpanel/recents")]
        public async Task<IActionResult> UserRecentVisits()
        {
            int userId = User.GetUserId();

            var recentVisits = _recentService.GetUserRecentVisits(userId).ToList();
            if (recentVisits.Any())
            {
                foreach (var visit in recentVisits)
                {
                    visit.MainImageName = (await _imageService.GetMainImage(visit.ProductId)).ImageName;
                }
            }
            ViewData["selected"] = "recents";

            return View(recentVisits);
        }

        #region Active Account

        [Route("/userpanel/verifyemail")]
        public async Task<IActionResult> VerifyEmail()
        {
            int userId = User.GetUserId();
            var user = await _userService.GetUser(userId);

            var body = _renderService.RenderToStringAsync("_ActiveAccount", user);

            _emailSender.Send(user.Email, "فعال سازی حساب کاربری", body);

            ViewData["selected"] = "verifyemail";

            return null;
        }

        #endregion

        #region Change Password

        [Route("/userpanel/change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost("/userpanel/change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePassword)
        {
            if (!ModelState.IsValid)
                return Redirect("/");

            var user = await _userService.GetUser(User.GetUserId());
            if (user == null)
                return Redirect("/");

            if (user.Password != changePassword.OldPassword.EncodeToMd5())
            {
                ModelState.AddModelError(nameof(changePassword.OldPassword),"پسورد فعلی اشتباه است");
                return View();
            }

            user.Password = changePassword.Password.EncodeToMd5();
            _userService.UpdateUser(user);

            ViewBag.IsSuccess = true;

            return View();
        }

        #endregion

        [Route("/userpanel/edit")]
        public async Task<IActionResult> EditProfile()
        {
            int userId = User.GetUserId();

            var user = await _userService.GetUser(userId);

            ViewData["selected"] = "edit";

            return View(user);
        }

        [HttpPost("/userpanel/edit")]
        public async Task<IActionResult> EditProfile(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return View(userViewModel);

            UserViewModel orginalUser = await _userService.GetUser(User.GetUserId());

            orginalUser.FullName = userViewModel.FullName;
            orginalUser.PhoneNumber = userViewModel.PhoneNumber;
            orginalUser.Email = userViewModel.Email.FixEmail();
            orginalUser.ReceiveNews = userViewModel.ReceiveNews;
            orginalUser.AvatarFile = userViewModel.AvatarFile;
            orginalUser.NationalCode = userViewModel.NationalCode;

            ViewBag.Result = _userService.UpdateUser(orginalUser);

            return RedirectToAction("Index");
        }

        
    }
}
