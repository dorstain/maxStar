using System;
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
using System.Windows.Shapes;
using LogicLayer;
using BackEndLayer;


namespace CoolGUI
{
    /// <summary>
    /// Interaction logic for DoctorScreen.xaml
    /// </summary>
    public partial class DoctorScreen : Window
    {
        public Manager m;

        public DoctorScreen(Manager m)
        {
            this.m = m;
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            rectangle2.Visibility = System.Windows.Visibility.Hidden;
            List<Patient> p = new List<Patient>();
            MessageBoxResult err = MessageBox.Show("id of user" +  this.textBox1.Text);
            p = m.SearchPatientByID(this.textBox1.Text);

            //this.

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
