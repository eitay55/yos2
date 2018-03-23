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

public partial class Login : System.Web.UI.Page{
    protected void Page_Load(object sender, EventArgs e){
        
    }

    protected void Btn_Login_Click(object sender, EventArgs e){
        DataSet ds = SqlAC.CheckData("SELECT * FROM Users WHERE Username='" + TB_User.Text + "' AND Password='" + TB_password.Text + "'");
        if (ds.Tables[0].Rows.Count > 0){
            Session["login"] = true;
            Session["Username"] = TB_User.Text;
            Response.Redirect("Home.aspx");
        }
        else
            LBL_output.Text = "Wrong username or password";
    }

    protected void Btn_Clear_Click(object sender, EventArgs e){
        TB_User.Text = "";
        TB_password.Text = "";
    }
}