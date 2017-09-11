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
                ret = ReadDR(reader);
            }
            return ret;
        }

        private List<Region> ReadDR(SqlDataReader reader)
        {
            List<Region> regions = new List<Region>();
            while (reader.Read())
            {
                var reg = new Region();
                reg.RegionID = (Int32)reader["RegionID"];
                reg.Description = reader["RegionDescription"].ToString();
                regions.Add(reg);
            }
            return regions;
        }

        #endregion Methods
    }
}