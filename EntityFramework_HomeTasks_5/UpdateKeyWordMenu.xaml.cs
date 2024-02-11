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
    /// Interaction logic for UpdateKeyWordMenu.xaml
    /// </summary>
    public partial class UpdateKeyWordMenu : Window
    {
        private readonly MainWindow mainWindow;
        public UpdateKeyWordMenu(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new HomeTaskThirdContext())
            {
                try
                {
                    var word = new Word
                    {
                        Id = Guid.Parse(IdKeyWordComboBox.SelectedValue.ToString()!),
                        Header = HeaderTextBox.Text,
                        KeyWord = NameTextBox.Text,
                    };
                    context.Words.Update(word);
                    context.SaveChanges();
                    MessageBox.Show("Word was update!");
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

        private async void Window_Initialized(object sender, EventArgs e)
        {
            using (var context = new HomeTaskThirdContext())
            {
                IdKeyWordComboBox.ItemsSource = await context.Categories.ToListAsync();
                IdKeyWordComboBox.DisplayMemberPath = "Id";
                IdKeyWordComboBox.SelectedValuePath = "Id";
            }
        }
    }
}
