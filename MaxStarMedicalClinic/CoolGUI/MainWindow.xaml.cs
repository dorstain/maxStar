﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataAccessLayer;
using LogicLayer;

namespace CoolGUI
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Linq_DAL linq;
        public Manager m;
        public MainWindow()
        {
            linq = new Linq_DAL();
            m = new Manager(linq);
            InitializeComponent();  
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            if (m.validate(input_id.Text, input_pass.Text))
            {
                DoctorScreen ds = new DoctorScreen(m);
                ds.Show();
                ds.textBox1.Text = "sasa";
                this.Hide();
            }
            else
            {
                MessageBoxResult err = MessageBox.Show("Wrong username or password");
            }
        }

        private void image1_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}
