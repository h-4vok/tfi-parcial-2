<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Title="Gestión de Paquetes" CodeBehind="ServicePlansForm.aspx.cs" Inherits="Guzmanflix.ServicePlansForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Cree, Edite o Elimine Paquetes</h3>

    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="grdItems" runat="server" AutoGenerateColumns="false" DataKeyNames="Code" OnSelectedIndexChanged="grdItems_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="true" />
                    <asp:BoundField DataField="Code" HeaderText="Código" ReadOnly="true" />
                    <asp:BoundField DataField="Name" HeaderText="Nombre" ReadOnly="true" />
                    <asp:BoundField DataField="Price" HeaderText="Precio" ReadOnly="true" />
                    <asp:BoundField DataField="ClientPurchaseDiscount" HeaderText="Descuento Abono Total" ReadOnly="true" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label>Código</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtCode"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-3">
            <div class="form-group">
                <label>Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtName"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-3">
            <div class="form-group">
                <label>Precio</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPrice"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label>Tipo de Paquete</label>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlServicePlanType">
                    <asp:ListItem Text="Común" Value="COMMON"></asp:ListItem>
                    <asp:ListItem Text="Silver" Value="SILVER"></asp:ListItem>
                    <asp:ListItem Text="Premium" Value="PREMIUM"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>Canales</label>
                <asp:ListBox ID="lstChannels" SelectionMode="Multiple" Height="200px" runat="server"></asp:ListBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <asp:Button ID="btnCreate" runat="server" Text="Crear" OnClick="btnCreate_Click" ValidationGroup="validate" />
        </div>
        <div class="col-md-3">
            <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" OnClick="btnUpdate_Click" ValidationGroup="validate" />
        </div>
        <div class="col-md-3">
            <asp:Button ID="btnDelete" runat="server" Text="Eliminar" OnClick="btnDelete_Click" />
        </div>
    </div>

    <div class="row">
        <asp:RequiredFieldValidator
            runat="server"
            ErrorMessage="Debe especificar un Código"
            ID="codeRequired"
            ValidationGroup="validate"
            ControlToValidate="txtCode">
        </asp:RequiredFieldValidator>

        <asp:RegularExpressionValidator
            runat="server"
            ID="codeOnlyInteger"
            ControlToValidate="txtCode"
            ErrorMessage="El código debe ser numérico"
            ValidationGroup="validate"
            ValidationExpression="\d+">
        </asp:RegularExpressionValidator>

        <asp:RequiredFieldValidator
            runat="server"
            ErrorMessage="Debe especificar un Nombre"
            ID="nameRequired"
            ValidationGroup="validate"
            ControlToValidate="txtName">
        </asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator
            runat="server"
            ErrorMessage="Debe especificar un Precio"
            ID="priceRequired"
            ValidationGroup="validate"
            ControlToValidate="txtPrice">
        </asp:RequiredFieldValidator>

        <asp:RegularExpressionValidator
            runat="server"
            ID="priceInteger"
            ControlToValidate="txtPrice"
            ErrorMessage="El precio debe ser numérico"
            ValidationGroup="validate"
            ValidationExpression="\d+">
        </asp:RegularExpressionValidator>
    </div>
</asp:Content>