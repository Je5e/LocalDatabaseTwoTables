using System;
using System.Collections.ObjectModel; // 
using LocalDatabaseTwoTables.Model;
using Xamarin.Forms;
using System.Collections.Generic;

namespace LocalDatabaseTwoTables
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Product> Products =
            new ObservableCollection<Product>();
        public MainPage()
        {
            InitializeComponent();
            // La vista no va a mostrar los productos --- cambio de dato
            ListViewProducts.ItemsSource = Products;
        }


        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
          
            Product nuevoProducto = new Product();
            nuevoProducto.ProductName = ProductNameEntry.Text;

            // Agregamos el objeto product a la lista.
            Products.Add(nuevoProducto);
        }

        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            string categoryName = CategoryNameEntry.Text;
            Database db = new Database();
            List<Category> categories = db.GetCategoriesWithChildren();

           

            Category newCategory = new Category();
            newCategory.CategoryName = CategoryNameEntry.Text;
            newCategory.Description = DescriptionEntry.Text;

            newCategory.Products = new List<Product>();

            // Recorrer la collection Products
            foreach (Product product in Products)
            {
                newCategory.Products.Add(product);


                // Instancia de Database
             
               Category Result = db.CreateCategoryWithChildren(newCategory);
                if (Result.CategoryID > 0)
                {
                    lblMensaje.Text = "Ok";
                }
            }
        }   
    }
}
