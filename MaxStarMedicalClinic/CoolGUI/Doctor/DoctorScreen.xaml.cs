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
            this.dataBlock.Visibility = System.Windows.Visibility.Visible;
            List<Patient> p = new List<Patient>();
            
           
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

        private void image1_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            //init prescription screen
            Doctor.Prescription w1 = new Doctor.Prescription();

            //this code is for the tabel population 
            //put here date and prescription in plain text.

          /*var query =
            from customer in customers
            orderby customer.CompanyName
            select new
            {
                customer.LastName,
                customer.FirstName,
                customer.CompanyName,
                customer.Title,
                customer.EmailAddress,
                customer.Phone,
                customer.SalesPerson
            };


            w1.dataTable.ItemsSource = query.ToList();
            */
            //populate data grid function here


            //show prescription screen

            w1.Show();


        }
    }
}
