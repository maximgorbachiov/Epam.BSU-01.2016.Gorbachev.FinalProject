using System.Linq;
using System.Web.Mvc;
using BLL.Interfaces;
using MVC.Models;
using System.Web.Security;
using MVC.CustomProviders;
using MVC.Infrastructure.Mappers;

namespace MVC.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IClientService service;

        public AuthorizationController(IClientService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            var type = HttpContext.User.GetType();
            var iden = HttpContext.User.Identity.GetType();
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(viewModel.Email, viewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, viewModel.RememberMe);

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password.");
                }
            }
            return View(viewModel);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Authorization");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            /*if (viewModel.Captcha != (string)Session[CaptchaImage.CaptchaValueKey])
            {
                ModelState.AddModelError("Captcha", "Incorrect input.");
                return View(viewModel);
            }*/

            var anyUser = service.GetAllClientEntities().Any(u => u.Email == viewModel.Email);

            if (anyUser)
            {
                ModelState.AddModelError("", "User with this address already registered.");
            }

            if (ModelState.IsValid)
            {
                var membershipUser = ((ClientMembershipProvider)Membership.Provider).CreateClient(viewModel);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error registration.");
                }
            }

            return View(viewModel);
        }
    }
}