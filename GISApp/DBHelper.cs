using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesGDB;
using System.Collections;

namespace GISApp
{
    class DBHelper  
    {
        public static string DbPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "data\\";
        public static string vecDbName = "vec.gdb";//矢量数据库
        public static string rasDbName = "ras.gdb";//栅格数据库
        public static string docDbName = "doc.gdb";//文档数据库
        public static IWorkspace vec_workspace = null;
        public static IWorkspace ras_workspace = null;
        public static IWorkspace doc_workspace = null;
        public static Boolean ifLogin = false;//是否登录
        public static string userName = "";//用户名
        public static string userType = "";//用户类型

        public static ArrayList queryResult = new ArrayList();

        //打开的不是数据，而是name
        public static IDatasetName USER_TABLE = null;//用户表, 位于文档数据库
        public static IDatasetName DOC_TABLE = null;//文档表
        public static IDatasetName VEC_TABLE = null;//矢量表
        public static IDatasetName RAS_TABLE = null;//栅格表
        public static IDatasetName VEC_META_TABLE = null;//矢量元数据表
        public static IDatasetName RAS_META_TABLE = null;//栅格元数据表




        //初始化，得到所有数据name
        public static void init()
        {
            vec_workspace = OpenFileGdbWorkspace(DbPath, vecDbName);
            ras_workspace = OpenFileGdbWorkspace(DbPath, rasDbName);
            doc_workspace = OpenFileGdbWorkspace(DbPath, docDbName);

            if (vec_workspace == null || ras_workspace == null || doc_workspace == null)
            {
                MessageBox.Show("workspace == null");
                return;
            }
            //1 vec
            IEnumDatasetName vec_datasetNames = vec_workspace.get_DatasetNames(esriDatasetType.esriDTTable);
            vec_datasetNames.Reset();
            IDatasetName vec_ids = vec_datasetNames.Next() as IDatasetName;
            while (vec_ids is IDatasetName)
            {
                if (vec_ids.Name.Equals("VEC_TABLE"))
                {
                    VEC_TABLE = vec_ids;
                }
                else if (vec_ids.Name.Equals("VEC_META_TABLE"))
                {
                    VEC_META_TABLE = vec_ids;
                }
                vec_ids = vec_datasetNames.Next() as IDatasetName;
            }
            vec_datasetNames.Reset();
            //2 ras
            IEnumDatasetName ras_datasetNames = ras_workspace.get_DatasetNames(esriDatasetType.esriDTTable);
            ras_datasetNames.Reset();
            IDatasetName ras_ids = ras_datasetNames.Next() as IDatasetName;
            while (ras_ids is IDatasetName)
            {
                if (ras_ids.Name.Equals("RAS_TABLE"))
                {
                    RAS_TABLE = ras_ids;
                }
                else if (ras_ids.Name.Equals("RAS_META_TABLE"))
                {
                    RAS_META_TABLE = ras_ids;
                }
                ras_ids = ras_datasetNames.Next() as IDatasetName;
            }
            ras_datasetNames.Reset();
            //3 doc
            IEnumDatasetName doc_datasetNames = doc_workspace.get_DatasetNames(esriDatasetType.esriDTTable);
            doc_datasetNames.Reset();
            IDatasetName ids = doc_datasetNames.Next() as IDatasetName;
            while (ids is IDatasetName)
            {
                if (ids.Name.Equals("USER_TABLE"))
                {
                    USER_TABLE = ids;
                }
                else if (ids.Name.Equals("DOC_TABLE"))
                {
                    DOC_TABLE = ids;
                }
                ids = doc_datasetNames.Next() as IDatasetName;
            }
            doc_datasetNames.Reset();
            if (DOC_TABLE == null || USER_TABLE == null || RAS_META_TABLE == null || RAS_TABLE == null || VEC_META_TABLE == null || VEC_TABLE == null)
            {
                MessageBox.Show("table == null");
                return;
            }
            return;
        }
        //打开数据库
        public static IWorkspace OpenFileGdbWorkspace(String path, string name)
        {
            string DBPath = path + name;
            if (!Directory.Exists(DBPath))
            {
                //存在
                //MessageBox.Show("文件不存在，将自动创建");
                //return CreateFileGdbWorkspace(path, name);
                MessageBox.Show("文件不存在 ");
                return null;
            }
            else
            {
                try
                {
                    IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesGDB.FileGDBWorkspaceFactory();
                    IWorkspace w = workspaceFactory.OpenFromFile(DBPath, 0);
                    return w;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("OpenFileGdbWorkspace error:" + ex.Message);
                    return null;
                }
            }
        }

