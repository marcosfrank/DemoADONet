using Demo.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Demo.Data
{
    public class RegionAdapter : Adapter
    {
        #region Fields

        private const string DeleteQuery = "DELETE FROM Region WHERE RegionID = @regionID";
        private const string GetAllQuery = "SELECT * FROM Region";
        private const string InsertQuery = "INSERT INTO Region (RegionID, RegionDescription ) VALUES (@regionID,@regionDescription)";
        private const string MaxRegionIDQuery = "SELECT MAX(RegionID) from Region";
        private const string RegionDescriptionColumn = "RegionDescription";
        private const string RegionIDColumn = "RegionID";
        private const string UpdateQuery = "UPDATE Region SET RegionDescription = @regionDescription WHERE RegionID = @regionID";

        #endregion Fields

        #region Constructors

        public RegionAdapter()
        {
        }

        #endregion Constructors

        #region Methods

        public void Delete(Int32 regionID)
        {
            SqlCommand command = new SqlCommand(DeleteQuery);
            var paramId = new SqlParameter("@regionID", regionID);
            command.Parameters.Add(paramId);
            using (var conn = new SqlConnection(ConnectionString))
            {
                command.Connection = conn;
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Region> GetAll()
        {
            var ret = new List<Region>();
            SqlCommand command = new SqlCommand(GetAllQuery);
            using (var conn = new SqlConnection(ConnectionString))
            {
                command.Connection = conn;
                conn.Open();
                var reader = command.ExecuteReader();
                ret = Map(reader);
            }
            return ret;
        }

        public void Insert(Region region)
        {
            SqlCommand command = new SqlCommand(InsertQuery);
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

        public void Update(Region reg)
        {
            SqlCommand command = new SqlCommand(UpdateQuery);
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

        private int GetNextRegionID()
        {
            int ret = 0;
            SqlCommand command = new SqlCommand(MaxRegionIDQuery);
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                command.Connection = conn;
                ret = (Int32)command.ExecuteScalar();
            }
            ret++;
            return ret;
        }

        private List<Region> Map(SqlDataReader reader)
        {
            List<Region> regions = new List<Region>();
            while (reader.Read())
            {
                var reg = new Region();
                reg.RegionID = (Int32)reader[RegionIDColumn];
                reg.Description = reader[RegionDescriptionColumn].ToString().Trim();
                regions.Add(reg);
            }
            return regions;
        }

        #endregion Methods
    }
}