using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dapper.FluentMap;
using Dapper.FluentMap.Mapping;
using DapperColumnMappingsSamples.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperColumnMappingsSamples
{
    [TestClass]
    public class FluentMapTest
    {
        [TestMethod]
        public void Test_FluentMap()
        {
            FluentMapper.Initialize(cfg =>
            {
                cfg.AddMap(new ProductMap());
            });

            IEnumerable<Product> products;
            using (SqlConnection sql = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                products = sql.Query<Product>(@"SELECT * FROM TestTable");
            }

            Assert.AreEqual("無線網路分享器", products.Single().Name);
        }
    }

    public class ProductMap : EntityMap<Product>
    {
        public ProductMap()
        {
            Map(x => x.Id).ToColumn("myid", false);
            Map(x => x.Name).ToColumn("MyName");
            Map(x => x.Price).ToColumn("Num_Price");
        }
    }
}