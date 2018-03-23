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

public partial class ActiveAuctions : System.Web.UI.Page{
    string user;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (PID())
            Response.Redirect("CompletedAuctions.aspx.cs?page=1");
        try
        {
            user = Session["username"].ToString();
        }
        catch
        {
            Response.Redirect("Home.aspx");
        }
        CheckAuctions();//checks for any finished auctions.
        ShowAuctions();
          
    }
    private bool PID()
    {
        int page;
        try
        {
            page = int.Parse(Request.QueryString["page"]);
        }
        catch
        {
            return true;
        }
        if (page < 0)
            return true;
        return false;
    }
    private void ShowAuctions(){
        int page = int.Parse(Request.QueryString["page"]);
        string query = "SELECT * FROM CompletedAuctions WHERE Buser='" + user + "'";//and paid=0;
        DataSet ds = SqlAC.CheckData(query);
        int length = ds.Tables[0].Rows.Count;
        //add page max check
        if (length < 9){
            for(int i = 0; i < length; i++)
                CreateCard(ds.Tables[0].Rows[i]);
        }
        else
        {
            int start = (page - 1) * 9;
            int end = Math.Min(page * 9, length);
            for (int i = start; i < end; i++)
                CreateCard(ds.Tables[0].Rows[i]);
            AddButtons(end,length);
        }
    }
    private void CreateCard(DataRow r){//adds completed auction to the page
        HtmlGenericControl[] HGC = new HtmlGenericControl[5];
        DivM(HGC);
        AddInfo(r, HGC);
        HGC[0].Controls.Add(HGC[1]);
        HGC[3].Controls.Add(HGC[2]);
        HGC[3].Controls.Add(HGC[0]);
        div_Products.Controls.Add(HGC[3]);
        div_Products.Controls.Add(new LiteralControl("<br />"));
    }
    private void DivM(HtmlGenericControl[] HGC)
    {
        HGC[0] = new HtmlGenericControl("div");//card
        HGC[1] = new HtmlGenericControl("div");//inner info
        HGC[2] = new HtmlGenericControl("header");//img holder
        HGC[3] = new HtmlGenericControl("section");
        HGC[4] = new HtmlGenericControl("div");
        HGC[0].Attributes.Add("class", "mdl-card mdl-cell mdl-cell--9-col-desktop");
        HGC[1].Attributes.Add("class", "mdl-card__supporting-text");
        HGC[2].Attributes.Add("class", "mdl-cell mdl-cell--3-col-desktop mdl-color--teal-100");
        HGC[3].Attributes.Add("class", "section--center mdl-grid mdl-grid--no-spacing mdl-shadow--2dp");
        HGC[4].Attributes.Add("class", "mdl - cell mdl - cell--1 - col");

    }
    private void AddInfo(DataRow r, HtmlGenericControl[] HGC)
    {
        Button Redirect = new Button();
        Redirect.Click += delegate
        {
            Response.Redirect("");
        };
        Label[] info= new Label[2];
        for (int j = 0; j < 3; j++) {
            info[j] = new Label();
            info[j].Attributes["runat"] = "server";
        }
        info[0].Text = "Your offer: " + r["Price"].ToString();
        info[1].Text = "Paid:";
        HtmlGenericControl h4 = new HtmlGenericControl("h4");
        h4.InnerText = r["PName"].ToString();
        HGC[1].Controls.Add(h4);
        for (int j = 0; j < 2; j++)
        {
            HGC[1].Controls.Add(info[j]);
            HGC[1].Controls.Add(new LiteralControl("<br/>"));
            HGC[1].Controls.Add(new LiteralControl("<br/>"));
        }
    }
    private void AddButtons(int e, int l)
    {
        int p;
        if (Request.QueryString["page"] == null)
            p = 1;
        else
            p = int.Parse(Request.QueryString["page"]);
        Button prv = new Button();
        prv.Text = "Previous";
        prv.CssClass = "mdl-button mdl-js-button mdl-button--raised mdl-button--accent";
        if (p != 1)
        {
            int a = p - 1;
            prv.Click += delegate
            {
                Response.Redirect("CompletedAuctions.aspx?page=" + a);
            };
        }
        else
        {
            prv.Enabled = false;
        }
        Dprv.Controls.Add(prv);
        Button next = new Button();
        next.Text = "Next";
        next.CssClass = "mdl-button mdl-js-button mdl-button--raised mdl-button--accent";

        if (e <= l)
        {
            int b = p + 1;

            next.Click += delegate
            {
                Response.Redirect("CompletedAuctions.aspx?page=" + b);
            };


        }
        else
            next.Enabled = false;
        Dnext.Controls.Add(next);

    }
    private void CheckAuctions(){
        DateTime now = DateTime.Now;
        string query = "SELECT * FROM Auctions";// WHERE Buser='"+ user +"'
        DataSet ds = SqlAC.CheckData(query);//all auctions
        int i = ds.Tables[0].Rows.Count;
        int j = 0;
        DateTime end;
        while (j < i){
            end = CreateEndTime(ds.Tables[0].Rows[j]);
            if (CheckDate(now, end) == 1){
                UpdateDB(ds.Tables[0].Rows[j]);
            }
            j++;
        }
    }
    private int CheckDate(DateTime start, DateTime end){
        double interval = (end - start).TotalSeconds;
        if (interval < 1)
            return 1;
        return 0;
    }
    private DateTime CreateEndTime(DataRow r){
        int ey= int.Parse(r["EY"].ToString());
        int em = int.Parse(r["EM"].ToString());
        int ed = int.Parse(r["ED"].ToString());
        int eh = int.Parse(r["EH"].ToString());
        int emin = int.Parse(r["EMin"].ToString());
        DateTime end = new DateTime(ey, em, ed, eh, emin, 0, 0);
        return end;
    }
    private void UpdateDB(DataRow r){
        string Insert = "INSERT INTO CompletedAuctions VALUES ('" + r["ID"]+"','" + r["PName"] + "','"+ r["SUser"] + "','" + r["Buser"] + "','" + r["price"] + "','" + r["ImgUrl"] + "','" + r["Catagory"] + "','" + r["Description"] + "')";
        string Delete = "DELETE FROM Auctions WHERE ID="+r["ID"];
        SqlAC.udi(Insert);
        SqlAC.udi(Delete);

    }
}