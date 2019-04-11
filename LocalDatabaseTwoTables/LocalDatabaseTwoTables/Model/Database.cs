using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
// LocalDatabaseTwoTables.Model.Database
namespace LocalDatabaseTwoTables.Model
{

   public class Database
    {
        SQLiteConnection Db;

        public Database() // Constructor
        {
            // Path
            string PathDb =
                Path.Combine(Environment.GetFolderPath
                    (Environment.SpecialFolder.LocalApplicationData),
                    "Db.db3");

            Db = new SQLiteConnection(PathDb);

            Db.CreateTable<Category>();
            Db.CreateTable<Product>();
        }
        

        public Category CreateCategoryWithChildren(Category toCreate)
        {
            // TODO:
        }

        public List<Category> GetCategoriesWithChildren()
        {
            //TODO:
        }
    }
}
