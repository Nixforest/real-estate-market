<%@ Page Title="Register" Language="C#" MasterPageFile="~/Master/Home.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="RealEstateMarket.Account.Register" %>
    <%@ Register TagPrefix="nixforest" TagName="address" Src="~/CustomControl/AddressControl.ascx" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tr>
            <td>
               <asp:CreateUserWizard ID="RegisterUser" runat="server" EnableViewState="false" OnCreatedUser="RegisterUser_CreatedUser">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="wizardStepPlaceholder" runat="server"></asp:PlaceHolder>
                        <asp:PlaceHolder ID="navigationPlaceholder" runat="server"></asp:PlaceHolder>
                    </LayoutTemplate>
                    <WizardSteps>
                        <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">
                            <ContentTemplate>
                                <h2>
                                    Create a New Account
                                </h2>
                                <p>
                                    Use the form below to create a new account.
                                </p>
                                <p>
                                    Passwords are required to be a minimum of <%= Membership.MinRequiredPasswordLength %> characters in length.
                                </p>
                                <span class="failureNotification">
                                    <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                                </span>
                                <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                                     ValidationGroup="RegisterUserValidationGroup"/>
                                <div class="accountInfo">
                                    <fieldset class="register">
                                        <legend>Account Information</legend>
                                        <p>
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                            <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                                 CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                                                 ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                        </p>
                                        <p>
                                            <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                            <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" 
                                                 CssClass="failureNotification" ErrorMessage="E-mail is required." ToolTip="E-mail is required." 
                                                 ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                        </p>
                                        <p>
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                            <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                                 CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                                                 ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                        </p>
                                        <p>
                                            <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                                            <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic" 
                                                 ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired" runat="server" 
                                                 ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                                 CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                                 ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                                        </p>                            
                                    </fieldset>
                                    <p class="submitButton">
                                        <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Create User" 
                                             ValidationGroup="RegisterUserValidationGroup"/>
                                    </p>
                                </div>
                            </ContentTemplate>
                            <CustomNavigationTemplate>
                    
                            </CustomNavigationTemplate>
                
                        </asp:CreateUserWizardStep>
                    </WizardSteps>
                </asp:CreateUserWizard>
            </td>
            <td>
                <h3>
                    Thông tin bổ sung
                </h3>
                <p>
                    Bạn phải điền vào các trường bên dưới
                </p>
                <p>
                    <asp:CheckBox ID="AgreeCheckBox" runat="server"
                        Text="Bạn đồng ý với các điều khoản trong Quy định của Website"/>
                </p>
                <asp:Panel ID="InfoPanel" runat="server" BorderStyle="Groove">
                    <p>
                        <asp:Label ID="FullNameLabel" runat="server" AssociatedControlID="FullNameTextBox">Họ và tên:</asp:Label>
                        <asp:TextBox ID="FullNameTextBox" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator"
                            runat="server"
                            ControlToValidate="FullNameTextBox"
                            CssClass="failureNotification"
                            Display="Dynamic"
                            ErrorMessage="Nhập họ tên"
                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="AddressLabel" runat="server" AssociatedControlID="Address">Địa chỉ:</asp:Label>
                        <nixforest:address ID="Address" runat="server" />
                    <p>
                        <asp:Label ID="IdentityCardLabel" runat="server" AssociatedControlID="IdentityCardTextBox">Số CMND:</asp:Label>
                        <asp:TextBox ID="IdentityCardTextBox" runat="server" CssClass="textEntry"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Label ID="HomePhoneLabel" runat="server" AssociatedControlID="HomePhoneTextBox">Điện thoại bàn:</asp:Label>
                        <asp:TextBox ID="HomePhoneTextBox" runat="server" CssClass="textEntry"></asp:TextBox>                                
                    </p>
                    <p>
                        <asp:Label ID="PhoneLabel" runat="server" AssociatedControlID="PhoneTextBox">Di động:</asp:Label>
                        <asp:TextBox ID="PhoneTextBox" runat="server" CssClass="textEntry"></asp:TextBox>
                    </p>
                </asp:Panel>                
            </td>
        </tr>
    </table>

    
</asp:Content>
