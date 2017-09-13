using System;
using System.Configuration;

namespace Demo.Data
{
    public abstract class Adapter
    {
        #region Fields

        private const string ConnectionStringName = "Northwind";

        #endregion Fields

        #region Properties

        protected String ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[ConnectionStringName].ToString();
            }
        }

        #endregion Properties
    }
}