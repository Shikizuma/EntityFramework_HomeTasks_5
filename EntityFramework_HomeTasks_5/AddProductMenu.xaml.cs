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
    /// Interaction logic for AddProductMenu.xaml
    /// </summary>
    public partial class AddProductMenu : Window
    {
        private readonly MainWindow mainWindow;
        public AddProductMenu(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void ChooseButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
     
            openFileDialog.Filter = "Images (*.BMP;*.JPG)|*.BMP;*.JPG|All files (*.*)|*.*";
          
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
               ImageUrlTextBox.Text = openFileDialog.FileName;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new HomeTaskThirdContext())
            {
                try
                {
                    var product = new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = NameTextBox.Text,
                        Price = double.Parse(PriceTextBox.Text),
                        ActionPrice = double.Parse(ActionPriceTextBox.Text),
                        Description = DescriptionTextBox.Text,
                        ImageUrl = ImageUrlTextBox.Text,
                        CategoryId = Guid.Parse(CategoryComboBox.SelectedValue.ToString()!)
                    };
                    context.Products.Add(product);
                    context.SaveChanges();
                    MessageBox.Show("Product is added!");
                }
                catch (Exception ex) 
                { 
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new HomeTaskThirdContext())
            {
                CategoryComboBox.ItemsSource = await context.Categories.ToListAsync();
                CategoryComboBox.DisplayMemberPath = "Name";
                CategoryComboBox.SelectedValuePath = "Id";
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ProductsManageWin productsManageWin = new ProductsManageWin(mainWindow);
            productsManageWin.Show(); 
            Close();
        }
    }
}
