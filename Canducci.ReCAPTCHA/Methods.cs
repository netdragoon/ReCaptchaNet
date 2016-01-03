using System;
using System.Web;
using System.Web.Mvc;

namespace Canducci.ReCAPTCHA
{
    public static class Methods
    {

        private static _ReCaptchaLanguage _find;

        static Methods()
        {
            _find = new _ReCaptchaLanguage();
        }

        public static string GetValue(this ReCaptchaLanguage cl, string key)
        {
            string value = "";
            if (_find.TryGetValue(key, out value))
            {
                return value.TrimStart().TrimEnd().Trim();
            }
            return null;
        }

        public static string GetValueLower(this Enum cl)
        {
            return cl.ToString().ToLower();
        }

        public static IHtmlString ReCaptcha(this HtmlHelper _helpers,
            DataTheme dataTheme = DataTheme.Light, 
            DataType dataType = DataType.Image,
            DataSize dataSize = DataSize.Normal, 
            int dataTabIndex = 0, 
            string dataCallBack = null, 
            string dataExpiredCallBack = null)
        {

            TagBuilder tagDiv = new TagBuilder("div");

            tagDiv.Attributes.Add("data-sitekey", ReConfigurationCaptcha.GetCaptchaSiteKey());
            tagDiv.Attributes.Add("data-theme", dataTheme.GetValueLower());
            tagDiv.Attributes.Add("data-type", dataType.GetValueLower());
            tagDiv.Attributes.Add("data-size", dataSize.GetValueLower());
            tagDiv.Attributes.Add("data-tabindex", dataTabIndex.ToString());

            if (!string.IsNullOrEmpty(dataCallBack))
            {
                tagDiv.Attributes.Add("data-callback", dataCallBack);
            }

            if (!string.IsNullOrEmpty(dataExpiredCallBack))
            {
                tagDiv.Attributes.Add("data-expired-callback", dataExpiredCallBack);
            }

            tagDiv.AddCssClass("g-recaptcha");
            tagDiv.Attributes.Add("id", "g-recaptcha-id");

            return new HtmlString(tagDiv.ToString());

        }

        public static IHtmlString ReCaptchaScript(this HtmlHelper _helpers, Render render = Render.Onload, ReCaptchaLanguage language = ReCaptchaLanguage.Default, string onLoadCallBack = null)
        {

            TagBuilder tagDiv = new TagBuilder("script");

            string url = ReConfigurationCaptcha.GetCaptchaApiUrl();

            url = url + "?render=" + render.GetValueLower();

            if (!string.IsNullOrEmpty(onLoadCallBack))
            {
                url = url + "&onload=" + onLoadCallBack;
            }

            if (language != ReCaptchaLanguage.Default)
            {
                string valueHl = null;
                if (_find.TryGetValue(language.ToString(), out valueHl))
                {
                    url = url + "&hl=" + valueHl;
                }
            }

            tagDiv.Attributes.Add("src", url);
                        
            return new HtmlString(tagDiv.ToString().Replace("></", " async defer></"));

        }
                
    }
}
