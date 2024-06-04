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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minerals
{
    /// <summary>
    /// Логика взаимодействия для DepositPage.xaml
    /// </summary>
    public partial class DepositPage : Page
    {
        public DepositPage()
        {
            InitializeComponent();
        }

        minerals2Entities1 minerals = new minerals2Entities1();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query =
            from product in minerals.Deposit
            select new { id = product.DepositCode + 99, Наименование = product.Name, Единица_измерения = product.UnitOfMeasurement, Рыночная_цена = product.MarketPrice };

            dataGrid1.ItemsSource = query.ToList();
        }
        private void NextPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PointPage());
        }

        private void NoNextPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FieldPage());
        }
    }
}
