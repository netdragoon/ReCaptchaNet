using System;
using System.Net;
namespace Canducci.ReCAPTCHA
{
    internal class ReCaptchaCurl: IDisposable
    {

        private WebClient _curl;

        public ReCaptchaCurl()
        {
            _curl = new WebClient();
            _curl.Headers.Clear();
            _curl.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
        }

        public string Post(Uri url, string data)
        {
            return _curl.UploadString(url, "POST", data);
        }

        public string Get(Uri url)
        {
            return _curl.DownloadString(url);
        }

        public void Dispose()
        {
            if (_curl != null)
            {
                _curl.Dispose();
            }
            _curl = null;
        }

        public static ReCaptchaCurl Create()
        {
            return new ReCaptchaCurl();
        }

    }
}
