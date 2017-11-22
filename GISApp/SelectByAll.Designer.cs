namespace WaterReservoir
{
    partial class SelectByAll
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkedListBox3 = new System.Windows.Forms.CheckedListBox();
            this.查询 = new System.Windows.Forms.Button();
            this.year = new System.Windows.Forms.TextBox();
            this.month = new System.Windows.Forms.TextBox();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "请勾选查询月份：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "请勾选查询年份：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "请勾选查询数据库：";
            // 
            // checkedListBox3
            // 
            this.checkedListBox3.BackColor = System.Drawing.SystemColors.Menu;
            this.checkedListBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox3.FormattingEnabled = true;
            this.checkedListBox3.Items.AddRange(new object[] {
            "遥感影像数据库",
            "成果数据库",
            "元数据库",
            "基础地理数据库"});
            this.checkedListBox3.Location = new System.Drawing.Point(11, 121);
            this.checkedListBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkedListBox3.Name = "checkedListBox3";
            this.checkedListBox3.Size = new System.Drawing.Size(122, 80);
            this.checkedListBox3.TabIndex = 8;
            // 
            // 查询
            // 
            this.查询.Location = new System.Drawing.Point(90, 219);
            this.查询.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.查询.Name = "查询";
            this.查询.Size = new System.Drawing.Size(56, 32);
            this.查询.TabIndex = 12;
            this.查询.Text = "查询";
            this.查询.UseVisualStyleBackColor = true;
            this.查询.Click += new System.EventHandler(this.查询_Click);
            // 
            // year
            // 
            this.year.Location = new System.Drawing.Point(11, 46);
            this.year.Margin = new System.Windows.Forms.Padding(2);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(68, 21);
            this.year.TabIndex = 13;
            // 
            // month
            // 
            this.month.Location = new System.Drawing.Point(125, 45);
            this.month.Margin = new System.Windows.Forms.Padding(2);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(68, 21);
            this.month.TabIndex = 14;
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // SelectByAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 263);
            this.Controls.Add(this.month);
            this.Controls.Add(this.year);
            this.Controls.Add(this.查询);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkedListBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "SelectByAll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "联合查询";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox checkedListBox3;
        private System.Windows.Forms.Button 查询;
        private System.Windows.Forms.TextBox year;
        private System.Windows.Forms.TextBox month;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
    }
}