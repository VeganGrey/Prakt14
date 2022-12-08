using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prakt13
{
    /// <summary>
    /// Логика взаимодействия для PassWindow.xaml
    /// </summary>
    public partial class PassWindow : Window
    {
        public PassWindow()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Pass.Focus();
        }

        private void LetsGoooo(object sender, RoutedEventArgs e)
        {
            if (Pass.Password == "123") this.Close();
            else
            {
                MessageBoxResult result;
                result = MessageBox.Show("Пароль неверный", "Пароль",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Owner.Close();
        }

        private void Закрытие(object sender, System.ComponentModel.CancelEventArgs e)
        {
            pass.Data = Pass.Password;
        }
    }
}
