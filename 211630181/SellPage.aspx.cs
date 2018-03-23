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

public partial class SellPage : System.Web.UI.Page
{
    DataSet ak;
    protected void Page_Load(object sender, EventArgs e)
    {
        UDDL();
    }
    protected void Upload(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            string name = Session["username"].ToString();
            string desc = Despription.Text;
            string Catagory = ddl_c.Text;
            string Pname = PName.Text;
            string price = Price.Text;
            DateTime time = DateTime.Now;
            int min =  int.Parse(Min.Text);
            int hour =  int.Parse(Hour.Text);
            while(min > 60){
                min -= 60;
                hour++;
            }
            if (FileUpload1.HasFile||!(desc.Equals(""))||!(name.Equals(""))||!(price.Equals("")))
            {

                SqlAC.udi("INSERT INTO PhotosID (F) VALUES (0)");
                ak = SqlAC.CheckData("SELECT * FROM PhotosID WHERE F='0'");
                string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string fileName = ak.Tables[0].Rows[0]["ID"].ToString();
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/APhotos/") + fileName + extension);
                SqlAC.udi("UPDATE PhotosID SET PhotosID.F='1'");
                SqlAC.udi("INSERT INTO PendingAuctions (PName,SUser,Price,[Min],[Hour],ImgUrl,Catagory,Description) VALUES ('" + Pname + "','" + name + "','" + price + "','" + min.ToString() +"','" + hour.ToString() + "','" + fileName+extension+"','"+Catagory+"','"+desc+"')");
                Response.Redirect(Request.Url.AbsoluteUri);


            }
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
       


    }
    private void UDDL()
    {
        DataSet ds = SqlAC.CheckData("SELECT * FROM Catagories");
        ddl_c.DataSource = ds.Tables[0];
        ddl_c.DataTextField = ds.Tables[0].Columns["Catagory"].ToString();
        ddl_c.DataValueField = ds.Tables[0].Columns["Catagory"].ToString();
        ddl_c.DataBind();
    }
}