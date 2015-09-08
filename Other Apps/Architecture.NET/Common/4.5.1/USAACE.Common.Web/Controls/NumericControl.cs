using AjaxControlToolkit;
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;

namespace USAACE.Common.Web.Controls
{
    [ValidationProperty("Value")]
    public class NumericControl : CompositeControl
    {
        private TextBox _textBox;
        private MaskedEditExtender _maskedExtender;

        public Object Value
        {
            get
            {
                EnsureChildControls();
                return _textBox.Text;
            }
            set
            {
                EnsureChildControls();
                _textBox.Text = value.ToStringSafe();
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

        public override Unit Width
        {
            get
            {
                EnsureChildControls();
                return _textBox.Width;
            }
            set
            {
                EnsureChildControls();
                _textBox.Width = value;
            }
        }

        public String TextBoxCssClass
        {
            get
            {
                EnsureChildControls();
                return _textBox.CssClass;
            }
            set
            {
                EnsureChildControls();
                _textBox.CssClass = value;
            }
        }

        public String Mask
        {
            get
            {
                EnsureChildControls();
                return _maskedExtender.Mask;
            }
            set
            {
                EnsureChildControls();
                _maskedExtender.Mask = value;
            }
        }

        [DefaultValue("_")]
        public String PromptCharacter
        {
            get
            {
                EnsureChildControls();
                return _maskedExtender.PromptCharacter;
            }
            set
            {
                EnsureChildControls();
                _maskedExtender.PromptCharacter = value;
            }
        }

        [DefaultValue(true)]
        public Boolean ClearMaskOnLostFocus
        {
            get
            {
                EnsureChildControls();
                return _maskedExtender.ClearMaskOnLostFocus;
            }
            set
            {
                EnsureChildControls();
                _maskedExtender.ClearMaskOnLostFocus = value;
            }
        }

        [DefaultValue(MaskedEditType.Number)]
        public MaskedEditType MaskType
        {
            get
            {
                EnsureChildControls();
                return _maskedExtender.MaskType;
            }
            set
            {
                EnsureChildControls();
                _maskedExtender.MaskType = value;
            }
        }

        [DefaultValue(MaskedEditShowSymbol.None)]
        public MaskedEditShowSymbol AcceptNegative
        {
            get
            {
                EnsureChildControls();
                return _maskedExtender.AcceptNegative;
            }
            set
            {
                EnsureChildControls();
                _maskedExtender.AcceptNegative = value;
            }
        }

        protected override void RecreateChildControls()
        {
            EnsureChildControls();
        }

        protected override void CreateChildControls()
        {
            _textBox = new TextBox();
            _textBox.Attributes.Add("onfocus", "var textcontrol = this; setTimeout(function () { textcontrol.select(); }, 50);");
            _textBox.ID = this.ID + "TextBox";

            _maskedExtender = new MaskedEditExtender();
            _maskedExtender.ID = this.ID + "MaskedExtender";
            _maskedExtender.TargetControlID = _textBox.ID;
            _maskedExtender.ClearTextOnInvalid = true;
            _maskedExtender.InputDirection = MaskedEditInputDirection.RightToLeft;
            _maskedExtender.Filtered = ".";

            this.Controls.Add(_textBox);
            this.Controls.Add(_maskedExtender);

            this.ChildControlsCreated = true;
        }

        protected override void Render(HtmlTextWriter output)
        {
            if (base.Enabled == true)
            {
                if (!String.IsNullOrEmpty(this.PromptCharacter) && this.ClearMaskOnLostFocus == true)
                {
                    _textBox.Attributes.Add("onblur", String.Format("var textcontrol = this; setTimeout(function () {{ textcontrol.value = textcontrol.value.replace(new RegExp('{0}', 'g'), ''); }}, 50);", this.PromptCharacter));
                }

                _textBox.RenderControl(output);
                _maskedExtender.RenderControl(output);
            }
            else
            {
                output.Write(_textBox.Text);
            }
        }
    }
}
