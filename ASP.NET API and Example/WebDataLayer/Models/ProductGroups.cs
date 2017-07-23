using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebDataLayer.Models
{
    public class ProductGroups
    {

        public List<ProductsGroup> Get()
        {
            List<ProductsGroup> list = new List<ProductsGroup>();
            using (SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PWSConnectionString"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = Helpers.GetSql(Helpers.ProcNames.ProductGroups, Helpers.ProcType.Select);
                SqlDataReader rs = cmd.ExecuteReader();
                while (rs.Read())
                {
                    list.Add(new ProductsGroup(rs));
                }
                rs.Close();
                cmd = null;
                con.Close();
            }
            return list;
        }


        public ProductsGroup Add(ProductsGroup productgroup)
        {
            productgroup.Id = 0;
            return Update(productgroup);
        }

        public ProductsGroup Update(ProductsGroup productgroup)
        {
            using (SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PWSConnectionString"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = Helpers.GetSql(Helpers.ProcNames.ProductGroups, Helpers.ProcType.Insert);
                if (productgroup.Id != 0)
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = productgroup.Id;
                    cmd.CommandText = Helpers.GetSql(Helpers.ProcNames.ProductGroups, Helpers.ProcType.Update);
                }

                cmd.Parameters.Add("@ProductGroup", SqlDbType.VarChar, 100).Value = productgroup.ProductGroup;
                productgroup.Id = Convert.ToInt32(cmd.ExecuteScalar());
                cmd = null;
                con.Close();
            }
            return productgroup;
        }
        public bool Delete(ProductsGroup productgroup)
        {
            return Delete(productgroup.Id);
        }

        public bool Delete(int Id)
        {
            bool success = false;
            using (SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PWSConnectionString"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = Helpers.GetSql(Helpers.ProcNames.ProductGroups, Helpers.ProcType.Delete);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                success = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd = null;
                con.Close();
            }
            return success;
        }

        public class ProductsGroup
        {
            public enum fields
            {
                Id,
                ProductGroup
            }

            public int Id { get; set; }

            public string ProductGroup { get; set; }

            public ProductsGroup()
            {
            }

            public ProductsGroup(SqlDataReader rs)
            {
                Id = Helpers.SqlCheckForNullInt(rs[(int)fields.Id]);
                ProductGroup = Helpers.SqlCheckForNullString(rs[(int)fields.ProductGroup]);
            }

        }
    }
}