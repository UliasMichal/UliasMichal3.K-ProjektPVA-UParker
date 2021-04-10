namespace UParker
{
    partial class Form2
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
            this.HlavickaL = new System.Windows.Forms.Label();
            this.RezervaceUseraLB = new System.Windows.Forms.ListBox();
            this.ModListuCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LastLoginTimeL = new System.Windows.Forms.Label();
            this.BackB = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.OdstranitRezervB = new System.Windows.Forms.Button();
            this.AddRezervB = new System.Windows.Forms.Button();
            this.ZmenaHeslaB = new System.Windows.Forms.Button();
            this.IDRezervRemTB = new System.Windows.Forms.TextBox();
            this.UserIDL = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.IDVozidlaTB = new System.Windows.Forms.TextBox();
            this.ShowAutoInfoB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HlavickaL
            // 
            this.HlavickaL.AutoSize = true;
            this.HlavickaL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.HlavickaL.Location = new System.Drawing.Point(27, 21);
            this.HlavickaL.Name = "HlavickaL";
            this.HlavickaL.Size = new System.Drawing.Size(444, 25);
            this.HlavickaL.TabIndex = 0;
            this.HlavickaL.Text = "User: Křestní, Příjmení - rezervace účtu Username";
            // 
            // RezervaceUseraLB
            // 
            this.RezervaceUseraLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.RezervaceUseraLB.FormattingEnabled = true;
            this.RezervaceUseraLB.HorizontalScrollbar = true;
            this.RezervaceUseraLB.ItemHeight = 16;
            this.RezervaceUseraLB.Location = new System.Drawing.Point(32, 166);
            this.RezervaceUseraLB.Name = "RezervaceUseraLB";
            this.RezervaceUseraLB.ScrollAlwaysVisible = true;
            this.RezervaceUseraLB.Size = new System.Drawing.Size(302, 276);
            this.RezervaceUseraLB.TabIndex = 1;
            // 
            // ModListuCB
            // 
            this.ModListuCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModListuCB.FormattingEnabled = true;
            this.ModListuCB.Items.AddRange(new object[] {
            "",
            "Aktuální",
            "Historické"});
            this.ModListuCB.Location = new System.Drawing.Point(150, 135);
            this.ModListuCB.Name = "ModListuCB";
            this.ModListuCB.Size = new System.Drawing.Size(184, 21);
            this.ModListuCB.TabIndex = 2;
            this.ModListuCB.SelectedIndexChanged += new System.EventHandler(this.ModListuCB_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(26, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mód rezervací: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(26, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last-login: ";
            // 
            // LastLoginTimeL
            // 
            this.LastLoginTimeL.AutoSize = true;
            this.LastLoginTimeL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LastLoginTimeL.Location = new System.Drawing.Point(118, 92);
            this.LastLoginTimeL.Name = "LastLoginTimeL";
            this.LastLoginTimeL.Size = new System.Drawing.Size(196, 20);
            this.LastLoginTimeL.TabIndex = 5;
            this.LastLoginTimeL.Text = "První přihlášení! Gratulace!";
            // 
            // BackB
            // 
            this.BackB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BackB.Location = new System.Drawing.Point(718, 12);
            this.BackB.Name = "BackB";
            this.BackB.Size = new System.Drawing.Size(70, 33);
            this.BackB.TabIndex = 6;
            this.BackB.Text = "Back";
            this.BackB.UseVisualStyleBackColor = true;
            this.BackB.Click += new System.EventHandler(this.BackB_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(555, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Interakce";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(387, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Odstranit rezervaci (ID):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(387, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Přidat rezervaci: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(387, 351);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Změnit heslo:";
            // 
            // OdstranitRezervB
            // 
            this.OdstranitRezervB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.OdstranitRezervB.Location = new System.Drawing.Point(603, 159);
            this.OdstranitRezervB.Name = "OdstranitRezervB";
            this.OdstranitRezervB.Size = new System.Drawing.Size(175, 33);
            this.OdstranitRezervB.TabIndex = 11;
            this.OdstranitRezervB.Text = "Odstranit";
            this.OdstranitRezervB.UseVisualStyleBackColor = true;
            this.OdstranitRezervB.Click += new System.EventHandler(this.OdstranitB_Click);
            // 
            // AddRezervB
            // 
            this.AddRezervB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AddRezervB.Location = new System.Drawing.Point(603, 307);
            this.AddRezervB.Name = "AddRezervB";
            this.AddRezervB.Size = new System.Drawing.Size(175, 33);
            this.AddRezervB.TabIndex = 12;
            this.AddRezervB.Text = "Přidat";
            this.AddRezervB.UseVisualStyleBackColor = true;
            this.AddRezervB.Click += new System.EventHandler(this.AddB_Click);
            // 
            // ZmenaHeslaB
            // 
            this.ZmenaHeslaB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ZmenaHeslaB.Location = new System.Drawing.Point(603, 346);
            this.ZmenaHeslaB.Name = "ZmenaHeslaB";
            this.ZmenaHeslaB.Size = new System.Drawing.Size(175, 33);
            this.ZmenaHeslaB.TabIndex = 13;
            this.ZmenaHeslaB.Text = "Změnit Heslo";
            this.ZmenaHeslaB.UseVisualStyleBackColor = true;
            this.ZmenaHeslaB.Click += new System.EventHandler(this.ZmenaHeslaB_Click);
            // 
            // IDRezervRemTB
            // 
            this.IDRezervRemTB.Location = new System.Drawing.Point(603, 133);
            this.IDRezervRemTB.Name = "IDRezervRemTB";
            this.IDRezervRemTB.Size = new System.Drawing.Size(175, 20);
            this.IDRezervRemTB.TabIndex = 14;
            // 
            // UserIDL
            // 
            this.UserIDL.AutoSize = true;
            this.UserIDL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UserIDL.Location = new System.Drawing.Point(118, 63);
            this.UserIDL.Name = "UserIDL";
            this.UserIDL.Size = new System.Drawing.Size(60, 20);
            this.UserIDL.TabIndex = 16;
            this.UserIDL.Text = "UserID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(28, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "User-ID:";
            // 
            // IDVozidlaTB
            // 
            this.IDVozidlaTB.Location = new System.Drawing.Point(603, 213);
            this.IDVozidlaTB.Name = "IDVozidlaTB";
            this.IDVozidlaTB.Size = new System.Drawing.Size(175, 20);
            this.IDVozidlaTB.TabIndex = 19;
            // 
            // ShowAutoInfoB
            // 
            this.ShowAutoInfoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ShowAutoInfoB.Location = new System.Drawing.Point(603, 239);
            this.ShowAutoInfoB.Name = "ShowAutoInfoB";
            this.ShowAutoInfoB.Size = new System.Drawing.Size(175, 33);
            this.ShowAutoInfoB.TabIndex = 18;
            this.ShowAutoInfoB.Text = "Auto-info";
            this.ShowAutoInfoB.UseVisualStyleBackColor = true;
            this.ShowAutoInfoB.Click += new System.EventHandler(this.ShowAutoInfoB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(387, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Zobrazit info o vozidlu (ID):";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.IDVozidlaTB);
            this.Controls.Add(this.ShowAutoInfoB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserIDL);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.IDRezervRemTB);
            this.Controls.Add(this.ZmenaHeslaB);
            this.Controls.Add(this.AddRezervB);
            this.Controls.Add(this.OdstranitRezervB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BackB);
            this.Controls.Add(this.LastLoginTimeL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ModListuCB);
            this.Controls.Add(this.RezervaceUseraLB);
            this.Controls.Add(this.HlavickaL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(820, 500);
            this.Name = "Form2";
            this.Text = "UParker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HlavickaL;
        private System.Windows.Forms.ListBox RezervaceUseraLB;
        private System.Windows.Forms.ComboBox ModListuCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LastLoginTimeL;
        private System.Windows.Forms.Button BackB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button OdstranitRezervB;
        private System.Windows.Forms.Button AddRezervB;
        private System.Windows.Forms.Button ZmenaHeslaB;
        private System.Windows.Forms.TextBox IDRezervRemTB;
        private System.Windows.Forms.Label UserIDL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox IDVozidlaTB;
        private System.Windows.Forms.Button ShowAutoInfoB;
        private System.Windows.Forms.Label label1;
    }
}