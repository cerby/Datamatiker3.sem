namespace Klient
{
    partial class Form1
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
            this.BUTFindRejse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RICHTXTrutepris = new System.Windows.Forms.RichTextBox();
            this.COMBOdestination = new System.Windows.Forms.ComboBox();
            this.COMBOafrejse = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BUTFindRejse
            // 
            this.BUTFindRejse.Location = new System.Drawing.Point(275, 267);
            this.BUTFindRejse.Name = "BUTFindRejse";
            this.BUTFindRejse.Size = new System.Drawing.Size(75, 23);
            this.BUTFindRejse.TabIndex = 3;
            this.BUTFindRejse.Text = "Find Rejse";
            this.BUTFindRejse.UseVisualStyleBackColor = true;
            this.BUTFindRejse.Click += new System.EventHandler(this.BUTFindRejse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rute og pris";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Afrejse by";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Destination";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "__";
            // 
            // RICHTXTrutepris
            // 
            this.RICHTXTrutepris.Location = new System.Drawing.Point(47, 153);
            this.RICHTXTrutepris.Name = "RICHTXTrutepris";
            this.RICHTXTrutepris.ReadOnly = true;
            this.RICHTXTrutepris.Size = new System.Drawing.Size(303, 108);
            this.RICHTXTrutepris.TabIndex = 11;
            this.RICHTXTrutepris.Text = "";
            // 
            // COMBOdestination
            // 
            this.COMBOdestination.FormattingEnabled = true;
            this.COMBOdestination.Items.AddRange(new object[] {
            "Berlin",
            "Dublin",
            "Koebenhavn",
            "London",
            "Oslo",
            "Paris",
            "Rom",
            "Stockholm"});
            this.COMBOdestination.Location = new System.Drawing.Point(228, 89);
            this.COMBOdestination.Name = "COMBOdestination";
            this.COMBOdestination.Size = new System.Drawing.Size(121, 21);
            this.COMBOdestination.Sorted = true;
            this.COMBOdestination.TabIndex = 2;
            // 
            // COMBOafrejse
            // 
            this.COMBOafrejse.FormattingEnabled = true;
            this.COMBOafrejse.Items.AddRange(new object[] {
            "Berlin",
            "Dublin",
            "Koebenhavn",
            "London",
            "Oslo",
            "Paris",
            "Rom",
            "Stockholm"});
            this.COMBOafrejse.Location = new System.Drawing.Point(47, 89);
            this.COMBOafrejse.Name = "COMBOafrejse";
            this.COMBOafrejse.Size = new System.Drawing.Size(121, 21);
            this.COMBOafrejse.Sorted = true;
            this.COMBOafrejse.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 329);
            this.Controls.Add(this.COMBOafrejse);
            this.Controls.Add(this.COMBOdestination);
            this.Controls.Add(this.RICHTXTrutepris);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BUTFindRejse);
            this.Name = "Form1";
            this.Text = "FlyRejseSøge";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BUTFindRejse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox RICHTXTrutepris;
        private System.Windows.Forms.ComboBox COMBOdestination;
        private System.Windows.Forms.ComboBox COMBOafrejse;
    }
}

