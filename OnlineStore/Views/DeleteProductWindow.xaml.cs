using OnlineStore.ViewModels;
using System.Windows;

namespace OnlineStore.Views
{
    public partial class DeleteProductWindow : Window
    {
        public DeleteProductWindow()
        {
            InitializeComponent();
            DataContext = new DeleteProductWindowViewModel();
        }
    }
}