        //登录
        public static Boolean login(string name, string pass)
        {
            if (USER_TABLE == null)
            {
                MessageBox.Show("还未初始化");
                return false;
            }

            IName pName = USER_TABLE as IName;
            ITable table = pName.Open() as ITable;
            IQueryFilter query = new QueryFilterClass();
            if (name == "木子lee")
            { query.WhereClause = "NAME='" + "刘亚奇" + "' AND PASS='" + pass + "'"; }
            else
            { MessageBox.Show("登录失败"); }
            ISelectionSet selectionSet = table.Select(query, esriSelectionType.esriSelectionTypeIDSet, esriSelectionOption.esriSelectionOptionNormal, null);

            ICursor cursor;
            selectionSet.Search(null, false, out cursor);
            IRow row = cursor.NextRow();

            if (selectionSet.Count == 1)
            {
                userName = name;
                ifLogin = true;
                userType = row.get_Value(2).Equals("1") ? "管理员" : "作业员";
                LogHelper.writeLog(name + " login success");
                return true;
            }
            LogHelper.writeLog(name + " login fail");
            return false;
        }

        //查找 from user,参数为空则查找所有
        private static ArrayList queryFromUSER(string where)
        {
            ArrayList t = new ArrayList();

            IName pName = USER_TABLE as IName;
            ITable table = pName.Open() as ITable;
            IQueryFilter query = new QueryFilterClass();
            query.WhereClause = where;
            ISelectionSet selectionSet = table.Select(query, esriSelectionType.esriSelectionTypeIDSet, esriSelectionOption.esriSelectionOptionNormal, null);

            ICursor cursor;
            selectionSet.Search(null, false, out cursor);
            IRow row = cursor.NextRow();

            int name_index = cursor.Fields.FindField("NAME");
            int type_index = cursor.Fields.FindField("TYPE");

            if (selectionSet.Count > 0)
            {
                while (row != null)
                {
                    NameAndType nat = new NameAndType();
                    nat.name = row.get_Value(name_index) + "";
                    nat.type = row.get_Value(type_index) + "";
                    t.Add(nat);
                    row = cursor.NextRow();
                }
            }
            return t;

        }

