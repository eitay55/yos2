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

public partial class ChangeInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                DataSet ak = SqlAC.CheckData("SELECT * FROM Users WHERE Username='" + Session["Username"].ToString() + "'");
                TB_password.Text = ak.Tables[0].Rows[0]["Password"].ToString();
                TB_Conforirmpassword.Text = ak.Tables[0].Rows[0]["Password"].ToString();
                TB_Email.Text = ak.Tables[0].Rows[0]["Email"].ToString();
                TB_FN.Text = ak.Tables[0].Rows[0]["FName"].ToString();
                TB_LN.Text = ak.Tables[0].Rows[0]["LName"].ToString();
                TB_PN.Text = ak.Tables[0].Rows[0]["Phone"].ToString(); DataSet ds = SqlAC.CheckData("SELECT * FROM Cities");
                TB_City.DataSource = ds.Tables[0];
                TB_City.DataTextField = ds.Tables[0].Columns["City"].ToString();
                TB_City.DataValueField = ds.Tables[0].Columns["City"].ToString();
                TB_City.DataBind();
                TB_City.Text = ak.Tables[0].Rows[0]["City"].ToString();
            }
            catch (Exception)
            {
                Response.Redirect("Home.aspx");
            }
        }
    }
    private bool ask()
    {
        if (TB_PN.Text.Equals("") || TB_password.Text.Equals("") || TB_LN.Text.Equals("") || TB_FN.Text.Equals("") || TB_Email.Text.Equals("") || TB_Conforirmpassword.Text.Equals("") || TB_City.Text.Equals(""))
        {
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
    protected void Btn_SignUp_Click(object sender, EventArgs e)
    {
       
            if (ask())
            {
            LBL_output.Text = "User info updated";
            SqlAC.udi("UPDATE Users SET Users.Password='" + TB_password.Text + "', Users.Email='" + TB_Email.Text + "', Users.FName='" + TB_FN.Text + "', Users.LName='" + TB_LN.Text + "', Users.City='" + TB_City.Text + "', Users.Phone='" + TB_PN.Text + "' WHERE Users.Username='" + Session["Username"].ToString() + "'");
            }
    }
}
