using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DapperColumnMappingsSamples.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperColumnMappingsSamples
{
    [TestClass]
    public class SqlMapperTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Dapper.SqlMapper.SetTypeMap(
                typeof(Product),
                new ColumnAttributeTypeMapper<Product>());

            IEnumerable<Product> products;
            using (SqlConnection sql = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                products = sql.Query<Product>(@"SELECT * FROM TestTable");
            }

            Assert.AreEqual("無線網路分享器", products.Single().Name);
        }
    }
}