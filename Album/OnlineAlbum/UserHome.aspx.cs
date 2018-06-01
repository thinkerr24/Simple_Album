using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/**
 * 获取日期+时间
DateTime.Now.ToString();            // 2008-9-4 20:02:10
DateTime.Now.ToLocalTime().ToString();        // 2008-9-4 20:12:12//

获取日期
DateTime.Now.ToLongDateString().ToString();    // 2008年9月4日
DateTime.Now.ToShortDateString().ToString();    // 2008-9-4
DateTime.Now.ToString("yyyy-MM-dd");        // 2008-09-04
DateTime.Now.Date.ToString();            // 2008-9-4 0:00:00

获取时间
DateTime.Now.ToLongTimeString().ToString();    // 20:16:16
DateTime.Now.ToShortTimeString().ToString();    // 20:16
DateTime.Now.ToString("hh:mm:ss");         // 08:05:57
DateTime.Now.TimeOfDay.ToString();         // 20:33:50.7187500

其他
DateTime.ToFileTime().ToString();        // 128650040212500000
DateTime.Now.ToFileTimeUtc().ToString();    // 128650040772968750
DateTime.Now.ToOADate().ToString();        // 39695.8461709606
DateTime.Now.ToUniversalTime().ToString();    // 2008-9-4 12:19:14

获取年份、月份、星期、小时、分钟、秒数

DateTime.Now.Year.ToString();          获取年份    // 2008
DateTime.Now.Month.ToString();      获取月份    // 9
DateTime.Now.DayOfWeek.ToString();  获取星期    // Thursday
DateTime.Now.DayOfYear.ToString();  获取第几天    // 248
DateTime.Now.Hour.ToString();          获取小时    // 20
DateTime.Now.Minute.ToString();     获取分钟    // 31
DateTime.Now.Second.ToString();     获取秒数    // 45
 */

namespace Album.OnlineEmail
{
    public partial class UserHome : System.Web.UI.Page
    {
        private int Pic_num;
        private static int CurrentPage = 0;
        private static int Img1_Id;
        private static int Img2_Id;
        private static string File1;
        private static string File2;
        private static string Tag1;
        private static string Tag2;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            Pic_num = Get_Pic_Num();
            Label1.Text = Pic_num + "";
            int nowHour = int.Parse(DateTime.Now.Hour.ToString());
            if (nowHour == 6 || nowHour == 7)
            {
                timeLabel.Text = "早上好,";
            }
           else if (nowHour > 7 && nowHour < 12)
            {
                timeLabel.Text = "上午好,";
            }
            else if (nowHour < 18)
            {
                timeLabel.Text = "下午好,";
            }
            else
            {
                timeLabel.Text = "晚上好,";
            }
            if (Session["CurrentUser"] != null)
            {
                chgInfo.Text = Session["CurrentUser"].ToString();
                 if (!IsPostBack)
                {
                    Init_Pic(CurrentPage);
                 
                }
             
            }

         
        


        }

        //加载当前页面的两张图片
        protected void Init_Pic(int Page_Num)
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string sqlselect;
                if (Session["CurrentUser"] != null)
                {

                    Img1.Visible = true;
                    Img2.Visible = true;
                    Img1_Id = 0;
                    Img2_Id = 0;
                    File1 = "";
                    File2 = "";
                    Tag1 = "";
                    Tag2 = "";

                   sqlselect = "select * from Pic where ULUser='" + Session["CurrentUser"] + "' order by PId desc";
                    SqlCommand cmd = new SqlCommand(sqlselect, conn);
                    SqlDataReader reder = cmd.ExecuteReader();
                    Image2.Visible = true;
                    int Count = 0;
                   // int Max_Page = (Pic_num - 1) / 2; 
                    for (;Count < CurrentPage * 2; Count++)
                    {   
                  
                        reder.Read();
                       
                    }

                    if (reder.Read())
                    {
                        Image1.ImageUrl = "./Image/" + reder["FName"];
                        int index1 = reder["Date"].ToString().IndexOf(' ');
                        Tag1 = reder["Tag"].ToString();
                        Image1.ToolTip = Tag1 + "\n" + reder["Date"].ToString().Substring(0, index1);
                        Img1_Id = (int)reder["PId"];
                        File1 = Image1.ImageUrl;
                        DropDownList1.SelectedIndex = Checked_DropDL(Tag1);
                        
                    }

                    else
                    {
                        Img1.Visible = false;
                    }

                    //  Response.Write("<script>alert('" + reder["FName"].ToString().Length + "')</script>");
                    if (reder.Read())
                    {

                        Image2.ImageUrl = "./Image/" + reder["FName"];
                        int index2 = reder["Date"].ToString().IndexOf(' ');
                        Tag2 = reder["Tag"].ToString();
                        Image2.ToolTip = Tag2 + " \n" + reder["Date"].ToString().Substring(0, index2);
                        Img2_Id = (int)reder["PId"];
                        File2 = Image2.ImageUrl;
                        DropDownList2.SelectedIndex = Checked_DropDL(Tag2);
                       
                    }
                    else
                    {
                        Img2.Visible = false;
                    }
                   
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
        }

