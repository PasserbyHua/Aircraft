using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;
using System.Collections;
using System.Reflection;

namespace Aircraft.Session3
{
    public class ExcelHelper
    {
        /// <summary>
        /// C#中获取Excel文件的表名 
        /// </summary>
        /// <param name="excelFileName">路径名</param>
        /// <returns></returns>
        public static List<string> GetExcelTableName(string pathName)
        {
            List<string> tableName = new List<string>();
            if (File.Exists(pathName))
            {
                string strConn = string.Empty;
                FileInfo file = new FileInfo(pathName);
                string extension = file.Extension;
                switch (extension)
                {
                    case ".xls":
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                        break;
                    case ".xlsx":
                        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                        break;
                    default:
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                        break;
                }
                using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(strConn))
                {
                    conn.Open();
                    System.Data.DataTable dt = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        string strSheetTableName = row["TABLE_NAME"].ToString();
                        //过滤无效SheetName   
                        if (strSheetTableName.Contains("$") && strSheetTableName.Replace("'", "").EndsWith("$"))
                        {
                            strSheetTableName = strSheetTableName.Replace("'", "");   //可能会有 '1X$' 出现
                            strSheetTableName = strSheetTableName.Substring(0, strSheetTableName.Length - 1);
                            tableName.Add(strSheetTableName);
                        }
                    }
                }
            }
            return tableName;
        }

        /// <summary>
        /// 获取EXCEL工作表的列名 返回list集合
        /// </summary>
        /// <param name="Path">Excel路径名</param>
        /// <returns></returns>
        public static List<string> getExcelFileInfo(string pathName)
        {
            string strConn;
            List<string> lstColumnName = new List<string>();
            FileInfo file = new FileInfo(pathName);
            if (!file.Exists) { throw new Exception("文件不存在"); }
            string extension = file.Extension;
            switch (extension)
            {
                case ".xls":
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=2;'";
                    break;
                case ".xlsx":
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=2;'";
                    break;
                default:
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    break;
            }
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(strConn);
            conn.Open();
            System.Data.DataTable table = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, null });

            foreach (System.Data.DataRow drow in table.Rows)
            {
                string TableName = drow["Table_Name"].ToString();
                if (TableName.Contains("$") && TableName.Replace("'", "").EndsWith("$"))
                {
                    System.Data.DataTable tableColumns = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Columns, new object[] { null, null, TableName, null });
                    foreach (System.Data.DataRow drowColumns in tableColumns.Rows)
                    {
                        string ColumnName = drowColumns["Column_Name"].ToString();
                        lstColumnName.Add(ColumnName);
                    }
                }
            }
            return lstColumnName;
        }

        /// <summary>
        /// OLEDB方式读取Excel
        /// </summary>
        /// <param name="pathName">Excel路径</param>
        /// <param name="sheetName">工作表名，默认读取第一个有数据的工作表（至少有2列数据）</param>
        /// <returns></returns>
        public static System.Data.DataTable DBExcelToDataTable(string pathName, string sheetName = "")
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string ConnectionString = string.Empty;
            FileInfo file = new FileInfo(pathName);
            if (!file.Exists) { throw new Exception("文件不存在"); }
            string extension = file.Extension;
            switch (extension)                          // 连接字符串
            {
                case ".xls":
                    ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=no;IMEX=1;'";
                    break;
                case ".xlsx":
                    ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=no;IMEX=1;'";
                    break;
                default:
                    ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=no;IMEX=1;'";
                    break;
            }
            System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection(ConnectionString);
            try
            {
                con.Open();
                if (sheetName != "")                      //若指定了工作表名
                {      //读Excel的过程中，发现dt末尾有些行是空的，所以在sql语句中加了Where 条件筛选符合要求的数据。OLEDB会自动生成列名F1,F2……Fn  
                    System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand("select * from [" + sheetName + "$] where F1 is not null ", con);
                    System.Data.OleDb.OleDbDataAdapter apt = new System.Data.OleDb.OleDbDataAdapter(cmd);
                    try
                    {
                        apt.Fill(dt);
                    }
                    catch (Exception ex) { throw new Exception("该Excel文件中未找到指定工作表名," + ex.Message); }
                    dt.TableName = sheetName;
                }
                else
                {
                    //默认读取第一个有数据的工作表
                    var tables = con.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { });
                    if (tables.Rows.Count == 0)
                    { throw new Exception("Excel必须包含一个表"); }
                    foreach (System.Data.DataRow row in tables.Rows)
                    {
                        string strSheetTableName = row["TABLE_NAME"].ToString();
                        //过滤无效SheetName   
                        if (strSheetTableName.Contains("$") && strSheetTableName.Replace("'", "").EndsWith("$"))
                        {
                            System.Data.DataTable tableColumns = con.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Columns, new object[] { null, null, strSheetTableName, null });
                            if (tableColumns.Rows.Count < 2)                     //工作表列数
                                continue;
                            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand("select * from [" + strSheetTableName + "] where F1 is not null", con);
                            System.Data.OleDb.OleDbDataAdapter apt = new System.Data.OleDb.OleDbDataAdapter(cmd);
                            apt.Fill(dt);
                            dt.TableName = strSheetTableName.Replace("$", "").Replace("'", "");
                            break;
                        }
                    }
                }
                if (dt.Rows.Count < 2)
                    throw new Exception("表必须包含数据");
                //重构字段名
                System.Data.DataRow headRow = dt.Rows[0];
                foreach (System.Data.DataColumn c in dt.Columns)
                {
                    string headValue = (headRow[c.ColumnName] == DBNull.Value || headRow[c.ColumnName] == null) ? "" : headRow[c.ColumnName].ToString().Trim();
                    if (headValue.Length == 0)
                    { throw new Exception("必须输入列标题"); }
                    if (dt.Columns.Contains(headValue))
                    { throw new Exception("不能用重复的列标题：" + headValue); }
                    c.ColumnName = headValue;
                }
                dt.Rows.RemoveAt(0);
                return dt;
            }
            catch (Exception ee)
            { throw ee; }
            finally
            { con.Close(); }
        }

        /// <summary>
        /// OLEDB方式导出DataTable
        /// </summary>
        /// <param name="Path">路径</param>
        /// <param name="dt">DataTable</param>
        public static void DTToExcel(string Path, System.Data.DataTable dt)
        {
            string strCon = string.Empty;
            FileInfo file = new FileInfo(Path);
            string extension = file.Extension;
            switch (extension)
            {
                case ".xls":
                    strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path + ";Extended Properties=Excel 8.0;";
                    //strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=0;'";
                    //strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=2;'";
                    break;
                case ".xlsx":
                    //strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Extended Properties=Excel 12.0;";
                    //strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=2;'";    //出现错误了
                    strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=0;'";
                    break;
                default:
                    strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=0;'";
                    break;
            }
            try
            {
                using (System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection(strCon))
                {
                    con.Open();
                    StringBuilder strSQL = new StringBuilder();
                    System.Data.OleDb.OleDbCommand cmd;
                    try
                    {
                        cmd = new System.Data.OleDb.OleDbCommand(string.Format("drop table {0}", dt.TableName), con);    //覆盖文件时可能会出现Table 'Sheet1' already exists.所以这里先删除了一下
                        cmd.ExecuteNonQuery();
                    }
                    catch { }
                    //创建表格字段
                    strSQL.Append("CREATE TABLE ").Append("[" + dt.TableName + "]");
                    strSQL.Append("(");
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        strSQL.Append("[" + dt.Columns[i].ColumnName + "] text,");
                    }
                    strSQL = strSQL.Remove(strSQL.Length - 1, 1);
                    strSQL.Append(")");

                    cmd = new System.Data.OleDb.OleDbCommand(strSQL.ToString(), con);
                    cmd.ExecuteNonQuery();
                    //添加数据
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strSQL.Clear();
                        StringBuilder strvalue = new StringBuilder();
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            strvalue.Append("'" + dt.Rows[i][j].ToString() + "'");
                            if (j != dt.Columns.Count - 1)
                            {
                                strvalue.Append(",");
                            }
                            else
                            {
                            }
                        }
                        cmd.CommandText = strSQL.Append(" insert into [" + dt.TableName + "] values (").Append(strvalue).Append(")").ToString();
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch(Exception ex) { throw ex; }
        }

        /// <summary>
        /// 使用OLEDB读取excel和csv文件
        /// </summary>
        /// <param name="path">文件所在目录地址</param>
        /// <param name="name">文件名</param>
        /// <returns></returns>
        public static DataSet ReadFile(string path, string name)
        {
            if (string.IsNullOrWhiteSpace(path) || string.IsNullOrWhiteSpace(name) || !File.Exists(path +"\\"+ name))
                return null;
            // 读取excel 
            string connstring = string.Empty;
            string strSql = string.Empty;
            if (name.EndsWith(".xls") || name.EndsWith(".xlsx"))
            {
                connstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\\" + name + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                List<string> ls = GetExcelTableName(path + "\\" + name);
                strSql = "select * from ["+ls[0]+"$]";
            }
            // 读取csv文件
            else if (name.EndsWith(".csv"))
            {
                connstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='text;HDR=YES;FMT=Delimited';";
                strSql = "select * from " + name;
            }
            else
            {
                return null;
            }
            DataSet ds = null;
            OleDbConnection conn = null;
            try
            {
                conn = new OleDbConnection(connstring);
                conn.Open();
                OleDbDataAdapter myCommand = null;

                myCommand = new OleDbDataAdapter(strSql, connstring);
                ds = new DataSet();
                myCommand.Fill(ds, "table1");
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }

        public static DataTable ToDataTable<T>(IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();
            var dt = new DataTable();
            dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());
            if (collection.Count() > 0)
            {
                for (int i = 0; i < collection.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(collection.ElementAt(i), null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }

        //author: walker
        //date: 2014-01-07
        //function: 将DataTable导出到csv文件
        public static bool datatableToCSV(DataTable dt, string pathFile)
        {
            string strLine = "";
            StreamWriter sw;
            try
            {
                sw = new StreamWriter(pathFile, false, System.Text.Encoding.GetEncoding(-0)); //覆盖
                                                                                              //表头
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i > 0)
                        strLine += ",";
                    strLine += dt.Columns[i].ColumnName;
                }
                strLine.Remove(strLine.Length - 1);
                sw.WriteLine(strLine);
                strLine = "";
                //表的内容
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    strLine = "";
                    int colCount = dt.Columns.Count;
                    for (int k = 0; k < colCount; k++)
                    {
                        if (k > 0 && k < colCount)
                            strLine += ",";
                        if (dt.Rows[j][k] == null)
                            strLine += "";
                        else
                        {
                            string cell = dt.Rows[j][k].ToString().Trim();
                            //防止里面含有特殊符号
                            cell = cell.Replace("\"", "\"\"");
                            cell = "\"" + cell + "\"";
                            strLine += cell;
                        }
                    }
                    sw.WriteLine(strLine);
                }
                sw.Close();
                string msg = "数据被成功导出到：" + pathFile;
                Console.WriteLine(msg);
            }
            catch (Exception ex)
            {
                string msg = "导出错误：" + pathFile;
                Console.WriteLine(msg);
                return false;
            }
            return true;
        }

    }


}
