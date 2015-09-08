using AjaxControlToolkit;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USAACE.Common.Web.Controls
{
    [ParseChildren(false)]
    [PersistChildren(true)]
    public class ModalPopup : CompositeControl
    {
        private Button _falseTrigger;
        private Button _falseOk;
        private Panel _panel;
        private ModalPopupExtender _modalExtender;

        public String BackgroundCssClass { get; set; }

        /// <summary>
        /// Gets or sets the command argument.
        /// </summary>
        /// <value>The command argument.</value>
        private Boolean ShowDialog
        {
            get
            {
                return this.ViewState["ShowDialog"] as String == "1";
            }
            set
            {
                this.ViewState["ShowDialog"] = value ? "1" : "0";
            }
        }

        public void Show()
        {
            EnsureChildControls();
            this.ShowDialog = true;
        }

        public void Hide()
        {
            EnsureChildControls();
            this.ShowDialog = false;
        }

        protected override void RecreateChildControls()
        {
            EnsureChildControls();
        }

        protected override void CreateChildControls()
        {
            _panel = new Panel();
            _panel.ID = this.ID + "Panel";
            _panel.CssClass = this.CssClass;

            if (!this.ShowDialog)
            {
                _panel.Style.Add(HtmlTextWriterStyle.Display, "none");
            }

            _falseTrigger = new Button();
            _falseTrigger.Style.Add(HtmlTextWriterStyle.Display, "none");
            _falseTrigger.ID = this.ID + "TriggerButton";

            _falseOk = new Button();
            _falseOk.Style.Add(HtmlTextWriterStyle.Display, "none");
            _falseOk.ID = this.ID + "OKButton";

            _modalExtender = new ModalPopupExtender();
            _modalExtender.ID = this.ID + "ModalExtender";
            _modalExtender.TargetControlID = _falseTrigger.ID;
            _modalExtender.OkControlID = _falseOk.ID;
            _modalExtender.CancelControlID = _falseOk.ID;
            _modalExtender.PopupControlID = _panel.ID;
            _modalExtender.BackgroundCssClass = this.BackgroundCssClass;
            _modalExtender.DropShadow = true;
            _modalExtender.RepositionMode = ModalPopupRepositionMode.RepositionOnWindowResizeAndScroll;
            _modalExtender.ViewStateMode = ViewStateMode.Enabled;

            this.Controls.Add(_falseTrigger);
            this.Controls.Add(_panel);
            this.Controls.Add(_falseOk);
            this.Controls.Add(_modalExtender);

            this.ChildControlsCreated = true;
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (this.ShowDialog)
            {
                _modalExtender.Show();
            }
            else
            {
                _modalExtender.Hide();
            }

            base.OnPreRender(e);
        }

        protected override void Render(HtmlTextWriter output)
        {
            _falseTrigger.RenderControl(output);
            _falseOk.RenderControl(output);
            _panel.RenderBeginTag(output);

            foreach (Control control in this.Controls)
            {
                if (control != _falseTrigger && control != _falseOk && control != _panel && control != _modalExtender)
                {
                    control.RenderControl(output);
                }
            }

            _panel.RenderEndTag(output);
            _modalExtender.RenderControl(output);
        }
    }
}
