﻿using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USAACE.Common.Web.Controls
{
    [ValidationProperty("SelectedItem")]
    public class ComboBoxControl : ComboBox
    {
        protected override void Render(HtmlTextWriter output)
        {
            if (base.Enabled == true)
            {
                base.DropDownStyle = ComboBoxStyle.DropDownList;
                base.AutoCompleteMode = ComboBoxAutoCompleteMode.SuggestAppend;
                base.Render(output);
            }
            else
            {
                output.Write(base.SelectedItem != null ? base.SelectedItem.Text : String.Empty);
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
                String commandName = ViewState["CommandName"] as String;
                return commandName ?? "";
            }
            set
            {
                ViewState["CommandName"] = value;
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
                String commandArgument = ViewState["CommandArgument"] as String;
                return commandArgument ?? "";
            }
            set
            {
                ViewState["CommandArgument"] = value;
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
