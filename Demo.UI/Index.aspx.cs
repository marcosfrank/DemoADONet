using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Demo.Business;

namespace Demo.UI
{
    public partial class Index : System.Web.UI.Page
    {
        #region Properties

        private Logic BusinessLogic { get; set; }

        #endregion Properties

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.BusinessLogic = new Logic();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtInit.Text = "Marcos";
            this.dgvResultados.DataSource = this.BusinessLogic.ExecuteSelect();
            this.dgvResultados.DataBind();
        }

        #endregion Methods

        protected void btnExecuteSelect_Click(object sender, EventArgs e)
        {
        }

        protected void btnExecuteStoreProcedure_Click(object sender, EventArgs e)
        {
            this.BusinessLogic.ExecuteSelect();
        }

        protected void btnExecuteUpdate_Click(object sender, EventArgs e)
        {
            this.BusinessLogic.ExecuteUpdate();
        }
    }
}