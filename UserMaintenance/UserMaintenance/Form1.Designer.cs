
namespace UserMaintenance
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
            this.listUser = new System.Windows.Forms.ListBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnFileWriting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listUser
            // 
            this.listUser.FormattingEnabled = true;
            this.listUser.ItemHeight = 16;
            this.listUser.Location = new System.Drawing.Point(12, 15);
            this.listUser.Name = "listUser";
            this.listUser.Size = new System.Drawing.Size(361, 532);
            this.listUser.TabIndex = 0;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(379, 36);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(46, 17);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "label1";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(447, 31);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(239, 22);
            this.txtFullName.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(382, 59);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(304, 54);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "button1";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnFileWriting
            // 
            this.btnFileWriting.Location = new System.Drawing.Point(382, 493);
            this.btnFileWriting.Name = "btnFileWriting";
            this.btnFileWriting.Size = new System.Drawing.Size(304, 54);
            this.btnFileWriting.TabIndex = 6;
            this.btnFileWriting.Text = "button2";
            this.btnFileWriting.UseVisualStyleBackColor = true;
            this.btnFileWriting.Click += new System.EventHandler(this.btnFileWriting_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 559);
            this.Controls.Add(this.btnFileWriting);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.listUser);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listUser;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnFileWriting;
    }
}

