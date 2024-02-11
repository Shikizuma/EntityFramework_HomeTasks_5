using EntityFramework_HomeTasks_5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for BackUpMenu.xaml
    /// </summary>
    public partial class BackUpMenu : Window
    {
        readonly string backupDirectory = @"C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup";
        private readonly MainWindow mainWindow;
        public BackUpMenu(MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            Closed += SecondWindow_Closed;

            Directory.CreateDirectory(backupDirectory);
            string[] backupFiles = Directory.GetFiles(backupDirectory, "*.bak");
            BackupComboBox.ItemsSource = backupFiles;
         
           
        }

        private void SecondWindow_Closed(object sender, EventArgs e)
        {
            mainWindow.Close();
        }

        private void CreateBackupButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new HomeTaskThirdContext())
            {

                try
                {
                    var backupPath = System.IO.Path.Combine(backupDirectory, $"myDatabase_{Guid.NewGuid()}.bak");
                    context.Database.ExecuteSqlRaw($"BACKUP DATABASE HomeTaskThird TO DISK = '{backupPath}' WITH FORMAT, MEDIANAME = 'SQL_Backup', NAME = 'Full Backup of HomeTaskThird';");

                }
                catch { }
            }

            MessageBox.Show("Резервна копія успішно створена!");
        }

        private void RestoreButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new HomeTaskThirdContext())
            {
                context.Database.ExecuteSqlRaw($"USE master; RESTORE DATABASE [YourDatabaseName] FROM DISK = '{BackupComboBox.SelectedValue}' WITH REPLACE;");
            }

            MessageBox.Show("База даних успішно відновлена!");
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Closed -= SecondWindow_Closed;
            Close();
            mainWindow.Show();
        }
    }
}
