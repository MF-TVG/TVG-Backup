using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USAACE.Common.Web.Controls
{
    public class RepeaterListControl : Repeater
    {
        private ITemplate _emptyDataTemplate = null;

        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate EmptyDataTemplate
        {
            get
            {
                return _emptyDataTemplate;
            }
            set
            {
                _emptyDataTemplate = value;
            }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            CheckEmptyTemplate();
        }

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            CheckEmptyTemplate();
        }

        protected override void OnItemDataBound(RepeaterItemEventArgs e)
        {
            foreach (Control control in e.Item.Controls)
            {
                if (control is WebControl)
                {
                    (control as WebControl).Enabled = this.Enabled;
                }
            }

            base.OnItemDataBound(e);
        }

        /// <summary>
        /// Gets or sets the name of the command.
        /// </summary>
        /// <value>The name of the command.</value>
        public Boolean Enabled
        {
            get
            {
                return this.ViewState["Enabled"] as Nullable<Boolean> != false;
            }
            set
            {
                this.ViewState["Enabled"] = value;
            }
        }

        private void CheckEmptyTemplate()
        {
            if (this.Items.Count == 0 && EmptyDataTemplate != null)
            {
                EmptyDataTemplate.InstantiateIn(this);
            }
        }
    }
}