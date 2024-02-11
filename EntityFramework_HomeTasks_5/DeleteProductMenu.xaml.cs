using EntityFramework_HomeTasks_5.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for DeleteProductMenu.xaml
    /// </summary>
    public partial class DeleteProductMenu : Window
    {
        private readonly MainWindow mainWindow;

        public DeleteProductMenu(MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new HomeTaskThirdContext())
            {
                try
                {
                    var idProduct = context.Products.FirstOrDefault(p => p.Id == Guid.Parse(IdProductComboBox.SelectedValue.ToString()!));
                    context.Products.Remove(idProduct);
                    context.SaveChanges();
                    MessageBox.Show("Product was delete!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ProductsManageWin productsManageWin = new ProductsManageWin(mainWindow);
            productsManageWin.Show();
            Close();
        }

        private async void Window_Initialized(object sender, EventArgs e)
        {
            using (var context = new HomeTaskThirdContext())
            {
                IdProductComboBox.ItemsSource = await context.Products.ToListAsync();
                IdProductComboBox.DisplayMemberPath = "Id";
                IdProductComboBox.SelectedValuePath = "Id";       
            }
        }
    }
}
