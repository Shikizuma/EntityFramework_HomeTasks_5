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
    /// Interaction logic for DeleteKeyWordMenu.xaml
    /// </summary>
    public partial class DeleteKeyWordMenu : Window
    {
        private readonly MainWindow mainWindow;
        public DeleteKeyWordMenu(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private async void Window_Initialized(object sender, EventArgs e)
        {
            using (var context = new HomeTaskThirdContext())
            {
                IdKeyWordComboBox.ItemsSource = await context.Words.ToListAsync();
                IdKeyWordComboBox.DisplayMemberPath = "Id";
                IdKeyWordComboBox.SelectedValuePath = "Id";
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new HomeTaskThirdContext())
            {
                try
                {
                    var idWord = context.Words.FirstOrDefault(p => p.Id == Guid.Parse(IdKeyWordComboBox.SelectedValue.ToString()!));
                    context.Words.Remove(idWord);
                    context.SaveChanges();
                    MessageBox.Show("Word was delete!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            KeyWordsMenu productsManageWin = new KeyWordsMenu(mainWindow);
            productsManageWin.Show();
            Close();
        }
    }
}
