using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Week5.LogService;
using Week5.ProdService;

namespace Week5
{
    /// <summary>
    /// Interaction logic for StoreWindow.xaml
    /// </summary>
    public partial class StoreWindow : Window
    {
        private ProductService productService = new ProductService();
        private LoginService loginService = new LoginService();

        private readonly String username;
        private List<ProductItem> productItems = new List<ProductItem>();

        public StoreWindow(string username)
        {
            this.username = username;
            InitializeComponent();
            RefreshScreen();
        }

        private void BuyBtnClick(object sender, RoutedEventArgs e)
        {
            int index = ProductList.SelectedIndex;
            if (index < 0)
                return;

            ProductItem item = productItems.ElementAt(index);
            if (item != null)
            {
                productService.BuyProduct(item.Name, username, out bool bought, out bool bought2);
                Debug.Content = bought ? "Product bought" : "Couldn't buy product";

                if (bought)
                {
                    RefreshScreen();
                }
            }
        }

        private void RefreshBtnClick(object sender, RoutedEventArgs e)
        {
            RefreshScreen();
        }

        private void RefreshScreen()
        {
            Product[] products = productService.GetAllProducts();
            if (products.Length <= 0)
                return;

            var gridView = new GridView();
            ProductList.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Name",
                DisplayMemberBinding = new Binding("Name")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Price",
                DisplayMemberBinding = new Binding("Price")
            });

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Stock",
                DisplayMemberBinding = new Binding("Stock")
            });

            ProductList.Items.Clear();
            productItems.Clear();

            foreach (Product product in products)
            {
                ProductItem item = new ProductItem { Name = product.Name, Price = product.Price, Stock = product.AmountInStock };
                productItems.Add(item);
                ProductList.Items.Add(item);
            }

            // TODO: update user inv
            User user = GetUser();


            Money.Content = user == null ? "0.00" : user.Money.ToString();
        }

        private User GetUser()
        {
            return loginService.GetUser(username);
        }

    }

    public class ProductItem
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int Stock{ get; set; }
    }
}
