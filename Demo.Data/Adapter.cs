using Demo.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System;

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

        public void Delete(Int32 regionID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Region WHERE RegionID = @regionID");
            var paramId = new SqlParameter("@regionID", regionID);
            command.Parameters.Add(paramId);
            using (var conn = new SqlConnection(ConnectionString))
            {
                command.Connection = conn;
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Region reg)
        {
            SqlCommand command = new SqlCommand("UPDATE Region SET RegionDescription = @regionDescription WHERE RegionID = @regionID");
            var paramId = new SqlParameter("@regionID", reg.RegionID);
            var paramDescription = new SqlParameter("@regionDescription", reg.Description);
            command.Parameters.Add(paramId);
            command.Parameters.Add(paramDescription);
            using (var conn = new SqlConnection(ConnectionString))
            {
                command.Connection = conn;
                conn.Open();
                command.ExecuteNonQuery();
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
            var ret = new List<Region>();
            SqlCommand command = new SqlCommand("SELECT * FROM Region");
            using (var conn = new SqlConnection(ConnectionString))
            {
                command.Connection = conn;
                conn.Open();
                var reader = command.ExecuteReader();
                ret = ReadDR(reader);
            }
            return ret;
        }

        public void Insert(Region region)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Region (RegionID, RegionDescription ) VALUES (@regionID,@regionDescription)");
            int nextId = GetNextRegionID();
            var paramId = new SqlParameter("@regionID", nextId);
            var paramDescription = new SqlParameter("@regionDescription", region.Description);
            command.Parameters.Add(paramId);
            command.Parameters.Add(paramDescription);
            using (var conn = new SqlConnection(ConnectionString))
            {
                command.Connection = conn;
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        private int GetNextRegionID()
        {
            int ret = 0;
            SqlCommand command = new SqlCommand("SELECT MAX(RegionID) from Region");
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                command.Connection = conn;
                ret = (Int32)command.ExecuteScalar();
            }
            ret++;
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