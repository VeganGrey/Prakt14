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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Windows.Diagnostics;
using LibMas;
using System.IO;

namespace Prakt13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private DispatcherTimer timer;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PassWindow password = new PassWindow();
            password.Owner = this;
            password.ShowDialog();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(this.Timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.IsEnabled = true;
            if (File.Exists(".\\config.ini"))
            {
                Masssiv.ConfigDoubleOpenMassiv(ref matrica);
                nachl.ItemsSource = VisualArray.ToDataTable(matrica).DefaultView;
            }
            else
            {
                matrica = new double[0, 0];

            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if(pass.Data != "123" || pass.Data == null)
            {
                PassWindow pass = new PassWindow();
                pass.Owner = this;
                pass.ShowDialog();
            }   
            DateTime now = DateTime.Now;
            time.Text = now.ToString("HH:mm:ss");
            data.Text = now.ToString("dd.MM.yyyy");
            matrrazm.Text = $"{matrica.GetLength(0)}x{matrica.GetLength(1)}";
            if (nachl != null) indx.Text = $"{nachl.SelectedIndex + 1}";
            else indx.Text = "0";
        }

        double[,] matrica;
        double[,] rematr;

        private void Spavka(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Калитин С.А. ИСП-31 Вариант 13\nДана вещественная матрица А(M, N). " +
                "Строку, содержащий максимальный элемент, поменять местами со строкой, содержащей минимальный элемент.");
        }

        private void Support(object sender, RoutedEventArgs e)
        {
            string target = "https://t.me/Username1_1";
            System.Diagnostics.Process.Start(target);
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Clear_Click(object sender,RoutedEventArgs e)
        {           
            matrica = new double[0,0];rematr = null;
            rezu.ItemsSource = null; nachl.ItemsSource = null;
            Row.Clear(); Column.Clear(); Maxrand.Clear();
        }

        private void Massiv(object sender, RoutedEventArgs e)
        {
            if(Row.Text == "" || Column.Text == "" || Maxrand.Text == "")
            {
                MessageBox.Show("Введите правильные данные");
            }
            else
            {
                Int32.TryParse(Row.Text, out int row); Int32.TryParse(Column.Text, out int column); Int32.TryParse(Maxrand.Text, out int maxrand);
                matrica = new double[row, column];
                LibMas.Masssiv.DvDoubleZapol(maxrand, ref matrica);
                nachl.ItemsSource = VisualArray.ToDataTable(matrica).DefaultView;
                LibMas.Masssiv.clearmatrica(ref rematr);
                rezu.ItemsSource = null;
                Row.Clear();Column.Clear();Maxrand.Clear();
            }
        }
        private void CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int indexColumn = nachl.CurrentCell.Column.DisplayIndex;
            int indexRow = nachl.SelectedIndex;
            Double.TryParse(((TextBox)e.EditingElement).Text, out double value);
            matrica[indexRow, indexColumn] = value;
        }

        private void Rechange(object sender,RoutedEventArgs e)
        {
            rematr = Swap.MatrixSwap(matrica);
            rezu.ItemsSource = VisualArray.ToDataTable(rematr).DefaultView;
        }



        private void SaveMas(object sender, RoutedEventArgs e)
        {
            LibMas.Masssiv.DVDoubleSaveMassiv(matrica);
        }

        private void OpenMas(object sender, RoutedEventArgs e)
        {
            LibMas.Masssiv.DVDoubleOpenMassiv(ref matrica);
            nachl.ItemsSource = VisualArray.ToDataTable(matrica).DefaultView;
        }

        private void OpenSettings(object sender, RoutedEventArgs e)
        {
            Settings set = new Settings();
            set.Owner = this;
            set.ShowDialog();
            Masssiv.ConfigDoubleOpenMassiv(ref matrica);
            nachl.ItemsSource = VisualArray.ToDataTable(matrica).DefaultView;
        }
    }

    public static class pass
    {
        public static string Data;
    }
}
