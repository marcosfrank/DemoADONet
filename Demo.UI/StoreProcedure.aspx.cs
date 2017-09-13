using Demo.Business;
using System;

namespace Demo.UI
{
    public partial class StoreProcedure : System.Web.UI.Page
    {
        #region Properties

        private ProductLogic BusinessLogic { get; set; }

        #endregion Properties

        #region Methods

        protected void btnExecuteStoreProcedure_Click(object sender, EventArgs e)
        {
            this.dgvResultadosStoreProcedure.DataSource = this.BusinessLogic.GetMostExpensiveProducts();
            this.dgvResultadosStoreProcedure.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BusinessLogic = new ProductLogic();
        }

        #endregion Methods
    }
}