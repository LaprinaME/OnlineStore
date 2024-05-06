using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Microsoft.EntityFrameworkCore;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Input;
using OnlineStore.ViewModels;

namespace OnlineStore
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Получение данных из текстовых полей
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            // Получение экземпляра ViewModel
            var viewModel = (MainWindowViewModel)this.DataContext;

            // Поиск пользователя в базе данных по логину и паролю
            var user = viewModel.CheckUser(login, password);

            if (user != null)
            {
                // Успешная аутентификация
                MessageBox.Show($"Добро пожаловать, {user.Логин}!");
                // Здесь можно добавить логику перехода на другую страницу в зависимости от роли пользователя
            }
            else
            {
                // Неверный логин или пароль
                MessageBox.Show("Неверный логин или пароль. Пожалуйста, попробуйте снова.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}