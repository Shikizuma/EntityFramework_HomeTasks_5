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
    /// Interaction logic for UpdateCategoryMenu.xaml
    /// </summary>
    public partial class UpdateCategoryMenu : Window
    {
        private readonly MainWindow mainWindow;
        public UpdateCategoryMenu(MainWindow mainWindow)
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
                IconTextBox.Text = openFileDialog.FileName;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new HomeTaskThirdContext())
            {
                try
                {
                    var category = new Category
                    {
                        Id = Guid.Parse(IdCategoryComboBox.SelectedValue.ToString()!),
                        Name = NameTextBox.Text,
                        Icon = IconTextBox.Text,
                    };
                    context.Categories.Update(category);
                    context.SaveChanges();
                    MessageBox.Show("Category was update!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryMenu productsManageWin = new CategoryMenu(mainWindow);
            productsManageWin.Show();
            Close();
        }

        private async void BackButton_Initialized(object sender, EventArgs e)
        {
            using (var context = new HomeTaskThirdContext())
            {
                IdCategoryComboBox.ItemsSource = await context.Categories.ToListAsync();
                IdCategoryComboBox.DisplayMemberPath = "Id";
                IdCategoryComboBox.SelectedValuePath = "Id";
            }
        }
    }
}
