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
            var _product = new Product();
            _product.ProductID = product.ProductID;
            _product.ProductName = product.ProductName;
            _product.SupplierId = product.SupplierId;
            _product.CategoryId = product.CategoryId;
            _product.QuantityPerUnit = product.QuantityPerUnit;
            _product.UnitPrice = product.UnitPrice;
            _product.UnitsInStock = product.UnitsInStock;
            _product.UnitsOnOrder = product.UnitsOnOrder;
            _product.ReorderLevel = product.ReorderLevel;
            _product.Discontinued = product.Discontinued;

            int discontinued = Convert.ToInt32(_product.Discontinued);
            DbHelper.ExecuteNonQuery($"INSERT INTO Products values( {_product.ProductID},'{_product.ProductName}', {_product.SupplierId}, {_product.CategoryId}, '{_product.QuantityPerUnit}', {_product.UnitPrice}, {_product.UnitsInStock}, {_product.UnitsOnOrder}, {_product.ReorderLevel}, {discontinued})");


            //DbHelper.ExecuteNonQuery("INSERT INTO Products (ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsInOrder,ReorderLevel,Discontinued) " +
            //    " values(@ProductName, @SupplierId, @CategoryId, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued )", _product);

            //DbHelper.ExecuteNonQuery("INSERT INTO Products values(@ProductID, @ProductName, @SupplierId, @CategoryId, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued )", _product);

        }
    }
}
