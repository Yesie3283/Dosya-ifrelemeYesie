namespace Dosyasifreleme
{
    partial class DSS
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
            this.SurukleAlanPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sifre_mtb = new System.Windows.Forms.MaskedTextBox();
            this.sifregoster_btn = new System.Windows.Forms.Button();
            this.chkAES = new System.Windows.Forms.CheckBox();
            this.chkTwofish = new System.Windows.Forms.CheckBox();
            this.chkTripleDES = new System.Windows.Forms.CheckBox();
            this.sifrele_rbtn = new System.Windows.Forms.RadioButton();
            this.coz_rbtn = new System.Windows.Forms.RadioButton();
            this.SurukleAlanPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SurukleAlanPanel
            // 
            this.SurukleAlanPanel.AllowDrop = true;
            this.SurukleAlanPanel.Controls.Add(this.label1);
            this.SurukleAlanPanel.Location = new System.Drawing.Point(-1, 184);
            this.SurukleAlanPanel.Name = "SurukleAlanPanel";
            this.SurukleAlanPanel.Size = new System.Drawing.Size(429, 268);
            this.SurukleAlanPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(90, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buraya Sürükle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Şifre:";
            // 
            // sifre_mtb
            // 
            this.sifre_mtb.Location = new System.Drawing.Point(50, 9);
            this.sifre_mtb.Name = "sifre_mtb";
            this.sifre_mtb.Size = new System.Drawing.Size(125, 20);
            this.sifre_mtb.TabIndex = 3;
            // 
            // sifregoster_btn
            // 
            this.sifregoster_btn.Location = new System.Drawing.Point(171, 7);
            this.sifregoster_btn.Name = "sifregoster_btn";
            this.sifregoster_btn.Size = new System.Drawing.Size(26, 23);
            this.sifregoster_btn.TabIndex = 4;
            this.sifregoster_btn.Text = "👁";
            this.sifregoster_btn.UseVisualStyleBackColor = true;
            // 
            // chkAES
            // 
            this.chkAES.AutoSize = true;
            this.chkAES.Location = new System.Drawing.Point(50, 51);
            this.chkAES.Name = "chkAES";
            this.chkAES.Size = new System.Drawing.Size(68, 17);
            this.chkAES.TabIndex = 5;
            this.chkAES.Text = "AES-256";
            this.chkAES.UseVisualStyleBackColor = true;
            // 
            // chkTwofish
            // 
            this.chkTwofish.AutoSize = true;
            this.chkTwofish.Location = new System.Drawing.Point(50, 75);
            this.chkTwofish.Name = "chkTwofish";
            this.chkTwofish.Size = new System.Drawing.Size(63, 17);
            this.chkTwofish.TabIndex = 6;
            this.chkTwofish.Text = "Twofish";
            this.chkTwofish.UseVisualStyleBackColor = true;
            // 
            // chkTripleDES
            // 
            this.chkTripleDES.AutoSize = true;
            this.chkTripleDES.Location = new System.Drawing.Point(50, 99);
            this.chkTripleDES.Name = "chkTripleDES";
            this.chkTripleDES.Size = new System.Drawing.Size(74, 17);
            this.chkTripleDES.TabIndex = 7;
            this.chkTripleDES.Text = "TripleDES";
            this.chkTripleDES.UseVisualStyleBackColor = true;
            // 
            // sifrele_rbtn
            // 
            this.sifrele_rbtn.AutoSize = true;
            this.sifrele_rbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifrele_rbtn.Location = new System.Drawing.Point(268, 33);
            this.sifrele_rbtn.Name = "sifrele_rbtn";
            this.sifrele_rbtn.Size = new System.Drawing.Size(109, 35);
            this.sifrele_rbtn.TabIndex = 8;
            this.sifrele_rbtn.TabStop = true;
            this.sifrele_rbtn.Text = "Şifrele";
            this.sifrele_rbtn.UseVisualStyleBackColor = true;
            // 
            // coz_rbtn
            // 
            this.coz_rbtn.AutoSize = true;
            this.coz_rbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.coz_rbtn.Location = new System.Drawing.Point(268, 99);
            this.coz_rbtn.Name = "coz_rbtn";
            this.coz_rbtn.Size = new System.Drawing.Size(81, 35);
            this.coz_rbtn.TabIndex = 9;
            this.coz_rbtn.TabStop = true;
            this.coz_rbtn.Text = "Çöz";
            this.coz_rbtn.UseVisualStyleBackColor = true;
            // 
            // DSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 450);
            this.Controls.Add(this.coz_rbtn);
            this.Controls.Add(this.sifrele_rbtn);
            this.Controls.Add(this.chkTripleDES);
            this.Controls.Add(this.chkTwofish);
            this.Controls.Add(this.chkAES);
            this.Controls.Add(this.sifregoster_btn);
            this.Controls.Add(this.sifre_mtb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SurukleAlanPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "DSS";
            this.Text = "Dosya Şifreleme";
            this.SurukleAlanPanel.ResumeLayout(false);
            this.SurukleAlanPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel SurukleAlanPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox sifre_mtb;
        private System.Windows.Forms.Button sifregoster_btn;
        private System.Windows.Forms.CheckBox chkAES;
        private System.Windows.Forms.CheckBox chkTwofish;
        private System.Windows.Forms.CheckBox chkTripleDES;
        private System.Windows.Forms.RadioButton sifrele_rbtn;
        private System.Windows.Forms.RadioButton coz_rbtn;
    }
}

