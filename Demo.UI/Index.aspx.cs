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
        #region Fields

        private const string Command_Name = "Select";

        #endregion Fields

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
            FillDataGrid();
        }

        protected void btnExecuteStoreProcedure_Click(object sender, EventArgs e)
        {
            //this.BusinessLogic.ExecuteSelect();dgvResultados_RowCommand
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

        protected void dgvResultados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == Command_Name)
            {
                var row = this.dgvResultados.Rows[Convert.ToInt32(e.CommandArgument)];
                this.txtDescription.Text = row.Cells[1].Text;
                this.txtRegionId.Text = row.Cells[2].Text;
            }
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

        protected void btnExecuteDelete_Click(object sender, EventArgs e)
        {
            int regiondID = Convert.ToInt32(this.txtRegionId.Text);
            this.BusinessLogic.Delete(regiondID);
            FillDataGrid();
        }
    }
}