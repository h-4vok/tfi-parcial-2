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
    public partial class StreamingChannelsForm : System.Web.UI.Page
    {
        private IList<StreamingChannel> items;
        private IList<StreamingShow> shows;
        private StreamingChannelBLL business;

        protected void Page_Load(object sender, EventArgs e)
        {
            var showsBusiness = new StreamingShowBLL();
            shows = showsBusiness.Get();

            if (business == null) business = new StreamingChannelBLL();

            if (!Page.IsPostBack)
            {
                this.LoadSatelliteData();
                this.RefreshItems();
            }
        }

        private void LoadSatelliteData()
        {
            foreach(var show in shows)
            {
                lstShows.Items.Add(new ListItem(show.Name, show.Code.AsString()));
            }
        }

        private void RefreshItems()
        {
            this.items = this.business.Get();

            this.grdItems.DataSource = this.items;
            this.grdItems.DataBind();
        }

        private void ClearControls()
        {
            txtCode.Text = String.Empty;
            txtName.Text = String.Empty;

            foreach(ListItem item in this.lstShows.Items)
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

                foreach (ListItem item in this.lstShows.Items)
                {
                    var itemCode = item.Value.AsInt();

                    if (entity.Shows.Any(x => x.Code == itemCode))
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        private IList<StreamingShow> GetSelectedShows()
        {
            var list = new List<StreamingShow>();

            foreach(ListItem item in this.lstShows.Items)
            {
                if (item.Selected)
                {
                    var show = shows.First(x => x.Code == item.Value.AsInt());
                    list.Add(show);
                }
            }

            return list;
        }

        private StreamingChannel CreateModelFromUI()
        {
            var item = new StreamingChannel
            {
                Code = this.txtCode.Text.AsInt(),
                Name = this.txtName.Text,
                Shows = this.GetSelectedShows(),
            };

            return item;
        }

        private void CallBusinessAction(Action<StreamingChannelBLL, StreamingChannel> action)
        {
            var model = this.CreateModelFromUI();

            var business = new StreamingChannelBLL();
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