namespace UParker
{
    partial class Form5
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
            this.NoveHesloJednaTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PotvrditB = new System.Windows.Forms.Button();
            this.AktualniHesloTB = new System.Windows.Forms.TextBox();
            this.NoveHesloDvaTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BackB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NoveHesloJednaTB
            // 
            this.NoveHesloJednaTB.Location = new System.Drawing.Point(195, 96);
            this.NoveHesloJednaTB.Name = "NoveHesloJednaTB";
            this.NoveHesloJednaTB.PasswordChar = '*';
            this.NoveHesloJednaTB.Size = new System.Drawing.Size(155, 20);
            this.NoveHesloJednaTB.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(15, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "Nové:";
            // 
            // PotvrditB
            // 
            this.PotvrditB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.PotvrditB.Location = new System.Drawing.Point(208, 185);
            this.PotvrditB.Name = "PotvrditB";
            this.PotvrditB.Size = new System.Drawing.Size(142, 32);
            this.PotvrditB.TabIndex = 44;
            this.PotvrditB.Text = "Potvrdit";
            this.PotvrditB.UseVisualStyleBackColor = true;
            this.PotvrditB.Click += new System.EventHandler(this.PotvrditB_Click);
            // 
            // AktualniHesloTB
            // 
            this.AktualniHesloTB.Location = new System.Drawing.Point(195, 54);
            this.AktualniHesloTB.Name = "AktualniHesloTB";
            this.AktualniHesloTB.PasswordChar = '*';
            this.AktualniHesloTB.Size = new System.Drawing.Size(155, 20);
            this.AktualniHesloTB.TabIndex = 42;
            // 
            // NoveHesloDvaTB
            // 
            this.NoveHesloDvaTB.Location = new System.Drawing.Point(195, 143);
            this.NoveHesloDvaTB.Name = "NoveHesloDvaTB";
            this.NoveHesloDvaTB.PasswordChar = '*';
            this.NoveHesloDvaTB.Size = new System.Drawing.Size(155, 20);
            this.NoveHesloDvaTB.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(15, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "Nové pro potvrzení:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(15, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Aktuální:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label8.Location = new System.Drawing.Point(125, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 25);
            this.label8.TabIndex = 36;
            this.label8.Text = "Změna hesla";
            // 
            // BackB
            // 
            this.BackB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BackB.Location = new System.Drawing.Point(292, 8);
            this.BackB.Name = "BackB";
            this.BackB.Size = new System.Drawing.Size(70, 33);
            this.BackB.TabIndex = 48;
            this.BackB.Text = "Back";
            this.BackB.UseVisualStyleBackColor = true;
            this.BackB.Click += new System.EventHandler(this.BackB_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 241);
            this.Controls.Add(this.BackB);
            this.Controls.Add(this.NoveHesloJednaTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PotvrditB);
            this.Controls.Add(this.AktualniHesloTB);
            this.Controls.Add(this.NoveHesloDvaTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form5";
            this.Text = "UParker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NoveHesloJednaTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PotvrditB;
        private System.Windows.Forms.TextBox AktualniHesloTB;
        private System.Windows.Forms.TextBox NoveHesloDvaTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BackB;
    }
}