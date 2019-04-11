using SQLite;
using SQLiteNetExtensions.Attributes;


namespace LocalDatabaseTwoTables.Model
{
    [Table("Products")]
   public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int UnitsInStock { get; set; }
        
        public decimal UnitPrice { get; set; }

        [ForeignKey(typeof(Category))]
        public int CategoryID { get; set; }

        [ManyToOne]
        public Category Category { get; set; }
    }
}
