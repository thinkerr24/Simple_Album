using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Album.OnlineEmail
{
    public partial class UserInfo : System.Web.UI.Page
    {
   
        protected void Page_Load(object sender, EventArgs e)
        {

          
            ToChange.Visible = false;
          
            if (Session["CurrentUser"] != null)
            {
                LkBackToUserHome.Text = Session["CurrentUser"].ToString();
                LkBackToUserHome.ForeColor = System.Drawing.Color.LightBlue;
                
            }
          

            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
              
                string sqlselect;
                if (Session["CurrentUser"] != null)
                {
                     sqlselect = "select * from UserTable where UId='" + Session["CurrentUser"] + "'";
                    SqlCommand cmd = new SqlCommand(sqlselect, conn);
                    SqlDataReader reder = cmd.ExecuteReader();
                    reder.Read();
                    if (reder["Sex"] != null)
                    {
                        SexLbl.Text = reder["Sex"].ToString();
                    }
                    if (reder["Age"] != null)
                    {
                        AgeLbl.Text = reder["Age"].ToString();
                    }

                }

             

            }
            catch(Exception ee)
            {
                Response.Write(ee.ToString());
            }
            finally
            {
                conn.Close();
            }
          

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           string SexCk = RadioButton1.Checked ? "男":"女";
            string AgeText = AgeTb.Text;
            int Age = -1;
            try
            {
                 Age = int.Parse(AgeText);
            }
            catch
            {
              //  Response.Write("输入整数");
            }

            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connStr);

            try
            {
                conn.Open();

                string sqlselect;
                if (Session["CurrentUser"] != null)
                {
                    sqlselect = "update UserTable set Sex = N'" + SexCk + "', Age = '" + Age + "' where  UId='" + Session["CurrentUser"] + "'";
                    SqlCommand cmd = new SqlCommand(sqlselect, conn);
                    cmd.ExecuteNonQuery();

                    ToChange.Visible = false;
                }



            }
            catch (Exception ee)
            {
                Response.Write(ee.ToString());
            }
            finally
            {
                conn.Close();
            }

            Response.Redirect("UserInfo.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ToChange.Visible = true;
        }

        protected void LkBackToUserHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserHome.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
          
            if (FileUpload1.FileName == "")
            {
               Label1.Text = "上传文件不能为空";
                return;
            }

            bool fileIsValid = false;
            //如果确认了上传文件，则判断文件类型是否符合要求 
            if (this.FileUpload1.HasFile)
            {
                //获取上传文件的后缀 
                String fileExtension = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower();
                String[] restrictExtension = { ".gif", ".jpg", ".bmp", ".png" };
                //判断文件类型是否符合要求 
                for (int i = 0; i < restrictExtension.Length; i++)
                {
                    if (fileExtension == restrictExtension[i])
                    {
                        fileIsValid = true;
                    }
                    //如果文件类型符合要求,调用SaveAs方法实现上传,并显示相关信息 
                    if (fileIsValid == true)
                    {
                        //上传文件是否大于10M
                        if (FileUpload1.PostedFile.ContentLength > (10 * 1024 * 1024))
                        {
                            Label1.Text = "上传文件过大";
                            return;
                        }

                        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
                        SqlConnection conn = new SqlConnection(connStr);
                        conn.Open();
                        try
                        {
                         
                          string sqlselect;
                            if (Session["CurrentUser"] != null)
                            {

                                //new SqlCommand("select count(*) from UserTable where UId=@UId", conn);
                                sqlselect = "select count(*) from Pic where (ULUser='" + Session["CurrentUser"] + "' and  FName='" + FileUpload1.FileName + "')";
                                SqlCommand cmd1 = new SqlCommand(sqlselect, conn);
                                int count = (int)cmd1.ExecuteScalar();
                                if (count > 0)
                                {
                                  
                             
                                    Label1.Text = "文件重复";
                         
                                    conn.Close();
                                    return;
                                }
                                else
                                {
                           
                                    Image1.ImageUrl = "./Image/" + FileUpload1.FileName;
                                    FileUpload1.SaveAs(Server.MapPath("")+ "./Image/" + FileUpload1.FileName);
                                    Label1.Text = "文件上传成功!";
                                    Image1.ToolTip = FileUpload1.FileName;
                                    sqlselect = "INSERT INTO Pic (ULUser, FName,Tag,Date) VALUES ('" + Session["CurrentUser"] + "', N'" + FileUpload1.FileName + "', N'" + RadioButtonList1.SelectedItem.Text + "', '" + DateTime.Now.ToShortDateString().ToString() + "')";
                                    SqlCommand cmd2 = new SqlCommand(sqlselect, conn);
                                    cmd2.ExecuteNonQuery();
                                    return;
                                }
                              

                             }


                        }
                        catch(Exception ee)
                        {
                            //Label1.Text = "文件上传失败！";
                            Response.Write(ee.ToString());
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                    else
                    {
                        this.Label1.Text = "只能够上传后缀为.gif,.jpg,.bmp,.png的文件";
                    }
                }
            }
        }

       
    }
}
