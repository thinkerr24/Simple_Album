<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Album.OnlineAlbum.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>O Album</title>
    <style>
        #header{
           height:40px;
         text-align:right; 
         border:solid;
         background-color:lightblue;
         padding:10px;
        }
        .navigationBtn{
            text-decoration:none;
        }
        #OtherBtn{
            margin-right:75px;
        }
        #btnToReg{
            margin-right:10px;
        }
        .linkBtn{
            text-decoration:none;
            padding:3px 7px;
            border:solid 1px;
            border-radius:2px;
         
        }
        #logo{
            margin-right:300px;
        }
        #body{
            border:solid 1px;
            text-align:center;
            border-radius : 2px;
            padding:5px 10px;
           margin-top:20px;
             background-color:lightgrey;
        }
        .ImgDiv{
            float:left;
            text-align:center;
            width:48%;
            max-height:50%;
            margin:5px;
             

        }
        .Img{
            z-index: 102; 
            left: 20px;
            top: 49px;
            width:330px;
            margin:26px;
        }
        #bottom{
            margin-top:50px;
            margin-bottom:10px;
            background-color:black;
            padding:15px;
            text-align:center;
        }
        .useraccess{
            color:black;
        }
       
        .clear{
            clear:both;
        }
    </style>
</head>
<body>
   
    

        <form runat="server">
           <div id="header">
               <asp:Label runat="server" Font-Size="Large" Font-Bold="false" ForeColor="Blue" ID="logo">OA相册</asp:Label>
           
               <asp:LinkButton ID="AllBtn" runat="server" OnClick="AllBtn_Click" CssClass="navigationBtn">全部</asp:LinkButton>
               &nbsp;  &nbsp;  &nbsp;
               <asp:LinkButton ID="SenseBtn" runat="server" OnClick="SenseBtn_Click" CssClass="navigationBtn">风景</asp:LinkButton>
                  &nbsp;  &nbsp;  &nbsp;
               <asp:LinkButton ID="LifeBtn" runat="server" OnClick="LifeBtn_Click" CssClass="navigationBtn">生活</asp:LinkButton>
                      &nbsp;  &nbsp;  &nbsp;
               <asp:LinkButton ID="PersonBtn" runat="server" OnClick="PersonBtn_Click" CssClass="navigationBtn">人物</asp:LinkButton>
                  &nbsp;  &nbsp;  &nbsp;
               <asp:LinkButton ID="AnimeBtn" runat="server" OnClick="AnimeBtn_Click" CssClass="navigationBtn">动漫</asp:LinkButton>
                   &nbsp;  &nbsp;  &nbsp;
               <asp:LinkButton ID="ImageBtn" runat="server" OnClick="ImageBtn_Click" CssClass="navigationBtn">奇幻</asp:LinkButton>
                  &nbsp;  &nbsp;  &nbsp;
               <asp:LinkButton ID="OtherBtn" runat="server" OnClick="OtherBtn_Click" CssClass="navigationBtn">其它</asp:LinkButton>
                &nbsp; &nbsp;
                    
                     <span>照片数量:</span>
              <asp:Label runat="server" ID="ShowNum" Width="30px"></asp:Label>
          
                  &nbsp; &nbsp;
               <asp:LinkButton runat="server" OnClick="Unnamed1_Click" ID="btnToLog" CssClass="linkBtn" Text="登录"></asp:LinkButton>
                &nbsp; 
               <asp:LinkButton runat="server" OnClick="Unnamed2_Click" ID="btnToReg" CssClass="linkBtn" Text="注册"></asp:LinkButton>
           &nbsp;
       
           </div>
        
           <div id="body">
               <div class="ImgDiv">
                   <asp:Image ID="Image1" runat="server" CssClass="Img" />
               </div>
                  <div class="ImgDiv">
                   <asp:Image ID="Image2" runat="server" CssClass="Img"/>
               </div>
               <div class="clear"></div>
                  <div class="ImgDiv">
                   <asp:Image ID="Image3" runat="server" CssClass="Img"/>
               </div>
               
                  <div class="ImgDiv">
                   <asp:Image ID="Image4" runat="server" CssClass="Img"/>
               </div>
               <div class="clear"></div>
                  <div class="ImgDiv">
                   <asp:Image ID="Image5" runat="server" CssClass="Img"/>
               </div>
                  <div class="ImgDiv">
                   <asp:Image ID="Image6" runat="server" CssClass="Img"/>
               </div>
               <div class="clear"></div>
               <div id="Index" style="text-align:center">
                   <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">上一页</asp:LinkButton>
                   <span>&nbsp;&nbsp;</span>
                   <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">下一页</asp:LinkButton> 

               </div>
           </div>
            <div id="bottom">
                <p style="color:white">
          &copy;2018 黑衣秀士 & windbird All Rights Reserved.
                </p>
            </div>
        </form>
         
   
 </body>
</html>
