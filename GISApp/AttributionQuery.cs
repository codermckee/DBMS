using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System.Data;

namespace GISApp
{

    public class AttributionQuery
    {
        private IMapControl3 m_MapControl = null;
        private string m_VecPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "data/vec.gdb";//矢量数据库路径
        private string m_DocPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "data/doc.gdb";//文档数据库路径
        /// <summary>
        /// 构造
        /// </summary>
        public AttributionQuery(IMapControl3 mapControl)
        {
            m_MapControl = mapControl;
        }

        public void ShowQueryResult()
        {
            QueryResult f = new QueryResult(OpenVec(OpenDoc()));
            f.Show();
        }

        private DataTable OpenVec(Dictionary<string, DataType> Dic)
        {
            IWorkspaceFactory pWorkspaceFactory = new FileGDBWorkspaceFactoryClass();
            IWorkspace pVecWorkspace = pWorkspaceFactory.OpenFromFile(m_VecPath, 0);
            IFeatureWorkspace pFeatureWorkspace = pVecWorkspace as IFeatureWorkspace;
            IEnumDataset pEnumDataset = pVecWorkspace.get_Datasets(esriDatasetType.esriDTAny) as IEnumDataset;
            pEnumDataset.Reset();
            IDataset pDataset = pEnumDataset.Next();
            while (null != pDataset)
            {
                if (pDataset is IFeatureClass)//SHP文件
                {
                    if (pDataset.Name.ToUpper().Equals("PROVINCE"))
                    {
                        IFeatureClass pFeatureClass = pFeatureWorkspace.OpenFeatureClass(pDataset.Name);
                        if (null == pFeatureClass) return null;
                        //加载图层
                        IFeatureLayer pFeaLayer = new FeatureLayerClass();
                        pFeaLayer.Name = pDataset.Name;
                        pFeaLayer.FeatureClass = pFeatureClass;
                        m_MapControl.AddLayer(pFeaLayer as ILayer, 0);
                        m_MapControl.Refresh();
                        //读取字段
                        DataTable mDtResult = new DataTable();
                        mDtResult.Columns.Add("字段名", typeof(System.String));
                        mDtResult.Columns.Add("类型", typeof(System.String));
                        mDtResult.Columns.Add("长度", typeof(System.String));
                        mDtResult.Columns.Add("最大值", typeof(System.String));
                        mDtResult.Columns.Add("最小值", typeof(System.String));
                        foreach (var value in Dic)
                        {
                            DataRow DtRow = mDtResult.NewRow();
                            DtRow[0] = value.Key;
                            for (int i = 0; i < pFeatureClass.Fields.FieldCount; i++)
                            {
                                if (pFeatureClass.Fields.Field[i].Name == value.Key)
                                {
                                    if (pFeatureClass.Fields.Field[i].Type == value.Value.Texttype)
                                        DtRow[1] = "类型为" + pFeatureClass.Fields.Field[i].Type.ToString() + "，正确";
                                    else
                                        DtRow[1] = "类型为" + pFeatureClass.Fields.Field[i].Type.ToString() + "，错误，实际应为" + value.Value.Texttype;
                                    if (pFeatureClass.Fields.Field[i].Length <= value.Value.Length)
                                        DtRow[2] = "最大长度为" + pFeatureClass.Fields.Field[i].Length.ToString() + "，正确";
                                    else
                                        DtRow[2] = "最大长度超过" + value.Value.Length.ToString();
                                    if (value.Value.Max > 999999)
                                        DtRow[3] = "最大值无限制";
                                    else
                                        DtRow[3] = QueryMax(pFeatureClass, value.Value.Max, value.Key);
                                    if (value.Value.Min < -999999)
                                        DtRow[4] = "最小值无限制";
                                    else
                                        DtRow[4] = QueryMin(pFeatureClass, value.Value.Min, value.Key);
                                    break;
                                }
                            }
                            mDtResult.Rows.Add(DtRow);
                        }
                        return mDtResult;
                    }
                }
                pDataset = pEnumDataset.Next();
            }
            return null;
        }

