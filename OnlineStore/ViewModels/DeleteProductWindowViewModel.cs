using System;
using System.Windows.Input;
using OnlineStore.Commands;
using OnlineStore.Models;

namespace OnlineStore.ViewModels
{
    public class DeleteProductWindowViewModel : ViewModelBase
    {
        private Товары _selectedProduct;
        public Товары SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
                OnPropertyChanged(nameof(DeleteProductCommand));
            }
        }

        private RelayCommand _deleteProductCommand;
        public ICommand DeleteProductCommand
        {
            get
            {
                return _deleteProductCommand ?? (_deleteProductCommand = new RelayCommand(
                    obj =>
                    {
                        // Логика удаления товара
                        if (SelectedProduct != null)
                        {
                            // Ваш код удаления товара
                        }
                    },
                    obj => CanDeleteProduct() // Проверка, доступна ли команда
                ));
            }
        }

        private bool CanDeleteProduct()
        {
            // Логика проверки доступности команды удаления товара
            return SelectedProduct != null;
        }
    }
}
