using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using OnlineStore.Commands;
using OnlineStore.DataContext;
using OnlineStore.Models;
using System.Windows;

namespace OnlineStore.ViewModels
{
    public class PickupPointsWindowViewModel : ViewModelBase
    {
        private readonly OnlineStoreContext _context;

        public ObservableCollection<Пункты_выдачи> Пункты_выдачи { get; set; }

        public ICommand ReturnToMainCommand { get; }

        public PickupPointsWindowViewModel()
        {
            _context = new OnlineStoreContext();
            Пункты_выдачи = new ObservableCollection<Пункты_выдачи>();

            ReturnToMainCommand = new RelayCommand(ReturnToMain);

            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                // Получаем все пункты выдачи из базы данных и добавляем их в коллекцию
                var пунктыВыдачи = _context.Пункты_выдачи.ToList();
                Пункты_выдачи = new ObservableCollection<Пункты_выдачи>(пунктыВыдачи);
            }
            catch (Exception ex)
            {
                // В случае ошибки выводим сообщение в консоль
                Console.WriteLine($"Ошибка при загрузке пунктов выдачи: {ex.Message}");
                // Можно добавить дополнительную логику обработки ошибки, например, показ сообщения пользователю
            }
        }

        private void ReturnToMain(object parameter)
        {
            // Переход на главную страницу (MainWindow)
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            // Закрытие текущего окна (ProductsWindow)
            if (parameter is Window window)
            {
                window.Close();
            }
        }

    }
}

