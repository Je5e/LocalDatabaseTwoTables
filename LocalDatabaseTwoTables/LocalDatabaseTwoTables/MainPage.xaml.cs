using System;
using System.Collections.ObjectModel; // 
using LocalDatabaseTwoTables.Model;
using Xamarin.Forms;

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

        }
    }
}
