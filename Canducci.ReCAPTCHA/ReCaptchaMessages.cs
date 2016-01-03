using System;
namespace Canducci.ReCAPTCHA
{

    internal class ReCaptchaMessages
    {

        private const string MsgMissing = "The {0} parameter is missing.";
        private const string MsgParameterMissing = "The {0} parameter is invalid or malformed.";

        private static string Message(string corpo, string parameter)
        {
            return string.Format(corpo, parameter);
        }

        public static Exception[] GetMessage(string[] errors)
        {
            Exception[] _exceptions = null;

            if (errors != null && errors.Length > 0)
            {   
                _exceptions = new Exception[errors.Length];                
                string _msg = string.Empty;
                for (int _i = 0; _i < errors.Length; _i++)
                {    
                    if (errors[_i].Equals("missing-input-secret"))
                        _exceptions[_i] = new Exception(Message(MsgMissing, "secret"));
                    else if (errors[_i].Equals("invalid-input-secret"))
                        _exceptions[_i] = new Exception(Message(MsgParameterMissing, "secret"));
                    else if (errors[_i].Equals("missing-input-response"))
                        _exceptions[_i] = new Exception(Message(MsgMissing, "response"));
                    else if (errors[_i].Equals("invalid-input-response"))
                        _exceptions[_i] = new Exception(Message(MsgParameterMissing, "response"));                    
                }
            }    
            return _exceptions;            

        }
                
    }
}