        private string QueryMax(IFeatureClass pFeaCls, double max, string Field)
        {
            int index = pFeaCls.Fields.FindField(Field);
            IQueryFilter pQf = new QueryFilter();
            pQf.WhereClause = Field + " > " + max;
            IFeatureCursor pFeaCur = pFeaCls.Search(pQf, true);
            IFeature pFea = pFeaCur.NextFeature();
            if (pFea == null)
                return "最大值小于等于" + max.ToString();
            else
            {
                string MIN = "";
                while (pFea != null)
                {
                    m_MapControl.Map.SelectFeature(m_MapControl.get_Layer(0), pFea);
                    MIN += pFea.get_Value(index) + ",";
                    pFea = pFeaCur.NextFeature();
                }
                return "存在值" + MIN + "大于" + max.ToString();
            }
        }

        private string QueryMin(IFeatureClass pFeaCls, double min, string Field)
        {
            int index = pFeaCls.Fields.FindField(Field);
            IQueryFilter pQf = new QueryFilter();
            pQf.WhereClause = Field + " < " + min;
            IFeatureCursor pFeaCur = pFeaCls.Search(pQf, true);
            IFeature pFea = pFeaCur.NextFeature();
            if (pFea == null)
                return "最小值大于等于" + min.ToString();
            else
            {
                string MAX = "";
                while (pFea != null)
                {
                    m_MapControl.Map.SelectFeature(m_MapControl.get_Layer(0), pFea);
                    MAX += pFea.get_Value(index) + ",";
                    pFea = pFeaCur.NextFeature();
                }
                return "存在值" + MAX + "小于" + min.ToString();
            }
        }

        private Dictionary<string, DataType> OpenDoc()
        {
            IWorkspaceFactory pWorkspaceFactory = new FileGDBWorkspaceFactoryClass();
            IWorkspace pVecWorkspace = pWorkspaceFactory.OpenFromFile(m_DocPath, 0);
            IFeatureWorkspace pFeatureWorkspace = pVecWorkspace as IFeatureWorkspace;
            IEnumDataset pEnumDataset = pVecWorkspace.get_Datasets(esriDatasetType.esriDTAny) as IEnumDataset;
            pEnumDataset.Reset();
            IDataset pDataset = pEnumDataset.Next();
            while (null != pDataset)
            {
                if (pDataset is ITable)//表
                {
                    if (pDataset.Name.ToUpper().Equals("STANDARD"))
                    {
                        Dictionary<string, DataType> DicResult = new Dictionary<string, DataType>();
                        ITable pTable = pFeatureWorkspace.OpenTable(pDataset.Name);
                        //读取字段
                        ICursor pCur = pTable.Search(null, true);
                        IRow pRow = pCur.NextRow();
                        while (null != pRow)
                        {
                            if (!pRow.Value[1].Equals("字段"))
                            {
                                DicResult.Add(pRow.Value[1].ToString(), new DataType { Texttype = GetTextType(pRow.Value[2].ToString()), Length = GetTextLength(pRow.Value[3].ToString()), Max = GetTextMax(pRow.Value[4].ToString()), Min = GetTextMin(pRow.Value[5].ToString()) });
                            }
                            pRow = pCur.NextRow();
                        }
                        return DicResult;
                    }
                }
                pDataset = pEnumDataset.Next();
            }
            return null;
        }

        /// <summary>
        /// 获取文本类型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private esriFieldType GetTextType(string s)
        {
            switch (s.ToLower())
            {
                case "int":
                    return esriFieldType.esriFieldTypeInteger;
                case "double":
                case "float":
                    return esriFieldType.esriFieldTypeDouble;
                case "string":
                default:
                    return esriFieldType.esriFieldTypeString;
            }
        }

        /// <summary>
        /// 获取文本长度
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private int GetTextLength(string s)
        {
            try
            {
                return Convert.ToInt16(s);
            }
            catch (System.Exception ex)
            {
                return 999999999;
            }
        }

        /// <summary>
        /// 获取文本最大值
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private double GetTextMax(string s)
        {
            try
            {
                return Convert.ToDouble(s);
            }
            catch (System.Exception ex)
            {
                return 99999999999999;
            }
        }

        /// <summary>
        /// 获取文本最小值
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private double GetTextMin(string s)
        {
            try
            {
                return Convert.ToDouble(s);
            }
            catch (System.Exception ex)
            {
                return -99999999999999;
            }
        }

    }
    public class DataType
    {
        public int Length { get; set; }//长度
        public double Max { get; set; }//最大值
        public double Min { get; set; }//最小值
        public esriFieldType Texttype { get; set; }// 文本类型
    }
}
