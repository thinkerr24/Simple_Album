using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Album.OnlineAlbum
{
    public partial class Home : System.Web.UI.Page
    {

        private static string SqlString;
        private static string SqlCount;
        private static int CurrentPage;
        private static int Pic_num;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["CurrentUser"] != null)
            {
                btnToLog.Text = Session["CurrentUser"].ToString();
                btnToReg.Text = "注销";

                btnToLog.CssClass = "useraccess";
                btnToReg.CssClass = "useraccess";
            }
            else
            {
                btnToLog.CssClass = "linkBtn";
                btnToReg.CssClass = "linkBtn";
                btnToLog.Text = "登录";
                btnToReg.Text = "注册";

            }
            if (!IsPostBack)
            {
                SqlString = "select * from Pic  order by PId desc";
                CurrentPage = 0;
                Init_Pic(SqlString, CurrentPage);
                SqlCount = "select count(*) from Pic";
                Pic_num = Get_Pic_Num(SqlCount);
                ShowNum.Text = Pic_num + "";
            }
          
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (Session["CurrentUser"] != null)
            {

                Response.Redirect("UserHome.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            if (Session["CurrentUser"] != null)
            {
                Session["CurrentUser"] = null;
                Response.Redirect("Index.aspx");
            }
            else
            {
                Response.Redirect("Register.aspx");
            }
               
        }
        //加载符合查询字符串条件的当前页面图片
        protected void Init_Pic(string SqlString, int CurrentPage)
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                Image1.Visible = true;
                Image2.Visible = true;
                Image3.Visible = true;
                Image4.Visible = true;
                Image5.Visible = true;
                Image6.Visible = true;

                SqlCommand cmd = new SqlCommand(SqlString, conn);
                SqlDataReader reder = cmd.ExecuteReader();
                int Count = 0;
                for (; Count < CurrentPage * 6; Count++)
                {
                            reder.Read();
                }

                //读取第一张照片
                if (reder.Read())
                {
                    Image1.ImageUrl = "./Image/" + reder["FName"];
                    int index1 = reder["Date"].ToString().IndexOf(' ');
                    Image1.ToolTip = reder["ULUser"].ToString() + "\n" + reder["Tag"].ToString() + "\n" +reder["Date"].ToString().Substring(0, index1);
                }
                else
                {
                    Image1.Visible = false;
                }
                //读取第二张照片
                if (reder.Read())
                {
                    Image2.ImageUrl = "./Image/" + reder["FName"];
                    int index2 = reder["Date"].ToString().IndexOf(' ');
                    Image2.ToolTip = reder["ULUser"].ToString() + "\n" + reder["Tag"].ToString() + "\n" + reder["Date"].ToString().Substring(0, index2);
                }
                else
                {
                    Image2.Visible = false;
                }
                //读取第三张照片
                if (reder.Read())
                {
                    Image3.ImageUrl = "./Image/" + reder["FName"];
                    int index3 = reder["Date"].ToString().IndexOf(' ');
                    Image3.ToolTip = reder["ULUser"].ToString() + "\n" + reder["Tag"].ToString() + "\n" + reder["Date"].ToString().Substring(0, index3);
                }
                else
                {
                    Image3.Visible = false;
                }
                //第四张
                if (reder.Read())
                {
                    Image4.ImageUrl = "./Image/" + reder["FName"];
                    int index4 = reder["Date"].ToString().IndexOf(' ');
                    Image4.ToolTip = reder["ULUser"].ToString() + "\n" + reder["Tag"].ToString() + "\n" + reder["Date"].ToString().Substring(0, index4);
                }
                else
                {
                    Image4.Visible = false;
                }
                //第五张
                if (reder.Read())
                {
                    Image5.ImageUrl = "./Image/" + reder["FName"];
                    int index5 = reder["Date"].ToString().IndexOf(' ');
                    Image5.ToolTip = reder["ULUser"].ToString() + "\n" + reder["Tag"].ToString() + "\n" + reder["Date"].ToString().Substring(0, index5);
                }
                else
                {
                    Image5.Visible = false;
                }
                //第六张
                if (reder.Read())
                {
                    Image6.ImageUrl = "./Image/" + reder["FName"];
                    int index6 = reder["Date"].ToString().IndexOf(' ');
                    Image6.ToolTip = reder["ULUser"].ToString() + "\n" + reder["Tag"].ToString() + "\n" + reder["Date"].ToString().Substring(0, index6);
                }
                else
                {
                    Image6.Visible = false;
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

        //获取当前条件下的照片数量
        protected int Get_Pic_Num(string SqlString)
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(SqlString, conn);
                 return (int)cmd.ExecuteScalar();
              

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
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 0)
            {

                Init_Pic(SqlString,--CurrentPage);

            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (CurrentPage < (Pic_num - 1) / 6)
            {
                CurrentPage = CurrentPage + 1;
                Init_Pic(SqlString, CurrentPage);
                //Response.Write("<script>alert('" + CurrentPage + "=" + (Pic_num - 1) / 6 + "')</script>");

            }
        }

        protected void AllBtn_Click(object sender, EventArgs e)
        {
            SqlString = "select * from Pic  order by PId desc";
            CurrentPage = 0;
            Init_Pic(SqlString, CurrentPage);
            SqlCount = "select count(*) from Pic";
            Pic_num = Get_Pic_Num(SqlCount);
            ShowNum.Text = Pic_num + "";
        }

        protected void SenseBtn_Click(object sender, EventArgs e)
        {
         
            SqlString = "select * from Pic where Tag=N'风景' order by PId desc";
            CurrentPage = 0;
            Init_Pic(SqlString, CurrentPage);
            SqlCount = "select count(*) from Pic where Tag=N'风景'";
            Pic_num = Get_Pic_Num(SqlCount);
            ShowNum.Text = Pic_num + "";
        }

        protected void LifeBtn_Click(object sender, EventArgs e)
        {
            SqlString = "select * from Pic where Tag=N'生活' order by PId desc";
            CurrentPage = 0;
            Init_Pic(SqlString, CurrentPage);
            SqlCount = "select count(*) from Pic where Tag=N'生活'";
            Pic_num = Get_Pic_Num(SqlCount);
            ShowNum.Text = Pic_num + "";
        }

        protected void PersonBtn_Click(object sender, EventArgs e)
        {
            SqlString = "select * from Pic where Tag=N'人物' order by PId desc";
            CurrentPage = 0;
            Init_Pic(SqlString, CurrentPage);
            SqlCount = "select count(*) from Pic where Tag=N'人物'";
            Pic_num = Get_Pic_Num(SqlCount);
            ShowNum.Text = Pic_num + "";
        }

        protected void AnimeBtn_Click(object sender, EventArgs e)
        {
            SqlString = "select * from Pic where Tag=N'动漫' order by PId desc";
            CurrentPage = 0;
            Init_Pic(SqlString, CurrentPage);
            SqlCount = "select count(*) from Pic where Tag=N'动漫'";
            Pic_num = Get_Pic_Num(SqlCount);
            ShowNum.Text = Pic_num + "";
        }

        protected void ImageBtn_Click(object sender, EventArgs e)
        {
            SqlString = "select * from Pic where Tag=N'奇幻' order by PId desc";
            CurrentPage = 0;
            Init_Pic(SqlString, CurrentPage);
            SqlCount = "select count(*) from Pic where Tag=N'奇幻'";
            Pic_num = Get_Pic_Num(SqlCount);
            ShowNum.Text = Pic_num + "";
        }

        protected void OtherBtn_Click(object sender, EventArgs e)
        {
            SqlString = "select * from Pic where Tag=N'其它' order by PId desc";
            CurrentPage = 0;
            Init_Pic(SqlString, CurrentPage);
            SqlCount = "select count(*) from Pic where Tag=N'其它'";
            Pic_num = Get_Pic_Num(SqlCount);
            ShowNum.Text = Pic_num + "";
        }
    }
}