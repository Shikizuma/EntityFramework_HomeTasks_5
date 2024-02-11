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

namespace EntityFramework_HomeTasks_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProductsMenuButton_Click(object sender, RoutedEventArgs e)
        {
            ProductsManageWin productsManageWin = new ProductsManageWin(this);
            productsManageWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            productsManageWin.Show();
            Hide();
        
        }

        private void CategoriesMenuButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryMenu categoryMenu = new CategoryMenu(this);
            categoryMenu.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            categoryMenu.Show();
            Hide();
        }

        private void KeyWordsMenuButton_Click(object sender, RoutedEventArgs e)
        {
            KeyWordsMenu keyWordMenu = new KeyWordsMenu(this);
            keyWordMenu.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            keyWordMenu.Show();
            Hide();
        }

        private void BackMenuButton_Click(object sender, RoutedEventArgs e)
        {
            BackUpMenu keyWordMenu = new BackUpMenu(this);
            keyWordMenu.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            keyWordMenu.Show();
            Hide();
        }
    }
}
