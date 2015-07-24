using System;
using System.Xml.Linq;
using System.Linq;

namespace iPOS.Core.Helper
{
    public static class CaptionEngine
    {
        public static string ReadFileSource()
        {
            XDocument xml = XDocument.Load(ConfigEngine.CaptionPath);
            if (xml != null)
                return xml + "";

            return "";
        }

        public static string GetControlCaption(string parent_name, string control_name, string type, string language)
        {
            var caption_source = ReadFileSource();
            if (!string.IsNullOrEmpty(caption_source))
            {
                var parents = (from parent in XDocument.Parse(caption_source).Descendants("parent")
                               where parent.Attribute("name").Value.Equals(parent_name)
                               select new
                               {
                                   name = parent.Attribute("name").Value,
                                   text = parent.Element("text"),
                                   controls = (from controls in parent.Descendants("control")
                                               select new
                                               {
                                                   name = controls.Element("name"),
                                                   type = controls.Element("type"),
                                                   text = controls.Element("text"),
                                                   items = controls.Element("items"),
                                                   gridviews = controls.Element("gridviews")
                                               }).ToList()
                               }).First();
                if (parents != null)
                {
                    switch (type)
                    {
                        case BaseConstant.PARENT_TEXT:
                            return parents.text.Element(language).Value + "";
                        case BaseConstant.CONTROL_TEXT:
                            var control = (from controls in parents.controls
                                           where controls.name.Value.ToLower().Equals(string.Format("{0}_{1}", parent_name, control_name).ToLower())
                                           select controls).First();
                            if (control != null)
                                return control.text.Element(language).Value + "";
                            return "";
                        case BaseConstant.IMAGE_COMBOBOX_EDIT:
                            var result = "";
                            var image_box_edit_control = (from controls in parents.controls
                                                          where controls.name.Value.ToLower().Equals(string.Format("{0}_{1}", parent_name, control_name).ToLower())
                                                          select new
                                                          {
                                                              items = (from item in controls.items.Descendants("item")
                                                                       select new
                                                                       {
                                                                           text = item.Element("text")
                                                                       }).ToList()
                                                          }).First();
                            if (image_box_edit_control != null)
                            {
                                if (image_box_edit_control.items != null && image_box_edit_control.items.Count > 0)
                                {
                                    foreach (var item in image_box_edit_control.items)
                                        result += "@" + item.text.Element(language).Value + "";
                                }
                            }
                            return result;
                    }
                }
                return "";
            }
            return "";
        }
    }
}
