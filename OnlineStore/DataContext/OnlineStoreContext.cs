using System;
using OnlineStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataContext
{
    // Класс OnlineStoreContext, который наследует DbContext для работы с базой данных
    public class OnlineStoreContext : DbContext
    {
        // DbSet для каждой таблицы в базе данных

        // Детали заказа
        public DbSet<Детали_заказа> Детали_заказа { get; set; }

        // Заказы
        public DbSet<Заказы> Заказы { get; set; }

        // Клиенты
        public DbSet<Клиенты> Обслуживание { get; set; }

        // Пользователи
        public DbSet<Пользователи> Пользователи { get; set; }

        // Поставщики
        public DbSet<Поставщики> Продавцы { get; set; }

        // Пункты выдачи
        public DbSet<Пункты_выдачи> Пункты_выдачи { get; set; }

        // Роли
        public DbSet<Роли> Роли { get; set; }

        // Склад продавца
        public DbSet<Склад_продавца> Склад_продавца { get; set; }

        // Сотрудники
        public DbSet<Сотрудники> Сотрудники { get; set; }

        // Товары
        public DbSet<Товары> Товары { get; set; }

        // Переопределение метода OnConfiguring для указания строки подключения к базе данных
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Использование SQL Server в качестве провайдера базы данных и указание строки подключения
            optionsBuilder.UseSqlServer("Server=(localdb)\\Local;Database=Онлайн_магазин;Integrated Security=True;");
        }
    }
}
