using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USAACE.Common.Web.Controls
{
    [ValidationProperty("SelectedItem")]
    public class CheckBoxListControl : CheckBoxList
    {
        protected override void Render(HtmlTextWriter output)
        {
            if (base.Enabled == true)
            {
                base.Render(output);
            }
            else
            {
                IList<ListItem> selectedItems = this.GetSelectedItems();

                if (selectedItems.Count > 0)
                {
                    output.Write(String.Join("; ", selectedItems.Select(x => x.Text)));
                }
            }
        }

        /// <summary>
        /// Object which acts as key for the Command event
        /// </summary>
        private static readonly Object EventCommand = new Object();

        /// <summary>
        /// Occurs when [command].
        /// </summary>
        public event CommandEventHandler Command
        {
            add { Events.AddHandler(EventCommand, value); }
            remove { Events.RemoveHandler(EventCommand, value); }
        }

        /// <summary>
        /// Raises the <see cref="E:Command"/> event.
        /// </summary>
        /// <param name="eventArgs">The <see cref="System.Web.UI.WebControls.CommandEventArgs"/> instance containing 
        ///the event data.</param>
        protected virtual void OnCommand(CommandEventArgs eventArgs)
        {
            //Command event can be attached for this control from outside
            //and hence that attached method needs to be executed
            CommandEventHandler commandEventHandler = Events[EventCommand] as CommandEventHandler;

            if (commandEventHandler != null)
            {
                commandEventHandler(this, eventArgs);
            }

            //Bubble up this event so that the base control ItemCommand event can be fired
            base.RaiseBubbleEvent(this, eventArgs);
        }

        /// <summary>
        /// Gets or sets the name of the command.
        /// </summary>
        /// <value>The name of the command.</value>
        public String CommandName
        {
            get
            {
                return this.ViewState["CommandName"] as String ?? "";
            }
            set
            {
                this.ViewState["CommandName"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the command argument.
        /// </summary>
        /// <value>The command argument.</value>
        public String CommandArgument
        {
            get
            {
                return this.ViewState["CommandArgument"] as String ?? "";
            }
            set
            {
                this.ViewState["CommandArgument"] = value;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.WebControls.ListControl.SelectedIndexChanged"/> event. This allows you to 
        /// provide a custom handler for the event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);

            if (AutoPostBack)
            {
                CommandEventArgs commandEventArgs = new CommandEventArgs(this.CommandName, this.CommandArgument);
                OnCommand(commandEventArgs);
            }
        }
    }
}
