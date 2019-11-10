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
    public partial class ClientsForm : Page
    {
        private IList<Client> items;
        private IList<ServicePlan> servicePlans;
        private ClientBLL business;
        private static Client entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            var plansBusiness = new ServicePlanBLL();
            servicePlans = plansBusiness.Get();

            if (business == null) business = new ClientBLL();

            if (!Page.IsPostBack)
            {
                this.LoadSatelliteData();
                this.RefreshItems();
            }
        }

        private void LoadSatelliteData()
        {
            foreach (var plan in servicePlans)
            {
                this.lstServicePlans.Items.Add(new ListItem(plan.Name, plan.Code.AsString()));
            }
        }

        private void RefreshItems()
        {
            this.items = this.business.Get();

            this.grdItems.DataSource = items;
            this.grdItems.DataBind();
        }

        private void ClearControls()
        {
            foreach (ListItem item in this.lstServicePlans.Items)
            {
                item.Selected = false;
            }
        }

        private void LoadControls(GridViewRow row)
        {
            var code = row.Cells[1].Text.AsInt();
            entity = this.business.Get(code);

            {
                foreach (ListItem item in this.lstServicePlans.Items)
                {
                    var itemCode = item.Value.AsInt();

                    if (entity.ServicePlans.Any(x => x.Code == itemCode))
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        private IList<ServicePlan> GetSelectedPlans()
        {
            var list = new List<ServicePlan>();

            foreach (ListItem item in this.lstServicePlans.Items)
            {
                if (item.Selected)
                {
                    var plan = servicePlans.First(x => x.Code == item.Value.AsInt());
                    list.Add(plan);
                }
            }

            return list;
        }
        
        private void CallBusinessAction(Action<ClientBLL, Client> action)
        {
            entity.ServicePlans = this.GetSelectedPlans();

            action(business, entity);

            this.ClearControls();
            this.RefreshItems();
        }

        protected void btnUpdate_Click(object sender, EventArgs e) => this.CallBusinessAction((business, model) => business.Update(model));

        protected void grdItems_SelectedIndexChanged(object sender, EventArgs e) => this.LoadControls(this.grdItems.SelectedRow);
    }
}