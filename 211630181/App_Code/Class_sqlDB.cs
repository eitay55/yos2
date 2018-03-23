using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

/// <summary>
/// Summary description for Class_sqlDB
/// </summary>
public class SqlAC {
    public SqlAC(){

    }
    public static DataSet CheckData(string sqlstr) {
        string path = HttpContext.Current.Server.MapPath("~/Database/");
        string filename = "Database12.accdb";
        path += filename;
        string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
        OleDbConnection conn = new OleDbConnection(connString);
        OleDbDataAdapter da = new OleDbDataAdapter(sqlstr, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    public static void udi(string sqlstr){
        string path = HttpContext.Current.Server.MapPath("~/Database/");
        string filename = "Database12.accdb";
        path += filename;
        string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
        OleDbConnection conn = new OleDbConnection(connString);
        OleDbCommand build = new OleDbCommand(sqlstr, conn);
        conn.Open();
        build.ExecuteNonQuery();

        conn.Close();
    }
    

}