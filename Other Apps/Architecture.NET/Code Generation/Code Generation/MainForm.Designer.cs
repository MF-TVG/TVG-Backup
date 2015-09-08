namespace Code_Generation
{
    partial class frmCodeGeneration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.txtRootNamespace = new System.Windows.Forms.TextBox();
            this.lblRootNamespace = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 107);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(12, 25);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(532, 20);
            this.txtConnectionString.TabIndex = 1;
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.AutoSize = true;
            this.lblConnectionString.Location = new System.Drawing.Point(9, 9);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(94, 13);
            this.lblConnectionString.TabIndex = 2;
            this.lblConnectionString.Text = "Connection String:";
            // 
            // txtRootNamespace
            // 
            this.txtRootNamespace.Location = new System.Drawing.Point(12, 64);
            this.txtRootNamespace.Name = "txtRootNamespace";
            this.txtRootNamespace.Size = new System.Drawing.Size(532, 20);
            this.txtRootNamespace.TabIndex = 1;
            // 
            // lblRootNamespace
            // 
            this.lblRootNamespace.AutoSize = true;
            this.lblRootNamespace.Location = new System.Drawing.Point(9, 48);
            this.lblRootNamespace.Name = "lblRootNamespace";
            this.lblRootNamespace.Size = new System.Drawing.Size(93, 13);
            this.lblRootNamespace.TabIndex = 2;
            this.lblRootNamespace.Text = "Root Namespace:";
            // 
            // frmCodeGeneration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 142);
            this.Controls.Add(this.lblRootNamespace);
            this.Controls.Add(this.lblConnectionString);
            this.Controls.Add(this.txtRootNamespace);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.btnGenerate);
            this.Name = "frmCodeGeneration";
            this.Text = "Code Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.TextBox txtRootNamespace;
        private System.Windows.Forms.Label lblRootNamespace;
    }
}

