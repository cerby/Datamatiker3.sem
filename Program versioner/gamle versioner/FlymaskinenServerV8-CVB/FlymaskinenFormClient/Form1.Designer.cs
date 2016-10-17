namespace FlymaskinenFormClient
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
            this.Afbudsbox = new System.Windows.Forms.RichTextBox();
            this.Fjernetrejsebox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AfbudsClear = new System.Windows.Forms.Button();
            this.FjernerClear = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Afbudsbox
            // 
            this.Afbudsbox.Location = new System.Drawing.Point(8, 105);
            this.Afbudsbox.Name = "Afbudsbox";
            this.Afbudsbox.Size = new System.Drawing.Size(325, 208);
            this.Afbudsbox.TabIndex = 1;
            this.Afbudsbox.Text = "";
            // 
            // Fjernetrejsebox
            // 
            this.Fjernetrejsebox.Location = new System.Drawing.Point(339, 105);
            this.Fjernetrejsebox.Name = "Fjernetrejsebox";
            this.Fjernetrejsebox.Size = new System.Drawing.Size(353, 208);
            this.Fjernetrejsebox.TabIndex = 2;
            this.Fjernetrejsebox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // AfbudsClear
            // 
            this.AfbudsClear.Location = new System.Drawing.Point(156, 76);
            this.AfbudsClear.Name = "AfbudsClear";
            this.AfbudsClear.Size = new System.Drawing.Size(75, 23);
            this.AfbudsClear.TabIndex = 11;
            this.AfbudsClear.Text = "CLEAR";
            this.AfbudsClear.UseVisualStyleBackColor = true;
            this.AfbudsClear.Click += new System.EventHandler(this.button2_Click);
            // 
            // FjernerClear
            // 
            this.FjernerClear.Location = new System.Drawing.Point(479, 76);
            this.FjernerClear.Name = "FjernerClear";
            this.FjernerClear.Size = new System.Drawing.Size(75, 23);
            this.FjernerClear.TabIndex = 13;
            this.FjernerClear.Text = "CLEAR";
            this.FjernerClear.UseVisualStyleBackColor = true;
            this.FjernerClear.Click += new System.EventHandler(this.button4_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(304, 22);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 14;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 338);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.FjernerClear);
            this.Controls.Add(this.AfbudsClear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Fjernetrejsebox);
            this.Controls.Add(this.Afbudsbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Afbudsbox;
        private System.Windows.Forms.RichTextBox Fjernetrejsebox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AfbudsClear;
        private System.Windows.Forms.Button FjernerClear;
        private System.Windows.Forms.Button Start;
    }
}

