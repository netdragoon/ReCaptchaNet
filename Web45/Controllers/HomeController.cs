using System.Web.Mvc;
using Canducci.ReCAPTCHA;

namespace Web45.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet()]
        public ActionResult Site()
        {            
            return View();
        }

        [HttpPost()]
        public ActionResult Site(ReCaptchaResponse ReCaptchaResponse)
        {
            
            if (ReCaptchaResponse.Success)
            {
                //validation passed    
            }
            else
            {
                //validation errors
            }

            return View();
        }
    }
}