<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="Album.OnlineEmail.UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>个人信息</title>
    <style>
        #LkBackToUserHome{
            text-decoration:none;
        }
        #showInfo{
            border:solid 1px;
            border-radius:3px;
             height:20px;
             padding:10px;
        }
      
      
        .clear{
            clear:both;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    
         <div style="margin:20px;">
            <span>当前用户</span> <asp:LinkButton ID="LkBackToUserHome" runat="server" Text="*" OnClick="LkBackToUserHome_Click">LinkButton</asp:LinkButton>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="Button2" runat="server" Height="27px" OnClick="Button2_Click" style="margin-top: 0px" Text="修改" />
          
         </div>

           <asp:ScriptManager ID="ScriptManager1" runat="server">
             </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                  <div  id="showInfo" runat="server" >
                <div id="info" style="float:left">
                       <asp:Label runat="server" ID="SexLbl" Text="unknown"></asp:Label>
                         &nbsp;
                         <span>|</span>
                            &nbsp;
                         <asp:Label ID="AgeLbl" runat="server" Text="unknown"></asp:Label><span>岁</span>
                </div>
                <div id="ToChange" runat="server" style="float:left;margin-left:150px">
                       <span>男:</span> <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="SexRadio" />
                         <span>女:</span>  <asp:RadioButton ID="RadioButton2" runat="server" GroupName="SexRadio" />
                         &nbsp; &nbsp; &nbsp;
                        <span>年龄:</span><asp:TextBox runat="server" ID="AgeTb" Width="42px"></asp:TextBox>
                            &nbsp; &nbsp; &nbsp;
                          <asp:Button ID="Button1" runat="server" Text="保存修改" OnClick="Button1_Click" />
                 </div>
                      <div class="clear"></div>
          </div>
            </ContentTemplate>
        </asp:UpdatePanel>
   
   <div id="ToUploadImg" style="float:left; width:24%;margin:40px; padding-left:30px;padding-top:40px;">
<asp:FileUpload ID="FileUpload1" runat="server" />

     <br />
<asp:Label ID="Label1" runat="server" Text="" Style="color: Red"></asp:Label>
       <br />
       <br />
       <span>选择标签:</span>
       <br />
       <asp:RadioButtonList ID="RadioButtonList1" runat="server"  RepeatColumns="1">
         <asp:ListItem Selected="True">风景</asp:ListItem>
        <asp:ListItem>生活</asp:ListItem>
         <asp:ListItem>人物</asp:ListItem>
        <asp:ListItem>动漫</asp:ListItem>
         <asp:ListItem>奇幻</asp:ListItem>
        <asp:ListItem>其它</asp:ListItem>
       </asp:RadioButtonList>
       <asp:Button ID="Button4" runat="server" Text="上传" Width="54px" OnClick="Button4_Click" />
</div>
       
   <div id="Preview"  style="float:left;margin-left:100px;padding:100px">
       <asp:Image runat="server" ID="Image1" Style="z-index: 102; left: 20px;top: 49px" Width="360px" />
       
   </div>
           
       <div class="clear"></div>
    </form>
</body>
</html>
