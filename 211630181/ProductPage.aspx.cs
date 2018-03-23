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

public partial class ProductPage : System.Web.UI.Page
{
    DataSet ak;
    protected void Page_Load(object sender, EventArgs e)
    {

        string id = Request.QueryString["id"];
        ak = SqlAC.CheckData("SELECT * FROM Auctions WHERE ID=" + id);
        count();
        price.Text= ak.Tables[0].Rows[0]["price"].ToString();
        title.InnerText= ak.Tables[0].Rows[0]["PName"].ToString();
        PPic.ImageUrl = "~/APhotos/" + ak.Tables[0].Rows[0]["ImgUrl"].ToString();
        PPic.Width=300;
        PPic.Height = 300;
        string seller = ak.Tables[0].Rows[0]["SUser"].ToString();
        if (Session["login"] == null||(Session["Username"].Equals(seller)))
        {
            Offer.Enabled = false;
            Btn_Offer.Enabled = false;
        }
        
        
        AH(id);

    }
    private void AH(string id)
    {
        DataSet uv = SqlAC.CheckData("SELECT * FROM History WHERE PID='" + id + "'");
        int l = uv.Tables[0].Rows.Count;
        HtmlGenericControl td;
        HtmlGenericControl Utr;
        HtmlGenericControl Btr;

        for (int j = 0; j < l; j++)
        {
            td = new HtmlGenericControl("tr");
            Utr = new HtmlGenericControl("td");
            Utr.Attributes.Add("class", "mdl-data-table__cell--non-numeric");
            Btr = new HtmlGenericControl("td");
            Utr.InnerText = uv.Tables[0].Rows[j]["Username"].ToString();
            Btr.InnerText = uv.Tables[0].Rows[j]["Bid"].ToString();
            td.Controls.Add(Utr);
            td.Controls.Add(Btr);
            tbody.Controls.Add(td);
        }
    }

    private void count()
    {
        DateTime now = DateTime.Now;
        int day= int.Parse(ak.Tables[0].Rows[0]["ED"].ToString());
        int hour = int.Parse(ak.Tables[0].Rows[0]["EH"].ToString());
        int min = int.Parse(ak.Tables[0].Rows[0]["EMIN"].ToString());
        int year= int.Parse(ak.Tables[0].Rows[0]["EY"].ToString());
        int month = int.Parse(ak.Tables[0].Rows[0]["EM"].ToString());
        DateTime end = new DateTime(year, month, day, hour, min, 0);
        double interval = ((end - now).TotalSeconds);
        TimeSpan kkk = end - now;
        if (interval>0)
            Time.Text = kkk.ToString();
        else
        {
            Offer.Enabled = false;
            Btn_Offer.Enabled = false;
            Timer1.Enabled = false;
            Time.Text = "Times up, auction closed";
        }

       
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        count();

    }
    protected void Btn_Offer_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        if (Offer.Text == null)
        {
            Offer.Text = "0";
        }
        long offer = int.Parse(Offer.Text);//input
        int Coffer = int.Parse(ak.Tables[0].Rows[0]["Price"].ToString());//current offer
        string user;
        
        user = Session["login"].ToString();
        if (Session["login"] == null)
        {
            Offer.Enabled = false;
        }
       
        if (offer > Coffer){
            int v = ak.Tables[0].Rows.Count;
            
            SqlAC.udi("UPDATE Auctions SET Auctions.price='" + offer + "', Buser='"+ Session["username"].ToString() +"' WHERE Auctions.ID=" + id);
            SqlAC.udi("INSERT INTO History VALUES('1','"+id+"','"+ Session["username"].ToString()+"','"+offer.ToString()+"')");
            Response.Redirect("ProductPage.aspx?id=" + id);
        }
    }
    private void SA(){
        DataSet u = ak;
       
    }
}