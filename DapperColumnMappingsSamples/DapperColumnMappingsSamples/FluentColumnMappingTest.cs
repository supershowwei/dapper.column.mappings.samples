using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dapper.FluentColumnMapping;
using DapperColumnMappingsSamples.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperColumnMappingsSamples
{
    [TestClass]
    public class FluentColumnMappingTest
    {
        [TestMethod]
        public void Test_FluentColumnMapping()
        {
            var columnMappings = new ColumnMappingCollection();

            columnMappings.RegisterType<Product>()
                          .MapProperty(x => x.Id).ToColumn("MyId")
                          .MapProperty(x => x.Name).ToColumn("MyName")
                          .MapProperty(x => x.Price).ToColumn("Num_Price");

            columnMappings.RegisterWithDapper();

            IEnumerable<Product> products;
            using (SqlConnection sql = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                products = sql.Query<Product>(@"SELECT * FROM TestTable");
            }

            Assert.AreEqual("無線網路分享器", products.Single().Name);
        }
    }
}