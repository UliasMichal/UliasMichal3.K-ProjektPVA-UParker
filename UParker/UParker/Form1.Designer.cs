namespace UParker
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.adminCheckB = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.HesloTB = new System.Windows.Forms.TextBox();
            this.UsernameTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.loginB = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.UserIDTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(119, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(9, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Heslo:";
            // 
            // adminCheckB
            // 
            this.adminCheckB.AutoSize = true;
            this.adminCheckB.Location = new System.Drawing.Point(153, 198);
            this.adminCheckB.Name = "adminCheckB";
            this.adminCheckB.Size = new System.Drawing.Size(15, 14);
            this.adminCheckB.TabIndex = 3;
            this.adminCheckB.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(12, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Admin-check-box:";
            // 
            // HesloTB
            // 
            this.HesloTB.Location = new System.Drawing.Point(153, 143);
            this.HesloTB.Name = "HesloTB";
            this.HesloTB.PasswordChar = '*';
            this.HesloTB.Size = new System.Drawing.Size(142, 20);
            this.HesloTB.TabIndex = 5;
            // 
            // UsernameTB
            // 
            this.UsernameTB.Location = new System.Drawing.Point(150, 54);
            this.UsernameTB.Name = "UsernameTB";
            this.UsernameTB.Size = new System.Drawing.Size(142, 20);
            this.UsernameTB.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label5.Location = new System.Drawing.Point(15, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Zaškrtněte pokud jste admin a chcete do admin-práv";
            // 
            // loginB
            // 
            this.loginB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.loginB.Location = new System.Drawing.Point(153, 255);
            this.loginB.Name = "loginB";
            this.loginB.Size = new System.Drawing.Size(142, 32);
            this.loginB.TabIndex = 9;
            this.loginB.Text = "Login";
            this.loginB.UseVisualStyleBackColor = true;
            this.loginB.Click += new System.EventHandler(this.LoginB_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(12, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Login button:";
            // 
            // UserIDTB
            // 
            this.UserIDTB.Location = new System.Drawing.Point(150, 96);
            this.UserIDTB.Name = "UserIDTB";
            this.UserIDTB.Size = new System.Drawing.Size(142, 20);
            this.UserIDTB.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(9, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "UserID:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 301);
            this.Controls.Add(this.UserIDTB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.loginB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.UsernameTB);
            this.Controls.Add(this.HesloTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.adminCheckB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(330, 340);
            this.Name = "Form1";
            this.Text = "UParker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox adminCheckB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox HesloTB;
        private System.Windows.Forms.TextBox UsernameTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button loginB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox UserIDTB;
        private System.Windows.Forms.Label label7;
    }
}