﻿using System;
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
    /// Interaction logic for KeyWordsMenu.xaml
    /// </summary>
    public partial class KeyWordsMenu : Window
    {
        private readonly MainWindow mainWindow;
        public KeyWordsMenu(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            Closed += SecondWindow_Closed;
        }

        private void SecondWindow_Closed(object sender, EventArgs e)
        {
            mainWindow.Close();
        }

        private void AddCategoryMenu_Click(object sender, RoutedEventArgs e)
        {
            Closed -= SecondWindow_Closed;
            AddKeyWordMenu addKeyWordMenu = new AddKeyWordMenu(mainWindow);
            addKeyWordMenu.Show();
            Close();
        }

        private void UpdateCategoryMenu_Click(object sender, RoutedEventArgs e)
        {
            Closed -= SecondWindow_Closed;
            UpdateKeyWordMenu updateKeyWordMenu = new UpdateKeyWordMenu(mainWindow);
            updateKeyWordMenu.Show();
            Close();
        }

        private void DeleteCategoryMenu_Click(object sender, RoutedEventArgs e)
        {
            Closed -= SecondWindow_Closed;
            DeleteKeyWordMenu deleteKeyWordMenu = new DeleteKeyWordMenu(mainWindow);
            deleteKeyWordMenu.Show();
            Close();
        }

        private void BackProductMenu_Click(object sender, RoutedEventArgs e)
        {
            Closed -= SecondWindow_Closed;
            Close();
            mainWindow.Show();
        }
    }
}
