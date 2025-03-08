using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Library
{
    public class ExportImportHelp
    {
        private static WaitDialogForm wdf = null;

        public static void ExportExcel(string strFilename, GridView gridivew)
        {
            string path = Convert.ToString(ConfigurationManager.AppSettings["ExportExcelPath"]);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string str = path + strFilename + ".xlsx";
            gridivew.ExportToXlsx(str);
            Process.Start(str);
        }

        public static void ImportExcel(GridView gridivew, ref DataTable dt)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel文件(*.xlsx;*.xls)()|*.xlsx;*.xls";
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                string fileName = openFileDialog.FileName;
                dt = ExportImportHelp.ReadExcelToTable(fileName);
                ExportImportHelp.OpenWaitDialog("正在导入数据");
                for (int index = 0; index < dt.Columns.Count; ++index)
                    dt.Columns[index].ColumnName = dt.Columns[index].ColumnName.Replace(" ", "").Trim();
                for (int rowHandle = 0; rowHandle < dt.Rows.Count && rowHandle + 1 <= gridivew.RowCount; ++rowHandle)
                {
                    DataRow row = dt.Rows[rowHandle];
                    for (int index = 0; index < dt.Columns.Count; ++index)
                    {
                        try
                        {
                            Type columnType = gridivew.VisibleColumns[index].ColumnType;
                            string fieldName = gridivew.VisibleColumns[index].FieldName;
                            if (columnType.FullName.ToLower().Contains("system."))
                                gridivew.SetRowCellValue(rowHandle, fieldName, row[fieldName]);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                if (gridivew.RowCount > dt.Rows.Count)
                {
                    for (int count = dt.Rows.Count; count < gridivew.RowCount; ++count)
                    {
                        gridivew.OptionsSelection.MultiSelect = true;
                        gridivew.SelectRow(count);
                    }
                    gridivew.GetSelectedRows();
                    gridivew.DeleteSelectedRows();
                }
                if (gridivew.RowCount < dt.Rows.Count)
                {
                    int rowCount1 = gridivew.RowCount;
                    for (int rowCount2 = gridivew.RowCount; rowCount2 < dt.Rows.Count; ++rowCount2)
                    {
                        gridivew.AddNewRow();
                        DataRow row = dt.Rows[rowCount2];
                        for (int index = 0; index < dt.Columns.Count; ++index)
                        {
                            try
                            {
                                Type columnType = gridivew.VisibleColumns[index].ColumnType;
                                string fieldName = gridivew.VisibleColumns[index].FieldName;
                                if (columnType.FullName.ToLower().Contains("system."))
                                    gridivew.SetRowCellValue(rowCount2, fieldName, row[fieldName]);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        gridivew.UpdateCurrentRow();
                    }
                    for (int rowHandle = rowCount1; rowHandle < dt.Rows.Count; ++rowHandle)
                    {
                        DataRow row = dt.Rows[rowHandle];
                        for (int index = 0; index < dt.Columns.Count; ++index)
                        {
                            try
                            {
                                Type columnType = gridivew.VisibleColumns[index].ColumnType;
                                string fieldName = gridivew.VisibleColumns[index].FieldName;
                                if (columnType.FullName.ToLower().Contains("system."))
                                    gridivew.SetRowCellValue(rowHandle, fieldName, row[fieldName]);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        gridivew.UpdateCurrentRow();
                    }
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("操作失败" + ex.Message, "提示");
            }
            finally
            {
                ExportImportHelp.CloseWaitDialog();
            }
        }

        public static DataTable ReadExcelToTable(string strPath)
        {
            string str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strPath + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
            using (OleDbConnection oleDbConnection = new OleDbConnection(str))
            {
                oleDbConnection.Open();
                oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[4]
                {
          null,
          null,
          null,
          (object) "Table"
                });
                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}]", (object)"Sheet$"), str);
                DataSet dataSet = new DataSet();
                oleDbDataAdapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
        }

        public static T GetEnumName<T>(string description)
        {
            foreach (FieldInfo field in typeof(T).GetFields())
            {
                DescriptionAttribute[] descriptAttr = ExportImportHelp.GetDescriptAttr(field);
                if (descriptAttr != null && (uint)descriptAttr.Length > 0U)
                {
                    if (descriptAttr[0].Description == description)
                        return (T)field.GetValue((object)null);
                }
                else if (field.Name == description)
                    return (T)field.GetValue((object)null);
            }
            throw new ArgumentException(string.Format("{0} 未能找到对应的枚举.", (object)description), "Description");
        }

        public static DescriptionAttribute[] GetDescriptAttr(FieldInfo fieldInfo)
        {
            if (fieldInfo != (FieldInfo)null)
                return (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (DescriptionAttribute[])null;
        }

        private static void OpenWaitDialog(string caption)
        {
            ExportImportHelp.wdf = new WaitDialogForm(caption + "...", "请等待...");
        }

        private static void CloseWaitDialog()
        {
            if (ExportImportHelp.wdf == null)
                return;
            ExportImportHelp.wdf.Close();
        }
    }
}
