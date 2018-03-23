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

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        string Pname = Lbl_Auction.Text;
        DataSet ak = SqlAC.CheckData("SELECT * FROM Auctions WHERE ID =" + Pname);
        int a = ak.Tables[0].Rows.Count;
        if (a == 1)
        {
            Grv2.DataSource = ak;
            Grv2.DataBind();
            msg.Text = "";
        }
        else
        {
            msg.Text = "Auction was not found";
            Grv2.DataSource = null;
            Grv2.DataBind();
        }

    }
}