using Demo.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.Data;
using AutoMapper;

namespace Demo.Data
{
    public class Adapter
    {
        #region Fields

        private const string ConnectionStringName = "Northwind";

        #endregion Fields

        #region Properties

        public String ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[ConnectionStringName].ToString();
            }
        }

        #endregion Properties

        #region Constructors

        public Adapter()
        {
        }

        #endregion Constructors

        #region Methods

        public IEnumerable<Region> GetAll()
        {
            //TODO Corregir esto.
            var ret = new List<Region>();
            SqlCommand command = new SqlCommand("SELECT * FROM Region");
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                command.Connection = conn;
                var reader = command.ExecuteReader();
                ret = Mapper.Map<IDataReader, List<Region>>(reader);
            }
            return ret;
        }

        #endregion Methods
    }
}