        //查找 from doc,参数为空则查找所有
        private static ArrayList queryFromDOC(string where)
        {
            ArrayList t = new ArrayList();

            IName pName = DOC_TABLE as IName;
            ITable table = pName.Open() as ITable;
            IQueryFilter query = new QueryFilterClass();
            query.WhereClause = where;
            ISelectionSet selectionSet = table.Select(query, esriSelectionType.esriSelectionTypeIDSet, esriSelectionOption.esriSelectionOptionNormal, null);

            ICursor cursor;
            selectionSet.Search(null, false, out cursor);
            IRow row = cursor.NextRow();

            if (selectionSet.Count > 0)
            {
                while (row != null)
                {
                    NameAndType nat = new NameAndType();
                    nat.name = row.get_Value(1) + "";
                    nat.type = row.get_Value(3) + "";
                    t.Add(nat);
                    row = cursor.NextRow();
                }
            }
            return t;

        }
        //查找 from vec,参数为空则查找所有
        private static ArrayList queryFromVEC(string where)
        {
            ArrayList t = new ArrayList();

            IName pName = VEC_TABLE as IName;
            ITable table = pName.Open() as ITable;
            IQueryFilter query = new QueryFilterClass();
            query.WhereClause = where;
            ISelectionSet selectionSet = table.Select(query, esriSelectionType.esriSelectionTypeIDSet, esriSelectionOption.esriSelectionOptionNormal, null);

            ICursor cursor;
            selectionSet.Search(null, false, out cursor);
            IRow row = cursor.NextRow();

            if (selectionSet.Count > 0)
            {
                while (row != null)
                {
                    NameAndType nat = new NameAndType();
                    nat.name = row.get_Value(1) + "";
                    nat.type = "featureDataset";
                    t.Add(nat);
                    row = cursor.NextRow();
                }
            }
            return t;

        }
        //查找 from vec,参数为空则查找所有
        private static ArrayList queryFromRAS(string where)
        {
            ArrayList t = new ArrayList();

            IName pName = RAS_TABLE as IName;
            ITable table = pName.Open() as ITable;
            IQueryFilter query = new QueryFilterClass();
            query.WhereClause = where;
            ISelectionSet selectionSet = table.Select(query, esriSelectionType.esriSelectionTypeIDSet, esriSelectionOption.esriSelectionOptionNormal, null);

            ICursor cursor;
            selectionSet.Search(null, false, out cursor);
            IRow row = cursor.NextRow();

            if (selectionSet.Count > 0)
            {
                while (row != null)
                {
                    NameAndType nat = new NameAndType();
                    nat.name = row.get_Value(1) + "";
                    nat.type = "rasterDataset";
                    t.Add(nat);
                    row = cursor.NextRow();
                }
            }
            return t;

        }

        //查找所有,参数为空则查找所有
        public static ArrayList queryAll(string where)
        {
            LogHelper.writeLog("query all : " + where);
            ArrayList t = new ArrayList();
            ArrayList t1 = queryFromVEC(where);
            ArrayList t2 = queryFromRAS(where);
            ArrayList t3 = queryFromDOC(where);
           
            t.AddRange(t1);
            t.AddRange(t2);
            t.AddRange(t3);

            return t;

        }

        //按照名称与类型打开数据集，针对featureDataset和rasterDataset
        public static object openByTypeAndName(string name,string type)
        {
            try
            {
                if (type.Equals("featureDataset"))
                {
                    IFeatureWorkspace w = vec_workspace as IFeatureWorkspace;
                    IFeatureDataset data = w.OpenFeatureDataset(name);
                    return data;
                }
                else if (type.Equals("rasterDataset"))
                {
                    IRasterWorkspace2 w = ras_workspace as IRasterWorkspace2;
                    IRasterDataset data = w.OpenRasterDataset(name);
                    return data;
                }
                else
                {
                    LogHelper.writeLog("error openByTypeAndName wrong type");
                    MessageBox.Show("wrong type");
                }
            }
            catch (System.Exception ex)
            {
                LogHelper.writeLog("error openByTypeAndName " + ex.Message);
                MessageBox.Show("error : "+ex.Message);
            }
            return null;
        }
        //打开用户管理列表
        public static void showUserTable()
        {
            LogHelper.writeLog(userName+" : showUserTable" );
            if (!ifLogin || !userType.Equals("管理员"))
            {
                MessageBox.Show("您无权限！");
                return;
            }
            if (USER_TABLE==null)
            {
                MessageBox.Show("未初始化！");
                return;
            }
            ArrayList t = queryFromUSER("");
            //MessageBox.Show("用户数量："+t.Count);
            UserTableForm dialog = new UserTableForm(t);
            dialog.Show();

        }

        //管理员添加用户
        public static Boolean addUser(string name)
        {
            string pass = "123";
            LogHelper.writeLog(name + ": new user");
            return true;
        }
        //管理员删除用户
        public static Boolean delUser(string name)
        {
            LogHelper.writeLog(name + ": deleted user");
            return true;
        }
        //上传数据
        public static Boolean insertData(object data)
        {
            return true;
        }



    
    }
    public struct NameAndType
    {
        public string name;
        public string type;
    }
}
