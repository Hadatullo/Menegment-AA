using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Franges1.Views
{
    internal partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            // Инициализация данных
            InitializeData();


            void InitializeComponent()
            {
                AvaloniaXamlLoader.Load(this);
            }

            void InitializeData()
            {
                // Инициализация карточек статистики
                var statsCards = this.FindControl<ItemsControl>("StatsCards");
                if (statsCards != null)
                {
                    var list = new List<StatCard>
                    {
                        new StatCard { Title = "Всего автоматов", Value = "24", Description = "+2 за месяц" },
                        new StatCard { Title = "Активных автоматов", Value = "22", Description = "91.7% работают" },
                        new StatCard { Title = "Общая выручка", Value = "₽284,500", Description = "+12% за месяц" },
                        new StatCard { Title = "Средний чек", Value = "₽450", Description = "Стабильно" },
                        new StatCard { Title = "Оборот за месяц", Value = "₽156,800", Description = "+8.5%" },
                        new StatCard { Title = "Новых клиентов", Value = "348", Description = "+15% к прошлому месяцу" }
                    };
                }

                // Инициализация последних действий
                var recentActivities = this.FindControl<ItemsControl>("RecentActivities");
                if (recentActivities != null)
                {
                    new List<Activity>
                    {
                        new Activity
                        {
                            Action = "Добавлен новый автомат", Details = "Торговый центр 'Мега', №A-24",
                            Time = "2 часа назад"
                        },
                        new Activity
                        {
                            Action = "Обновление прошивки", Details = "Автомат №A-15 успешно обновлен",
                            Time = "5 часов назад"
                        },
                        new Activity
                        {
                            Action = "Пополнение баланса", Details = "Автомат №B-07: ₽12,500", Time = "Вчера, 14:30"
                        },
                        new Activity
                        {
                            Action = "Техническое обслуживание", Details = "Автомат №C-12 завершил ТО",
                            Time = "Вчера, 11:15"
                        },
                        new Activity
                        {
                            Action = "Новый рекорд продаж", Details = "Автомат №A-08: ₽8,400 за день",
                            Time = "2 дня назад"
                        }
                    };
                }
            }

            async void OnUserProfileButtonClick(object sender, RoutedEventArgs e)
            {
                var button = sender as Button;
                if (button != null)
                {
                    var contextMenu = new ContextMenu
                    {

                    };

                    // Обработчики для пунктов меню
                    if (contextMenu.Items[0] is MenuItem profileItem)
                        profileItem.Click += OnProfileClick;

                    if (contextMenu.Items[1] is MenuItem sessionsItem)
                        sessionsItem.Click += OnSessionsClick;

                    if (contextMenu.Items[3] is MenuItem logoutItem)
                        logoutItem.Click += OnLogoutClick;

                    contextMenu.Open(button);
                }
            }

            void OnProfileClick(object? sender, RoutedEventArgs e)
            {
                // TODO: Реализовать переход в профиль
                var dialog = new Window
                {
                    Title = "Мой профиль",
                    Width = 400,
                    Height = 500,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };
                dialog.ShowDialog(this);
            }

            void OnSessionsClick(object? sender, RoutedEventArgs e)
            {
                // TODO: Реализовать просмотр сессий
                var dialog = new Window
                {
                    Title = "Мои сессии",
                    Width = 600,
                    Height = 400,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };
                dialog.ShowDialog(this);
            }

            void OnLogoutClick(object? sender, RoutedEventArgs e)
            {
                // TODO: Реализовать выход из системы
                // Пока просто закрываем окно
                Close();
            }
        }

        // Модели данных для привязки
        public class StatCard
        {
            public required string Title { get; set; }
            public string? Value { get; set; }
            public string? Description { get; set; }
        }

        public class Activity
        {
            public string? Action { get; set; }
            public string? Details { get; set; }
            public required string Time { get; set; }
        }
    }
}