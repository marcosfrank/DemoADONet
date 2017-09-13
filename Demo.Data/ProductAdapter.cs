using Demo.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data
{
    public class ProductAdapter : Adapter
    {
        #region Fields

        private static string StoreProcedureName = "Ten Most Expensive Products";
        private readonly string DescriptionColumn = "TenMostExpensiveProducts";
        private readonly string UnitPriceColumn = "UnitPrice";

        #endregion Fields

        #region Methods

        public IEnumerable<Product> GetMostExpensiveProducts()
        {
            var ret = new List<Product>();
            SqlCommand command = new SqlCommand(StoreProcedureName);
            command.CommandType = System.Data.CommandType.StoredProcedure; //IMPORTANTE!!
            using (var conn = new SqlConnection(ConnectionString))
            {
                command.Connection = conn;
                conn.Open();
                var reader = command.ExecuteReader();
                ret = Map(reader);
            }
            return ret;
        }

        private List<Product> Map(SqlDataReader reader)
        {
            List<Product> regions = new List<Product>();
            while (reader.Read())
            {
                var pro = new Product();
                pro.Description = reader[DescriptionColumn].ToString();
                pro.UnitPrice = Convert.ToDouble(reader[UnitPriceColumn].ToString());
                regions.Add(pro);
            }
            return regions;
        }

        #endregion Methods
    }
}