using OnlineStore.Commands;
using OnlineStore.DataContext;
using OnlineStore.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace OnlineStore.ViewModels
{
    public class AddProductWindowViewModel : ViewModelBase
    {
        private readonly OnlineStoreContext _context;

        private string _наименование;
        private decimal _цена;
        private float _рейтинг_товара;
        private int _количество;
        private string _категория;
        private string _бренд;
        private string _производитель;

        public string Наименование
        {
            get { return _наименование; }
            set
            {
                _наименование = value;
                OnPropertyChanged(nameof(Наименование));
            }
        }

        public decimal Цена
        {
            get { return _цена; }
            set
            {
                _цена = value;
                OnPropertyChanged(nameof(Цена));
            }
        }

        public float Рейтинг_товара
        {
            get { return _рейтинг_товара; }
            set
            {
                _рейтинг_товара = value;
                OnPropertyChanged(nameof(Рейтинг_товара));
            }
        }

        public int Количество
        {
            get { return _количество; }
            set
            {
                _количество = value;
                OnPropertyChanged(nameof(Количество));
            }
        }

        public string Категория
        {
            get { return _категория; }
            set
            {
                _категория = value;
                OnPropertyChanged(nameof(Категория));
            }
        }

        public string Бренд
        {
            get { return _бренд; }
            set
            {
                _бренд = value;
                OnPropertyChanged(nameof(Бренд));
            }
        }

        public string Производитель
        {
            get { return _производитель; }
            set
            {
                _производитель = value;
                OnPropertyChanged(nameof(Производитель));
            }
        }

        public ICommand AddProductCommand { get; }
        public ICommand CancelCommand { get; }

        public AddProductWindowViewModel()
        {
            _context = new OnlineStoreContext();

            AddProductCommand = new RelayCommand(AddProduct);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void AddProduct(object parameter)
        {
            try
            {
                Товары newProduct = new Товары
                {
                    Наименование = Наименование,
                    Цена = Цена,
                    Рейтинг_товара = Рейтинг_товара,
                    Количество = Количество,
                    Категория = Категория,
                    Бренд = Бренд,
                    Производитель = Производитель
                };

                _context.Товары.Add(newProduct);
                _context.SaveChanges();

                MessageBox.Show("Товар успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении товара: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel(object parameter)
        {
            // Закрыть окно добавления товара
            (parameter as Window)?.Close();
        }
    }
}
