using System.Web.UI;
using System.Web.UI.WebControls;

namespace USAACE.Common.Web.Controls
{
    [ValidationProperty("Text")]
    public class TextControl : TextBox
    {
        protected override void Render(HtmlTextWriter output)
        {
            if (base.Enabled == true)
            {
                base.Render(output);
            }
            else
            {
                output.Write(base.Text);
            }
        }
    }
}
