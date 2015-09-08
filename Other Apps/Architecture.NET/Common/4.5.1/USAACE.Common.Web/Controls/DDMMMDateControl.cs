using AjaxControlToolkit;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;

namespace USAACE.Common.Web.Controls
{
    [ValidationProperty("SelectedDate")]
    public class DDMMMDateControl : CompositeControl
    {
        private TextBox _textBox;
        private Image _calendarImage;
        private CalendarExtender _calendarExtender;
        private MaskedEditExtender _maskedExtender;

        /// <summary>
        /// The selected date of the control
        /// </summary>
        public Nullable<DateTime> SelectedDate
        {
            get
            {
                EnsureChildControls();
                return _textBox.Text.TryParseDateExact("dd-MMM-yyyy");
                //return _textBox.Text.TryParseDateExact("yyyy-MM-dd");
            }
            set
            {
                EnsureChildControls();
                _textBox.Text = value.ToDateStringSafe("dd-MMM-yyyy");
                //_textBox.Text = value.ToDateStringSafe("yyyy-MM-dd");
            }
        }

        public String ImageUrl
        {
            get
            {
                EnsureChildControls();
                return _calendarImage.ImageUrl;
            }
            set
            {
                EnsureChildControls();
                _calendarImage.ImageUrl = value;
            }
        }

        public String ImageCssClass
        {
            get
            {
                EnsureChildControls();
                return _calendarImage.CssClass;
            }
            set
            {
                EnsureChildControls();
                _calendarImage.CssClass = value;
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

        protected override void RecreateChildControls()
        {
            EnsureChildControls();
        }

        protected override void CreateChildControls()
        {
            _textBox = new TextBox();
            _textBox.Attributes.Add("onfocus", "var textcontrol = this; setTimeout(function () { textcontrol.select(); }, 50);");
            _textBox.ID = this.ID + "TextBox";

            _calendarImage = new Image();
            _calendarImage.ID = this.ID + "CalendarImage";
            _calendarImage.Style.Add(HtmlTextWriterStyle.Cursor, "pointer");
            _calendarImage.ImageUrl = "~/images/calendar.png";

            if (String.IsNullOrEmpty(_calendarImage.CssClass))
            {
                _calendarImage.CssClass = "dateControlImage";
            }

            _calendarExtender = new CalendarExtender();
            _calendarExtender.ID = this.ID + "CalendarExtender";
            _calendarExtender.TargetControlID = _textBox.ID;
            _calendarExtender.PopupButtonID = _calendarImage.ID;
            _calendarExtender.Format = "dd-MMM-yyyy";
            //_calendarExtender.Format = "yyyy-MM-dd";

            _maskedExtender = new MaskedEditExtender();
            _maskedExtender.ID = this.ID + "MaskedExtender";
            _maskedExtender.TargetControlID = _textBox.ID;
            //_maskedExtender.Mask = "99-99-9999";
            //_maskedExtender.Mask = "9999-99-99";
            _maskedExtender.MaskType = MaskedEditType.None;
            _maskedExtender.InputDirection = MaskedEditInputDirection.LeftToRight;
            _maskedExtender.ClearTextOnInvalid = true;
            _maskedExtender.ClearMaskOnLostFocus = false;

            this.Controls.Add(_textBox);
            this.Controls.Add(_calendarImage);
            this.Controls.Add(_calendarExtender);
            this.Controls.Add(_maskedExtender);

            this.ChildControlsCreated = true;
        }

        protected override void Render(HtmlTextWriter output)
        {
            if (base.Enabled == true)
            {
                _textBox.RenderControl(output);
                _calendarImage.RenderControl(output);
                _calendarExtender.RenderControl(output);
                // _maskedExtender.RenderControl(output);
            }
            else
            {
                output.Write(_textBox.Text);
            }
        }
    }
}

