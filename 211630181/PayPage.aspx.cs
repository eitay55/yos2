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

public partial class PayPage : System.Web.UI.Page
{
    DataRow ak;
    int CM;
    int ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        if (CheckID())
            Response.Redirect("CompletedAuctions.aspx?page=1");
            */
        ID = 1;
        string query = "SELECT * FROM CompletedAuctions WHERE ID='" + ID.ToString() + "'";
        ak = SqlAC.CheckData(query).Tables[0].Rows[0];
        SUser.Text = ak["SUser"].ToString();
        PriceTP.Text = ak["Price"].ToString();
        PDesc.Text = ak["Description"].ToString();
    }
    private bool CheckID()
    {
        try
        {
            ID = int.Parse(Request.QueryString["ID"]);
        }
        catch
        {
            return true;
        }
        if (ID < 0)
            return true;
        string query = "SELECT * FROM CompletedAuctions WHERE ID='" + ID.ToString() + "'";
        ak = SqlAC.CheckData(query).Tables[0].Rows[0];
        string name = ak["BName"].ToString();
        if (Session["username"].ToString() != name)//XXXXXXXXXXXXXXXXXXXXX
            return true;
        return false;
    }

    protected void Check_Click(object sender, EventArgs e)
    {
        CM = int.Parse(PaymentMethod.SelectedValue);
        Panel_Payment.Visible = true;
        switch (CM)
        {
            case 1://balance
                PaymentM1.Visible = true;
                int balance = GetBalance();
                Balance.Text = balance.ToString();
                break;
            case 2://CreditCard
                PaymentM2.Visible = true;
                break;
        }
        Submit.Enabled = true;
        PaymentMethod.Enabled = false;
    }

    private int GetBalance(){
        string name = "";
        try
        {
            name = Session["username"].ToString();
        }
        catch
        {
            Response.Redirect("Home.aspx");
        }
        string query = "SELECT * FROM Users WHERE Username='" + name + "'";
        DataRow UserInfo = SqlAC.CheckData(query).Tables[0].Rows[0];
        return int.Parse(UserInfo["Balance"].ToString());
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        int price = int.Parse(ak["Price"].ToString());
        switch (CM)
        {
            
            case 1://balance
                int AmountLeft = GetBalance()- price;
                if (AmountLeft < 0)
                {
                    string seller = ak["SUser"].ToString();
                    string buyer = ak["BUser"].ToString();
                    SqlAC.udi("UPDATE Users SET Balance=Balance+" + price + " WHERE Username='" + seller + "'");
                    SqlAC.udi("UPDATE Users SET Balance=" + AmountLeft + " WHERE Username='" + buyer + "'");
                    SqlAC.udi("DELETE FROM CompletedAuctions WHERE ID='" + ID + "'");
                    Output.Text = "Transaction completed";
                    Submit.Enabled = false;
                }
                else
                    Output.Text = "not enough funds";
                    
                break;
            case 2://CreditCard
                Check.Enabled = false;
                Service.WebService s = new Service.WebService();
                int result = s.Purchase(CCNum.Text, CVV.Text, ExpDate.Text, Person_ID.Text, price.ToString());
                if (result == 1)
                {
                    Output.Text = " Transaction completed";
                    Submit.Enabled = false;
                    SqlAC.udi("DELETE FROM CompletedAuctions WHERE ID='" + ID + "'");
                }
                else if(result==0){
                    Output.Text = "Check your input";
                }
                else{
                    Output.Text = "You can't use that credit card";
                }
                
                break;
        }
    }
}