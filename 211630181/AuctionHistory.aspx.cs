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
using System.Threading;

public partial class Database_AuctionHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Loading the page
        AH();
    }
    private void AH()
    {
        DataSet uv = SqlAC.CheckData("SELECT * FROM History WHERE Username='" + Session["username"].ToString() + "'");
        int l = uv.Tables[0].Rows.Count;
        HtmlGenericControl td;
        HtmlGenericControl Utr;
        HtmlGenericControl Btr;

        for (int j = 0; j < l; j++)
        {
            
            string id = uv.Tables[0].Rows[j]["PID"].ToString();
            DataSet ak = SqlAC.CheckData("SELECT * FROM Auctions WHERE ID=" + id);
            int a = int.Parse(ak.Tables[0].Rows[0]["Open"].ToString());
            if (a == 1)
            {
                td = new HtmlGenericControl("tr");
                Utr = new HtmlGenericControl("td");
                Utr.Attributes.Add("class", "mdl-data-table__cell--non-numeric");
                Btr = new HtmlGenericControl("td");
                Utr.InnerText = ak.Tables[0].Rows[0]["PName"].ToString();
                Btr.InnerText = uv.Tables[0].Rows[j]["Bid"].ToString();
                td.Controls.Add(Utr);
                td.Controls.Add(Btr);
                tbody.Controls.Add(td);
            }
        }
    }
}