        //获取当前用户上传的照片数量
        protected int Get_Pic_Num()
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string sqlselect;
                if (Session["CurrentUser"] != null)
                {
                    sqlselect = "select count(*) from Pic where ULUser='" + Session["CurrentUser"] + "'";
                    SqlCommand cmd = new SqlCommand(sqlselect, conn);
                  return (int)cmd.ExecuteScalar();
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
            return 0;
       }

        //删除指定ID的图片
        protected void Delete_Pic(int PId)
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string sqlselect;
                if (Session["CurrentUser"] != null)
                {
                    sqlselect = "delete from Pic where PId='" + PId + "'";
                    SqlCommand cmd = new SqlCommand(sqlselect, conn);
                        cmd.ExecuteNonQuery();
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
            return ;
        }

        //选中当前图片的当前标签
        protected int Checked_DropDL(string tag)
        {

            switch (tag)
            {
                case "风景": return 0;
                case "生活": return 1;
                case "人物": return 2;
                case "动漫": return 3;
                case "奇幻": return 4;
                case "其它": return 5;
            }
            return 5;
        }
        //修改指定图片的标签
        protected void Chang_Tag(int PId, string NewTag)
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string sqlselect;
                if (Session["CurrentUser"] != null)
                { 
                    sqlselect = "update  Pic set Tag = N'"+ NewTag +  "' where PId='" + PId + "'";
                    SqlCommand cmd = new SqlCommand(sqlselect, conn);
                    cmd.ExecuteNonQuery();
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
            return;
        }
        protected void chgInfo_Click(object sender, EventArgs e)
        {
            if (Session["CurrentUser"] != null)
            {
                Response.Redirect("UserInfo.aspx");
            }
        }

        protected void LinkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
          
            if (CurrentPage > 0)
            {
            
                Init_Pic(--CurrentPage);
      
            }
                
            
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
        
           // Response.Write("<script>alert('" + CurrentPage  + "')</script>");
             if (CurrentPage < (Pic_num - 1) / 2)
            {
              
                Init_Pic(++CurrentPage);
      
            }
          
        }

        protected void DeleteBtn1_Click(object sender, EventArgs e)
        {
            Delete_Pic(Img1_Id);
            Img1.Visible = false;
            string FName = Server.MapPath("") +  File1;
            if (File.Exists(FName))
                File.Delete(FName);
            Label1.Text = int.Parse(Label1.Text) - 1 + "";
            Response.Redirect("UserHome.aspx");

        }

        protected void DeleteBtn2_Click(object sender, EventArgs e)
        {
            Delete_Pic(Img2_Id);
            Img2.Visible = false;
           string FName =  Server.MapPath("") + File2;
            if (File.Exists(FName))
                File.Delete(FName);
            Label1.Text = int.Parse(Label1.Text) - 1 + "";
            Response.Redirect("UserHome.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Chang_Tag(Img1_Id, DropDownList1.SelectedItem.Text);
          
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Chang_Tag(Img2_Id, DropDownList1.SelectedItem.Text);
           
        }
    }
}