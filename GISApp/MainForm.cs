using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
//using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using MapControlApplication3;
using WaterReservoir;
using QueryAndStatistics;
using ESRI.ArcGIS.Geometry;
using System.Collections.Generic;

namespace GISApp
{
    public sealed partial class MainForm : Form
    {
        #region class private members
        public IMapControl3 m_mapControl = null;
        private string m_mapDocumentName = string.Empty;
        private ISelectionEnvironment selectionEnvironment;
        #endregion

        #region class constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            //get the MapControl
            this.skinEngine1.SkinFile = "SteelBlue.ssk";
            m_mapControl = (IMapControl3)axMapControl1.Object;

            //disable the Save menu (since there is no document yet)
            menuSaveDoc.Enabled = false;
        }

        #region Main Menu event handlers
        private void menuNewDoc_Click(object sender, EventArgs e)
        {
            //execute New Document command
            ICommand command = new CreateNewDocument();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuOpenDoc_Click(object sender, EventArgs e)
        {
            LogHelper.writeLog("open doc");
            //execute Open Document command
            ICommand command = new ControlsOpenDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuSaveDoc_Click(object sender, EventArgs e)
        {
            LogHelper.writeLog("save doc");
            //execute Save Document command
            if (m_mapControl.CheckMxFile(m_mapDocumentName))
            {
                //create a new instance of a MapDocument
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(m_mapDocumentName, string.Empty);

                //Make sure that the MapDocument is not readonly
                if (mapDoc.get_IsReadOnly(m_mapDocumentName))
                {
                    MessageBox.Show("Map document is read only!");
                    mapDoc.Close();
                    return;
                }

                //Replace its contents with the current map
                mapDoc.ReplaceContents((IMxdContents)m_mapControl.Map);

                //save the MapDocument in order to persist it
                mapDoc.Save(mapDoc.UsesRelativePaths, false);

                //close the MapDocument
                mapDoc.Close();
            }
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            //execute SaveAs Document command
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuExitApp_Click(object sender, EventArgs e)
        {
            //exit the application
            Application.Exit();
        }
        #endregion

        //listen to MapReplaced evant in order to update the statusbar and the Save menu
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            //get the current document name from the MapControl
            m_mapDocumentName = m_mapControl.DocumentFilename;

            //if there is no MapDocument, diable the Save menu and clear the statusbar
            if (m_mapDocumentName == string.Empty)
            {
                menuSaveDoc.Enabled = false;
                statusBarXY.Text = string.Empty;
            }
            else
            {
                //enable the Save manu and write the doc name to the statusbar
                menuSaveDoc.Enabled = true;
                statusBarXY.Text = System.IO.Path.GetFileName(m_mapDocumentName);
            }
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }

        private void gdbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBHelper.init();
            Login dialog = new Login();
            dialog.ShowDialog();
            if (dialog.DialogResult == DialogResult.OK)
            {
                if (DBHelper.login(dialog.name, dialog.pass))
                {
                    MessageBox.Show("��¼�ɹ�\n��ݣ�" + DBHelper.userType);
                    ��ѯToolStripMenuItem.Visible = true;
                    ����ToolStripMenuItem.Visible = true;
                    ��������ToolStripMenuItem.Visible = true;
                    ͳ��ToolStripMenuItem.Visible = true;
                    ѡ�������ToolStripMenuItem.Visible = true;
                    դ�����ݼ��ToolStripMenuItem.Visible = true;
                    //���ToolStripMenuItem.Visible = true;
                    if (DBHelper.userType.Equals("����Ա"))
                    {
                        �û�����ToolStripMenuItem.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("��¼ʧ��");
                }
            }
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DBHelper.ifLogin)
            {
                MessageBox.Show("���¼");
                return;
            }
            
            ArrayList test = DBHelper.queryAll("NAME LIKE '%52%'");
            for (int i = 0; i < test.Count;i++ )
            {
                MessageBox.Show(((NameAndType)test[i]).name + "");
            }
            object data = DBHelper.openByTypeAndName(((NameAndType)test[0]).name, ((NameAndType)test[0]).type);

            //��ʾʸ��ͼ�ķ���
            if (((NameAndType)test[0]).type.StartsWith("f"))
            {
                IFeatureDataset queryData = (IFeatureDataset)data;
                IFeatureClassContainer datasetContainer = (IFeatureClassContainer)queryData;
                IFeatureLayer m_FeatureLayer;
                for (int i = 0; i < datasetContainer.ClassCount; i++)
                {
                    IFeatureClass pFeatureClass = datasetContainer.get_Class(i);
                    if (pFeatureClass.FeatureType == esriFeatureType.esriFTAnnotation)
                    {
                        m_FeatureLayer = new CadAnnotationLayerClass();
                        MessageBox.Show("");

                    }
                    else
                    {
                        m_FeatureLayer = new FeatureLayerClass();
                        m_FeatureLayer.Name = pFeatureClass.AliasName;
                        m_FeatureLayer.FeatureClass = pFeatureClass;

                        m_mapControl.Map.AddLayer(m_FeatureLayer);
                    }
                }
            }

            //��ʾդ��ͼ�ķ���
            if (((NameAndType)test[0]).type.StartsWith("r"))
            {
                IRasterDataset queryData = (IRasterDataset)data; 
                IRasterLayer pRasterLayer = new RasterLayerClass();
                pRasterLayer.CreateFromDataset(queryData);
                m_mapControl.Map.AddLayer(pRasterLayer as ILayer);
            }

        }

        private void �û�����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBHelper.showUserTable();
        }

