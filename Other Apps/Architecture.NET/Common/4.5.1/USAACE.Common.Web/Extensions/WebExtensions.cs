using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USAACE.Common.Web
{
    /// <summary>
    /// A class for web-specific extension methods
    /// </summary>
    public static class WebExtensions
    {
        public static void ShowAlert(this Page page, String message)
        {
            // Cleans the message to allow single quotation marks
            String cleanMessage = message.Replace("'", "\\'");
            String script = "alert('" + cleanMessage + "');";

            // Checks if the handler is a Page and that the script isn't already on the Page
            page.ClientScript.RegisterStartupScriptIfNeeded("alert", script);
        }

        /// <summary>
        /// Sets the checked value of all nodes to the specified value
        /// </summary>
        /// <param name="nodes">The nodes to set</param>
        /// <param name="value">The value to set</param>
        public static void SetAll(this TreeNodeCollection nodes, Boolean value)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.ShowCheckBox == true)
                {
                    node.Checked = value;
                }

                node.ChildNodes.SetAll(value);
            }
        }

        /// <summary>
        /// Sets the selected value of all list items to the specified value
        /// </summary>
        /// <param name="control">The ListControl to set the value to</param>
        /// <param name="value">The value to set</param>
        public static void SetAll(this ListControl control, Boolean value)
        {
            foreach (ListItem item in control.Items)
            {
                item.Selected = value;
            }
        }

        /// <summary>
        /// Recursively gets all nodes for a TreeView
        /// </summary>
        /// <param name="tree">The TreeView to get the nodes for</param>
        /// <returns>A list of all nodes for the TreeView</returns>
        public static IList<TreeNode> GetAllNodes(this TreeView tree)
        {
            IList<TreeNode> nodes = new List<TreeNode>();

            foreach (TreeNode node in tree.Nodes)
            {
                nodes.Add(node);

                foreach (TreeNode subNode in node.GetAllNodes())
                {
                    nodes.Add(subNode);
                }
            }

            return nodes;
        }

        /// <summary>
        /// Recursively gets all child nodes for a TreeNode
        /// </summary>
        /// <param name="node">The TreeNode to get the nodes for</param>
        /// <returns>A list of all child nodes for the TreeNode</returns>
        public static IList<TreeNode> GetAllNodes(this TreeNode node)
        {
            IList<TreeNode> nodes = new List<TreeNode>();

            foreach (TreeNode rootNode in node.ChildNodes)
            {
                nodes.Add(rootNode);

                foreach (TreeNode subNode in rootNode.GetAllNodes())
                {
                    nodes.Add(subNode);
                }
            }

            return nodes;
        }

        public static IList<Control> GetAllChildControls(this Control control)
        {
            List<Control> controls = new List<Control>();

            controls.AddRange(control.Controls.Cast<Control>());

            foreach (Control childControl in control.Controls)
            {
                controls.AddRange(childControl.GetAllChildControls());
            }

            return controls;
        }

        public static IList<MenuItem> GetAllItems(this Menu menu)
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            foreach (MenuItem item in menu.Items)
            {
                menuItems.Add(item);

                if (item.ChildItems.Count > 0)
                {
                    menuItems.AddRange(item.GetChildItems());
                }
            }

            return menuItems;
        }

        private static IList<MenuItem> GetChildItems(this MenuItem item)
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            foreach (MenuItem childItem in item.ChildItems)
            {
                menuItems.Add(childItem);

                if (childItem.ChildItems.Count > 0)
                {
                    menuItems.AddRange(childItem.GetChildItems());
                }
            }

            return menuItems;
        }

        /// <summary>
        /// Gets all selected items for a ListControl
        /// </summary>
        /// <param name="control">The ListControl to get the selected items for</param>
        /// <returns>A list of the selected items for the Listcontrol</returns>
        public static IList<ListItem> GetSelectedItems(this ListControl control)
        {
            return control.Items.Cast<ListItem>().Where(x => x.Selected).ToList();
        }

        public static void BindBooleanListControl(this ListControl control, String trueText, String falseText)
        {
            control.Items.Clear();

            control.Items.Add(new ListItem(trueText, Boolean.TrueString));
            control.Items.Add(new ListItem(falseText, Boolean.FalseString));
        }

        public static void BindBooleanListControl(this ListControl control, String trueText, String falseText, String noneText)
        {
            control.Items.Clear();

            control.Items.Add(new ListItem(trueText, Boolean.TrueString));
            control.Items.Add(new ListItem(falseText, Boolean.FalseString));
            control.Items.Add(new ListItem(noneText, String.Empty));
        }

        /// <summary>
        /// Wraps a control in a panel
        /// </summary>
        /// <param name="control">The control to wrap in a panel</param>
        /// <returns>The control wrapped in a panel</returns>
        public static Control WrapInPanel(this Control control)
        {
            Panel panel = new Panel();
            panel.Controls.Add(control);
            return panel;
        }

        /// <summary>
        /// Registers a client script by checking if the script is already registered and registering only if not already there
        /// </summary>
        /// <param name="clientScript">The ClientScriptManager of the page</param>
        /// <param name="key">The key of the script to register</param>
        /// <param name="url">The URL of the script to register</param>
        public static void RegisterClientScriptIfNeeded(this ClientScriptManager clientScript, String key, String url)
        {
            if (!clientScript.IsClientScriptIncludeRegistered(key))
            {
                clientScript.RegisterClientScriptInclude(key, url);
            }
        }

        /// <summary>
        /// Registers a startup script by checking if the script is already registered and registering only if not already there
        /// </summary>
        /// <param name="clientScript">The ClientScriptManager of the page</param>
        /// <param name="key">The key of the script to register</param>
        /// <param name="url">The URL of the script to register</param>
        public static void RegisterStartupScriptIfNeeded(this ClientScriptManager clientScript, String key, String script)
        {
            if (!clientScript.IsStartupScriptRegistered(key))
            {
                clientScript.RegisterStartupScript(typeof(Page), key, script, true);
            }
        }
    }
}
