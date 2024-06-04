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
    /// Логика взаимодействия для FieldPage.xaml
    /// </summary>
    public partial class FieldPage : Page
    {
        public FieldPage()
        {
            InitializeComponent();
        }

         minerals2Entities1 material = new minerals2Entities1();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query =
            from product in material.Field
            select new { product.Id, Способ_разработки = product.DevelopmentMethod, Открытие = product.Opening, Закрытие = product.Closing, Запасы = product.Reserves, Себестоимость = product.CostPrice };

            dataGrid1.ItemsSource = query.ToList();
        }

        private void NextPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DepositPage());
        }

        private void NoNextPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PointPage());
        }
    }
}
