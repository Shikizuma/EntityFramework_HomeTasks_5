using EntityFramework_HomeTasks_5.Models;
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
    /// Interaction logic for AddCategoryMenu.xaml
    /// </summary>
    public partial class AddCategoryMenu : Window
    {
        private readonly MainWindow mainWindow;
        public AddCategoryMenu(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryMenu productsManageWin = new CategoryMenu(mainWindow);
            productsManageWin.Show();
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new HomeTaskThirdContext())
            {
                try
                {
                    var category = new Category
                    {
                        Id = Guid.NewGuid(),
                        Name = NameTextBox.Text,
                        Icon = IconTextBox.Text,
                    };
                    context.Categories.Add(category);
                    context.SaveChanges();
                    MessageBox.Show("Category is added!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
    }
}
