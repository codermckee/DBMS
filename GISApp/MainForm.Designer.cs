namespace GISApp
{
    partial class MainForm
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
            //Ensures that any ESRI libraries that have been used are unloaded in the correct order. 
            //Failure to do this may result in random crashes on exit due to the operating system unloading 
            //the libraries in the incorrect order. 
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.打开MXDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加FileGeoDatabase数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.gdbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.时间查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.范围查寻ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.联合查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空间查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图形查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图选择集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入CADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入影像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查找ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.入库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.质量控制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.现势性检查ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.坐标检查ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性检查ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择操作项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.拓扑一致性检查ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.位置精度检查ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.表征精度检查ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.gdbToolStripMenuItem,
            this.查询ToolStripMenuItem,
            this.导入ToolStripMenuItem,
            this.用户管理ToolStripMenuItem,
            this.查找ToolStripMenuItem,
            this.入库ToolStripMenuItem,
            this.质量控制ToolStripMenuItem,
            this.统计ToolStripMenuItem,
            this.选择操作项ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(644, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.BackColor = System.Drawing.SystemColors.Control;
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewDoc,
            this.menuOpenDoc,
            this.打开MXDToolStripMenuItem,
            this.添加FileGeoDatabase数据ToolStripMenuItem,
            this.menuSaveDoc,
            this.menuSaveAs,
            this.menuSeparator,
            this.menuExitApp});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(44, 21);
            this.menuFile.Text = "文件";
            this.menuFile.Click += new System.EventHandler(this.menuFile_Click);
            // 
            // menuNewDoc
            // 
            this.menuNewDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuNewDoc.Image")));
            this.menuNewDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuNewDoc.Name = "menuNewDoc";
            this.menuNewDoc.Size = new System.Drawing.Size(222, 22);
            this.menuNewDoc.Text = "新建";
            this.menuNewDoc.Click += new System.EventHandler(this.menuNewDoc_Click);
            // 
            // menuOpenDoc
            // 
            this.menuOpenDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenDoc.Image")));
            this.menuOpenDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuOpenDoc.Name = "menuOpenDoc";
            this.menuOpenDoc.Size = new System.Drawing.Size(222, 22);
            this.menuOpenDoc.Text = "打开";
            this.menuOpenDoc.Click += new System.EventHandler(this.menuOpenDoc_Click);
            // 
            // 打开MXDToolStripMenuItem
            // 
            this.打开MXDToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.打开MXDToolStripMenuItem.Name = "打开MXDToolStripMenuItem";
            this.打开MXDToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.打开MXDToolStripMenuItem.Text = "打开MXD";
            this.打开MXDToolStripMenuItem.Click += new System.EventHandler(this.打开MXDToolStripMenuItem_Click);
            // 
            // 添加FileGeoDatabase数据ToolStripMenuItem
            // 
            this.添加FileGeoDatabase数据ToolStripMenuItem.Name = "添加FileGeoDatabase数据ToolStripMenuItem";
            this.添加FileGeoDatabase数据ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.添加FileGeoDatabase数据ToolStripMenuItem.Text = "添加FileGeoDatabase数据";
            this.添加FileGeoDatabase数据ToolStripMenuItem.Click += new System.EventHandler(this.添加FileGeoDatabase数据ToolStripMenuItem_Click);
            // 
            // menuSaveDoc
            // 
            this.menuSaveDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveDoc.Image")));
            this.menuSaveDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuSaveDoc.Name = "menuSaveDoc";
            this.menuSaveDoc.Size = new System.Drawing.Size(222, 22);
            this.menuSaveDoc.Text = "保存";
            this.menuSaveDoc.Click += new System.EventHandler(this.menuSaveDoc_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(222, 22);
            this.menuSaveAs.Text = "另存为";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(219, 6);
            // 
            // menuExitApp
            // 
            this.menuExitApp.Name = "menuExitApp";
            this.menuExitApp.Size = new System.Drawing.Size(222, 22);
            this.menuExitApp.Text = "退出";
            this.menuExitApp.Click += new System.EventHandler(this.menuExitApp_Click);
            // 
            // gdbToolStripMenuItem
            // 
            this.gdbToolStripMenuItem.Name = "gdbToolStripMenuItem";
            this.gdbToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.gdbToolStripMenuItem.Text = "登录";
            this.gdbToolStripMenuItem.Click += new System.EventHandler(this.gdbToolStripMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.时间查询ToolStripMenuItem,
            this.范围查寻ToolStripMenuItem,
            this.联合查询ToolStripMenuItem,
            this.属性查询ToolStripMenuItem,
            this.空间查询ToolStripMenuItem,
            this.图形查询ToolStripMenuItem,
            this.地图选择集ToolStripMenuItem});
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.查询ToolStripMenuItem.Text = "查询";
            this.查询ToolStripMenuItem.Visible = false;
            this.查询ToolStripMenuItem.Click += new System.EventHandler(this.查询ToolStripMenuItem_Click);
            // 
            // 时间查询ToolStripMenuItem
            // 
            this.时间查询ToolStripMenuItem.Name = "时间查询ToolStripMenuItem";
            this.时间查询ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.时间查询ToolStripMenuItem.Text = "时间查询";
            this.时间查询ToolStripMenuItem.Click += new System.EventHandler(this.时间查询ToolStripMenuItem_Click);
            // 
            // 范围查寻ToolStripMenuItem
            // 
            this.范围查寻ToolStripMenuItem.Name = "范围查寻ToolStripMenuItem";
            this.范围查寻ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.范围查寻ToolStripMenuItem.Text = "图幅查询";
            this.范围查寻ToolStripMenuItem.Click += new System.EventHandler(this.范围查寻ToolStripMenuItem_Click);
            // 
            // 联合查询ToolStripMenuItem
            // 
            this.联合查询ToolStripMenuItem.Name = "联合查询ToolStripMenuItem";
            this.联合查询ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.联合查询ToolStripMenuItem.Text = "联合查询";
            this.联合查询ToolStripMenuItem.Click += new System.EventHandler(this.联合查询ToolStripMenuItem_Click);
            // 
            // 属性查询ToolStripMenuItem
            // 
            this.属性查询ToolStripMenuItem.Name = "属性查询ToolStripMenuItem";
            this.属性查询ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.属性查询ToolStripMenuItem.Text = "属性查询";
            this.属性查询ToolStripMenuItem.Click += new System.EventHandler(this.属性查询ToolStripMenuItem_Click);
            // 
            // 空间查询ToolStripMenuItem
            // 
            this.空间查询ToolStripMenuItem.Name = "空间查询ToolStripMenuItem";
            this.空间查询ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.空间查询ToolStripMenuItem.Text = "空间查询";
            this.空间查询ToolStripMenuItem.Click += new System.EventHandler(this.空间查询ToolStripMenuItem_Click);
            // 
            // 图形查询ToolStripMenuItem
            // 
            this.图形查询ToolStripMenuItem.Name = "图形查询ToolStripMenuItem";
            this.图形查询ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.图形查询ToolStripMenuItem.Text = "图形查询";
            // 
            // 地图选择集ToolStripMenuItem
            // 
            this.地图选择集ToolStripMenuItem.Name = "地图选择集ToolStripMenuItem";
            this.地图选择集ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.地图选择集ToolStripMenuItem.Text = "地图选择集";
            this.地图选择集ToolStripMenuItem.Click += new System.EventHandler(this.地图选择集ToolStripMenuItem_Click);
            // 
            // 导入ToolStripMenuItem
            // 
            this.导入ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入CADToolStripMenuItem,
            this.导入影像ToolStripMenuItem});
            this.导入ToolStripMenuItem.Name = "导入ToolStripMenuItem";
            this.导入ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.导入ToolStripMenuItem.Text = "导入";
            this.导入ToolStripMenuItem.Visible = false;
            this.导入ToolStripMenuItem.Click += new System.EventHandler(this.导入ToolStripMenuItem_Click);
            // 
            // 导入CADToolStripMenuItem
            // 
            this.导入CADToolStripMenuItem.Name = "导入CADToolStripMenuItem";
            this.导入CADToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.导入CADToolStripMenuItem.Text = "导入CAD";
            // 
            // 导入影像ToolStripMenuItem
            // 
            this.导入影像ToolStripMenuItem.Name = "导入影像ToolStripMenuItem";
            this.导入影像ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.导入影像ToolStripMenuItem.Text = "导入影像";
            this.导入影像ToolStripMenuItem.Click += new System.EventHandler(this.导入影像ToolStripMenuItem_Click);
            // 
            // 用户管理ToolStripMenuItem
            // 
            this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.用户管理ToolStripMenuItem.Text = "用户管理";
            this.用户管理ToolStripMenuItem.Visible = false;
            this.用户管理ToolStripMenuItem.Click += new System.EventHandler(this.用户管理ToolStripMenuItem_Click);
            // 
            // 查找ToolStripMenuItem
            // 
            this.查找ToolStripMenuItem.Name = "查找ToolStripMenuItem";
            this.查找ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.查找ToolStripMenuItem.Text = "查找";
            this.查找ToolStripMenuItem.Visible = false;
            this.查找ToolStripMenuItem.Click += new System.EventHandler(this.查找ToolStripMenuItem_Click);
            // 
            // 入库ToolStripMenuItem
            // 
            this.入库ToolStripMenuItem.Name = "入库ToolStripMenuItem";
            this.入库ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.入库ToolStripMenuItem.Text = "入库";
            this.入库ToolStripMenuItem.Visible = false;
            this.入库ToolStripMenuItem.Click += new System.EventHandler(this.入库ToolStripMenuItem_Click);
            // 
            // 质量控制ToolStripMenuItem
            // 
            this.质量控制ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.现势性检查ToolStripMenuItem,
            this.坐标检查ToolStripMenuItem,
            this.属性检查ToolStripMenuItem1,
            this.拓扑一致性检查ToolStripMenuItem,
            this.位置精度检查ToolStripMenuItem,
            this.表征精度检查ToolStripMenuItem});
            this.质量控制ToolStripMenuItem.Name = "质量控制ToolStripMenuItem";
            this.质量控制ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.质量控制ToolStripMenuItem.Text = "质量控制";
            this.质量控制ToolStripMenuItem.Visible = false;
            this.质量控制ToolStripMenuItem.Click += new System.EventHandler(this.质量控制ToolStripMenuItem_Click);
            // 
            // 现势性检查ToolStripMenuItem
            // 
            this.现势性检查ToolStripMenuItem.Name = "现势性检查ToolStripMenuItem";
            this.现势性检查ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.现势性检查ToolStripMenuItem.Text = "现势性检查";
            this.现势性检查ToolStripMenuItem.Click += new System.EventHandler(this.现势性检查ToolStripMenuItem_Click);
            // 
            // 坐标检查ToolStripMenuItem
            // 
            this.坐标检查ToolStripMenuItem.Name = "坐标检查ToolStripMenuItem";
            this.坐标检查ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.坐标检查ToolStripMenuItem.Text = "坐标检查";
            this.坐标检查ToolStripMenuItem.Click += new System.EventHandler(this.坐标检查ToolStripMenuItem_Click);
            // 
            // 属性检查ToolStripMenuItem1
            // 
            this.属性检查ToolStripMenuItem1.Name = "属性检查ToolStripMenuItem1";
            this.属性检查ToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.属性检查ToolStripMenuItem1.Text = "属性检查";
            this.属性检查ToolStripMenuItem1.Click += new System.EventHandler(this.属性检查ToolStripMenuItem1_Click);
            // 
            // 统计ToolStripMenuItem
            // 
            this.统计ToolStripMenuItem.Name = "统计ToolStripMenuItem";
            this.统计ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.统计ToolStripMenuItem.Text = "统计";
            this.统计ToolStripMenuItem.Visible = false;
            this.统计ToolStripMenuItem.Click += new System.EventHandler(this.统计ToolStripMenuItem_Click_1);
            // 
            // 选择操作项ToolStripMenuItem
            // 
            this.选择操作项ToolStripMenuItem.Name = "选择操作项ToolStripMenuItem";
            this.选择操作项ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.选择操作项ToolStripMenuItem.Text = "选择操作项";
            this.选择操作项ToolStripMenuItem.Visible = false;
            this.选择操作项ToolStripMenuItem.Click += new System.EventHandler(this.选择操作项ToolStripMenuItem_Click);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 25);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(644, 28);
            this.axToolbarControl1.TabIndex = 3;
            this.axToolbarControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IToolbarControlEvents_Ax_OnMouseDownEventHandler(this.axToolbarControl1_OnMouseDown);
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.axTOCControl1.Location = new System.Drawing.Point(3, 53);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(235, 356);
            this.axTOCControl1.TabIndex = 4;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(466, 278);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 53);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 378);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarXY});
            this.statusStrip1.Location = new System.Drawing.Point(3, 409);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(641, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusBar1";
            // 
            // statusBarXY
            // 
            this.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarXY.Name = "statusBarXY";
            this.statusBarXY.Size = new System.Drawing.Size(57, 17);
            this.statusBarXY.Text = "Test 123";
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
            // 拓扑一致性检查ToolStripMenuItem
            // 
            this.拓扑一致性检查ToolStripMenuItem.Name = "拓扑一致性检查ToolStripMenuItem";
            this.拓扑一致性检查ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.拓扑一致性检查ToolStripMenuItem.Text = "拓扑一致性检查";
            this.拓扑一致性检查ToolStripMenuItem.Click += new System.EventHandler(this.拓扑一致性检查ToolStripMenuItem_Click);
            // 
            // 位置精度检查ToolStripMenuItem
            // 
            this.位置精度检查ToolStripMenuItem.Name = "位置精度检查ToolStripMenuItem";
            this.位置精度检查ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.位置精度检查ToolStripMenuItem.Text = "位置精度检查";
            this.位置精度检查ToolStripMenuItem.Click += new System.EventHandler(this.位置精度检查ToolStripMenuItem_Click);
            // 
            // 表征精度检查ToolStripMenuItem
            // 
            this.表征精度检查ToolStripMenuItem.Name = "表征精度检查ToolStripMenuItem";
            this.表征精度检查ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.表征精度检查ToolStripMenuItem.Text = "表征精度检查";
            this.表征精度检查ToolStripMenuItem.Click += new System.EventHandler(this.表征精度检查ToolStripMenuItem_Click);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(238, 53);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(406, 356);
            this.axMapControl1.TabIndex = 2;
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 431);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Water Resource DBMS";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuNewDoc;
        private System.Windows.Forms.ToolStripMenuItem menuOpenDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuExitApp;
        private System.Windows.Forms.ToolStripSeparator menuSeparator;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarXY;
        private System.Windows.Forms.ToolStripMenuItem gdbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查找ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 联合查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 时间查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 范围查寻ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入CADToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入影像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 入库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 质量控制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 现势性检查ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 坐标检查ToolStripMenuItem;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.ToolStripMenuItem 属性检查ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 打开MXDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加FileGeoDatabase数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 属性查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空间查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图形查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地图选择集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择操作项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拓扑一致性检查ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 位置精度检查ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 表征精度检查ToolStripMenuItem;
    }
}

