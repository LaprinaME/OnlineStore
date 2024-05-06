using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using OnlineStore.Commands;
using OnlineStore.DataContext;
using OnlineStore.Models;

namespace OnlineStore.ViewModels
{
    public class MainWindowViewModel : Notify
    {
        private readonly OnlineStoreContext _dbContext;

        public ObservableCollection<Пользователи> Пользователи { get; set; }
        public ObservableCollection<Роли> Роли { get; set; }

        public MainWindowViewModel()
        {
            _dbContext = new OnlineStoreContext();
            _dbContext.Database.EnsureCreated();

            LoadData();
        }

        private void LoadData()
        {
            Пользователи = new ObservableCollection<Пользователи>(_dbContext.Пользователи);
            Роли = new ObservableCollection<Роли>(_dbContext.Роли);
        }

        public Пользователи CheckUser(string login, string password)
        {
            return _dbContext.Пользователи.FirstOrDefault(u => u.Логин == login && u.Пароль == password);
        }

        // Добавьте здесь другие методы и свойства по необходимости

        #region Команды

        private RelayCommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand(
                    obj =>
                    {
                        // В этом месте можно добавить логику для выполнения действий при нажатии кнопки "Войти"
                        // Например, переход на другую страницу в зависимости от роли пользователя
                    },
                    obj => true // Команда всегда доступна
                ));
            }
        }

        #endregion
    }
}
