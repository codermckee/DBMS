using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using System.Collections;
using GISApp;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.DataSourcesFile;


namespace MapControlApplication3
{
    public partial class ListForm : Form
    {
        public ArrayList data = new ArrayList();
        IMapControl3 m_mapControl;

        public ListForm(ArrayList data, IMapControl3 m_mapControl)
        {
            InitializeComponent();
            this.m_mapControl = m_mapControl;
            this.data = data;
            listView1.View = View.Details; 
            //listView1.CheckBoxes = true;
            listView1.BeginUpdate();
            listView1.Columns.Add("名称");
            listView1.Columns.Add("格式");

            for (int i = 0; i < data.Count;i++ )
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = ((NameAndType)data[i]).name;
                lvi.SubItems.Add(((NameAndType)data[i]).type);
                this.listView1.Items.Add(lvi);
            }

            this.listView1.Columns[0].Width = 100;
            this.listView1.Columns[1].Width = 100;
            listView1.EndUpdate();
        }

        private void ListForm_Load(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count>0)
            {
                NameAndType select = new NameAndType();
                int lvi = listView1.SelectedItems[0].Index;
                select = (NameAndType)data[lvi];
                object dBdata = DBHelper.openByTypeAndName((select).name, (select).type);
                m_mapControl.Map.ClearLayers();
                //显示矢量图的方法
                if ((select).type.StartsWith("f"))
                {
                    IFeatureDataset queryData = (IFeatureDataset)dBdata;
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

                //显示栅格图的方法
                if ((select).type.StartsWith("r"))
                {
                    IRasterDataset queryData = (IRasterDataset)dBdata;
                    IRasterLayer pRasterLayer = new RasterLayerClass();
                    pRasterLayer.CreateFromDataset(queryData);
                    m_mapControl.Map.AddLayer(pRasterLayer as ILayer);
                }
            }
            //MessageBox.Show(listView1.SelectedItems[0].Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }

}
