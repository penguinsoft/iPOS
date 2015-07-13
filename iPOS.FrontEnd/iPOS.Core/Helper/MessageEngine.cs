using System;
using System.Linq;
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
    }
}
