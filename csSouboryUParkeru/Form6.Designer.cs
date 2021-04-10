namespace UParker
{
    partial class Form6
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
            this.HesloJednaTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loginAPotvrditB = new System.Windows.Forms.Button();
            this.HesloDvaTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HesloJednaTB
            // 
            this.HesloJednaTB.Location = new System.Drawing.Point(197, 53);
            this.HesloJednaTB.Name = "HesloJednaTB";
            this.HesloJednaTB.PasswordChar = '*';
            this.HesloJednaTB.Size = new System.Drawing.Size(155, 20);
            this.HesloJednaTB.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(17, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 54;
            this.label1.Text = "Nové:";
            // 
            // loginAPotvrditB
            // 
            this.loginAPotvrditB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.loginAPotvrditB.Location = new System.Drawing.Point(210, 141);
            this.loginAPotvrditB.Name = "loginAPotvrditB";
            this.loginAPotvrditB.Size = new System.Drawing.Size(142, 32);
            this.loginAPotvrditB.TabIndex = 53;
            this.loginAPotvrditB.Text = "Potvrdit";
            this.loginAPotvrditB.UseVisualStyleBackColor = true;
            this.loginAPotvrditB.Click += new System.EventHandler(this.loginB_Click);
            // 
            // HesloDvaTB
            // 
            this.HesloDvaTB.Location = new System.Drawing.Point(197, 100);
            this.HesloDvaTB.Name = "HesloDvaTB";
            this.HesloDvaTB.PasswordChar = '*';
            this.HesloDvaTB.Size = new System.Drawing.Size(155, 20);
            this.HesloDvaTB.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(17, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 20);
            this.label3.TabIndex = 50;
            this.label3.Text = "Nové pro potvrzení:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label8.Location = new System.Drawing.Point(71, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(217, 25);
            this.label8.TabIndex = 48;
            this.label8.Text = "Vynucená změna hesla";
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 191);
            this.Controls.Add(this.HesloJednaTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginAPotvrditB);
            this.Controls.Add(this.HesloDvaTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form6";
            this.Text = "UParker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form6_FormClosed);
            this.Load += new System.EventHandler(this.Form6_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox HesloJednaTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loginAPotvrditB;
        private System.Windows.Forms.TextBox HesloDvaTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
    }
}