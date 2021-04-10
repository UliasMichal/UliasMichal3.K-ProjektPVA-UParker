namespace UParker
{
    partial class Form0
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BrandNewB = new System.Windows.Forms.Button();
            this.SelectLoadB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(71, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "File select";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Brand-new file: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Select-load-file:";
            // 
            // BrandNewB
            // 
            this.BrandNewB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BrandNewB.Location = new System.Drawing.Point(136, 62);
            this.BrandNewB.Name = "BrandNewB";
            this.BrandNewB.Size = new System.Drawing.Size(75, 23);
            this.BrandNewB.TabIndex = 4;
            this.BrandNewB.Text = "Enter";
            this.BrandNewB.UseVisualStyleBackColor = true;
            this.BrandNewB.Click += new System.EventHandler(this.BrandNewB_Click);
            // 
            // SelectLoadB
            // 
            this.SelectLoadB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SelectLoadB.Location = new System.Drawing.Point(136, 112);
            this.SelectLoadB.Name = "SelectLoadB";
            this.SelectLoadB.Size = new System.Drawing.Size(75, 23);
            this.SelectLoadB.TabIndex = 5;
            this.SelectLoadB.Text = "Enter";
            this.SelectLoadB.UseVisualStyleBackColor = true;
            this.SelectLoadB.Click += new System.EventHandler(this.SelectLoadB_Click);
            // 
            // Form0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 170);
            this.Controls.Add(this.SelectLoadB);
            this.Controls.Add(this.BrandNewB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form0";
            this.Text = "UParker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form0_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BrandNewB;
        private System.Windows.Forms.Button SelectLoadB;
    }
}

