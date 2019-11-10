using Guzmanflix.BE;
using Guzmanflix.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guzmanflix
{
    public partial class ServicePlansForm : System.Web.UI.Page
    {
        private IList<ServicePlan> items;
        private IList<StreamingChannel> channels;
        private ServicePlanBLL business;

        protected void Page_Load(object sender, EventArgs e)
        {
            var channelsBusiness = new StreamingChannelBLL();
            channels = channelsBusiness.Get();

            if (business == null) business = new ServicePlanBLL();

            if (!Page.IsPostBack)
            {
                this.LoadSatelliteData();
                this.RefreshItems();
            }
        }

        private void LoadSatelliteData()
        {
            foreach (var channel in channels)
            {
                this.lstChannels.Items.Add(new ListItem(channel.Name, channel.Code.AsString()));
            }
        }

        private void RefreshItems()
        {
            this.items = this.business.Get();
            var source = items.Select(x => new { x.Code, x.Name, x.Price, x.ClientPurchaseDiscount });

            this.grdItems.DataSource = source;
            this.grdItems.DataBind();
        }

        private void ClearControls()
        {
            txtCode.Text = String.Empty;
            txtName.Text = String.Empty;
            txtPrice.Text = String.Empty;

            foreach (ListItem item in this.lstChannels.Items)
            {
                item.Selected = false;
            }
        }

        private void LoadControls(GridViewRow row)
        {
            var code = row.Cells[1].Text.AsInt();
            var entity = this.business.Get(code);

            {
                txtCode.Text = entity.Code.AsString();
                txtName.Text = entity.Name;
                txtPrice.Text = entity.Price.AsString();
                ddlServicePlanType.SelectedIndex = 0;

                foreach (ListItem item in this.lstChannels.Items)
                {
                    var itemCode = item.Value.AsInt();

                    if (entity.Channels.Any(x => x.Code == itemCode))
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        private IList<StreamingChannel> GetSelectedChannels()
        {
            var list = new List<StreamingChannel>();

            foreach (ListItem item in this.lstChannels.Items)
            {
                if (item.Selected)
                {
                    var channel = channels.First(x => x.Code == item.Value.AsInt());
                    list.Add(channel);
                }
            }

            return list;
        }

        private ServicePlan CreateServicePlanInstance()
        {
            var type = this.ddlServicePlanType.SelectedValue;

            switch(type)
            {
                case "COMMON":
                    {
                        return new CommonServicePlan();
                    }
                case "SILVER":
                    {
                        return new SilverServicePlan();
                    }
                case "PREMIUM":
                    {
                        return new PremiumServicePlan();
                    }
            }

            throw new Exception("Tipo de plan seleccionado inválido");
        }

        private ServicePlan CreateModelFromUI()
        {
            var item = this.CreateServicePlanInstance();

            item.Code = this.txtCode.Text.AsInt();
            item.Name = this.txtName.Text;
            item.Price = this.txtPrice.Text.AsDouble();
            item.Channels = this.GetSelectedChannels();

            return item;
        }

        private void CallBusinessAction(Action<ServicePlanBLL, ServicePlan> action)
        {
            var model = this.CreateModelFromUI();

            action(business, model);

            this.ClearControls();
            this.RefreshItems();
        }

        protected void btnCreate_Click(object sender, EventArgs e) => this.CallBusinessAction((business, model) => business.Create(model));

        protected void btnUpdate_Click(object sender, EventArgs e) => this.CallBusinessAction((business, model) => business.Update(model));

        protected void btnDelete_Click(object sender, EventArgs e) => this.CallBusinessAction((business, model) => business.Delete(model));

        protected void grdItems_SelectedIndexChanged(object sender, EventArgs e) => this.LoadControls(this.grdItems.SelectedRow);
    }
}