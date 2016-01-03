using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Canducci.ReCAPTCHA;
using Web45.Models;

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
            //ViewBag.SiteKey = System.Configuration.ConfigurationManager.AppSettings.Get("Captcha-Site-Key");
            return View();
        }

        [HttpPost()]
        public ActionResult Site(Pessoas form, ReCaptchaResponse ReCaptchaResponse)
        {

            //string response = CaptchaResponse.GReCaptchaResponse;
            //string secret = System.Configuration.ConfigurationManager.AppSettings.Get("Captcha-Secrety-Key");            

            //KeyValuePair<string, string>[] values = new KeyValuePair<string, string>[2];
            //values[0] = new KeyValuePair<string, string>("response", response);
            //values[1] = new KeyValuePair<string, string>("secret", secret);


            //FormUrlEncodedContent content = new FormUrlEncodedContent(values);
            //HttpClient http = new HttpClient();
            //HttpResponseMessage message = await http.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);
            //string status = await message.Content.ReadAsStringAsync();

            var c = ReCaptchaResponse;
            if (c.Success)
            {
                
            }
            //CaptchaLanguage abc = CaptchaLanguage.Portuguese_Brazil;            


            return View();
        }
    }
}