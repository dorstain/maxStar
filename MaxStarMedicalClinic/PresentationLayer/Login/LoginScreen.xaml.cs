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
using LogicLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        private IManager m;

        public LoginScreen(IManager m)
        {
            this.m = m;
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
                switch (m.getUserRank(input_id.Text))
                {
                    case 0: //admin
                        AdminScreen asc = new AdminScreen(m, input_id.Text);
                        asc.Show();
                        this.Hide();
                        break;

                    case 1: //doctor
                        if (input_id.Text.Equals(input_pass.Text))
                        {
                            Login.ChangePass cp = new Login.ChangePass(m, input_id.Text);
                            this.Hide();
                            cp.Show();
                        }
                        else
                        {
                            DoctorScreen ds = new DoctorScreen(m, input_id.Text);
                            BackEndLayer.Doctor[] tDoc = (m.SearchDoctorByID(input_id.Text)).ToArray();
                            if (tDoc.Length > 0)
                                ds.data_doctor.Content = "Dr. " + tDoc[0].getName();
                            ds.Show();
                            this.Hide();
                        }
                        break;
                    case 2: //patient
                        if (input_id.Text.Equals(input_pass.Text))
                        {
                            Login.ChangePass cp = new Login.ChangePass(m, input_id.Text);
                            this.Hide();
                            cp.Show();
                        }
                        else
                        {
                            PatientScreen ps = new PatientScreen(m, input_id.Text);
                            ps.Show();
                            this.Hide();
                        }
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
