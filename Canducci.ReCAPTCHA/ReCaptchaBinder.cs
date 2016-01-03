using System.Web;
using System.Web.Mvc;
namespace Canducci.ReCAPTCHA
{    
    internal class ReCaptchaBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;
            string remoteIp = request.UserHostAddress;
            return new ReCaptchaResponse(request.Form.Get("g-recaptcha-response"), remoteIp);
        }
    }

}
