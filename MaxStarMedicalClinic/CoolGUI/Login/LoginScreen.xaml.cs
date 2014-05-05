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
using BackEndLayer;
using DataAccessLayer;
using LogicLayer;

namespace CoolGUI
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        private Linq_DAL linq;
        public Manager m;
        public LoginScreen()
        {
            linq = new Linq_DAL();
            m = new Manager(linq); 
            InitializeComponent();  
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
               
            if (m.validate(input_id.Text, input_pass.Text))
            {
                switch ((m.getUserRank(input_id.Text)).ElementAt(0).rank)
                {
                    case 0: //admin
                        AdminScreen asc = new AdminScreen(m);
                        asc.Show();
                        this.Hide();
                    break;

                    case 1: //doctor
                         DoctorScreen ds = new DoctorScreen(m, input_id.Text);
                         BackEndLayer.Doctor [] tDoc = (m.SearchDoctorByID(input_id.Text)).ToArray();
                         if (tDoc.Length > 0)
                            ds.data_doctor.Content = "Dr. "+tDoc[0].getName();
                         ds.Show();
                         this.Hide();
                    break;

                    case 2: //patient
                    PatientScreen ps = new PatientScreen(m);
                        ps.Show();
                        this.Hide();
                    break;
                }
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
