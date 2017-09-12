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

        private Adapter Adapter { get; set; }

        #endregion Properties

        #region Methods

        public IEnumerable<Region> GetAll()
        {
            return this.Adapter.GetAll();
        }

        public void Insert(Region reg)
        {
            this.Adapter.Insert(reg);
        }

        public void Update(Region reg)
        {
            this.Adapter.Update(reg);
        }

        #endregion Methods
    }
}