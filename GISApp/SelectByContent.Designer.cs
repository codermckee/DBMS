namespace WaterReservoir
{
    partial class SelectByContent
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
            System.Windows.Forms.CheckBox dixing;
            this.label1 = new System.Windows.Forms.Label();
            this.查询 = new System.Windows.Forms.Button();
            this.water = new System.Windows.Forms.CheckBox();
            this.pipe = new System.Windows.Forms.CheckBox();
            this.report = new System.Windows.Forms.CheckBox();
            dixing = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dixing
            // 
            dixing.AutoSize = true;
            dixing.Location = new System.Drawing.Point(73, 53);
            dixing.Name = "dixing";
            dixing.Size = new System.Drawing.Size(106, 22);
            dixing.TabIndex = 6;
            dixing.Tag = "";
            dixing.Text = "地形信息";
            dixing.UseVisualStyleBackColor = true;
            dixing.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "请勾选查询专题：";
            // 
            // 查询
            // 
            this.查询.Location = new System.Drawing.Point(128, 176);
            this.查询.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.查询.Name = "查询";
            this.查询.Size = new System.Drawing.Size(84, 28);
            this.查询.TabIndex = 5;
            this.查询.Text = "查询";
            this.查询.UseVisualStyleBackColor = true;
            // 
            // water
            // 
            this.water.AutoSize = true;
            this.water.Location = new System.Drawing.Point(73, 81);
            this.water.Name = "water";
            this.water.Size = new System.Drawing.Size(124, 22);
            this.water.TabIndex = 7;
            this.water.Text = "水库区信息";
            this.water.UseVisualStyleBackColor = true;
            this.water.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // pipe
            // 
            this.pipe.AutoSize = true;
            this.pipe.Location = new System.Drawing.Point(73, 109);
            this.pipe.Name = "pipe";
            this.pipe.Size = new System.Drawing.Size(106, 22);
            this.pipe.TabIndex = 8;
            this.pipe.Text = "管道信息";
            this.pipe.UseVisualStyleBackColor = true;
            // 
            // report
            // 
            this.report.AutoSize = true;
            this.report.Location = new System.Drawing.Point(73, 137);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(70, 22);
            this.report.TabIndex = 9;
            this.report.Text = "报告";
            this.report.UseVisualStyleBackColor = true;
            // 
            // SelectByContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 218);
            this.Controls.Add(this.report);
            this.Controls.Add(this.pipe);
            this.Controls.Add(this.water);
            this.Controls.Add(dixing);
            this.Controls.Add(this.查询);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SelectByContent";
            this.Text = "按专题查询";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button 查询;
        private System.Windows.Forms.CheckBox water;
        private System.Windows.Forms.CheckBox pipe;
        private System.Windows.Forms.CheckBox report;
    }
}