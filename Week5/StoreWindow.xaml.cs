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
using Week5.UsService;

namespace Week5
{
    /// <summary>
    /// Interaction logic for StoreWindow.xaml
    /// </summary>
    public partial class StoreWindow : Window
    {
        private ProductService productService = new ProductService();
        private UserService userService = new UserService();

        private readonly String username;
        private List<StockItem> productItems = new List<StockItem>();

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

            StockItem item = productItems.ElementAt(index);
            if (item != null)
            {
                productService.BuyProduct(item.Name, username, out bool bought, out bool bought2);
                Debug.Content = bought ? "Product bought" : "Couldn't buy product";

                if (bought)
                {
                    userService.AddProduct(username, item.Name);
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
                StockItem item = new StockItem { Name = product.Name, Price = product.Price, Stock = product.AmountInStock };
                productItems.Add(item);
                ProductList.Items.Add(item);
            }

            userService.GetMoney(username, out double money, out bool success);
            Money.Content = money;
            RefreshInv();
        }

        private void RefreshInv()
        {
            ProductItem[] items = userService.GetProductItems(username);
            InventoryList.Items.Clear();
            if (items.Length <= 0)
                return;

            var gridView = new GridView();
            InventoryList.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Product",
                DisplayMemberBinding = new Binding("ProductName")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Amount",
                DisplayMemberBinding = new Binding("Amount")
            });

            foreach (ProductItem invItem in items)
            {
                InventoryList.Items.Add(invItem);
            }
        }

    }

    class StockItem
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int Stock{ get; set; }
    }
}
