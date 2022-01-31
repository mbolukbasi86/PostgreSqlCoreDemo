using Newtonsoft.Json.Linq;
using PostgresqlCoreDemo.DataAccess.DbHelper;
using PostgresqlCoreDemo.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostgreSqlCoreDemo.Business.Handlers
{
    public class ProductHandler
    {
        public ProductHandler()
        {

        }

        public IEnumerable<Product> GetProducts()
        {
            return DbHelper.Query<Product>("select * from Products", null);
        }

        public void AddProduct(Product product)
        {
            int discontinued = Convert.ToInt32(product.Discontinued);
            DbHelper.ExecuteNonQuery($"INSERT INTO Products values( {product.ProductID},'{product.ProductName}', {product.SupplierId}, {product.CategoryId}, '{product.QuantityPerUnit}', {product.UnitPrice}, {product.UnitsInStock}, {product.UnitsOnOrder}, {product.ReorderLevel}, {discontinued})");
        }
    }
}
