namespace QueryAndStatistics
{
    partial class FormSelection
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
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("图层");
            this.treeViewLayers = new System.Windows.Forms.TreeView();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.labelLayerSelectionCount = new System.Windows.Forms.Label();
            this.labelMapSelectionCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // treeViewLayers
            // 
            this.treeViewLayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewLayers.Location = new System.Drawing.Point(0, 0);
            this.treeViewLayers.Margin = new System.Windows.Forms.Padding(4);
            this.treeViewLayers.Name = "treeViewLayers";
            treeNode4.Name = "Layers";
            treeNode4.Text = "图层";
            this.treeViewLayers.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.treeViewLayers.Size = new System.Drawing.Size(245, 532);
            this.treeViewLayers.TabIndex = 0;
            this.treeViewLayers.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(247, 0);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(761, 496);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // labelLayerSelectionCount
            // 
            this.labelLayerSelectionCount.AutoSize = true;
            this.labelLayerSelectionCount.Location = new System.Drawing.Point(787, 504);
            this.labelLayerSelectionCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLayerSelectionCount.Name = "labelLayerSelectionCount";
            this.labelLayerSelectionCount.Size = new System.Drawing.Size(196, 15);
            this.labelLayerSelectionCount.TabIndex = 2;
            this.labelLayerSelectionCount.Text = "当前图层选择了 0 个要素。";
            // 
            // labelMapSelectionCount
            // 
            this.labelMapSelectionCount.AutoSize = true;
            this.labelMapSelectionCount.Location = new System.Drawing.Point(269, 504);
            this.labelMapSelectionCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMapSelectionCount.Name = "labelMapSelectionCount";
            this.labelMapSelectionCount.Size = new System.Drawing.Size(211, 15);
            this.labelMapSelectionCount.TabIndex = 3;
            this.labelMapSelectionCount.Text = "当前地图共选择了 0 个要素。";
            // 
            // FormSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 530);
            this.Controls.Add(this.labelMapSelectionCount);
            this.Controls.Add(this.labelLayerSelectionCount);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.treeViewLayers);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地图选择集";
            this.Load += new System.EventHandler(this.FormSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewLayers;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label labelLayerSelectionCount;
        private System.Windows.Forms.Label labelMapSelectionCount;
    }
}