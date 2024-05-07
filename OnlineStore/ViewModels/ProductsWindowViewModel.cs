using Microsoft.EntityFrameworkCore;
using OnlineStore.Commands;
using OnlineStore.DataContext;
using OnlineStore.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows;

namespace OnlineStore.ViewModels
{
    public class ProductsWindowViewModel : ViewModelBase
    {
        private readonly OnlineStoreContext _context;

        public ObservableCollection<Товары> Товары { get; set; }

        public ICommand ReturnToMainCommand { get; }

        public ProductsWindowViewModel()
        {
            _context = new OnlineStoreContext();
            Товары = new ObservableCollection<Товары>();

            ReturnToMainCommand = new RelayCommand(ReturnToMain);

            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                // Получаем все товары из базы данных и добавляем их в коллекцию
                Товары = new ObservableCollection<Товары>(_context.Товары.ToList());
            }
            catch (Exception ex)
            {
                // В случае ошибки выводим сообщение в консоль
                Console.WriteLine($"Ошибка при загрузке товаров: {ex.Message}");
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
