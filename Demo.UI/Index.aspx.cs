using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Demo.Business;
using Demo.Entities;

namespace Demo.UI
{
    public partial class Index : System.Web.UI.Page
    {
        #region Properties

        private Logic BusinessLogic { get; set; }

        #endregion Properties

        #region Methods

        protected void btnExecuteInsert_Click(object sender, EventArgs e)
        {
            Region reg = new Region
            {
                Description = this.txtDescription.Text
            };
            this.BusinessLogic.Insert(reg);
            FillDataGrid();
        }

        protected void btnExecuteSelect_Click(object sender, EventArgs e)
        {
        }

        protected void btnExecuteStoreProcedure_Click(object sender, EventArgs e)
        {
            //this.BusinessLogic.ExecuteSelect();
        }

        protected void btnExecuteUpdate_Click(object sender, EventArgs e)
        {
            Region reg = new Region
            {
                RegionID = Convert.ToInt32(this.txtRegionId.Text),
                Description = this.txtDescription.Text
            };
            this.BusinessLogic.Update(reg);
            FillDataGrid();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BusinessLogic = new Logic();
            if (!Page.IsPostBack)
            {
                FillDataGrid();
            }
        }

        private void FillDataGrid()
        {
            this.dgvResultados.DataSource = this.BusinessLogic.GetAll();
            this.dgvResultados.DataBind();
        }

        #endregion Methods
    }
}