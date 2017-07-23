using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebDataLayer.Models
{
    public class Products
    {
       public List<Product> Get()
        {
            List<Product> list = new List<Product>();
            using (SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PWSConnectionString"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = Helpers.GetSql(Helpers.ProcNames.Products, Helpers.ProcType.Select);
                SqlDataReader rs = cmd.ExecuteReader();
                while (rs.Read())
                {
                    list.Add(new Product(rs));
                }
                rs.Close();
                cmd = null;
                con.Close();
            }
            return list;
        }

        public Product Add(Product product)
        {
            product.Id = 0;
            return Update(product);
        }

        public Product Update(Product product)
        {
            using (SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PWSConnectionString"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = Helpers.GetSql(Helpers.ProcNames.Products, Helpers.ProcType.Insert);
                if (product.Id != 0)
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = product.Id;
                    cmd.CommandText = Helpers.GetSql(Helpers.ProcNames.Products, Helpers.ProcType.Update);
                }
                cmd.Parameters.Add("@ProductDesc", SqlDbType.VarChar, 100).Value = product.ProductDesc;
                cmd.Parameters.Add("@Cost", SqlDbType.Float).Value = product.Cost;
                cmd.Parameters.Add("@RRP", SqlDbType.Float).Value = product.RRP;
                cmd.Parameters.Add("@ProductPicture", SqlDbType.VarChar, 255).Value = product.ProductPicture;
                cmd.Parameters.Add("@ProductNotes", SqlDbType.VarChar, 255).Value = product.ProductNotes;
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = product.Inactive;
                cmd.Parameters.Add("@ProdGroup", SqlDbType.Int).Value = product.ProdGroup;
                if (product.ProductId==null)
                {
                    product.ProductId = System.Guid.NewGuid().ToString();
                }
                cmd.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = Guid.Parse( product.ProductId);

                product.Id = Convert.ToInt32(cmd.ExecuteScalar());
                cmd = null;
                con.Close();
            }
            return product;
        }
        public bool Delete(Product product)
        {
            return Delete(product.Id);

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
                cmd.CommandText = Helpers.GetSql(Helpers.ProcNames.Products, Helpers.ProcType.Delete);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                success = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd = null;
                con.Close();
            }
            return success;
        }

        public class Product
        {
            public enum fields
            {
                Id,
                ProductDesc,
                Cost,
                RRP,
                ProductPicture,
                ProductNotes,
                Inactive,
                ProdGroup,
                ProductId
            }

            public int Id { get; set; }
            public string ProductDesc { get; set; }
            public double? Cost { get; set; }
            public double? RRP { get; set; }
            public string ProductPicture { get; set; }
            public string ProductNotes { get; set; }
            public bool? Inactive { get; set; }
            public int? ProdGroup { get; set; }
            public string ProductId { get; set; }

            public Product()
            {

            }

            public Product(SqlDataReader rs)
            {
                Id = Helpers.SqlCheckForNullInt(rs[(int)fields.Id]);
                ProductDesc = Helpers.SqlCheckForNullString(rs[(int)fields.ProductDesc]);
                Cost = Helpers.SqlCheckForNullableFloat(rs[(int)fields.Cost]);
                RRP = Helpers.SqlCheckForNullableFloat(rs[(int)fields.RRP]);
                ProductPicture = Helpers.SqlCheckForNullString(rs[(int)fields.ProductPicture]);
                ProductNotes = Helpers.SqlCheckForNullString(rs[(int)fields.ProductNotes]);
                Inactive = Helpers.SqlCheckForNullableBool(rs[(int)fields.Inactive]);
                ProdGroup = Helpers.SqlCheckForNullableInt(rs[(int)fields.ProdGroup]);
                ProductId = Helpers.SqlCheckForNullString(rs[(int)fields.ProductId]);
            }

        }
    }
}