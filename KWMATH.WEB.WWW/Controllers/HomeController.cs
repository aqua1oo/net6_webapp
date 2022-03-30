using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KWMATH.WEB.WWW.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //cookie 생성 테스트
            //var test = User.Identity.IsAuthenticated ? User.FindFirst("Test").Value : "";


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}