using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Data;
using Demo.Entities;

namespace Demo.Business
{
    public class Logic
    {
        #region Constructors

        public Logic()
        {
            this.Adapter = new Adapter();
        }

        #endregion Constructors

        #region Properties

        public Adapter Adapter { get; set; }

        #endregion Properties

        #region Methods

        public IEnumerable<Region> ExecuteSelect()
        {
            return this.Adapter.GetAll();
        }

        public string ExecuteUpdate()
        {
            string a = "";
            return a;
        }

        #endregion Methods
    }
}