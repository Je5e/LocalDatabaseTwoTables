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
            bool Result = VerificarCategory();
            if (Result)
            {
                DisplayAlert
                    ("Message", "Ya existe nombre de la categoría", "Ok");
            }
            else
            {
                Database db = new Database();
                Category newCategory = new Category();
                newCategory.CategoryName = CategoryNameEntry.Text;
                newCategory.Description = DescriptionEntry.Text;

                newCategory.Products = new List<Product>();

                // Recorrer la collection Products
                foreach (Product product in Products)
                {
                    newCategory.Products.Add(product); 
                }

                // Instancia de Database
                Category NewResult = db.CreateCategoryWithChildren(newCategory);
                if (NewResult.CategoryID > 0)
                {
                    lblMensaje.Text = "Ok";
                    lblMensaje.Text += $" ID: {NewResult.CategoryID}";
                }
            }
            
        }   

 
        private bool VerificarCategory()
        {
            // Hay que validar esa regla de negocio. No categorias duplicadas
            string categoryName = CategoryNameEntry.Text;
            Database db = new Database();
            bool Existe = false;

            List<Category> categories = db.GetCategoriesWithChildren();

            foreach (Category c in categories)
            {
                var text = categoryName.ToUpper(); // Convertir a Mayúsculas
                if (c.CategoryName == categoryName)
                {
                    Existe = true;
                    return Existe;
                }
            }
            return Existe;
        }
    }

}
