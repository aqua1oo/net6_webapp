using KWMATH.WEB.WWW.Models;
using log4net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KWMATH.WEB.WWW.Controllers
{
    public class ExceptionController : Controller
    {
        ILog _logger = LogManager.GetLogger(typeof(ExceptionController));   

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            #region exception log 생성
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            _logger.Error(context.Error.Message + "\n" + context.Error.StackTrace + "\n\n");
            #endregion

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, StatusCd = HttpContext.Response.StatusCode });
        }
    }
}