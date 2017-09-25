using Demo.Data;
using Demo.Entities;
using System.Collections.Generic;

namespace Demo.Business
{
    public class ProductLogic
    {
        #region Properties

        private ProductAdapter Adapter { get; set; }

        #endregion Properties

        #region Constructors

        public ProductLogic()
        {
            this.Adapter = new ProductAdapter();
        }

        #endregion Constructors

        #region Methods

        public IEnumerable<Product> GetMostExpensiveProducts()
        {
            return this.Adapter.GetMostExpensiveProducts();
        }

        #endregion Methods
    }
}