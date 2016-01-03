using Newtonsoft.Json;
namespace Canducci.ReCAPTCHA
{
    internal class ReCaptchaConvert
    {
        public static ReCaptchaValid GetCaptchaValid(string json)
        {
            return (ReCaptchaValid)JsonConvert.DeserializeObject(json, typeof(ReCaptchaValid));
        }
    }
}
