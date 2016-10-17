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
            this.Rejsebox = new System.Windows.Forms.RichTextBox();
            this.Afbudsbox = new System.Windows.Forms.RichTextBox();
            this.Fjernetrejsebox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AfbudsClear = new System.Windows.Forms.Button();
            this.RejseClear = new System.Windows.Forms.Button();
            this.FjernerClear = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Rejsebox
            // 
            this.Rejsebox.Location = new System.Drawing.Point(18, 235);
            this.Rejsebox.Name = "Rejsebox";
            this.Rejsebox.Size = new System.Drawing.Size(300, 208);
            this.Rejsebox.TabIndex = 0;
            this.Rejsebox.Text = "";
            // 
            // Afbudsbox
            // 
            this.Afbudsbox.Location = new System.Drawing.Point(324, 235);
            this.Afbudsbox.Name = "Afbudsbox";
            this.Afbudsbox.Size = new System.Drawing.Size(325, 208);
            this.Afbudsbox.TabIndex = 1;
            this.Afbudsbox.Text = "";
            this.Afbudsbox.TextChanged += new System.EventHandler(this.Afbudsbox_TextChanged);
            // 
            // Fjernetrejsebox
            // 
            this.Fjernetrejsebox.Location = new System.Drawing.Point(655, 235);
            this.Fjernetrejsebox.Name = "Fjernetrejsebox";
            this.Fjernetrejsebox.Size = new System.Drawing.Size(353, 208);
            this.Fjernetrejsebox.TabIndex = 2;
            this.Fjernetrejsebox.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(678, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "SEND";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(85, 101);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(237, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(687, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(376, 101);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(264, 21);
            this.comboBox2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(386, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "label5";
            // 
            // AfbudsClear
            // 
            this.AfbudsClear.Location = new System.Drawing.Point(472, 206);
            this.AfbudsClear.Name = "AfbudsClear";
            this.AfbudsClear.Size = new System.Drawing.Size(75, 23);
            this.AfbudsClear.TabIndex = 11;
            this.AfbudsClear.Text = "CLEAR";
            this.AfbudsClear.UseVisualStyleBackColor = true;
            this.AfbudsClear.Click += new System.EventHandler(this.button2_Click);
            // 
            // RejseClear
            // 
            this.RejseClear.Location = new System.Drawing.Point(132, 205);
            this.RejseClear.Name = "RejseClear";
            this.RejseClear.Size = new System.Drawing.Size(75, 23);
            this.RejseClear.TabIndex = 12;
            this.RejseClear.Text = "CLEAR";
            this.RejseClear.UseVisualStyleBackColor = true;
            this.RejseClear.Click += new System.EventHandler(this.button3_Click);
            // 
            // FjernerClear
            // 
            this.FjernerClear.Location = new System.Drawing.Point(795, 206);
            this.FjernerClear.Name = "FjernerClear";
            this.FjernerClear.Size = new System.Drawing.Size(75, 23);
            this.FjernerClear.TabIndex = 13;
            this.FjernerClear.Text = "CLEAR";
            this.FjernerClear.UseVisualStyleBackColor = true;
            this.FjernerClear.Click += new System.EventHandler(this.button4_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(472, 142);
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
            this.ClientSize = new System.Drawing.Size(1024, 455);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.FjernerClear);
            this.Controls.Add(this.RejseClear);
            this.Controls.Add(this.AfbudsClear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Fjernetrejsebox);
            this.Controls.Add(this.Afbudsbox);
            this.Controls.Add(this.Rejsebox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Rejsebox;
        private System.Windows.Forms.RichTextBox Afbudsbox;
        private System.Windows.Forms.RichTextBox Fjernetrejsebox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AfbudsClear;
        private System.Windows.Forms.Button RejseClear;
        private System.Windows.Forms.Button FjernerClear;
        private System.Windows.Forms.Button Start;
    }
}

