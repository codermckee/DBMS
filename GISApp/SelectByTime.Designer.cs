namespace WaterReservoir
{
    partial class FormByTime
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
            this.btnQuery = new System.Windows.Forms.Button();
            this.year = new System.Windows.Forms.TextBox();
            this.month = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "请输入查询年份：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "请输入查询月份：";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(84, 109);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(56, 23);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // year
            // 
            this.year.Location = new System.Drawing.Point(17, 52);
            this.year.Margin = new System.Windows.Forms.Padding(2);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(68, 21);
            this.year.TabIndex = 5;
            // 
            // month
            // 
            this.month.Location = new System.Drawing.Point(131, 52);
            this.month.Margin = new System.Windows.Forms.Padding(2);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(68, 21);
            this.month.TabIndex = 6;
            // 
            // FormByTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 158);
            this.Controls.Add(this.month);
            this.Controls.Add(this.year);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FormByTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "按时间查询";
            this.Load += new System.EventHandler(this.FormByTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox year;
        private System.Windows.Forms.TextBox month;
    }
}