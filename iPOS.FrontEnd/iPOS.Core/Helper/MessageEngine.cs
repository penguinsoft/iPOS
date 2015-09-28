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
            try
            {
                if (!string.IsNullOrEmpty(message_source))
                {
                    var _message = (from message in XDocument.Parse(message_source).Descendants("message")
                                    where message.Attribute("name").Value.ToLower().Equals(name.ToLower())
                                    select message).First();
                    if (_message != null)
                        result = _message.Element(language).Value + "";
                }
            }
            catch
            {
                return "";
            }

            return result;
        }

        public static string GetHTTPStatusCodes(string name, string language)
        {
            string result = "";
            if (name.ToLower().Equals("ok")) return "";
            var message_source = ReadFileSource();
            try
            {
                if (!string.IsNullOrEmpty(message_source))
                {
                    var _message = (from message in XDocument.Parse(message_source).Descendants("message")
                                    where message.Attribute("name").Value.ToLower().Equals(name.ToLower())
                                    select new
                                    {
                                        code = message.Attribute("code").Value,
                                        message = message.Element(language).Value
                                    }).First();
                    if (_message != null)
                    {
                        result = string.Join("|", "Error", _message.code, _message.message);
                    }
                }
            }
            catch
            {
                return string.Join("|", "Error", name, name);
            }

            return result;
        }
    }
}
