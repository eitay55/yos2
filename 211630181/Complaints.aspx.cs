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
using System.IO;
using System.Collections.Generic;

public partial class Complaints : System.Web.UI.Page
{
    DataSet ds;
    string s;
    protected void Page_Load(object sender, EventArgs e)
    {
        UDDL();

    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {

        s = DDL.Text;
        SqlAC.udi("UPDATE Complaints SET Response='"+Res.Text+"',Checked='1' WHERE Title='"+s+"'");
        Response.Redirect("Compllaints.aspx");
    }
    private void UDDL()
    {
         ds = SqlAC.CheckData("SELECT * FROM Complaints WHERE Checked='0'");
        DDL.DataSource = ds.Tables[0];
        DDL.DataTextField = ds.Tables[0].Columns["Title"].ToString();
        DDL.DataValueField = ds.Tables[0].Columns["Title"].ToString();
        DDL.DataBind();
    }

    protected void btn2_Click(object sender, EventArgs e)
    {
        
        s = DDL.Text;
        DataSet ak = SqlAC.CheckData("SELECT * FROM Complaints WHERE Title='" + s + "'");
        CCC.InnerText = ak.Tables[0].Rows[0]["Description"].ToString();
        Ltitle.Text = ak.Tables[0].Rows[0]["Title"].ToString();
        LUser.Text = ak.Tables[0].Rows[0]["User"].ToString();

    }
}