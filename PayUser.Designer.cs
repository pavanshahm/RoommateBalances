namespace GroceryForm
{
    partial class PayUser
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
            this.payerChosen = new System.Windows.Forms.ComboBox();
            this.payeeChosen = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.itemModified = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Me:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pay to whom: ";
            // 
            // payerChosen
            // 
            this.payerChosen.FormattingEnabled = true;
            this.payerChosen.Location = new System.Drawing.Point(119, 44);
            this.payerChosen.Name = "payerChosen";
            this.payerChosen.Size = new System.Drawing.Size(121, 28);
            this.payerChosen.TabIndex = 2;
            this.payerChosen.SelectedIndexChanged += new System.EventHandler(this.payerChosen_SelectedIndexChanged);
            // 
            // payeeChosen
            // 
            this.payeeChosen.FormattingEnabled = true;
            this.payeeChosen.Location = new System.Drawing.Point(119, 89);
            this.payeeChosen.Name = "payeeChosen";
            this.payeeChosen.Size = new System.Drawing.Size(121, 28);
            this.payeeChosen.TabIndex = 3;
            this.payeeChosen.SelectedIndexChanged += new System.EventHandler(this.payeeChosen_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Payment amount: $";
            // 
            // itemModified
            // 
            this.itemModified.Location = new System.Drawing.Point(164, 145);
            this.itemModified.Name = "itemModified";
            this.itemModified.Size = new System.Drawing.Size(100, 26);
            this.itemModified.TabIndex = 5;
            this.itemModified.TextChanged += new System.EventHandler(this.paymentEntered_TextChanged);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(221, 187);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(60, 38);
            this.OK.TabIndex = 6;
            this.OK.Text = "Pay";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.payPressed_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(287, 187);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(81, 38);
            this.Cancel.TabIndex = 7;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.cancelPressed_Click);
            // 
            // PayUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 330);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.itemModified);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.payeeChosen);
            this.Controls.Add(this.payerChosen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PayUser";
            this.Text = "PayUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox payerChosen;
        private System.Windows.Forms.ComboBox payeeChosen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox itemModified;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
    }
}