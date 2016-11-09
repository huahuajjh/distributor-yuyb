using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;
using NPOI.HSSF.UserModel;

namespace TravelAgent.Tool
{
    public class ExcelHelper
    {
        /// <summary>   
        /// 下载控件内容到，Excel 文件   
        /// </summary>   
        /// <param name="response">Response 引用</param>   
        /// <param name="con">父控件，接受子控件的引用（GridView , DataList , Repeater）</param>   
        /// <param name="fileName">下载文件名</param>   
        public static string DownLoadControlAsExcel(HttpResponse response, Control con, string fileName)   
        {   
            try  
            {   
               //设置文件名，及下载格式   
                response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8) + ".xls");   
                response.ContentType = "application/vnd.ms-excel";   
                //response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");   
                //this.EnableViewState = false;   
                System.IO.StringWriter strWriter = new System.IO.StringWriter();   
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(strWriter);   
               //设置到处内容控件（Anyone 父类Control即可）       
                con.RenderControl(hw);   
                response.Write(strWriter.ToString());   
                //释放资源   
                strWriter.Dispose();   
                hw.Dispose();   
               response.End();   
                return null;   
            }   
           catch  
            {   
                return "导出数据到Excel发生异常。";   
            }   
        }
        /// <summary>
        /// 导出excel
        /// </summary>
        /// <param name="response"></param>
        /// <param name="dt"></param>
        /// <param name="fileName"></param>
        /// <param name="sheetname"></param>
        public static void ExportExcel(HttpResponse response, DataTable dt, string fileName,string sheetname)   
        {   
              NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
              NPOI.SS.UserModel.ISheet sheet = book.CreateSheet(sheetname);   
              NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
              NPOI.SS.UserModel.ICell cell = null;
              NPOI.SS.UserModel.IFont font = book.CreateFont();
              NPOI.SS.UserModel.ICellStyle style = book.CreateCellStyle();
              font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
              font.FontName = "微软雅黑";
              
              style.SetFont(font);

              for (int i = 0; i < dt.Columns.Count; i++)   
              {
                   cell = row.CreateCell(i);
                   cell.CellStyle = style;
                   cell.SetCellValue(dt.Columns[i].ColumnName);   
               }   
          
               for (int i = 0; i < dt.Rows.Count; i++)   
               {   
                  NPOI.SS.UserModel.IRow row2 = sheet.CreateRow(i + 1);
                  for (int j = 0; j < dt.Columns.Count; j++)
                  {
                      string strColDataType = dt.Columns[j].DataType.ToString();
                      if (strColDataType.Equals("System.Int32"))
                      {
                          int intValue = 0;
                          int.TryParse(dt.Rows[i][j].ToString(), out intValue);
                          row2.CreateCell(j).SetCellValue(intValue);
                      }
                      else if (strColDataType.Equals("System.String"))
                      {
                          row2.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                      }
                      else if (strColDataType.Equals("System.Double"))
                      {
                          double dblValue = 0;
                          double.TryParse(dt.Rows[i][j].ToString(), out dblValue);
                          row2.CreateCell(j).SetCellValue(dblValue);
                      }
                  }
              }   
               //写入到客户端   
              System.IO.MemoryStream ms = new System.IO.MemoryStream();   
              book.Write(ms);
              response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + HttpUtility.UrlEncode(fileName,Encoding.UTF8)+DateTime.Now.ToShortDateString()+ ".xls"));
              response.ContentType = "application/vnd.ms-excel";
              //response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312"); 
              response.BinaryWrite(ms.ToArray());
              book = null;   
              ms.Close();   
              ms.Dispose();
         }
        /// <summary>
        /// 设置样式
        /// </summary>
         private static void SetExcelValue(DataTable dt, string sheetname,NPOI.HSSF.UserModel.HSSFWorkbook book,NPOI.SS.UserModel.ICellStyle style)
        {
            NPOI.SS.UserModel.ISheet sheet = book.CreateSheet(sheetname);
            NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
            NPOI.SS.UserModel.ICell cell = null;
            NPOI.SS.UserModel.ICell newCell = null;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                cell = row.CreateCell(i);
                cell.CellStyle = style;
                cell.SetCellValue(dt.Columns[i].ColumnName);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NPOI.SS.UserModel.IRow row2 = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string strColDataType = dt.Columns[j].DataType.ToString();
                    if (strColDataType.Equals("System.Int32"))
                    {
                        int intValue = 0;
                        int.TryParse(dt.Rows[i][j].ToString(), out intValue);
                        row2.CreateCell(j).SetCellValue(intValue);
                    }
                    else if (strColDataType.Equals("System.String"))
                    {
                        row2.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                    }
                    else if (strColDataType.Equals("System.Double"))
                    {
                        double dblValue = 0;
                        double.TryParse(dt.Rows[i][j].ToString(), out dblValue);
                        row2.CreateCell(j).SetCellValue(dblValue);
                    }
                    else if (strColDataType.Equals("System.DateTime"))
                    {
                        DateTime dateV;
                        DateTime.TryParse(dt.Rows[i][j].ToString(), out dateV);
                        newCell = row2.CreateCell(j);
                        newCell.SetCellValue(dateV);

                        //格式化显示
                        HSSFCellStyle cellStyle = (HSSFCellStyle)book.CreateCellStyle();
                        HSSFDataFormat format = (HSSFDataFormat)book.CreateDataFormat();
                        cellStyle.DataFormat = format.GetFormat("yyyy-m-d");
                        newCell.CellStyle = cellStyle;
                    }
                }
            }
        }

        #region 连接Excel  读取Excel数据   并返回DataSet数据集合
         /// <summary>
         /// 连接Excel  读取Excel数据   并返回DataSet数据集合
         /// </summary>
         /// <param name="filepath">Excel服务器路径</param>
         /// <param name="tableName">Excel表名称</param>
         /// <param name="scope">查询范围 如A:D</param>
         /// <returns></returns>
         public static DataSet ExcelToDataSet(string filepath, string tableName,string scope)
         {
             string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
             string strSheetName = string.Empty;
             OleDbConnection excelConn = new OleDbConnection(strCon);
             try
             {
                 excelConn.Open();
                 using (DataTable dataTable = excelConn.GetSchema("Tables"))
                 {
                     using (DataTableReader dtReader = new DataTableReader(dataTable))
                     {
                         while (dtReader.Read())
                         {
                             //获取一个Sheet名
                             strSheetName = dtReader["Table_Name"].ToString();
                             break;
                         }
                     }

                 }
                 string strCom = string.Format("SELECT * FROM [" + strSheetName+ scope + "]");
                 OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, excelConn);
                 DataSet ds = new DataSet();
                 myCommand.Fill(ds, "[" + tableName + "$]");
                 excelConn.Close();
                 return ds;
             }
             catch
             {
                 excelConn.Close();
                 return null;
             }
         }
         /// <summary>
         /// 批量插入数据
         /// </summary>
         /// <param name="dataTable"></param>
         /// <param name="tableName"></param>
         public static void InsertBySqlBulkCopy(DataTable dataTable, string tableName)
         {
             using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["str_conn"].ConnectionString))
             {
                 connection.Open();
                 using (SqlBulkCopy sbc = new SqlBulkCopy(connection))
                 {
                     sbc.DestinationTableName = tableName;
                     sbc.WriteToServer(dataTable);
                 }
             }
         }
         #endregion

    }
}
