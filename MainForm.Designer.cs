
namespace ReadXMLDocumentProject
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectFileBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DataListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AddToDatabaseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 31.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(325, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(576, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "Read XML Document";
            // 
            // SelectFileBtn
            // 
            this.SelectFileBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SelectFileBtn.Location = new System.Drawing.Point(50, 171);
            this.SelectFileBtn.Name = "SelectFileBtn";
            this.SelectFileBtn.Size = new System.Drawing.Size(102, 61);
            this.SelectFileBtn.TabIndex = 1;
            this.SelectFileBtn.Text = "Chọn File";
            this.SelectFileBtn.UseVisualStyleBackColor = true;
            this.SelectFileBtn.Click += new System.EventHandler(this.SelectFileBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(50, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(309, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chọn file XML muốn đọc tại đây";
            // 
            // DataListBox
            // 
            this.DataListBox.FormattingEnabled = true;
            this.DataListBox.ItemHeight = 20;
            this.DataListBox.Items.AddRange(new object[] {
            "Nội dung"});
            this.DataListBox.Location = new System.Drawing.Point(50, 297);
            this.DataListBox.Name = "DataListBox";
            this.DataListBox.Size = new System.Drawing.Size(570, 284);
            this.DataListBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(50, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(279, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nội dung của file Xml ở đây";
            // 
            // AddToDatabaseBtn
            // 
            this.AddToDatabaseBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddToDatabaseBtn.Location = new System.Drawing.Point(667, 297);
            this.AddToDatabaseBtn.Name = "AddToDatabaseBtn";
            this.AddToDatabaseBtn.Size = new System.Drawing.Size(146, 61);
            this.AddToDatabaseBtn.TabIndex = 5;
            this.AddToDatabaseBtn.Text = "Add to Database";
            this.AddToDatabaseBtn.UseVisualStyleBackColor = true;
            this.AddToDatabaseBtn.Click += new System.EventHandler(this.AddToDatabaseBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 789);
            this.Controls.Add(this.AddToDatabaseBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DataListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectFileBtn);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Read XML Document";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectFileBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox DataListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddToDatabaseBtn;
    }
}

