using System;
using Aspose.Cells;
using System.Drawing;

namespace iPOS.Core.Extensions
{
    public class AsposeCellsStyle
    {
        public class Cells
        {
            public class Font
            {
                public static void Color(Cell cell, Color color)
                {
                    Style style = cell.GetStyle();
                    style.Font.Color = color;
                    cell.SetStyle(style);
                }

                public static void IsBold(Cell cell, bool is_bold)
                {
                    Style style = cell.GetStyle();
                    style.Font.IsBold = is_bold;
                    cell.SetStyle(style);
                }

                public static void Size(Cell cell, int size)
                {
                    Style style = cell.GetStyle();
                    style.Font.Size = size;
                    cell.SetStyle(style);
                }
            }

            public static void IsTextWrapped(Cell cell, bool is_text_wrapped)
            {
                Style style = cell.GetStyle();
                style.IsTextWrapped = is_text_wrapped;
                cell.SetStyle(style);
            }

            public static void Borders(Cell cell, Style cell_style)
            {
                Style style = cell.GetStyle();
                style.Borders[BorderType.TopBorder].LineStyle = cell_style.Borders[BorderType.TopBorder].LineStyle;
                style.Borders[BorderType.BottomBorder].LineStyle = cell_style.Borders[BorderType.BottomBorder].LineStyle;
                style.Borders[BorderType.LeftBorder].LineStyle = cell_style.Borders[BorderType.LeftBorder].LineStyle;
                style.Borders[BorderType.RightBorder].LineStyle = cell_style.Borders[BorderType.RightBorder].LineStyle;
                cell.SetStyle(style);
            }

            public static void BackgroundColor(Cell cell, Color background_color)
            {
                Style style = cell.GetStyle();
                style.BackgroundColor = background_color;
                cell.SetStyle(style);
            }

            public static void ForegroundColor(Cell cell, Color foreground_color)
            {
                Style style = cell.GetStyle();
                style.ForegroundColor = foreground_color;
                cell.SetStyle(style);
            }

            public static void Custom(Cell cell, string Custom)
            {
                Style style = cell.GetStyle();
                style.Custom = Custom;
                cell.SetStyle(style);
            }

            public static void HorizontalAlignment(Cell cell, TextAlignmentType horizonltal_alignment)
            {
                Style style = cell.GetStyle();
                style.HorizontalAlignment = horizonltal_alignment;
                cell.SetStyle(style);
            }

            public static void TextDirection(Cell cell, TextDirectionType text_direction)
            {
                Style style = cell.GetStyle();
                style.TextDirection = text_direction;
                cell.SetStyle(style);
            }
        }
    }
}
