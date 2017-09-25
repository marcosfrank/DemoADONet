using Demo.Data;
using Demo.Entities;
using System.Collections.Generic;

namespace Demo.Business
{
    public class RegionLogic
    {
        #region Constructors

        public RegionLogic()
        {
            this.Adapter = new RegionAdapter();
        }

        #endregion Constructors

        #region Properties

        private RegionAdapter Adapter { get; set; }

        #endregion Properties

        #region Methods

        public void Delete(int regiondID)
        {
            this.Adapter.Delete(regiondID);
        }

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