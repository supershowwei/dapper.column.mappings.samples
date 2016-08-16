using System.ComponentModel.DataAnnotations.Schema;

namespace DapperColumnMappingsSamples.Models
{
    public class Product
    {
        [Column("MyId")]
        public int Id { get; set; }

        [Column("MyName")]
        public string Name { get; set; }

        [Column("Num_Price")]
        public int Price { get; set; }

        public string Memo { get; set; }
    }
}