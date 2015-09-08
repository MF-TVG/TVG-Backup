using AjaxControlToolkit;
using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USAACE.Common.Web.Controls
{
    [ValidationProperty("PlainText")]
    public class HTMLEditor : CompositeControl
    {
        private TextBox _textBox;
        private HtmlEditorExtender _htmlExtender;

        public String Text
        {
            get
            {
                EnsureChildControls();
                return HttpUtility.HtmlDecode(_textBox.Text);
            }
            set
            {
                EnsureChildControls();
                _textBox.Text = HttpUtility.HtmlEncode(value);
            }
        }

        public Int32 MaxLength
        {
            get
            {
                EnsureChildControls();
                return _textBox.MaxLength;
            }
            set
            {
                EnsureChildControls();
                _textBox.MaxLength = value;
            }
        }

        public String PlainText
        {
            get
            {
                if (this.Text == null)
                {
                    return null;
                }
                else
                {
                    Regex htmlRegex = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
                    return htmlRegex.Replace(this.Text.Replace("&nbsp;", " "), String.Empty).Trim();
                }
            }
        }

        public override Int16 TabIndex
        {
            get
            {
                EnsureChildControls();
                return _textBox.TabIndex;
            }
            set
            {
                EnsureChildControls();
                _textBox.TabIndex = value;
            }
        }

        public override Unit Height
        {
            get
            {
                EnsureChildControls();
                return _textBox.Height;
            }
            set
            {
                EnsureChildControls();
                _textBox.Height = value;
            }
        }

        protected override void RecreateChildControls()
        {
            EnsureChildControls();
        }

        protected override void CreateChildControls()
        {
            _textBox = new TextBox();
            _textBox.TabIndex = this.TabIndex;
            _textBox.ID = this.ID + "TextBox";

            _htmlExtender = new HtmlEditorExtender();
            _htmlExtender.ID = this.ID + "HTMLExtender";
            _htmlExtender.TargetControlID = _textBox.ID;
            _htmlExtender.EnableSanitization = false;
            _htmlExtender.DisplaySourceTab = false;
            _htmlExtender.Toolbar.Add(new Bold());
            _htmlExtender.Toolbar.Add(new Italic());
            _htmlExtender.Toolbar.Add(new Underline());
            _htmlExtender.Toolbar.Add(new StrikeThrough());
            _htmlExtender.Toolbar.Add(new Cut());
            _htmlExtender.Toolbar.Add(new Copy());
            _htmlExtender.Toolbar.Add(new Paste());
            _htmlExtender.Toolbar.Add(new ForeColorSelector());
            _htmlExtender.Toolbar.Add(new FontNameSelector());
            _htmlExtender.Toolbar.Add(new FontSizeSelector());

            this.Controls.Add(_textBox);
            this.Controls.Add(_htmlExtender);

            this.ChildControlsCreated = true;
        }

        protected override void Render(HtmlTextWriter output)
        {
            if (Page.IsPostBack)
            {
                _textBox.Text = HttpUtility.HtmlDecode(_textBox.Text);
            }

            if (this.Enabled == false)
            {
                output.Write(this.Text);
            }
            else
            {
                _textBox.RenderControl(output);
                _htmlExtender.RenderControl(output);
            }
        }
    }
}
