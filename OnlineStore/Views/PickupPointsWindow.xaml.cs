using OnlineStore.ViewModels;
using System.Windows;

namespace OnlineStore.Views
{
    public partial class PickupPointsWindow : Window
    {
        public PickupPointsWindow()
        {
            InitializeComponent();
            DataContext = new PickupPointsWindowViewModel();
        }
    }
}