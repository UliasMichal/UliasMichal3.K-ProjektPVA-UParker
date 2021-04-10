namespace UParker
{
    partial class Form8
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
            this.RemoveUserByIDTB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.OdstranitUserB = new System.Windows.Forms.Button();
            this.ReloadUserVSystemuB = new System.Windows.Forms.Button();
            this.panelOhraniceni2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panelOhraniceni1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.IsAdminCheckB = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.VynuceniZmenyHeslaCheckB = new System.Windows.Forms.CheckBox();
            this.KrestniTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.UsernameTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PrijmeniTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.HesloTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AddUserB = new System.Windows.Forms.Button();
            this.UserLB = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.panelOhraniceni2.SuspendLayout();
            this.panelOhraniceni1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RemoveUserByIDTB
            // 
            this.RemoveUserByIDTB.Location = new System.Drawing.Point(187, 19);
            this.RemoveUserByIDTB.Name = "RemoveUserByIDTB";
            this.RemoveUserByIDTB.Size = new System.Drawing.Size(175, 20);
            this.RemoveUserByIDTB.TabIndex = 93;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label11.Location = new System.Drawing.Point(5, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(153, 20);
            this.label11.TabIndex = 91;
            this.label11.Text = "Odstranit usera (ID):";
            // 
            // OdstranitUserB
            // 
            this.OdstranitUserB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.OdstranitUserB.Location = new System.Drawing.Point(187, 45);
            this.OdstranitUserB.Name = "OdstranitUserB";
            this.OdstranitUserB.Size = new System.Drawing.Size(175, 33);
            this.OdstranitUserB.TabIndex = 92;
            this.OdstranitUserB.Text = "Odstranit";
            this.OdstranitUserB.UseVisualStyleBackColor = true;
            this.OdstranitUserB.Click += new System.EventHandler(this.OdstranitUserB_Click);
            // 
            // ReloadUserVSystemuB
            // 
            this.ReloadUserVSystemuB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ReloadUserVSystemuB.Location = new System.Drawing.Point(200, 58);
            this.ReloadUserVSystemuB.Name = "ReloadUserVSystemuB";
            this.ReloadUserVSystemuB.Size = new System.Drawing.Size(144, 33);
            this.ReloadUserVSystemuB.TabIndex = 110;
            this.ReloadUserVSystemuB.Text = "Manual Reload List";
            this.ReloadUserVSystemuB.UseVisualStyleBackColor = true;
            this.ReloadUserVSystemuB.Click += new System.EventHandler(this.ReloadUserVSystemuB_Click);
            // 
            // panelOhraniceni2
            // 
            this.panelOhraniceni2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOhraniceni2.Controls.Add(this.RemoveUserByIDTB);
            this.panelOhraniceni2.Controls.Add(this.label11);
            this.panelOhraniceni2.Controls.Add(this.OdstranitUserB);
            this.panelOhraniceni2.Location = new System.Drawing.Point(350, 97);
            this.panelOhraniceni2.Name = "panelOhraniceni2";
            this.panelOhraniceni2.Size = new System.Drawing.Size(399, 94);
            this.panelOhraniceni2.TabIndex = 106;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(27, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 20);
            this.label10.TabIndex = 98;
            this.label10.Text = "Přidat usera:";
            // 
            // panelOhraniceni1
            // 
            this.panelOhraniceni1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOhraniceni1.Controls.Add(this.label4);
            this.panelOhraniceni1.Controls.Add(this.IsAdminCheckB);
            this.panelOhraniceni1.Controls.Add(this.label3);
            this.panelOhraniceni1.Controls.Add(this.VynuceniZmenyHeslaCheckB);
            this.panelOhraniceni1.Controls.Add(this.label10);
            this.panelOhraniceni1.Controls.Add(this.KrestniTB);
            this.panelOhraniceni1.Controls.Add(this.label7);
            this.panelOhraniceni1.Controls.Add(this.UsernameTB);
            this.panelOhraniceni1.Controls.Add(this.label9);
            this.panelOhraniceni1.Controls.Add(this.PrijmeniTB);
            this.panelOhraniceni1.Controls.Add(this.label5);
            this.panelOhraniceni1.Controls.Add(this.HesloTB);
            this.panelOhraniceni1.Controls.Add(this.label6);
            this.panelOhraniceni1.Controls.Add(this.label1);
            this.panelOhraniceni1.Controls.Add(this.AddUserB);
            this.panelOhraniceni1.Location = new System.Drawing.Point(350, 197);
            this.panelOhraniceni1.Name = "panelOhraniceni1";
            this.panelOhraniceni1.Size = new System.Drawing.Size(399, 352);
            this.panelOhraniceni1.TabIndex = 105;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(27, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 102;
            this.label4.Text = "Je admin:";
            // 
            // IsAdminCheckB
            // 
            this.IsAdminCheckB.AutoSize = true;
            this.IsAdminCheckB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.IsAdminCheckB.Location = new System.Drawing.Point(187, 242);
            this.IsAdminCheckB.Name = "IsAdminCheckB";
            this.IsAdminCheckB.Size = new System.Drawing.Size(211, 24);
            this.IsAdminCheckB.TabIndex = 101;
            this.IsAdminCheckB.Text = "jedná se o dalšího admina";
            this.IsAdminCheckB.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(27, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 20);
            this.label3.TabIndex = 100;
            this.label3.Text = "Vynutit změnu hesla:";
            // 
            // VynuceniZmenyHeslaCheckB
            // 
            this.VynuceniZmenyHeslaCheckB.AutoSize = true;
            this.VynuceniZmenyHeslaCheckB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.VynuceniZmenyHeslaCheckB.Location = new System.Drawing.Point(187, 200);
            this.VynuceniZmenyHeslaCheckB.Name = "VynuceniZmenyHeslaCheckB";
            this.VynuceniZmenyHeslaCheckB.Size = new System.Drawing.Size(167, 24);
            this.VynuceniZmenyHeslaCheckB.TabIndex = 99;
            this.VynuceniZmenyHeslaCheckB.Text = "vynutit změnu hesla";
            this.VynuceniZmenyHeslaCheckB.UseVisualStyleBackColor = true;
            // 
            // KrestniTB
            // 
            this.KrestniTB.Location = new System.Drawing.Point(187, 91);
            this.KrestniTB.Name = "KrestniTB";
            this.KrestniTB.Size = new System.Drawing.Size(175, 20);
            this.KrestniTB.TabIndex = 97;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(27, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 20);
            this.label7.TabIndex = 96;
            this.label7.Text = "Křestní jméno:";
            // 
            // UsernameTB
            // 
            this.UsernameTB.Location = new System.Drawing.Point(187, 62);
            this.UsernameTB.Name = "UsernameTB";
            this.UsernameTB.Size = new System.Drawing.Size(175, 20);
            this.UsernameTB.TabIndex = 95;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(27, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.TabIndex = 94;
            this.label9.Text = "Username: ";
            // 
            // PrijmeniTB
            // 
            this.PrijmeniTB.Location = new System.Drawing.Point(187, 117);
            this.PrijmeniTB.Name = "PrijmeniTB";
            this.PrijmeniTB.Size = new System.Drawing.Size(175, 20);
            this.PrijmeniTB.TabIndex = 93;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(27, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 92;
            this.label5.Text = "Příjmení: ";
            // 
            // HesloTB
            // 
            this.HesloTB.Location = new System.Drawing.Point(187, 174);
            this.HesloTB.Name = "HesloTB";
            this.HesloTB.PasswordChar = '*';
            this.HesloTB.Size = new System.Drawing.Size(175, 20);
            this.HesloTB.TabIndex = 91;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(27, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 90;
            this.label6.Text = "Heslo: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(27, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 89;
            this.label1.Text = "Add:";
            // 
            // AddUserB
            // 
            this.AddUserB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AddUserB.Location = new System.Drawing.Point(179, 289);
            this.AddUserB.Name = "AddUserB";
            this.AddUserB.Size = new System.Drawing.Size(175, 33);
            this.AddUserB.TabIndex = 88;
            this.AddUserB.Text = "Přidat usera";
            this.AddUserB.UseVisualStyleBackColor = true;
            this.AddUserB.Click += new System.EventHandler(this.AddUserB_Click);
            // 
            // UserLB
            // 
            this.UserLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.UserLB.FormattingEnabled = true;
            this.UserLB.HorizontalScrollbar = true;
            this.UserLB.ItemHeight = 16;
            this.UserLB.Location = new System.Drawing.Point(17, 97);
            this.UserLB.Name = "UserLB";
            this.UserLB.ScrollAlwaysVisible = true;
            this.UserLB.Size = new System.Drawing.Size(327, 452);
            this.UserLB.TabIndex = 98;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 25);
            this.label2.TabIndex = 104;
            this.label2.Text = "All-User-systému control";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Label12.Location = new System.Drawing.Point(13, 64);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(181, 20);
            this.Label12.TabIndex = 103;
            this.Label12.Text = "Seznam user v systému:";
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ReloadUserVSystemuB);
            this.Controls.Add(this.panelOhraniceni2);
            this.Controls.Add(this.panelOhraniceni1);
            this.Controls.Add(this.UserLB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form8";
            this.Text = "UParker";
            this.Load += new System.EventHandler(this.Form8_Load);
            this.panelOhraniceni2.ResumeLayout(false);
            this.panelOhraniceni2.PerformLayout();
            this.panelOhraniceni1.ResumeLayout(false);
            this.panelOhraniceni1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox RemoveUserByIDTB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button OdstranitUserB;
        private System.Windows.Forms.Button ReloadUserVSystemuB;
        private System.Windows.Forms.Panel panelOhraniceni2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panelOhraniceni1;
        private System.Windows.Forms.TextBox KrestniTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox UsernameTB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox PrijmeniTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox HesloTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddUserB;
        private System.Windows.Forms.ListBox UserLB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Label12;
        private System.Windows.Forms.CheckBox VynuceniZmenyHeslaCheckB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox IsAdminCheckB;
    }
}