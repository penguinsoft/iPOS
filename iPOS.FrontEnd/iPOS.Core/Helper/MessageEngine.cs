using System;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace iPOS.Core.Helper
{
    public static class MessageEngine
    {
        public static string ReadFileSource()
        {
            XDocument xml = XDocument.Load(ConfigEngine.MessagePath);
            if (xml != null)
                return xml + "";

            return "";
        }

        public static string GetMessageCaption(string name, string language)
        {
            var message_source = ReadFileSource();
            string result = "";
            if (!string.IsNullOrEmpty(message_source))
            {
                var _message = (from message in XDocument.Parse(message_source).Descendants("message")
                                where message.Attribute("name").Value.ToLower().Equals(name.ToLower())
                                select message).First();
                if (_message != null)
                    result = _message.Element(language).Value + "";
            }

            return result;
        }

        public static string GetHTTPStatusCodes(HttpStatusCode status_code)
        {
            string result="ErrCode:";
            switch (status_code)
            {
                case HttpStatusCode.BadRequest:
                    result += "400";
                    break;
                case HttpStatusCode.Unauthorized:
                    result += "401";
                    break;
                case HttpStatusCode.Forbidden:
                    result += "403";
                    break;
                case HttpStatusCode.NotFound:
                    result += "404";
                    break;
                case HttpStatusCode.RequestTimeout:
                    result += "408";
                    break;
                default:
                    result = "";
                    break;
            }
            return result;
        }
    }
}
