using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Web.Models;
using SampleProject.Web.Models.ViewModels;
using System.Diagnostics;

namespace SampleProject.Web.Controllers
{
    public class HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager) : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {

            if(!ModelState.IsValid) return View(model);

            var userToCreate = new IdentityUser()
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(userToCreate, model.Password);

            if (!result.Succeeded)
            {

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }


            return RedirectToAction(nameof(SignIn));
        }
        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult ProductList()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
