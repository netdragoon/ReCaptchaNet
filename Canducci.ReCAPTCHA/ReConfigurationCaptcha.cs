using System;
using System.Configuration;
namespace Canducci.ReCAPTCHA
{
    internal class ReConfigurationCaptcha
    {

        public static string GetCaptchaSecretyKey()
        {            
            return ConfigurationManager.AppSettings.Get("Captcha-Secrety-Key");
        }

        public static string GetCaptchaSiteKey()
        {
            return ConfigurationManager.AppSettings.Get("Captcha-Site-Key");
        }

        public static Uri GetCaptchaSiteVerifyUrl()
        {
            return new Uri(ConfigurationManager.AppSettings.Get("Captcha-Site-Verify-Url"));
        }

        public static string GetCaptchaApiUrl()
        {
            return ConfigurationManager.AppSettings.Get("Captcha-Api-Url");
        }
        
    }
}
