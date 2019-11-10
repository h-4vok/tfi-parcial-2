<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Title="Gestión de Clientes" CodeBehind="ClientsForm.aspx.cs" Inherits="Guzmanflix.ClientsForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Modifique los servicios de sus clientes.</h3>

    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="grdItems" runat="server" AutoGenerateColumns="false" DataKeyNames="Code" OnSelectedIndexChanged="grdItems_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="true" />
                    <asp:BoundField DataField="Code" HeaderText="Código" ReadOnly="true" />
                    <asp:BoundField DataField="FirstName" HeaderText="Nombre" ReadOnly="true" />
                    <asp:BoundField DataField="LastName" HeaderText="Apellido" ReadOnly="true" />
                    <asp:BoundField DataField="FinalFee" HeaderText="Abono" ReadOnly="true" />
                    <asp:BoundField DataField="SilverPlansCount" HeaderText="Planes Silver" ReadOnly="true" />
                    <asp:BoundField DataField="PremiumPlansCount" HeaderText="Planes Premium" ReadOnly="true" />
                    <asp:BoundField DataField="NationalId" HeaderText="Documento" ReadOnly="true" />
                    <asp:BoundField DataField="BirthDate" HeaderText="Fecha Nacimiento" ReadOnly="true" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label>Paquetes</label>
                <asp:ListBox ID="lstServicePlans" SelectionMode="Multiple" Height="200px" runat="server"></asp:ListBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" OnClick="btnUpdate_Click" ValidationGroup="validate" />
        </div>
    </div>

</asp:Content>
