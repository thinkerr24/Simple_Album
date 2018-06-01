<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="Album.OnlineEmail.UserHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>欢迎来到OA</title>
    <style>
        #Button1{
            text-decoration:none;

        }

         #logoHome{
            float:left;
              margin-top:15px;
              margin-left:20px;
        }
        #LinkHome{
          
         
            text-decoration:none;
            border:solid 1px;
            background-color:transparent;
            padding:10px 20px;
            border-color:greenyellow;
            
        }
     

        #welc{
            margin-left:100px;
              margin-top:15px;
             float:left;
        }
       
        #startWrite{
             margin-left:300px;
             float:left;
        }
        #Info{
             float:left;
        }
        .tip {
            display: inline-block;
            position: relative;
        }

        .tip:before, .tip:after {
            opacity: 0; /*透明度为完全透明*/
            position: absolute;
            z-index: 1000; /*设为最上层*/
            /*鼠标放上元素上时的动画，鼠标放上后效果在.tip-*:hover:before, .tip-*:hover:after中设置;
            0.3s:规定完成过渡效果需要多少秒或毫秒,ease:规定慢速开始，然后变快，然后慢速结束的过渡效果*/
            transition: 0.3s ease;
            -webkit-transition: 0.3s ease;
            -moz-transition: 0.3s ease;
        }

        .tip:before {
            content: '';
            border: 6px solid transparent;
        }

        .tip:after {
            content: attr(data-tip); /*后去要提示的文本*/
            padding: 5px;
            white-space: nowrap; /*强制不换行*/
            background-color: #000000;
            color: #ffffff;
        }

        .tip:hover:before, .tip:hover:after {
            opacity: 1; /*鼠标放上时透明度为完全显示*/
            z-index: 1000;
        }

       

        .tip-right:before {
            top: 50%;
            left: 100%;
            border-right-color: rgba(0, 0, 0, 0.8);
            margin-left: -9px;
            margin-top: -3px;
        }

        .tip-right:after {
            top: 50%;
            left: 100%;
            margin-left: 3px;
            margin-top: -6px;
        }

        .tip-right:hover:before {
            margin-left: -3px;
        }

        .tip-right:hover:after {
            margin-left: 9px;
        }
      .Img{
            z-index: 102;
             left: 20px;
             top: 49px;
             max-width:60%;
      }
      .showdiv{
          text-align:center;
         border:solid 1px;
         border-radius:2px;
         margin:10px;
         max-width:100%;
        padding-top:15px;
         padding-right:10px;
         padding-bottom:5px;
      }
        #title{
            margin:15px 30px;
        }
        #Label1{
            margin-left:100px;
        }
        #Button1{
           margin-left:500px;
            margin-top:20px;
        }
        #Button2
        {
             margin-left:20px;
             margin-top:20px;
        }
        #Navigate{
            text-align:center;
            border-bottom:20px;
        }
        .clear{
            clear:both;
        }
    </style>
</head>
   
<body>
    <form id="form1" runat="server">
    <div style="height:40px; padding:15px;background-color:lightblue">
        <div id="logoHome">
            <asp:LinkButton ID="LinkIndex" runat="server" Text="OAlbum" OnClick="LinkHome_Click"></asp:LinkButton>
        </div>
        <div id="welc">
                <asp:Label runat="server" ID="timeLabel" Text ="欢迎来到OA!" Font-Bold="true"></asp:Label>
       <asp:LinkButton runat="server" ID="chgInfo" Text="*" OnClick="chgInfo_Click" CssClass="tip tip-right" data-tip="上传图片&编辑个人资料"></asp:LinkButton>
        </div>
        <div style="text-align:center; float:left; margin-left:184px; margin-top:15px; width: 344px;">
              <span>上传照片数量:</span>
        <asp:Label ID="Label1" runat="server" Text="*"></asp:Label>
        </div>
   

     
    </div>
        <div class="clear"></div>
      <div class="showdiv" id="Img1" runat ="server">
          <asp:Image ID="Image1" runat="server" CssClass="Img" />
          <br />
          <asp:LinkButton ID="DeleteBtn1" runat="server" OnClick="DeleteBtn1_Click" ToolTip="删除这张图片">删除</asp:LinkButton>
          <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" ToolTip="修改图片分类">
              <asp:ListItem>风景</asp:ListItem>
              <asp:ListItem>生活</asp:ListItem>
              <asp:ListItem>人物</asp:ListItem>
              <asp:ListItem>动漫</asp:ListItem>
              <asp:ListItem>奇幻</asp:ListItem>
              <asp:ListItem>其它</asp:ListItem>
          </asp:DropDownList>
      </div>
        <br />
        <br />
        <div class="showdiv" id="Img2" runat ="server">
            <asp:Image ID="Image2" runat="server" CssClass="Img"/>
            <br />

          <asp:LinkButton ID="DeleteBtn2" runat="server" OnClick="DeleteBtn2_Click" ToolTip="删除这张图片">删除</asp:LinkButton>
            <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" ToolTip="修改图片分类">
               <asp:ListItem>风景</asp:ListItem>
              <asp:ListItem>生活</asp:ListItem>
              <asp:ListItem>人物</asp:ListItem>
              <asp:ListItem>动漫</asp:ListItem>
              <asp:ListItem>奇幻</asp:ListItem>
              <asp:ListItem>其它</asp:ListItem>
            </asp:DropDownList>
        </div>
       <div  id="Navigate">

           <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">上一页</asp:LinkButton>
           &nbsp;
           <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">下一页</asp:LinkButton>

        </div>
    </form>
</body>
</html>
