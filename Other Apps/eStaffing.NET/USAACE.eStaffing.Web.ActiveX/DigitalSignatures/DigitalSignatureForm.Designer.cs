namespace USAACE.eStaffing.Web.ActiveX.DigitalSignatures
{
    partial class DigitalSignatureForm
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
            this.lblDisclaimer = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.lnkChooseCertificate = new System.Windows.Forms.LinkLabel();
            this.grpSelectedCertificate = new System.Windows.Forms.GroupBox();
            this.lblCertificateName = new System.Windows.Forms.Label();
            this.lblCertificateNameValue = new System.Windows.Forms.Label();
            this.lblIssuerName = new System.Windows.Forms.Label();
            this.lblIssuerNameValue = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.grpSelectedCertificate.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDisclaimer
            // 
            this.lblDisclaimer.AutoSize = true;
            this.lblDisclaimer.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisclaimer.Location = new System.Drawing.Point(9, 9);
            this.lblDisclaimer.Name = "lblDisclaimer";
            this.lblDisclaimer.Size = new System.Drawing.Size(481, 32);
            this.lblDisclaimer.TabIndex = 0;
            this.lblDisclaimer.Text = "This signature is legally binding and constitutes concurrence with\r\nthe respectiv" +
    "e document.";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(452, 238);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSign
            // 
            this.btnSign.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSign.Location = new System.Drawing.Point(371, 238);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(75, 27);
            this.btnSign.TabIndex = 3;
            this.btnSign.Text = "Sign";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // lnkChooseCertificate
            // 
            this.lnkChooseCertificate.AutoSize = true;
            this.lnkChooseCertificate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkChooseCertificate.Location = new System.Drawing.Point(12, 122);
            this.lnkChooseCertificate.Name = "lnkChooseCertificate";
            this.lnkChooseCertificate.Size = new System.Drawing.Size(158, 16);
            this.lnkChooseCertificate.TabIndex = 4;
            this.lnkChooseCertificate.TabStop = true;
            this.lnkChooseCertificate.Text = "Choose a Certificate...";
            this.lnkChooseCertificate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkChooseCertificate_LinkClicked);
            // 
            // grpSelectedCertificate
            // 
            this.grpSelectedCertificate.Controls.Add(this.lblIssuerName);
            this.grpSelectedCertificate.Controls.Add(this.lblIssuerNameValue);
            this.grpSelectedCertificate.Controls.Add(this.lblCertificateNameValue);
            this.grpSelectedCertificate.Controls.Add(this.lblCertificateName);
            this.grpSelectedCertificate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSelectedCertificate.Location = new System.Drawing.Point(15, 141);
            this.grpSelectedCertificate.Name = "grpSelectedCertificate";
            this.grpSelectedCertificate.Size = new System.Drawing.Size(512, 91);
            this.grpSelectedCertificate.TabIndex = 5;
            this.grpSelectedCertificate.TabStop = false;
            // 
            // lblCertificateName
            // 
            this.lblCertificateName.AutoSize = true;
            this.lblCertificateName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCertificateName.Location = new System.Drawing.Point(6, 19);
            this.lblCertificateName.Name = "lblCertificateName";
            this.lblCertificateName.Size = new System.Drawing.Size(124, 16);
            this.lblCertificateName.TabIndex = 0;
            this.lblCertificateName.Text = "Certificate Name:";
            // 
            // lblCertificateNameValue
            // 
            this.lblCertificateNameValue.AutoSize = true;
            this.lblCertificateNameValue.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCertificateNameValue.Location = new System.Drawing.Point(136, 19);
            this.lblCertificateNameValue.Name = "lblCertificateNameValue";
            this.lblCertificateNameValue.Size = new System.Drawing.Size(0, 16);
            this.lblCertificateNameValue.TabIndex = 1;
            // 
            // lblIssuerName
            // 
            this.lblIssuerName.AutoSize = true;
            this.lblIssuerName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssuerName.Location = new System.Drawing.Point(7, 45);
            this.lblIssuerName.Name = "lblIssuerName";
            this.lblIssuerName.Size = new System.Drawing.Size(95, 16);
            this.lblIssuerName.TabIndex = 2;
            this.lblIssuerName.Text = "Issuer Name:";
            // 
            // lblIssuerNameValue
            // 
            this.lblIssuerNameValue.AutoSize = true;
            this.lblIssuerNameValue.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssuerNameValue.Location = new System.Drawing.Point(136, 45);
            this.lblIssuerNameValue.Name = "lblIssuerNameValue";
            this.lblIssuerNameValue.Size = new System.Drawing.Size(0, 16);
            this.lblIssuerNameValue.TabIndex = 1;
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.Location = new System.Drawing.Point(12, 68);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(343, 32);
            this.lblInstructions.TabIndex = 6;
            this.lblInstructions.Text = "To sign, choose a certificate and click Sign below,\r\nor click Cancel to abort.";
            // 
            // DigitalSignatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(539, 277);
            this.ControlBox = false;
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.grpSelectedCertificate);
            this.Controls.Add(this.lnkChooseCertificate);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblDisclaimer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DigitalSignatureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "eStaffing Digital Signature";
            this.Load += new System.EventHandler(this.DigitalSignatureForm_Load);
            this.grpSelectedCertificate.ResumeLayout(false);
            this.grpSelectedCertificate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDisclaimer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.LinkLabel lnkChooseCertificate;
        private System.Windows.Forms.GroupBox grpSelectedCertificate;
        private System.Windows.Forms.Label lblCertificateNameValue;
        private System.Windows.Forms.Label lblCertificateName;
        private System.Windows.Forms.Label lblIssuerName;
        private System.Windows.Forms.Label lblIssuerNameValue;
        private System.Windows.Forms.Label lblInstructions;
    }
}