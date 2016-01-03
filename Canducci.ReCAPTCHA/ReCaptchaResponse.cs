using System;
using System.Web.Mvc;
namespace Canducci.ReCAPTCHA
{     
    [ModelBinder(typeof(ReCaptchaBinder))]
    public class ReCaptchaResponse
    {
        public ReCaptchaResponse(string response, string remoteIp)
        {
            Response = response;
            RemoteIP = remoteIp;
            if (string.IsNullOrEmpty(Response))
            {
                ResponseEmpty();
            }
            else
            { 
                ResponseVerify();
            }

        }

        public string Response { get; private set; }   
             
        public bool Success { get; private set; }

        public string RemoteIP { get; private set; }    
            
        public Exception[] Exceptions { get; private set; }

        public string[] Erros { get; private set; }

        private void ResponseEmpty()
        {
            Success = false;
            Exceptions = new Exception[1] { new Exception("The Token GReCaptchaResponse is missing.",
                new FormatException("The Token GReCaptchaResponse is missing.")) };
            Erros = new string[1] { "missing-g-recaptcha-response" };
        }

        private void ResponseVerify()
        {
            ReCaptchaCurl _curl = ReCaptchaCurl.Create();
            string sKey = ReConfigurationCaptcha.GetCaptchaSecretyKey();
            string data = string.Format("response={0}&secret={1}&remoteip={2}", Response, sKey, RemoteIP);
            string json = _curl.Post(ReConfigurationCaptcha.GetCaptchaSiteVerifyUrl(), data);
            ReCaptchaValid ReCaptchaValid = ReCaptchaConvert.GetCaptchaValid(json);
            Success = ReCaptchaValid.Success;
            Exceptions = ReCaptchaValid.Exceptions;
            Erros = ReCaptchaValid.Errors;
            _curl.Dispose();
            _curl = null;
        }

    }
}
