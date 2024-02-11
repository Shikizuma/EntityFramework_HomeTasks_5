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
    /// Interaction logic for DeleteCategoryMenu.xaml
    /// </summary>
    public partial class DeleteCategoryMenu : Window
    {
        private readonly MainWindow mainWindow;
        public DeleteCategoryMenu(MainWindow mainWindow)
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
                    var idCategory = context.Categories.FirstOrDefault(p => p.Id == Guid.Parse(IdCategoryComboBox.SelectedValue.ToString()!));
                    context.Categories.Remove(idCategory);
                    context.SaveChanges();
                    MessageBox.Show("Category was delete!");
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

        private async void Window_Initialized(object sender, EventArgs e)
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
