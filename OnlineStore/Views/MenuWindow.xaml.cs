using System.Windows;

namespace OnlineStore.Views
{
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void ProductsWindow_Click(object sender, RoutedEventArgs e)
        {
            ProductsWindow productsWindow = new ProductsWindow();
            productsWindow.Show();
        }

        private void PickupPointsWindow_Click(object sender, RoutedEventArgs e)
        {
            PickupPointsWindow pickupPointsWindow = new PickupPointsWindow();
            pickupPointsWindow.Show();
        }

        private void MainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void DeleteProductWindow_Click(object sender, RoutedEventArgs e)
        {
            DeleteProductWindow deleteProductWindow = new DeleteProductWindow();
            deleteProductWindow.Show();
        }

        private void AddProductWindow_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.Show();
        }
    }
}
