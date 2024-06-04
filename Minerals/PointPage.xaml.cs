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

namespace Minerals
{
    /// <summary>
    /// Логика взаимодействия для PointPage.xaml
    /// </summary>
    public partial class PointPage : Page
    {
        public PointPage()
        {
            InitializeComponent();
        }

        minerals2Entities1 material = new minerals2Entities1();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query =
            from product in material.Point
            select new { id = product.PointCode + 9, Наименование = product.Name, Пропускная_способность = product.Capacity };

            dataGrid1.ItemsSource = query.ToList();
        }
        private void NextPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FieldPage());
        }

        private void NoNextPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DepositPage());
        }

        private void Btn_Del_CLick(object sender, RoutedEventArgs e)
        {
            var Pointik = (Point)dataGrid1.SelectedItem;
            
            if (MessageBox.Show($"Вы точно хотите удалить следующий пункт {Pointik.Name}?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    material.Point.Remove(Pointik);
                    material.SaveChanges();
                    MessageBox.Show("Данные удалены");
                    dataGrid1.ItemsSource = material.Point.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    throw;
                }
            }

        }
    }
}
