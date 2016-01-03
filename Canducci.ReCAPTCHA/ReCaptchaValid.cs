using Newtonsoft.Json;
using System;
namespace Canducci.ReCAPTCHA
{   
    internal class ReCaptchaValid
    {

        [JsonConstructor()]
        public ReCaptchaValid(bool success, string[] errors)
        {
            Success = success;
            Errors = errors;
            Exceptions = ReCaptchaMessages.GetMessage(errors);
        }

        [JsonProperty("success")]
        public bool Success { get; private set; }

        [JsonProperty("error-codes")]
        public string[] Errors { get; private set; }

        [JsonIgnore()]
        public Exception[] Exceptions { get; private set; } 

    }
}