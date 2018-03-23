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

public partial class MPAuctions : System.Web.UI.Page
{
    string id;
    DataSet ak;   
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Activate_Click(object sender, EventArgs e)
    {
        DateTime date = DateTime.Now;
        int H = int.Parse(Hours.Text);
        int M = int.Parse(mins.Text);
        TimeSpan time = new TimeSpan(0,H, M);
        DateTime combined = date.Add(time);
        string t = title.Text;
        string Userr = User.Text;
        string P = Price.Text;
        string ey = combined.Year.ToString();
        string em = combined.Month.ToString();
        string ed = combined.Day.ToString();
        string eh = combined.Hour.ToString();
        string emin = combined.Minute.ToString();
        string url = ak.Tables[0].Rows[0]["ImgUrl"].ToString();
        string catagory= ak.Tables[0].Rows[0]["Catagory"].ToString();


        SqlAC.udi("INSERT INTO Auctions (PName,SUser,Price,EY,EM,ED,EH,EMin,Open,ImgUrl,Catagory,Description) VALUES ('" + t + "','" + Userr + "','" + P + "','" + ey + "','" + em + "','" + ed + "','" + eh + "','" + emin + ",'1'," + url + "','" + catagory + "','" +desc+"'");
        SqlAC.udi("DELETE FROM PendingAuctions WHERE id="+id);
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        id = SearchT.Text;
        ak = SqlAC.CheckData("SELECT * FROM PendingAuctions WHERE ID="+ ID);
        title.Text = ak.Tables[0].Rows[0]["PName"].ToString();
        User.Text = ak.Tables[0].Rows[0]["SUser"].ToString();
        Price.Text= ak.Tables[0].Rows[0]["Price"].ToString();
        Hours.Text= ak.Tables[0].Rows[0]["Hour"].ToString();
        mins.Text= ak.Tables[0].Rows[0]["Min"].ToString();
        Pimg.ImageUrl= ak.Tables[0].Rows[0]["ImgUrl"].ToString();
        category.Text= ak.Tables[0].Rows[0]["Catagory"].ToString();
        desc.Text= ak.Tables[0].Rows[0]["Description"].ToString();
    }
}