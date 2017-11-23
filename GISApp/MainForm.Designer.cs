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
            this.��MXDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���FileGeoDatabase����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.gdbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ʱ���ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��Χ��ѰToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���ϲ�ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���Բ�ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�ռ��ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͼ�β�ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ͼѡ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����CADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����Ӱ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�û�����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�����Լ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���Լ��ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ͳ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ѡ�������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.����һ���Լ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.λ�þ��ȼ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�������ȼ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.��ѯToolStripMenuItem,
            this.����ToolStripMenuItem,
            this.�û�����ToolStripMenuItem,
            this.����ToolStripMenuItem,
            this.���ToolStripMenuItem,
            this.��������ToolStripMenuItem,
            this.ͳ��ToolStripMenuItem,
            this.ѡ�������ToolStripMenuItem});
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
            this.��MXDToolStripMenuItem,
            this.���FileGeoDatabase����ToolStripMenuItem,
            this.menuSaveDoc,
            this.menuSaveAs,
            this.menuSeparator,
            this.menuExitApp});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(44, 21);
            this.menuFile.Text = "�ļ�";
            this.menuFile.Click += new System.EventHandler(this.menuFile_Click);
            // 
            // menuNewDoc
            // 
            this.menuNewDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuNewDoc.Image")));
            this.menuNewDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuNewDoc.Name = "menuNewDoc";
            this.menuNewDoc.Size = new System.Drawing.Size(222, 22);
            this.menuNewDoc.Text = "�½�";
            this.menuNewDoc.Click += new System.EventHandler(this.menuNewDoc_Click);
            // 
            // menuOpenDoc
            // 
            this.menuOpenDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenDoc.Image")));
            this.menuOpenDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuOpenDoc.Name = "menuOpenDoc";
            this.menuOpenDoc.Size = new System.Drawing.Size(222, 22);
            this.menuOpenDoc.Text = "��";
            this.menuOpenDoc.Click += new System.EventHandler(this.menuOpenDoc_Click);
            // 
            // ��MXDToolStripMenuItem
            // 
            this.��MXDToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.��MXDToolStripMenuItem.Name = "��MXDToolStripMenuItem";
            this.��MXDToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.��MXDToolStripMenuItem.Text = "��MXD";
            this.��MXDToolStripMenuItem.Click += new System.EventHandler(this.��MXDToolStripMenuItem_Click);
            // 
            // ���FileGeoDatabase����ToolStripMenuItem
            // 
            this.���FileGeoDatabase����ToolStripMenuItem.Name = "���FileGeoDatabase����ToolStripMenuItem";
            this.���FileGeoDatabase����ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.���FileGeoDatabase����ToolStripMenuItem.Text = "���FileGeoDatabase����";
            this.���FileGeoDatabase����ToolStripMenuItem.Click += new System.EventHandler(this.���FileGeoDatabase����ToolStripMenuItem_Click);
            // 
            // menuSaveDoc
            // 
            this.menuSaveDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveDoc.Image")));
            this.menuSaveDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuSaveDoc.Name = "menuSaveDoc";
            this.menuSaveDoc.Size = new System.Drawing.Size(222, 22);
            this.menuSaveDoc.Text = "����";
            this.menuSaveDoc.Click += new System.EventHandler(this.menuSaveDoc_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(222, 22);
            this.menuSaveAs.Text = "���Ϊ";
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
            this.menuExitApp.Text = "�˳�";
            this.menuExitApp.Click += new System.EventHandler(this.menuExitApp_Click);
            // 
            // gdbToolStripMenuItem
            // 
            this.gdbToolStripMenuItem.Name = "gdbToolStripMenuItem";
            this.gdbToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.gdbToolStripMenuItem.Text = "��¼";
            this.gdbToolStripMenuItem.Click += new System.EventHandler(this.gdbToolStripMenuItem_Click);
            // 
            // ��ѯToolStripMenuItem
            // 
            this.��ѯToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ʱ���ѯToolStripMenuItem,
            this.��Χ��ѰToolStripMenuItem,
            this.���ϲ�ѯToolStripMenuItem,
            this.���Բ�ѯToolStripMenuItem,
            this.�ռ��ѯToolStripMenuItem,
            this.ͼ�β�ѯToolStripMenuItem,
            this.��ͼѡ��ToolStripMenuItem});
            this.��ѯToolStripMenuItem.Name = "��ѯToolStripMenuItem";
            this.��ѯToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.��ѯToolStripMenuItem.Text = "��ѯ";
            this.��ѯToolStripMenuItem.Visible = false;
            this.��ѯToolStripMenuItem.Click += new System.EventHandler(this.��ѯToolStripMenuItem_Click);
            // 
            // ʱ���ѯToolStripMenuItem
            // 
            this.ʱ���ѯToolStripMenuItem.Name = "ʱ���ѯToolStripMenuItem";
            this.ʱ���ѯToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ʱ���ѯToolStripMenuItem.Text = "ʱ���ѯ";
            this.ʱ���ѯToolStripMenuItem.Click += new System.EventHandler(this.ʱ���ѯToolStripMenuItem_Click);
            // 
            // ��Χ��ѰToolStripMenuItem
            // 
            this.��Χ��ѰToolStripMenuItem.Name = "��Χ��ѰToolStripMenuItem";
            this.��Χ��ѰToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.��Χ��ѰToolStripMenuItem.Text = "ͼ����ѯ";
            this.��Χ��ѰToolStripMenuItem.Click += new System.EventHandler(this.��Χ��ѰToolStripMenuItem_Click);
            // 
            // ���ϲ�ѯToolStripMenuItem
            // 
            this.���ϲ�ѯToolStripMenuItem.Name = "���ϲ�ѯToolStripMenuItem";
            this.���ϲ�ѯToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.���ϲ�ѯToolStripMenuItem.Text = "���ϲ�ѯ";
            this.���ϲ�ѯToolStripMenuItem.Click += new System.EventHandler(this.���ϲ�ѯToolStripMenuItem_Click);
            // 
            // ���Բ�ѯToolStripMenuItem
            // 
            this.���Բ�ѯToolStripMenuItem.Name = "���Բ�ѯToolStripMenuItem";
            this.���Բ�ѯToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.���Բ�ѯToolStripMenuItem.Text = "���Բ�ѯ";
            this.���Բ�ѯToolStripMenuItem.Click += new System.EventHandler(this.���Բ�ѯToolStripMenuItem_Click);
            // 
            // �ռ��ѯToolStripMenuItem
            // 
            this.�ռ��ѯToolStripMenuItem.Name = "�ռ��ѯToolStripMenuItem";
            this.�ռ��ѯToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.�ռ��ѯToolStripMenuItem.Text = "�ռ��ѯ";
            this.�ռ��ѯToolStripMenuItem.Click += new System.EventHandler(this.�ռ��ѯToolStripMenuItem_Click);
            // 
            // ͼ�β�ѯToolStripMenuItem
            // 
            this.ͼ�β�ѯToolStripMenuItem.Name = "ͼ�β�ѯToolStripMenuItem";
            this.ͼ�β�ѯToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ͼ�β�ѯToolStripMenuItem.Text = "ͼ�β�ѯ";
            // 
            // ��ͼѡ��ToolStripMenuItem
            // 
            this.��ͼѡ��ToolStripMenuItem.Name = "��ͼѡ��ToolStripMenuItem";
            this.��ͼѡ��ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.��ͼѡ��ToolStripMenuItem.Text = "��ͼѡ��";
            this.��ͼѡ��ToolStripMenuItem.Click += new System.EventHandler(this.��ͼѡ��ToolStripMenuItem_Click);
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.����CADToolStripMenuItem,
            this.����Ӱ��ToolStripMenuItem});
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.����ToolStripMenuItem.Text = "����";
            this.����ToolStripMenuItem.Visible = false;
            this.����ToolStripMenuItem.Click += new System.EventHandler(this.����ToolStripMenuItem_Click);
            // 
            // ����CADToolStripMenuItem
            // 
            this.����CADToolStripMenuItem.Name = "����CADToolStripMenuItem";
            this.����CADToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.����CADToolStripMenuItem.Text = "����CAD";
            // 
            // ����Ӱ��ToolStripMenuItem
            // 
            this.����Ӱ��ToolStripMenuItem.Name = "����Ӱ��ToolStripMenuItem";
            this.����Ӱ��ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.����Ӱ��ToolStripMenuItem.Text = "����Ӱ��";
            this.����Ӱ��ToolStripMenuItem.Click += new System.EventHandler(this.����Ӱ��ToolStripMenuItem_Click);
            // 
            // �û�����ToolStripMenuItem
            // 
            this.�û�����ToolStripMenuItem.Name = "�û�����ToolStripMenuItem";
            this.�û�����ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.�û�����ToolStripMenuItem.Text = "�û�����";
            this.�û�����ToolStripMenuItem.Visible = false;
            this.�û�����ToolStripMenuItem.Click += new System.EventHandler(this.�û�����ToolStripMenuItem_Click);
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.����ToolStripMenuItem.Text = "����";
            this.����ToolStripMenuItem.Visible = false;
            this.����ToolStripMenuItem.Click += new System.EventHandler(this.����ToolStripMenuItem_Click);
            // 
            // ���ToolStripMenuItem
            // 
            this.���ToolStripMenuItem.Name = "���ToolStripMenuItem";
            this.���ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.���ToolStripMenuItem.Text = "���";
            this.���ToolStripMenuItem.Visible = false;
            this.���ToolStripMenuItem.Click += new System.EventHandler(this.���ToolStripMenuItem_Click);
            // 
            // ��������ToolStripMenuItem
            // 
            this.��������ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�����Լ��ToolStripMenuItem,
            this.������ToolStripMenuItem,
            this.���Լ��ToolStripMenuItem1,
            this.����һ���Լ��ToolStripMenuItem,
            this.λ�þ��ȼ��ToolStripMenuItem,
            this.�������ȼ��ToolStripMenuItem});
            this.��������ToolStripMenuItem.Name = "��������ToolStripMenuItem";
            this.��������ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.��������ToolStripMenuItem.Text = "��������";
            this.��������ToolStripMenuItem.Visible = false;
            this.��������ToolStripMenuItem.Click += new System.EventHandler(this.��������ToolStripMenuItem_Click);
            // 
            // �����Լ��ToolStripMenuItem
            // 
            this.�����Լ��ToolStripMenuItem.Name = "�����Լ��ToolStripMenuItem";
            this.�����Լ��ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.�����Լ��ToolStripMenuItem.Text = "�����Լ��";
            this.�����Լ��ToolStripMenuItem.Click += new System.EventHandler(this.�����Լ��ToolStripMenuItem_Click);
            // 
            // ������ToolStripMenuItem
            // 
            this.������ToolStripMenuItem.Name = "������ToolStripMenuItem";
            this.������ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.������ToolStripMenuItem.Text = "������";
            this.������ToolStripMenuItem.Click += new System.EventHandler(this.������ToolStripMenuItem_Click);
            // 
            // ���Լ��ToolStripMenuItem1
            // 
            this.���Լ��ToolStripMenuItem1.Name = "���Լ��ToolStripMenuItem1";
            this.���Լ��ToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.���Լ��ToolStripMenuItem1.Text = "���Լ��";
            this.���Լ��ToolStripMenuItem1.Click += new System.EventHandler(this.���Լ��ToolStripMenuItem1_Click);
            // 
            // ͳ��ToolStripMenuItem
            // 
            this.ͳ��ToolStripMenuItem.Name = "ͳ��ToolStripMenuItem";
            this.ͳ��ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.ͳ��ToolStripMenuItem.Text = "ͳ��";
            this.ͳ��ToolStripMenuItem.Visible = false;
            this.ͳ��ToolStripMenuItem.Click += new System.EventHandler(this.ͳ��ToolStripMenuItem_Click_1);
            // 
            // ѡ�������ToolStripMenuItem
            // 
            this.ѡ�������ToolStripMenuItem.Name = "ѡ�������ToolStripMenuItem";
            this.ѡ�������ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.ѡ�������ToolStripMenuItem.Text = "ѡ�������";
            this.ѡ�������ToolStripMenuItem.Visible = false;
            this.ѡ�������ToolStripMenuItem.Click += new System.EventHandler(this.ѡ�������ToolStripMenuItem_Click);
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
            // ����һ���Լ��ToolStripMenuItem
            // 
            this.����һ���Լ��ToolStripMenuItem.Name = "����һ���Լ��ToolStripMenuItem";
            this.����һ���Լ��ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.����һ���Լ��ToolStripMenuItem.Text = "����һ���Լ��";
            this.����һ���Լ��ToolStripMenuItem.Click += new System.EventHandler(this.����һ���Լ��ToolStripMenuItem_Click);
            // 
            // λ�þ��ȼ��ToolStripMenuItem
            // 
            this.λ�þ��ȼ��ToolStripMenuItem.Name = "λ�þ��ȼ��ToolStripMenuItem";
            this.λ�þ��ȼ��ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.λ�þ��ȼ��ToolStripMenuItem.Text = "λ�þ��ȼ��";
            this.λ�þ��ȼ��ToolStripMenuItem.Click += new System.EventHandler(this.λ�þ��ȼ��ToolStripMenuItem_Click);
            // 
            // �������ȼ��ToolStripMenuItem
            // 
            this.�������ȼ��ToolStripMenuItem.Name = "�������ȼ��ToolStripMenuItem";
            this.�������ȼ��ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.�������ȼ��ToolStripMenuItem.Text = "�������ȼ��";
            this.�������ȼ��ToolStripMenuItem.Click += new System.EventHandler(this.�������ȼ��ToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem ����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �û�����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��ѯToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ���ϲ�ѯToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ʱ���ѯToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��Χ��ѰToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����CADToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����Ӱ��ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ���ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��������ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �����Լ��ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ������ToolStripMenuItem;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.ToolStripMenuItem ���Լ��ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ��MXDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ���FileGeoDatabase����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ���Բ�ѯToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �ռ��ѯToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ͼ�β�ѯToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��ͼѡ��ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ͳ��ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ѡ�������ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����һ���Լ��ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem λ�þ��ȼ��ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �������ȼ��ToolStripMenuItem;
    }
}

