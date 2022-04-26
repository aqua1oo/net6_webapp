using KWMATH.WEB.WWW.Data;
using KWMATH.WEB.WWW.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Security.Claims;

namespace KWMATH.WEB.WWW.Controllers
{    
    public class AccountController : Controller
    {
        Param paramSet = new Param();
        private readonly ApplicationDbContext _db;
        private HttpContext _httpContext;

        public AccountController(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContext = httpContextAccessor.HttpContext;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserParam user)
        {
            user.client_ip = Convert.ToString(Request.HttpContext.Connection.RemoteIpAddress);
            #region DB처리              
            List<SqlParameter> parms = paramSet.UserValidateParam(user);
            string sql = "EXEC UP_NEW_TN_USER_VALIDATE_SEL @user_id, @user_pass, @site_id, @client_ip, @guid";

            Procedure pro = new Procedure(_db);
            int userCheck = pro.UserInt(sql, parms);
            #endregion

            if (userCheck == 0)
            {
                //return Redirect("/");                
                return Content("<script type='text/javascript'>alert('일치하는 회원이 존재하지않습니다. \\n\\n다시 확인하신 후 이용해 주세요.');location.href='/login/';</script>");
            }
            
            var identity = new ClaimsIdentity(claims: new[] {
                    new Claim(type: ClaimTypes.Name, value: user.user_id),
                    new Claim(type: ClaimTypes.Role, value: "user"),
                    //cookie 생성 테스트  
                    new Claim("Test", value: user.user_pass)
                }, authenticationType: CookieAuthenticationDefaults.AuthenticationScheme);

            await _httpContext.SignInAsync(scheme: CookieAuthenticationDefaults.AuthenticationScheme, principal: new ClaimsPrincipal(identity: identity), properties: new AuthenticationProperties() { AllowRefresh = true, IsPersistent = true, ExpiresUtc = DateTime.UtcNow.AddHours(12) });

            return Redirect(user.return_url);            
        }

        public async Task<IActionResult> Logout()
        {
            await _httpContext.SignOutAsync(scheme: CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}