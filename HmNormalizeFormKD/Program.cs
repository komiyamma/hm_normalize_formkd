using System.Runtime.InteropServices;
using System.Text;



[Guid("A5DCE2E1-B5F1-4FB0-AF2B-38FBC22E80E8")]
public class HmNormalizeFormKD
{
    public string NormalizeKD(string str)
    {
        return str.Normalize(NormalizationForm.FormKD);
    }

    public string NormalizeD(string str)
    {
        return str.Normalize(NormalizationForm.FormD);
    }

}

