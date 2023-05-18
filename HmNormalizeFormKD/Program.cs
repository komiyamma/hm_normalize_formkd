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

            // BoldとかItalicとか色々あるかもしらんが、最初の１個しか使わない
            // 入ってる文字リストが違うなんてことは先ず無いので最初のTypeFaceだけ
            foreach (var typeface in fontFamily.GetTypefaces())
            {
                string sum = "";
                GlyphTypeface gTypeface;
                if (!typeface.TryGetGlyphTypeface(out gTypeface))
                {
                    return "TryGetGlyphTypeface Error";
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
                        try
                        {
                            // 完全互換分解を試みる
                            sum += temp.Normalize(NormalizationForm.FormKD);
                        }
                        catch (Exception ex)
                        {
                            sum += chr;
                        }
                    }
                }

                return sum;
            }

            return "Error";
        }
        catch (Exception ex)
        {
            Trace.WriteLine(ex);
        }
        return "Error";
    }
}

