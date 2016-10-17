namespace flymaskinenForms
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
            this.btnLuk = new System.Windows.Forms.Button();
            this.richTextUdskrivRejse = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxResultat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxStartby = new System.Windows.Forms.ComboBox();
            this.comboBoxSlutby = new System.Windows.Forms.ComboBox();
            this.listBoxFjernrejser = new System.Windows.Forms.ListBox();
            this.listBoxTilbudsrejser = new System.Windows.Forms.ListBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.btnUdskrivRejser.Location = new System.Drawing.Point(85, 269);
            this.btnUdskrivRejser.Name = "btnUdskrivRejser";
            this.btnUdskrivRejser.Size = new System.Drawing.Size(111, 23);
            this.btnUdskrivRejser.TabIndex = 3;
            this.btnUdskrivRejser.Text = "Udskriv Rejser";
            this.btnUdskrivRejser.UseVisualStyleBackColor = true;
            this.btnUdskrivRejser.Click += new System.EventHandler(this.btnUdskrivRejser_Click);
            // 
            // btnLuk
            // 
            this.btnLuk.Location = new System.Drawing.Point(12, 12);
            this.btnLuk.Name = "btnLuk";
            this.btnLuk.Size = new System.Drawing.Size(75, 23);
            this.btnLuk.TabIndex = 7;
            this.btnLuk.Text = "Luk";
            this.btnLuk.UseVisualStyleBackColor = true;
            this.btnLuk.Click += new System.EventHandler(this.btnLuk_Click);
            // 
            // richTextUdskrivRejse
            // 
            this.richTextUdskrivRejse.Location = new System.Drawing.Point(85, 298);
            this.richTextUdskrivRejse.Name = "richTextUdskrivRejse";
            this.richTextUdskrivRejse.Size = new System.Drawing.Size(321, 263);
            this.richTextUdskrivRejse.TabIndex = 9;
            this.richTextUdskrivRejse.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "StartBy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Slutby";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxResultat
            // 
            this.textBoxResultat.Location = new System.Drawing.Point(95, 155);
            this.textBoxResultat.Multiline = true;
            this.textBoxResultat.Name = "textBoxResultat";
            this.textBoxResultat.Size = new System.Drawing.Size(357, 95);
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
            // comboBoxStartby
            // 
            this.comboBoxStartby.FormattingEnabled = true;
            this.comboBoxStartby.Items.AddRange(new object[] {
            "Koebenhavn",
            "Oslo",
            "Stockholm",
            "Paris",
            "London",
            "Dublin",
            "Rom",
            "Berlin"});
            this.comboBoxStartby.Location = new System.Drawing.Point(95, 115);
            this.comboBoxStartby.Name = "comboBoxStartby";
            this.comboBoxStartby.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStartby.TabIndex = 18;
            // 
            // comboBoxSlutby
            // 
            this.comboBoxSlutby.FormattingEnabled = true;
            this.comboBoxSlutby.Items.AddRange(new object[] {
            "Koebenhavn",
            "Oslo",
            "Stockholm",
            "Paris",
            "London",
            "Dublin",
            "Rom",
            "Berlin"});
            this.comboBoxSlutby.Location = new System.Drawing.Point(229, 115);
            this.comboBoxSlutby.Name = "comboBoxSlutby";
            this.comboBoxSlutby.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSlutby.TabIndex = 19;
            // 
            // listBoxFjernrejser
            // 
            this.listBoxFjernrejser.FormattingEnabled = true;
            this.listBoxFjernrejser.Location = new System.Drawing.Point(466, 178);
            this.listBoxFjernrejser.Name = "listBoxFjernrejser";
            this.listBoxFjernrejser.Size = new System.Drawing.Size(352, 199);
            this.listBoxFjernrejser.TabIndex = 20;
            // 
            // listBoxTilbudsrejser
            // 
            this.listBoxTilbudsrejser.FormattingEnabled = true;
            this.listBoxTilbudsrejser.Location = new System.Drawing.Point(466, 410);
            this.listBoxTilbudsrejser.Name = "listBoxTilbudsrejser";
            this.listBoxTilbudsrejser.Size = new System.Drawing.Size(357, 199);
            this.listBoxTilbudsrejser.TabIndex = 21;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(229, 66);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 22;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(416, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(407, 124);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(463, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Nedlagt rejser";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(463, 394);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Tilbudsrejser";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 621);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.listBoxTilbudsrejser);
            this.Controls.Add(this.listBoxFjernrejser);
            this.Controls.Add(this.comboBoxSlutby);
            this.Controls.Add(this.comboBoxStartby);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxResultat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextUdskrivRejse);
            this.Controls.Add(this.btnLuk);
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
        private System.Windows.Forms.Button btnLuk;
        private System.Windows.Forms.RichTextBox richTextUdskrivRejse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxResultat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxStartby;
        private System.Windows.Forms.ComboBox comboBoxSlutby;
        private System.Windows.Forms.ListBox listBoxFjernrejser;
        private System.Windows.Forms.ListBox listBoxTilbudsrejser;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