        private void ���ϲ�ѯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectByAll dialog = new SelectByAll();
            dialog.ShowDialog();
            if (dialog.DialogResult == DialogResult.OK)
            {
                ArrayList result = new ArrayList();

                for (int i = 0; i < dialog.topicStr.Count; i++)
                {
                    string where;
                    if (dialog.yearStr.Length > 0 && dialog.monthStr.Length > 0)
                    {
                        where = "DESC LIKE '%" + dialog.topicStr[i] + "%' AND DATE like '" + dialog.yearStr + "-" + dialog.monthStr + "%'";
                    }
                    else
                    {
                        where = "DESC LIKE '%" + dialog.topicStr[i] + "%'";
                    }
                    ArrayList t = DBHelper.queryAll(where);
                    result.AddRange(t);
                }


                if (result.Count <= 0)
                {
                    MessageBox.Show("δ�ҵ�");
                    return;
                }/*
                for (int i = 0; i < result.Count; i++)
                {
                    MessageBox.Show(((NameAndType)result[i]).name + "");
                }*/
                ListForm resultDialog = new ListForm(result,m_mapControl);
                resultDialog.Show();
            }

        }

        private void ʱ���ѯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormByTime dialog = new FormByTime();
            dialog.Show();
        }

        private void ��Χ��ѰToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectByArea dialog = new SelectByArea();
            dialog.Show();
        }

        private void ���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("...");
            return;
        }

        private void ��ѯToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void �����Լ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DBHelper.VEC_TABLE == null || DBHelper.RAS_TABLE == null)
            {
                MessageBox.Show("��δ��ʼ��");
                return;
            }
            IName vec_Name = DBHelper.VEC_TABLE as IName;
            IName ras_Name = DBHelper.RAS_TABLE as IName;
            ITable vec_table = vec_Name.Open() as ITable;
            ITable ras_table = ras_Name.Open() as ITable;

            DataTable pTable = new DataTable();
            //����������
            DataColumn autoIncrease = new DataColumn("���",typeof(int));
            autoIncrease.AutoIncrement = true;
            autoIncrease.AutoIncrementStep = 1;
            autoIncrease.AutoIncrementSeed = 1;
            //����ֶ�
            pTable.Columns.Add(autoIncrease);
            pTable.Columns.Add("NAME", typeof(String));
            pTable.Columns.Add("DATE", typeof(String));

            //vec_Table
            ICursor vec_Cursor = vec_table.Search(null, false);
            IRow vec_Rrow = vec_Cursor.NextRow();
            while (vec_Rrow != null)
            {
                DataRow pRow = pTable.NewRow();
                //string[] StrRow = new string[pRrow.Fields.FieldCount];
                for (int i = 0; i < vec_Rrow.Fields.FieldCount; i++)
                {
                    if (vec_Rrow.Fields.get_Field(i).Name.Equals("NAME"))
                    {
                        pRow["NAME"] = vec_Rrow.get_Value(i).ToString();
                    }
                    if (vec_Rrow.Fields.get_Field(i).Name.Equals("DATE"))
                    {
                        pRow["DATE"] = vec_Rrow.get_Value(i).ToString();
                    }
                    //StrRow[i] = pRrow.get_Value(i).ToString();
                }
                //pRow.ItemArray = StrRow;
                pTable.Rows.Add(pRow);
                vec_Rrow = vec_Cursor.NextRow();
            }

            //ras_Table
            ICursor ras_Cursor = ras_table.Search(null, false);
            IRow ras_Rrow = ras_Cursor.NextRow();
            while (ras_Rrow != null)
            {
                DataRow pRow = pTable.NewRow();
                //string[] StrRow = new string[pRrow.Fields.FieldCount];
                for (int i = 0; i < ras_Rrow.Fields.FieldCount; i++)
                {
                    if (ras_Rrow.Fields.get_Field(i).Name.Equals("NAME"))
                    {
                        pRow["NAME"] = ras_Rrow.get_Value(i).ToString();
                    }
                    if (ras_Rrow.Fields.get_Field(i).Name.Equals("DATE"))
                    {
                        pRow["DATE"] = ras_Rrow.get_Value(i).ToString();
                    }
                    //StrRow[i] = pRrow.get_Value(i).ToString();
                }
                //pRow.ItemArray = StrRow;
                pTable.Rows.Add(pRow);
                ras_Rrow = ras_Cursor.NextRow();
            }
            //������ʾ��
            TimeCheck tc = new TimeCheck();
            tc.dataGridView1.DataSource = pTable;
            tc.dataGridView1.Columns[1].Width = 200;
            tc.dataGridView1.Columns[2].Width = 300;
            tc.Show();
        }

        private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DBHelper.VEC_TABLE == null || DBHelper.RAS_TABLE == null)
            {
                MessageBox.Show("��δ��ʼ��");
                return;
            }
            IName vec_Name = DBHelper.VEC_TABLE as IName;
            IName ras_Name = DBHelper.RAS_TABLE as IName;
            ITable vec_table = vec_Name.Open() as ITable;
            ITable ras_table = ras_Name.Open() as ITable;

            DataTable pTable = new DataTable();
            //����������
            DataColumn autoIncrease = new DataColumn("���", typeof(int));
            autoIncrease.AutoIncrement = true;
            autoIncrease.AutoIncrementStep = 1;
            autoIncrease.AutoIncrementSeed = 1;
            //����ֶ�
            pTable.Columns.Add(autoIncrease);
            pTable.Columns.Add("Name", typeof(String));
            pTable.Columns.Add("Message", typeof(String));

            String tempName = null;//�ñ���������¼NAME�ֶε�ֵ
            //vec_Table
            ICursor vec_Cursor = vec_table.Search(null, false);
            IRow vec_Rrow = vec_Cursor.NextRow();
            while (vec_Rrow != null)
            {
                DataRow pRow = pTable.NewRow();
                //string[] StrRow = new string[pRrow.Fields.FieldCount];
                for (int i = 0; i < vec_Rrow.Fields.FieldCount; i++)
                {
                    if (vec_Rrow.Fields.get_Field(i).Name.Equals("NAME"))
                    {
                        tempName = vec_Rrow.get_Value(i).ToString();
                    }
                    if (vec_Rrow.Fields.get_Field(i).Name.Equals("COOR"))
                    {
                        if (vec_Rrow.get_Value(i).ToString() == "")
                        {
                            pRow["Name"] = tempName;
                            pRow["Message"] = "������Ϣ����û�пռ�ο���Ϣ��";
                        }
                    }
                    //StrRow[i] = pRrow.get_Value(i).ToString();
                }
                //pRow.ItemArray = StrRow;
                pTable.Rows.Add(pRow);
                vec_Rrow = vec_Cursor.NextRow();
            }

            //ras_Table
            ICursor ras_Cursor = ras_table.Search(null, false);
            IRow ras_Rrow = ras_Cursor.NextRow();
            while (ras_Rrow != null)
            {
                DataRow pRow = pTable.NewRow();
                //string[] StrRow = new string[pRrow.Fields.FieldCount];
                for (int i = 0; i < ras_Rrow.Fields.FieldCount; i++)
                {
                    if (ras_Rrow.Fields.get_Field(i).Name.Equals("NAME"))
                    {
                        tempName = ras_Rrow.get_Value(i).ToString();
                    }
                    if (ras_Rrow.Fields.get_Field(i).Name.Equals("COOR"))
                    {
                        if (ras_Rrow.get_Value(i).ToString() == "")
                        {
                            pRow["Name"] = tempName;
                            pRow["Message"] = "������Ϣ����û�пռ�ο���Ϣ��";
                        }
                    }
                    //StrRow[i] = pRrow.get_Value(i).ToString();
                }
                //pRow.ItemArray = StrRow;
                pTable.Rows.Add(pRow);
                ras_Rrow = ras_Cursor.NextRow();
            }
            //������ʾ��
            CoordinateCheck cc = new CoordinateCheck();
            cc.dataGridView1.DataSource = pTable;
            cc.dataGridView1.Columns[1].Width = 200;
            cc.dataGridView1.Columns[2].Width = 300;
            cc.Show();
        }

        private void ���Լ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AttributionQuery(this.m_mapControl).ShowQueryResult();
        }

        private void menuFile_Click(object sender, EventArgs e)
        {

        }

        private void ����Ӱ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ���Լ��ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AttributionQuery(this.m_mapControl).ShowQueryResult();
        }

        private void ��MXDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ʹ�öԻ���ѡ��Ҫ�򿪵�mxd�ĵ�
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "ArcMap Documents (*.mxd)|*.mxd";
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    axMapControl1.LoadMxFile(filePath);
                }
            }
        }
        private void AddAllDataset(IWorkspace pWorkspace, AxMapControl mapControl)
        {
            IEnumDataset pEnumDataset = pWorkspace.get_Datasets(ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTAny);
            pEnumDataset.Reset();
            //��Enum���ݼ��е�����һ��������DataSet��
            IDataset pDataset = pEnumDataset.Next();

            //�ж����ݼ��Ƿ�������
            while (pDataset != null)
            {
                TreeNode node = new TreeNode();
                node.Name = pDataset.Name;
                node.Text = pDataset.Name;
                //treeView1.Nodes.Add(node);
                if (pDataset is IFeatureDataset)  //Ҫ�����ݼ�
                {
                    IFeatureWorkspace pFeatureWorkspace = (IFeatureWorkspace)pWorkspace;
                    IFeatureDataset pFeatureDataset = pFeatureWorkspace.OpenFeatureDataset(pDataset.Name);
                    IEnumDataset pEnumDataset1 = pFeatureDataset.Subsets;
                    pEnumDataset1.Reset();
                    IGroupLayer pGroupLayer = new GroupLayerClass();
                    pGroupLayer.Name = pFeatureDataset.Name;
                    IDataset pDataset1 = pEnumDataset1.Next();
                    while (pDataset1 != null)
                    {
                        if (pDataset1 is IFeatureClass)  //Ҫ����
                        {
                            IFeatureLayer pFeatureLayer = new FeatureLayerClass();
                            pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass(pDataset1.Name);

                            if (pFeatureLayer.FeatureClass != null)
                            {
                                pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;

                                CheckBox checkbox = new CheckBox();
                                checkbox.Text = pFeatureLayer.Name;
                                checkbox.Name = pFeatureLayer.Name;
                                node.Nodes.Add(checkbox.Name);

                                pGroupLayer.Add(pFeatureLayer);
                                mapControl.Map.AddLayer(pFeatureLayer);
                            }
                        }
                        pDataset1 = pEnumDataset1.Next();
                    }
                }
                else if (pDataset is IFeatureClass) //Ҫ����
                {
                    IFeatureWorkspace pFeatureWorkspace = (IFeatureWorkspace)pWorkspace;
                    IFeatureLayer pFeatureLayer = new FeatureLayerClass();
                    pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass(pDataset.Name);

                    pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;
                    mapControl.Map.AddLayer(pFeatureLayer);
                }
                else if (pDataset is IRasterDataset) //դ�����ݼ�
                {
                    IRasterWorkspaceEx pRasterWorkspace = (IRasterWorkspaceEx)pWorkspace;
                    IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pDataset.Name);
                    //Ӱ��������ж��봴��

                    IRasterPyramid3 pRasPyrmid;
                    pRasPyrmid = pRasterDataset as IRasterPyramid3;
                    if (pRasPyrmid != null)
                    {
                        if (!(pRasPyrmid.Present))
                        {
                            pRasPyrmid.Create(); //����������
                        }
                    }
                    IRasterLayer pRasterLayer = new RasterLayerClass();
                    pRasterLayer.CreateFromDataset(pRasterDataset);
                    ILayer pLayer = pRasterLayer as ILayer;
                    mapControl.AddLayer(pLayer, 0);
                }
                pDataset = pEnumDataset.Next();
            }

            mapControl.ActiveView.Refresh();

        }
        private void ���FileGeoDatabase����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IWorkspaceFactory pFileGDBWorkspaceFactory;

            //FolderBrowserDialog dlg = new FolderBrowserDialog();
            //if (dlg.ShowDialog() != DialogResult.OK) return;
            //string pFullPath = dlg.SelectedPath;

            //if (pFullPath == "")
            //{
            //    return;
            //}
            pFileGDBWorkspaceFactory = new FileGDBWorkspaceFactoryClass(); //using ESRI.ArcGIS.DataSourcesGDB;

            //ClearAllData();    //����ɾ������
            string pFullPath = "G:\\��һ\\�ռ����ݹ���\\DATABASE\\JCDL.gdb";
            //��ȡ�����ռ�
            IWorkspace pWorkspace = pFileGDBWorkspaceFactory.OpenFromFile(pFullPath, 0);
            AddAllDataset(pWorkspace, axMapControl1);
        }

        private void axToolbarControl1_OnMouseDown(object sender, IToolbarControlEvents_OnMouseDownEvent e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void ���Բ�ѯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //�´������Բ�ѯ����
            FormQueryByAttribute formQueryByAttribute = new FormQueryByAttribute();
            //����ǰ��������MapControl�ؼ��е�Map����ֵ��FormQueryByAttribute�����CurrentMap����
            formQueryByAttribute.CurrentMap = axMapControl1.Map;
            //��ʾ���Բ�ѯ����
            formQueryByAttribute.Show();
        }

        private void �ռ��ѯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //�´����ռ��ѯ����
            FormQueryBySpatial formQueryBySpatial = new FormQueryBySpatial();
            //����ǰ��������MapControl�ؼ��е�Map����ֵ��FormSelection�����CurrentMap����
            formQueryBySpatial.CurrentMap = axMapControl1.Map;
            //��ʾ�ռ��ѯ����
            formQueryBySpatial.Show();
        }

        private void ��ͼѡ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //�´�����ͼѡ�񼯴���
            FormSelection formSelection = new FormSelection();
            //����ǰ��������MapControl�ؼ��е�Map����ֵ��FormSelection�����CurrentMap����
            formSelection.CurrentMap = axMapControl1.Map;
            //��ʾ��ͼѡ�񼯴���
            formSelection.Show();
        }

        private void ͳ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //�´���ͳ�ƴ���
            FormStatistics formStatistics = new FormStatistics();
            //����ǰ��������MapControl�ؼ��е�Map����ֵ��FormStatistics�����CurrentMap����
            formStatistics.CurrentMap = axMapControl1.Map;
            //��ʾͳ�ƴ���
            formStatistics.Show();
        }

        private void ͳ��ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //�´���ͳ�ƴ���
            FormStatistics formStatistics = new FormStatistics();
            //����ǰ��������MapControl�ؼ��е�Map����ֵ��FormStatistics�����CurrentMap����
            formStatistics.CurrentMap = axMapControl1.Map;
            //��ʾͳ�ƴ���
            formStatistics.Show();
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ѡ�������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //�´���ѡ�����ѡ���
            FormOptions formOptions = new FormOptions();
            //����ǰ��������MapControl�ؼ��е�Map����ֵ��FormOptions�����CurrentMap����
            formOptions.CurrentSelectionEnvironment = selectionEnvironment;
            //��ʾѡ�����ѡ���
            formOptions.Show();
        }
       
       
        string pFullPath = System.Environment.CurrentDirectory + "\\data\\դ���������\\YGYX.gdb";
        private void �ο�ϵͳһ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IWorkspaceFactory pFileGDBWorkspaceFactory; 
            pFileGDBWorkspaceFactory = new FileGDBWorkspaceFactoryClass(); //using ESRI.ArcGIS.DataSourcesGDB;

            //��ȡ�����ռ�
            IWorkspace pWorkspace = pFileGDBWorkspaceFactory.OpenFromFile(pFullPath, 0);
            IEnumDataset pEnumDataset = pWorkspace.get_Datasets(ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTAny);
            pEnumDataset.Reset();
            //��Enum���ݼ��е�����һ��������DataSet��
            IDataset pDataset = pEnumDataset.Next();

            DataTable SpatialRefTable = new DataTable();

            SpatialRefTable.Columns.Add(new DataColumn("Ӱ������", typeof(string)));
            SpatialRefTable.Columns.Add(new DataColumn("��������", typeof(string)));
            SpatialRefTable.Columns.Add(new DataColumn("�������ݿ�", typeof(string)));
            SpatialRefTable.Columns.Add(new DataColumn("���Ƹ�ʽ���", typeof(string)));

            //�ж����ݼ��Ƿ�������
            while (pDataset != null)
            {
               
                
                if (pDataset is IRasterDataset) //դ�����ݼ�
                {
                    IRasterWorkspaceEx pRasterWorkspace = (IRasterWorkspaceEx)pWorkspace;
                    IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pDataset.Name);
                    //Ӱ��������ж��봴��
                    ISpatialReference pSpatialRef = (pRasterDataset as IGeoDataset).SpatialReference;
                    string spatialref = pSpatialRef.Name.ToString();

                    DataRow dr = SpatialRefTable.NewRow();
                    dr["Ӱ������"] = pDataset.Name.ToString();
                    dr["��������"] = "File GeoDatabase Raster Dataset";
                    dr["�������ݿ�"] = pFullPath;
                    string rastername = pDataset.Name.ToString();
                    string[] strArray = rastername.Split('_');
                    if (strArray[0]=="GF1"&& strArray[1].Length==10)
                    {
                        dr["���Ƹ�ʽ���"] = "��";

                    }
                    else
                    { 
                        dr["���Ƹ�ʽ���"] = "��";
                    }
                    SpatialRefTable.Rows.Add(dr);
                    //IRasterPyramid3 pRasPyrmid;
                    //pRasPyrmid = pRasterDataset as IRasterPyramid3;
                    //if (pRasPyrmid != null)
                    //{
                    //    if (!(pRasPyrmid.Present))
                    //    {
                    //        pRasPyrmid.Create(); //����������
                    //    }
                    //}
                    IRasterLayer pRasterLayer = new RasterLayerClass();
                    pRasterLayer.CreateFromDataset(pRasterDataset);
                    ILayer pLayer = pRasterLayer as ILayer;
                   

                    //axMapControl1.AddLayer(pLayer, 0);
                }
                pDataset = pEnumDataset.Next();
            }
           // ExportExcel(SpatialRefTable);
            //������ʾ��
            TimeCheck tc = new TimeCheck();
            tc.Text = "��ʽһ����";
            tc.dataGridView1.DataSource = SpatialRefTable;
            tc.dataGridView1.Columns[1].Width = 200;
            tc.dataGridView1.Columns[2].Width = 300;
            tc.Show();
        }
        public void ExportExcel(DataTable myDGV)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel�ļ�|*.xls";
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //������ȡ��   

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("�޷�����Excel���󣬿������Ļ���δ��װExcel");
                return;
            }

            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//ȡ��sheet1  

            //д�����  
            for (int i = 0; i < myDGV.Columns.Count; i++)
            {
                worksheet.Columns.Cells[1, i + 1] = myDGV.Columns[i].ColumnName;
            }
            //д����ֵ  
            for (int r = 0; r < myDGV.Rows.Count; r++)
            {
                for (int i = 0; i < myDGV.Columns.Count; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r][i].ToString();
                }
                System.Windows.Forms.Application.DoEvents();
            }

            worksheet.Columns.EntireColumn.AutoFit();//�п�����Ӧ  

            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�����ļ�ʱ����,�ļ����������򿪣�\n" + ex.Message);
                }
                xlApp.Quit();
                GC.Collect();//ǿ������   
                MessageBox.Show("���ϱ���ɹ�", "��ʾ", MessageBoxButtons.OK);
            }
        }

        private void ��ѧ���ȼ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IWorkspaceFactory pFileGDBWorkspaceFactory;
            pFileGDBWorkspaceFactory = new FileGDBWorkspaceFactoryClass(); //using ESRI.ArcGIS.DataSourcesGDB;

            
            //��ȡ�����ռ�
            IWorkspace pWorkspace = pFileGDBWorkspaceFactory.OpenFromFile(pFullPath, 0);
            //  AddAllDataset(pWorkspace, axMapControl1);

            IEnumDataset pEnumDataset = pWorkspace.get_Datasets(ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTAny);
            pEnumDataset.Reset();
            //��Enum���ݼ��е�����һ��������DataSet��
            IDataset pDataset = pEnumDataset.Next();

            DataTable SpatialRefTable = new DataTable();

            SpatialRefTable.Columns.Add(new DataColumn("Ӱ������", typeof(string)));
            SpatialRefTable.Columns.Add(new DataColumn("��������ϵͳ", typeof(string)));
          
            SpatialRefTable.Columns.Add(new DataColumn("����ϵ���", typeof(string)));
           
            //�ж����ݼ��Ƿ�������
            while (pDataset != null)
            {

                if (pDataset is IRasterDataset) //դ�����ݼ�
                {
                    IRasterWorkspaceEx pRasterWorkspace = (IRasterWorkspaceEx)pWorkspace;
                    IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pDataset.Name);
                    //Ӱ��������ж��봴��
                    ISpatialReference pSpatialRef = (pRasterDataset as IGeoDataset).SpatialReference;
                    string spatialref = pSpatialRef.Name.ToString();
                    
                    DataRow dr = SpatialRefTable.NewRow();
                    dr["Ӱ������"] = pDataset.Name.ToString();
                    dr["��������ϵͳ"] = spatialref;


                    //string rasterformat = pRasterDataset.Format.ToString();
                    if (spatialref == "Shenzhen_Local")
                    {
                        dr["����ϵ���"] = "��";

                    }
                    else
                    {
                        dr["����ϵ���"] = "��";
                    }
                  
                    SpatialRefTable.Rows.Add(dr);
                    //IRasterPyramid3 pRasPyrmid;
                    //pRasPyrmid = pRasterDataset as IRasterPyramid3;
                    //if (pRasPyrmid != null)
                    //{
                    //    if (!(pRasPyrmid.Present))
                    //    {
                    //        pRasPyrmid.Create(); //����������
                    //    }
                    //}
                    IRasterLayer pRasterLayer = new RasterLayerClass();
                    pRasterLayer.CreateFromDataset(pRasterDataset);
                    ILayer pLayer = pRasterLayer as ILayer;

                    IRasterProps rasterProps = (IRasterProps)pRasterLayer.Raster;
                    double dX = rasterProps.MeanCellSize().X;
                    //axMapControl1.AddLayer(pLayer, 0);
                }
                pDataset = pEnumDataset.Next();
            }
            // ExportExcel(SpatialRefTable);
            //������ʾ��
            TimeCheck tc = new TimeCheck();
            tc.Text = "��ѧ���ȼ��";
            tc.dataGridView1.DataSource = SpatialRefTable;
            tc.dataGridView1.Columns[1].Width = 200;
            tc.dataGridView1.Columns[2].Width = 300;
            tc.Show();
        }

        private void Ӱ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IWorkspaceFactory pFileGDBWorkspaceFactory;
            pFileGDBWorkspaceFactory = new FileGDBWorkspaceFactoryClass(); //using ESRI.ArcGIS.DataSourcesGDB;

          
            //��ȡ�����ռ�
            IWorkspace pWorkspace = pFileGDBWorkspaceFactory.OpenFromFile(pFullPath, 0);
            //  AddAllDataset(pWorkspace, axMapControl1);

            IEnumDataset pEnumDataset = pWorkspace.get_Datasets(ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTAny);
            pEnumDataset.Reset();
            //��Enum���ݼ��е�����һ��������DataSet��
            IDataset pDataset = pEnumDataset.Next();

            DataTable SpatialRefTable = new DataTable();

            SpatialRefTable.Columns.Add(new DataColumn("Ӱ������", typeof(string)));
            SpatialRefTable.Columns.Add(new DataColumn("Ӱ��ֱ���", typeof(string)));
            SpatialRefTable.Columns.Add(new DataColumn("Ӱ��ֱ��ʼ��", typeof(string)));

            //�ж����ݼ��Ƿ�������
            while (pDataset != null)
            {

                if (pDataset is IRasterDataset) //դ�����ݼ�
                {
                    IRasterWorkspaceEx pRasterWorkspace = (IRasterWorkspaceEx)pWorkspace;
                    IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pDataset.Name);
                    //Ӱ��������ж��봴��
                    ISpatialReference pSpatialRef = (pRasterDataset as IGeoDataset).SpatialReference;
                    string spatialref = pSpatialRef.Name.ToString();

                    DataRow dr = SpatialRefTable.NewRow();
                    dr["Ӱ������"] = pDataset.Name.ToString();
                    IRasterLayer pRasterLayer = new RasterLayerClass();
                    pRasterLayer.CreateFromDataset(pRasterDataset);


                    IRasterProps rasterProps = (IRasterProps)pRasterLayer.Raster;
                    double dX = rasterProps.MeanCellSize().X;
                    double dY = rasterProps.MeanCellSize().Y;
                    dr["Ӱ��ֱ���"] = "(" + dX.ToString() + "*" + dX.ToString() + ")";
                    //string rasterformat = pRasterDataset.Format.ToString();
                    if (dX == 20&&dY==20)
                    {
                        dr["Ӱ��ֱ��ʼ��"] = "��";

                    }
                    else
                    {
                        dr["Ӱ��ֱ��ʼ��"] = "��";
                    }

                    SpatialRefTable.Rows.Add(dr);
                  

                }
                pDataset = pEnumDataset.Next();
            }
            // ExportExcel(SpatialRefTable);
            //������ʾ��
            TimeCheck tc = new TimeCheck();
            tc.Text = "Ӱ���������";
            tc.dataGridView1.DataSource = SpatialRefTable;
            tc.dataGridView1.Columns[1].Width = 200;
            tc.dataGridView1.Columns[2].Width = 300;
            tc.Show();
        }


        private void �걸�Լ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IWorkspaceFactory pFileGDBWorkspaceFactory;
            pFileGDBWorkspaceFactory = new FileGDBWorkspaceFactoryClass(); //using ESRI.ArcGIS.DataSourcesGDB;

            //��ȡ�����ռ�
            IWorkspace pWorkspace = pFileGDBWorkspaceFactory.OpenFromFile(pFullPath, 0);
            //  AddAllDataset(pWorkspace, axMapControl1);

            IEnumDataset pEnumDataset = pWorkspace.get_Datasets(ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTAny);
            pEnumDataset.Reset();
            //��Enum���ݼ��е�����һ��������DataSet��
            IDataset pDataset = pEnumDataset.Next();


            DataTable SpatialRefTable = new DataTable();
            SpatialRefTable.Columns.Add(new DataColumn("δ�ַ�Ӱ������", typeof(string)));
            SpatialRefTable.Columns.Add(new DataColumn("�ַ�����", typeof(int)));
            SpatialRefTable.Columns.Add(new DataColumn("�ַ�Ӱ���걸�Լ��", typeof(string)));
            int rastercount=0;
            string rastername = "a";
            List<string> testList = new List<string>();
            //�ж����ݼ��Ƿ�������
            while (pDataset != null)
            {
                if (pDataset is IRasterDataset) //դ�����ݼ�
                {
                    IRasterWorkspaceEx pRasterWorkspace = (IRasterWorkspaceEx)pWorkspace;
                    IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pDataset.Name);
                    //Ӱ��������ж��봴��
                    ISpatialReference pSpatialRef = (pRasterDataset as IGeoDataset).SpatialReference;
                    string spatialref = pSpatialRef.Name.ToString();

                    
                    testList.Add(pDataset.Name.ToString());
               
                }
                pDataset = pEnumDataset.Next();
            }
            testList.Sort();
            
            for (int i = 0;i< testList.Count;i++)
            {
                DataRow dr = SpatialRefTable.NewRow();
                if (rastername != testList[i].Substring(0, testList[i].Length - 1))
                {
                    rastername = testList[i].Substring(0, testList[i].Length - 1);
                    dr["δ�ַ�Ӱ������"] = rastername;
                    dr["�ַ�����"] = rastercount;
                    if(rastercount==4)
                    {
                        dr["�ַ�Ӱ���걸�Լ��"] = "��";
                        SpatialRefTable.Rows.Add(dr);
                    }
                    else if(rastercount == 3)
                    {
                        dr["�ַ�Ӱ���걸�Լ��"] = "��";
                        SpatialRefTable.Rows.Add(dr);
                    }
                   
                  
                    rastercount = 1;
                }
                else
                {
                    rastercount = rastercount + 1;
                }
            }
            
            // ExportExcel(SpatialRefTable);
            //������ʾ��
            TimeCheck tc = new TimeCheck();
            tc.Text = "Ӱ���걸�Լ��";
            tc.dataGridView1.DataSource = SpatialRefTable;
            tc.dataGridView1.Columns[1].Width = 200;
            tc.dataGridView1.Columns[2].Width = 300;
            tc.Show();
        }

        private void �����Լ��ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IWorkspaceFactory pFileGDBWorkspaceFactory;
            pFileGDBWorkspaceFactory = new FileGDBWorkspaceFactoryClass(); //using ESRI.ArcGIS.DataSourcesGDB;

            //ClearAllData();    //����ɾ������
  
            //��ȡ�����ռ�
            IWorkspace pWorkspace = pFileGDBWorkspaceFactory.OpenFromFile(pFullPath, 0);
            //  AddAllDataset(pWorkspace, axMapControl1);

            IEnumDataset pEnumDataset = pWorkspace.get_Datasets(ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTAny);
            pEnumDataset.Reset();
            //��Enum���ݼ��е�����һ��������DataSet��
            IDataset pDataset = pEnumDataset.Next();

            DataTable SpatialRefTable = new DataTable();

            SpatialRefTable.Columns.Add(new DataColumn("Ӱ������", typeof(string)));
            SpatialRefTable.Columns.Add(new DataColumn("Ӱ������ʱ��", typeof(string)));
            SpatialRefTable.Columns.Add(new DataColumn("ʱ�������Լ��", typeof(string)));

            //�ж����ݼ��Ƿ�������
            while (pDataset != null)
            {

                if (pDataset is IRasterDataset) //դ�����ݼ�
                {
                    IRasterWorkspaceEx pRasterWorkspace = (IRasterWorkspaceEx)pWorkspace;
                    IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pDataset.Name);
                    //Ӱ��������ж��봴��
                    ISpatialReference pSpatialRef = (pRasterDataset as IGeoDataset).SpatialReference;
                    string spatialref = pSpatialRef.Name.ToString();
                    string rastername = pDataset.Name.ToString();
                    string[] strArray = rastername.Split('_');

                    DataRow dr = SpatialRefTable.NewRow();
                    dr["Ӱ������"] = pDataset.Name.ToString();
                    dr["Ӱ������ʱ��"] = strArray[1].Substring(0,8);
                    IRasterLayer pRasterLayer = new RasterLayerClass();
                    pRasterLayer.CreateFromDataset(pRasterDataset);
                    if(int.Parse(strArray[1].Substring(0, 8))<20170000&& int.Parse(strArray[1].Substring(0, 8))>20120000)
                    {
                        dr["ʱ�������Լ��"] = "��";
                    }
                    else
                    {
                        dr["ʱ�������Լ��"] = "��";
                    }
                    SpatialRefTable.Rows.Add(dr);

                }
                pDataset = pEnumDataset.Next();
            }
            // ExportExcel(SpatialRefTable);
            //������ʾ��
            TimeCheck tc = new TimeCheck();
            tc.Text = "Ӱ���������";
            tc.dataGridView1.DataSource = SpatialRefTable;
            tc.dataGridView1.Columns[1].Width = 200;
            tc.dataGridView1.Columns[2].Width = 300;
            tc.Show();
        }

       
    }
}