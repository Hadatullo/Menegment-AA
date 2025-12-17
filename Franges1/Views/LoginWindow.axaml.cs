using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Franges1.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnTestClick(object? sender, RoutedEventArgs e)
        {
            // Эта кнопка должна всегда работать
            if (this.FindControl<TextBlock>("MessageText") is TextBlock messageText)
            {
                messageText.Text = "Тестовая кнопка работает!";
                messageText.Foreground = Avalonia.Media.Brushes.Green;
            }
        }

        private void OnLoginClick(object? sender, RoutedEventArgs e)
        {
            // Эта функция вызывается при нажатии на кнопку "Войти"
            if (this.FindControl<TextBlock>("MessageText") is TextBlock messageText)
            {
                messageText.Text = "Обработчик кнопки 'Войти' вызван!";
                messageText.Foreground = Avalonia.Media.Brushes.Blue;
            }

            // Даем визуальную обратную связь
            if (sender is Button button)
            {
                button.Content = "Обрабатываю...";
            }

            // Используем правильные логин/пароль из твоего скриншота
            string username = "admin";
            string password = "123";

            if (this.FindControl<TextBox>("UsernameBox") is TextBox usernameBox)
            {
                username = usernameBox.Text ?? "admin";
            }

            if (this.FindControl<TextBox>("PasswordBox") is TextBox passwordBox)
            {
                password = passwordBox.Text ?? "123";
            }

            // Задержка для демонстрации
            System.Threading.Tasks.Task.Delay(500).ContinueWith(t => 
            {
                Avalonia.Threading.Dispatcher.UIThread.Post(() =>
                {
                    ProcessLogin(username, password);
                    
                    // Восстанавливаем кнопку
                    if (sender is Button btn)
                    {
                        btn.Content = "Войти";
                    }
                });
            });
        }

        private void ProcessLogin(string username, string password)
        {
            if (this.FindControl<TextBlock>("MessageText") is not TextBlock messageText)
                return;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                messageText.Text = "Введите имя пользователя и пароль";
                messageText.Foreground = Avalonia.Media.Brushes.Red;
                return;
            }

            // Проверяем логин и пароль - admin/123
            if (username.Trim() == "admin" && password.Trim() == "123")
            {
                messageText.Text = "Успешный вход! Открываю главное окно...";
                messageText.Foreground = Avalonia.Media.Brushes.Green;

                // Задержка перед открытием главного окна
                System.Threading.Tasks.Task.Delay(1000).ContinueWith(t => 
                {
                    Avalonia.Threading.Dispatcher.UIThread.Post(() =>
                    {
                        var mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    });
                });
            }
            else
            {
                messageText.Text = $"Неверные данные: {username}/{password}";
                messageText.Foreground = Avalonia.Media.Brushes.Red;
            }
        }
    }
}