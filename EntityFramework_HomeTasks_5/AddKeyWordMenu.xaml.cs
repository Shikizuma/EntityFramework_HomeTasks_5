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
    /// Interaction logic for AddKeyWordMenu.xaml
    /// </summary>
    public partial class AddKeyWordMenu : Window
    {
        private readonly MainWindow mainWindow;
        public AddKeyWordMenu(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new HomeTaskThirdContext())
            {
                try
                {
                    var word = new Word
                    {
                        Id = Guid.NewGuid(),
                        Header = HeaderTextBox.Text,
                        KeyWord = NameTextBox.Text,
                    };
                    context.Words.Add(word);
                    context.SaveChanges();
                    MessageBox.Show("Word is added!");
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
