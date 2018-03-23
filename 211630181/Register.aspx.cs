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

public partial class Register : System.Web.UI.Page{
    protected void Page_Load(object sender, EventArgs e){
        UDDL();
    }
    private void UDDL(){
        DataSet ds = SqlAC.CheckData("SELECT * FROM Cities");
        TB_City.DataSource = ds.Tables[0];
        TB_City.DataTextField = ds.Tables[0].Columns["City"].ToString();
        TB_City.DataValueField = ds.Tables[0].Columns["City"].ToString();
        TB_City.DataBind();
    }
    private bool ask(){
        if (TB_User.Text.Equals("") || TB_PN.Text.Equals("") || TB_password.Text.Equals("") || TB_LN.Text.Equals("") || TB_FN.Text.Equals("") || TB_Email.Text.Equals("") || TB_Conforirmpassword.Text.Equals("") || TB_City.Text.Equals("")){
            LBL_output.Text = "You can't leave input fields empty.";
            return false;
        }
        string email = TB_Email.Text;
        if (email.IndexOf("@") <= 0 || email.IndexOf("@") >= email.Length - 1)
        {
            LBL_output.Text = "invalid email adress";
            return false;
        }
        return true;
    }
    protected void Btn_SignUp_Click(object sender, EventArgs e){
        try { 
        if (ask()){
                SqlAC.udi("INSERT INTO Users VALUES('" + TB_User.Text + "','" + TB_password.Text + "','" + TB_Email.Text + "','" + TB_FN.Text + "','" + TB_LN.Text + "','" + TB_City.Text + "','" + TB_PN.Text + "','0')");
                Response.Redirect("Home.aspx");
            }
        
            
    }
        catch (Exception){
            LBL_output.Text = "username taken";
        }
    }
    protected void Btn_Clear_Click(object sender, EventArgs e){
        TB_City.Text = "";
        TB_Conforirmpassword.Text = "";
        TB_Email.Text = "";
        TB_FN.Text = "";
        TB_LN.Text = "";
        TB_password.Text = "";
        TB_PN.Text = "";
        TB_User.Text = "";
    }
}
