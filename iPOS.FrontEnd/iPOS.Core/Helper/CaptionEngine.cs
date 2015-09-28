using System;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

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
            try
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
                                       size = parent.Element("size"),
                                       controls = (from controls in parent.Descendants("control")
                                                   select new
                                                   {
                                                       name = controls.Element("name"),
                                                       type = controls.Element("type"),
                                                       text = controls.Element("text"),
                                                       items = controls.Element("items"),
                                                       gridviews = controls.Element("gridviews"),
                                                       columns = controls.Element("columns")
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
                            case BaseConstant.WIZARD_CONTROL:
                                result = "";
                                var wizard_buttons = (from controls in parents.controls
                                                      where controls.name.Value.ToLower().Equals(string.Format("{0}_{1}", parent_name, control_name).ToLower())
                                                      select new
                                                      {
                                                          items = (from item in controls.items.Descendants("item")
                                                                   select new
                                                                   {
                                                                       type = item.Attribute("type").Value,
                                                                       text = item.Element("text")
                                                                   }).ToList()
                                                      }).First();
                                if (wizard_buttons != null)
                                {
                                    if (wizard_buttons.items != null && wizard_buttons.items.Count > 0)
                                    {
                                        result = string.Format("{0}|{1}|{2}|{3}", wizard_buttons.items[0].text.Element(language).Value, wizard_buttons.items[1].text.Element(language).Value, wizard_buttons.items[2].text.Element(language).Value, wizard_buttons.items[3].text.Element(language).Value);
                                    }
                                }
                                return result;
                            case BaseConstant.FORM_SIZE:
                                result = "";
                                string width = "0", height = "0";
                                if(ConfigEngine.TouchMode)
                                {
                                    width = parents.size.Element("touch").Attribute("width").Value;
                                    height = parents.size.Element("touch").Attribute("height").Value;
                                }
                                else
                                {
                                    width = parents.size.Element("normal").Attribute("width").Value;
                                    height = parents.size.Element("normal").Attribute("height").Value;
                                }
                                result = string.Format("{0}|{1}", width, height);
                                return result;
                        }
                    }
                    return "";
                }
            }
            catch
            {
                return "";
            }
            return "";
        }

        public static List<CaptionControl> GetControlCaptionList(string parent_name, string control_name, string type, string language)
        {
            List<CaptionControl> result = new List<CaptionControl>();
            try
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
                                                       gridviews = controls.Element("gridviews"),
                                                       columns = controls.Element("columns")
                                                   }).ToList()
                                   }).First();
                    if (parents != null)
                    {
                        switch (type)
                        {
                            case BaseConstant.GRID_COLUMN:
                                var grid_columns = (from controls in parents.controls
                                                      where controls.name.Value.ToLower().Equals(string.Format("{0}_{1}", parent_name, control_name).ToLower())
                                                      select new
                                                      {
                                                          columns = (from item in controls.columns.Descendants("column")
                                                                   select new
                                                                   {
                                                                       name = item.Attribute("name"),
                                                                       text = item.Element("text")
                                                                   }).ToList()
                                                      }).First();
                                if (grid_columns != null && grid_columns.columns.Count > 0)
                                {
                                    foreach (var column in grid_columns.columns)
                                    {
                                        result.Add(new CaptionControl
                                        {
                                            Name = column.name.Value,
                                            Caption = column.text.Element(language).Value
                                        });
                                    }
                                }
                                break;
                        }
                    }
                    return result;
                }
            }
            catch
            {
                return result;
            }
            return result;
        }
    }

    public class CaptionControl
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Caption { get; set; }
    }
}
