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

        private const string CommandName = "Select";

        #endregion Fields

        #region Properties

        private RegionLogic BusinessLogic { get; set; }

        #endregion Properties

        #region Methods

        protected void btnExecuteInsert_Click(object sender, EventArgs e)
        {
            Region reg = new Region
            {
                Description = this.txtDescription.Text
            };
            this.BusinessLogic.Insert(reg);
            FillDataGridAndCleanTextBoxs();
        }

        protected void btnExecuteSelect_Click(object sender, EventArgs e)
        {
            FillDataGridAndCleanTextBoxs();
        }

        protected void btnExecuteUpdate_Click(object sender, EventArgs e)
        {
            Region reg = new Region
            {
                RegionID = Convert.ToInt32(this.txtRegionId.Text),
                Description = this.txtDescription.Text
            };
            this.BusinessLogic.Update(reg);
            FillDataGridAndCleanTextBoxs();
        }

        protected void dgvResultados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == CommandName)
            {
                var row = this.dgvResultados.Rows[Convert.ToInt32(e.CommandArgument)];
                this.txtDescription.Text = row.Cells[1].Text;
                this.txtRegionId.Text = row.Cells[2].Text;
            }
        }

        private void CleanTextBoxs()
        {
            this.txtDescription.Text = string.Empty;
            this.txtRegionId.Text = string.Empty;
        }

        private void FillDataGrid()
        {
            this.dgvResultados.DataSource = this.BusinessLogic.GetAll();
            this.dgvResultados.DataBind();
        }

        private void FillDataGridAndCleanTextBoxs()
        {
            this.CleanTextBoxs();
            this.FillDataGrid();
        }

        #endregion Methods

        protected void btnExecuteDelete_Click(object sender, EventArgs e)
        {
            int regiondID = Convert.ToInt32(this.txtRegionId.Text);
            this.BusinessLogic.Delete(regiondID);
            FillDataGridAndCleanTextBoxs();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BusinessLogic = new RegionLogic();
            if (!Page.IsPostBack)
            {
                FillDataGridAndCleanTextBoxs();
            }
        }
    }
}