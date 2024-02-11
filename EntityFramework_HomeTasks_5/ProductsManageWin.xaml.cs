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

namespace EntityFramework_HomeTasks_5
{
    /// <summary>
    /// Interaction logic for ProductsManageWin.xaml
    /// </summary>
    public partial class ProductsManageWin : Window
    {
        private readonly MainWindow mainWindow;
        public ProductsManageWin(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.Closed += SecondWindow_Closed; 
        }

        private void SecondWindow_Closed(object sender, EventArgs e)
        {
            mainWindow.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Closed -= SecondWindow_Closed;
            AddProductMenu addProductMenu = new AddProductMenu(mainWindow);
            addProductMenu.Show();
            Close();
        }

        private void BackProductMenu_Click(object sender, RoutedEventArgs e)
        {
            Closed -= SecondWindow_Closed;
            Close();
            mainWindow.Show();
        }

        private void UpdateProductMenu_Click(object sender, RoutedEventArgs e)
        {
            Closed -= SecondWindow_Closed;
            UpdateProductMenu updateProductMenu = new UpdateProductMenu(mainWindow);
            updateProductMenu.Show();
            Close();
        }

        private void DeleteProductMenu_Click(object sender, RoutedEventArgs e)
        {
            Closed -= SecondWindow_Closed;
            DeleteProductMenu deleteProductMenu = new DeleteProductMenu(mainWindow);
            deleteProductMenu.Show();
            Close();
        }
    }
}
