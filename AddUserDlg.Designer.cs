namespace GroceryForm
{
    partial class AddUserDlg
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
            this.paymentEntered = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okPressed = new System.Windows.Forms.Button();
            this.cancelPressed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // paymentEntered
            // 
            this.paymentEntered.Location = new System.Drawing.Point(117, 35);
            this.paymentEntered.Name = "paymentEntered";
            this.paymentEntered.Size = new System.Drawing.Size(177, 26);
            this.paymentEntered.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Name:";
            // 
            // okPressed
            // 
            this.okPressed.Location = new System.Drawing.Point(117, 68);
            this.okPressed.Name = "okPressed";
            this.okPressed.Size = new System.Drawing.Size(75, 36);
            this.okPressed.TabIndex = 2;
            this.okPressed.Text = "Add";
            this.okPressed.UseVisualStyleBackColor = true;
            this.okPressed.Click += new System.EventHandler(this.okPressed_Click);
            // 
            // cancelPressed
            // 
            this.cancelPressed.Location = new System.Drawing.Point(199, 68);
            this.cancelPressed.Name = "cancelPressed";
            this.cancelPressed.Size = new System.Drawing.Size(95, 36);
            this.cancelPressed.TabIndex = 3;
            this.cancelPressed.Text = "Cancel";
            this.cancelPressed.UseVisualStyleBackColor = true;
            this.cancelPressed.Click += new System.EventHandler(this.cancelPressed_Click);
            // 
            // AddUserDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 116);
            this.Controls.Add(this.cancelPressed);
            this.Controls.Add(this.okPressed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.paymentEntered);
            this.Name = "AddUserDlg";
            this.Text = "Add User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox paymentEntered;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okPressed;
        private System.Windows.Forms.Button cancelPressed;
    }
}