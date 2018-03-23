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

public partial class MasterPage : System.Web.UI.MasterPage{
    protected void Page_Load(object sender, EventArgs e) {
        if (Session["login"] != null){
            string user = Session["Username"].ToString();
            DataSet ak = SqlAC.CheckData("SELECT * FROM Users WHERE Username ='" + user + "'");
            string manager = ak.Tables[0].Rows[0]["Manager"].ToString();
            if (int.Parse(manager)==1)
            {
                ManagerSide.Visible = true;
            }
            Login.Visible = false;
            Register.Visible = false;
            Logout.Visible = true;
            UProfile.Visible = true;
            LBL_Userinfo.Text = "Hello " + Session["Username"];
            SellP.Visible = true;
            AH.Visible = true;
            Link2.Text = "Sell";
            Link3.Text = "Logout";
            Link2.Click += new EventHandler(LinkAuctions_Click);
            Link3.Click += new EventHandler(Logout_Click);
        }
        else
        {
            ManagerSide.Visible = false;
            AH.Visible = false;
            Login.Visible = true;
            Register.Visible = true;
            Logout.Visible = false;
            UProfile.Visible = false;
            SellP.Visible = false;
            Link2.Text = "Register";
            Link3.Text = "Login";
            Link2.Text = "Register";
            Link3.Text = "Login";
            Link2.Click += new EventHandler(Register_Click);
            Link3.Click += new EventHandler(Login_Click);
        }
    }
    protected void Login_Click(object sender, EventArgs e){
       Response.Redirect("Login.aspx");
    }

    protected void Logout_Click(object sender, EventArgs e){
        Session["username"] = null;
        Session["login"] = null;
        Login.Visible = true;
        SellP.Visible = false;
        Register.Visible = true;
        Logout.Visible = false;
        UProfile.Visible = false;
        AH.Visible = false;
        ManagerSide.Visible = false;
        Response.Redirect("Home.aspx");
    }
    protected void Register_Click(object sender, EventArgs e){
        Response.Redirect("Register.aspx");
    }

    protected void UProfile_Click(object sender, EventArgs e){
        Response.Redirect("ChangeInfo.aspx");
    }
    protected void HomeP_Click(object sender, EventArgs e){
       Response.Redirect("Home.aspx");
    }
    protected void Img_logo_Click(object sender, ImageClickEventArgs e){
       Response.Redirect("Home.aspx");
    }

    protected void LinkAuctions_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductList.aspx");
    }
    protected void Sell_click(object sender, EventArgs e)
    {
        Response.Redirect("SellPage.aspx");
    }
}
