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
public partial class ProductList : System.Web.UI.Page{
    int page;
    HtmlGenericControl[] HGC;
    ImageButton image;
    DataSet ak;
    protected void Page_Load(object sender, EventArgs e){
        HGC = new HtmlGenericControl[5];
        ak = SqlAC.CheckData("SELECT * FROM Auctions");
        try{
            page = int.Parse(Request.QueryString["page"]);
        }
        catch{
            Response.Redirect("ProductList.aspx?page=1");
        }
        if (int.Parse(Request.QueryString["page"]) < 1)
            Response.Redirect("ProductList.aspx?page=1");
        int length= ak.Tables[0].Rows.Count;
        if (page * 9 > 9+length)
        {
            Response.Redirect("ProductList.aspx?page=1");
        }

        if (length < 9)
            f1(length);
        else{
            int start = (page - 1) * 9;
            int end = page * 9;
            f2(start,end,length);
            AddButtons(end,length);
        }  
    }
    private void f1(int length){
        int i = 0;
        while (i < length){
            if (count(i))
                CreateCard(i);
            else
                Delete(i);
            i++;       
        }
        
    }
    private void f2(int s, int e, int length){
        while (s < e && s<length){
            int k = int.Parse(ak.Tables[0].Rows[s]["Open"].ToString());
            if (k == 1 && count(s)){
                CreateCard(s);
            }
            else{
                Delete(s);
                e++;
            }
            s++;
        }
    }
    private void Delete(int i){
        SqlAC.udi("UPDATE Auctions SET Auctions.Open='0' WHERE ID=" + ak.Tables[0].Rows[i]["ID"].ToString() + "");
    }
    private void CreateCard(int i)
    {
        DivM();
        AddInfo(i);
        AddProduct();

    }
    private ImageButton CImg(int i)
    {
        string id = ak.Tables[0].Rows[i]["ID"].ToString();
        image = new ImageButton();
        image.Click += delegate
        {
            Response.Redirect("ProductPage.aspx?id=" + id);
        };
        image.Attributes["runat"] = "server";
        image.Width = 300;
        image.Height = 300;
        image.ImageUrl = "~/APhotos/" + ak.Tables[0].Rows[i]["ImgUrl"].ToString();
        return image;
    }
    private void DivM()
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
    private void AddProduct()
    {
        HGC[0].Controls.Add(HGC[1]);
        HGC[3].Controls.Add(HGC[2]);
        HGC[3].Controls.Add(HGC[0]);
        kkk.Controls.Add(HGC[3]);
        kkk.Controls.Add(new LiteralControl("<br />"));
    }
    private void AddInfo(int i){
        image = CImg(i);
        Label[] info= new Label[3];
        for (int j = 0; j < 3; j++) {
            info[j] = new Label();
            info[j].Attributes["runat"] = "server";
        }
        info[0].Text = "Seller name: " + ak.Tables[0].Rows[i]["SUser"].ToString();
        info[1].Text = "Current offer: " + ak.Tables[0].Rows[i]["Price"].ToString();
        HtmlGenericControl h4 = new HtmlGenericControl("h4");
        h4.InnerText = ak.Tables[0].Rows[i]["PName"].ToString();
        HGC[1].Controls.Add(h4);
        for (int j = 0; j < 2; j++)
        {
            HGC[1].Controls.Add(info[j]);
            HGC[1].Controls.Add(new LiteralControl("<br/>"));
            HGC[1].Controls.Add(new LiteralControl("<br/>"));
        }
        HGC[2].Controls.Add(image);
    }
    private void AddButtons(int e,int l)
    {
        int p;
        if (Request.QueryString["page"] == null)
            p = 1;
        else
         p = int.Parse(Request.QueryString["page"]);
        Button prv = new Button();
        prv.Text = "Previous";
        prv.CssClass = "mdl-button mdl-js-button mdl-button--raised mdl-button--accent";
        if (p != 1){
            int a = p - 1;
            prv.Click += delegate
            {
                Response.Redirect("ProductList.aspx?page=" + a);
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
                Response.Redirect("ProductList.aspx?page=" + b);
            };


        }
        else
            next.Enabled = false;
        Dnext.Controls.Add(next);

    }
    private bool count(int i)
    {
        DateTime a = DateTime.Now;
        int day = int.Parse(ak.Tables[0].Rows[i]["ED"].ToString()) - a.Day;
        int hour = int.Parse(ak.Tables[0].Rows[i]["EH"].ToString()) - a.Hour + (day * 24);
        int min = int.Parse(ak.Tables[0].Rows[i]["EMIN"].ToString()) - a.Minute - 1;
        int sec = 59 - a.Second;
        if (min < 0)
        {
            min += 60;
            hour--;
        }
        if (hour >= 0)
            return true;
        return false;


    }
}