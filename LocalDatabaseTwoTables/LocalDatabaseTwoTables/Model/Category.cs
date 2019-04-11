using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic; // Collections

namespace LocalDatabaseTwoTables.Model
{
    [Table("Categories")]
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int CategoryID { get; set; }

        [MaxLength(50)]
        public string CategoryName { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeInsert)]
        public List<Product> Products { get; set; }
    }
}
