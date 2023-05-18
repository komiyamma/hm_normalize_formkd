using System.Diagnostics;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Media;

[Guid("A5DCE2E1-B5F1-4FB0-AF2B-38FBC22E80E8")]
public class HmNormalizeFormKD
{
    public string Normalize(string str, string fontname)
    {
        try
        {
            var fontFamily = new System.Windows.Media.FontFamily(fontname);
            foreach (var typeface in fontFamily.GetTypefaces())
            {
                string sum = "";
                GlyphTypeface gTypeface;
                if (!typeface.TryGetGlyphTypeface(out gTypeface))
                {
                    return "Error";
                }

                var chars = str.ToCharArray();
                foreach (var chr in chars)
                {
                    if (gTypeface.CharacterToGlyphMap.ContainsKey(chr))
                    {
                        sum += chr;
                    }

                    else
                    {
                        string temp = chr + "";
                        sum += temp.Normalize(NormalizationForm.FormKD);
                    }
                }

                return sum;
            }

            return "Error";
        } catch(Exception ex)
        {
            Trace.WriteLine(ex);
        }
        return "Error";
    }
}

