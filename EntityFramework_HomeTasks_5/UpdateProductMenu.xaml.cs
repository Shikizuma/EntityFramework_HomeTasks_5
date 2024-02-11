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
    /// Interaction logic for UpdateProductMenu.xaml
    /// </summary>
    public partial class UpdateProductMenu : Window
    {
        private readonly MainWindow mainWindow;
        public UpdateProductMenu(MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new HomeTaskThirdContext())
            {
                IdProductComboBox.ItemsSource = await context.Products.ToListAsync();
                IdProductComboBox.DisplayMemberPath = "Id";
                IdProductComboBox.SelectedValuePath = "Id";

                CategoryComboBox.ItemsSource = await context.Categories.ToListAsync();
                CategoryComboBox.DisplayMemberPath = "Name";
                CategoryComboBox.SelectedValuePath = "Id";
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new HomeTaskThirdContext())
            {
                try
                {
                    var product = new Product
                    {
                        Id = Guid.Parse(IdProductComboBox.SelectedValue.ToString()!),
                        Name = NameProductTextBox.Text,
                        Price = double.Parse(PriceProductTextBox.Text),
                        ActionPrice = double.Parse(ActionPriceProductTextBox.Text),
                        Description = DescriptionProductTextBox.Text,
                        ImageUrl = ImageProductTextBox.Text,
                        CategoryId = Guid.Parse(CategoryComboBox.SelectedValue.ToString()!)
                    };
                    context.Products.Update(product);
                    context.SaveChanges();
                    MessageBox.Show("Product was update!");
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

        private void ChooseButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            openFileDialog.Filter = "Images (*.BMP;*.JPG)|*.BMP;*.JPG|All files (*.*)|*.*";

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                ImageProductTextBox.Text = openFileDialog.FileName;
            }
        }
    }
}
