using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ShopMarket.Core.Interfaces;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.Utilities.Convertors;
using ShopMarket.Core.Utilities.Sernders;
using ShopMarket.Core.ViewModels.UserViewModels;

namespace ShopMarket.Areas.User.Controllers
{
    [Area("User")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IViewRenderService _renderService;
        private readonly IEmailSender _emailSender;
        // Inject Services
        public AccountController(IUserService userService, IViewRenderService renderService, IEmailSender emailSender)
        {
            _userService = userService;
            _renderService = renderService;
            _emailSender = emailSender;
        }

        #region ForgetPassword

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            if (!ModelState.IsValid)
                return View(forgetPasswordViewModel);

            var user = await _userService.GetUserByEmail(forgetPasswordViewModel.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email","حساب کاربری یافت نشد");
                return View(forgetPasswordViewModel);
            }

            var body = _renderService.RenderToStringAsync("_ForgetPassword", user);

            _emailSender.Send(forgetPasswordViewModel.Email, "بازیابی رمز عبور", body);

            ViewBag.ForgetPassword = "success";
            return View();
        }


        #endregion

        #region Reset Password

        [Route("/user/reset-password/{code}")]
        public async Task<IActionResult> ResetPassword(string code)
        {
            if (string.IsNullOrEmpty(code))
                return Redirect("/");

            var user = await _userService.GetUserByActiveCode(code);
            if (user == null)
                return Redirect("/");

            ResetPasswordViewModel resetPassword = new ResetPasswordViewModel()
            {
                ActiveCode = code
            };

            return View(resetPassword);
        }

        [HttpPost("/user/reset-password/{code}")]
        public async Task<IActionResult> ResetPassword(string code , ResetPasswordViewModel resetPassword)
        {
            if (!ModelState.IsValid)
                return Redirect("/");

            var user = await _userService.GetUserByActiveCode(code);
            if (user == null)
                return Redirect("/");

            user.Password = resetPassword.Password.EncodeToMd5();
            _userService.UpdateUser(user);

            TempData["ResetPassword"] = "Changed";

            return RedirectToAction("Login");
        }

        #endregion
        
        #region Active Account

        [Route("/userpanel/verify-account/{activeCode}")]
        public async Task<IActionResult> VerifyAccount(string activeCode)
        {
            var result = await _userService.ActiveAccount(activeCode);
            TempData["Activated"] = result ? "success" : "fail";

            return Redirect("/user");
        }

        #endregion

        #region Login

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel,string ReturnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                if (await _userService.DoesUserExist(loginViewModel))
                {
                    UserViewModel user = await _userService.GetUserByPhone(loginViewModel.PhoneNumber);
                    
                    if (user == null)
                    {
                        ModelState.AddModelError(nameof(loginViewModel.PhoneNumber),"کاربر پیدا نشد");
                        return View(loginViewModel);
                    }

                    #region Sign In User

                    Claim[] claims = new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, user.FullName.ToString())
                    };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        IsPersistent = loginViewModel.RememberMe
                    };
                    await HttpContext.SignInAsync(principal, properties);

                    #endregion

                    return Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError(nameof(loginViewModel.PhoneNumber), "کاربر پیدا نشد");
                    return View(loginViewModel);
                }
            }
            return View(loginViewModel);
        }

        #endregion

        #region Register

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel, string ReturnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                var status = await _userService.CheckUser(registerViewModel.PhoneNumber, registerViewModel.Email);
                switch (status)
                {
                    case CheckUserStatus.EmailAndPhoneExist:
                    {
                        ModelState.AddModelError("Email","ایمیل وارد شده موجود است");
                        ModelState.AddModelError("PhoneNumber","شماره تلفن وارد شده موجود است");
                        return View(registerViewModel);
                    }

                    case CheckUserStatus.EmailExists:
                        ModelState.AddModelError("Email", "ایمیل وارد شده موجود است");
                        return View(registerViewModel);

                    case CheckUserStatus.PhoneExists:
                        ModelState.AddModelError("PhoneNumber", "شماره تلفن وارد شده موجود است");
                        return View(registerViewModel);

                    case CheckUserStatus.DoesNotExist:
                    {
                        ViewBag.Status = await _userService.InsertUser(registerViewModel);
                        break;
                    }
                }
                
                return Redirect(ReturnUrl);
            }
            return View(registerViewModel);
        }

        #endregion

        #region Logout

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        #endregion

    }
}
