﻿namespace flymaskinenForms
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
            this.btnFindrejse = new System.Windows.Forms.Button();
            this.btnUdskrivRejser = new System.Windows.Forms.Button();
            this.BtnTilbudsrejse = new System.Windows.Forms.Button();
            this.btnLuk = new System.Windows.Forms.Button();
            this.richTextUdskrivRejse = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxResultat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFjernRejse = new System.Windows.Forms.Button();
            this.comboBoxStartBy = new System.Windows.Forms.ComboBox();
            this.comboBoxSlutBy = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFindrejse
            // 
            this.btnFindrejse.Location = new System.Drawing.Point(95, 64);
            this.btnFindrejse.Name = "btnFindrejse";
            this.btnFindrejse.Size = new System.Drawing.Size(75, 23);
            this.btnFindrejse.TabIndex = 2;
            this.btnFindrejse.Text = "Findrejse";
            this.btnFindrejse.UseVisualStyleBackColor = true;
            this.btnFindrejse.Click += new System.EventHandler(this.btnFindrejse_Click);
            // 
            // btnUdskrivRejser
            // 
            this.btnUdskrivRejser.Location = new System.Drawing.Point(84, 194);
            this.btnUdskrivRejser.Name = "btnUdskrivRejser";
            this.btnUdskrivRejser.Size = new System.Drawing.Size(111, 23);
            this.btnUdskrivRejser.TabIndex = 3;
            this.btnUdskrivRejser.Text = "Udskriv Rejser";
            this.btnUdskrivRejser.UseVisualStyleBackColor = true;
            this.btnUdskrivRejser.Click += new System.EventHandler(this.btnUdskrivRejser_Click);
            // 
            // BtnTilbudsrejse
            // 
            this.BtnTilbudsrejse.Location = new System.Drawing.Point(918, 194);
            this.BtnTilbudsrejse.Name = "BtnTilbudsrejse";
            this.BtnTilbudsrejse.Size = new System.Drawing.Size(75, 23);
            this.BtnTilbudsrejse.TabIndex = 4;
            this.BtnTilbudsrejse.Text = "Clear";
            this.BtnTilbudsrejse.UseVisualStyleBackColor = true;
            this.BtnTilbudsrejse.Click += new System.EventHandler(this.BtnTilbudsrejse_Click);
            // 
            // btnLuk
            // 
            this.btnLuk.Location = new System.Drawing.Point(918, 21);
            this.btnLuk.Name = "btnLuk";
            this.btnLuk.Size = new System.Drawing.Size(75, 23);
            this.btnLuk.TabIndex = 7;
            this.btnLuk.Text = "Luk";
            this.btnLuk.UseVisualStyleBackColor = true;
            this.btnLuk.Click += new System.EventHandler(this.btnLuk_Click);
            // 
            // richTextUdskrivRejse
            // 
            this.richTextUdskrivRejse.Location = new System.Drawing.Point(85, 223);
            this.richTextUdskrivRejse.Name = "richTextUdskrivRejse";
            this.richTextUdskrivRejse.Size = new System.Drawing.Size(321, 214);
            this.richTextUdskrivRejse.TabIndex = 9;
            this.richTextUdskrivRejse.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "By1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "By2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxResultat
            // 
            this.textBoxResultat.Location = new System.Drawing.Point(95, 155);
            this.textBoxResultat.Name = "textBoxResultat";
            this.textBoxResultat.Size = new System.Drawing.Size(357, 20);
            this.textBoxResultat.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Rejse";
            // 
            // btnFjernRejse
            // 
            this.btnFjernRejse.Location = new System.Drawing.Point(625, 197);
            this.btnFjernRejse.Name = "btnFjernRejse";
            this.btnFjernRejse.Size = new System.Drawing.Size(75, 23);
            this.btnFjernRejse.TabIndex = 16;
            this.btnFjernRejse.Text = "Clear";
            this.btnFjernRejse.UseVisualStyleBackColor = true;
            this.btnFjernRejse.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxStartBy
            // 
            this.comboBoxStartBy.FormattingEnabled = true;
            this.comboBoxStartBy.Items.AddRange(new object[] {
            "Koebenhavn",
            "Oslo",
            "Stockholm",
            "Paris",
            "London",
            "Dublin",
            "Rom",
            "Berlin"});
            this.comboBoxStartBy.Location = new System.Drawing.Point(95, 115);
            this.comboBoxStartBy.Name = "comboBoxStartBy";
            this.comboBoxStartBy.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStartBy.TabIndex = 18;
            // 
            // comboBoxSlutBy
            // 
            this.comboBoxSlutBy.FormattingEnabled = true;
            this.comboBoxSlutBy.Items.AddRange(new object[] {
            "Koebenhavn",
            "Oslo",
            "Stockholm",
            "Paris",
            "London",
            "Dublin",
            "Rom",
            "Berlin"});
            this.comboBoxSlutBy.Location = new System.Drawing.Point(229, 115);
            this.comboBoxSlutBy.Name = "comboBoxSlutBy";
            this.comboBoxSlutBy.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSlutBy.TabIndex = 19;
            this.comboBoxSlutBy.SelectedIndexChanged += new System.EventHandler(this.comboBoxSlutBy_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(446, 223);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(254, 212);
            this.listBox1.TabIndex = 20;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(749, 223);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(244, 212);
            this.listBox2.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(443, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Nedlagt rejse";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(746, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Tilbudsrejse";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(532, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(380, 154);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Location = new System.Drawing.Point(250, 66);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.TextBoxPassword.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(250, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Password";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 501);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.comboBoxSlutBy);
            this.Controls.Add(this.comboBoxStartBy);
            this.Controls.Add(this.btnFjernRejse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxResultat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextUdskrivRejse);
            this.Controls.Add(this.btnLuk);
            this.Controls.Add(this.BtnTilbudsrejse);
            this.Controls.Add(this.btnUdskrivRejser);
            this.Controls.Add(this.btnFindrejse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFindrejse;
        private System.Windows.Forms.Button btnUdskrivRejser;
        private System.Windows.Forms.Button BtnTilbudsrejse;
        private System.Windows.Forms.Button btnLuk;
        private System.Windows.Forms.RichTextBox richTextUdskrivRejse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxResultat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFjernRejse;
        private System.Windows.Forms.ComboBox comboBoxStartBy;
        private System.Windows.Forms.ComboBox comboBoxSlutBy;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.Label label6;
    }
}

