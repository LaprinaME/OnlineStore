using System;
using System.ComponentModel;
using System.Linq; // Добавляем директиву using для пространства имен System.Linq
using System.Windows.Input;
using OnlineStore.Commands;
using OnlineStore.Views;
using OnlineStore.DataContext;

namespace OnlineStore.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _логин;
        private string _пароль;

        public string Логин
        {
            get { return _логин; }
            set
            {
                if (_логин != value)
                {
                    _логин = value;
                    OnPropertyChanged(nameof(Логин));
                }
            }
        }

        public string Пароль
        {
            get { return _пароль; }
            set
            {
                if (_пароль != value)
                {
                    _пароль = value;
                    OnPropertyChanged(nameof(Пароль));
                }
            }
        }

        public ICommand LoginCommand { get; }

        public MainWindowViewModel()
        {
            LoginCommand = new RelayCommand(Login, CanLogin);
        }

        private void Login(object parameter)
        {
            // Проверка, имеет ли пользователь роль администратора (Код_Роли == 3)
            int userRoleCode = GetUserRoleCode(Логин, Пароль);
            if (userRoleCode == 3)
            {
                // Если пользователь администратор, переходим на страницу меню
                MenuWindow menuWindow = new MenuWindow();
                menuWindow.Show();
            }
            else
            {
                // Если у пользователя нет прав администратора, выдаем сообщение
                System.Windows.MessageBox.Show("У вас нет разрешения на доступ к меню.");
            }
        }

        private bool CanLogin(object parameter)
        {
            return !string.IsNullOrEmpty(Логин) && !string.IsNullOrEmpty(Пароль);
        }

        private int GetUserRoleCode(string username, string password)
        {
            using (var dbContext = new OnlineStoreContext())
            {
                var user = dbContext.Пользователи.FirstOrDefault(u => u.Логин == username && u.Пароль == password);
                if (user != null)
                {
                    return user.Код_Роли; // Заменяем Код_роли на Код_Роли
                }
            }

            return -1; // Если пользователь не найден, возвращаем -1 или другое значение, указывающее на ошибку
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
