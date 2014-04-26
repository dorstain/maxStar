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

namespace CoolGUI.Doctor
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
        }

        private void Input_PatientID_TextChanged(object sender, TextChangedEventArgs e)
        {
            this = 
        }

        private void Search_PatientID(object sender, RoutedEventArgs e)
        {
            List <Patient> result = m.SearchPatientByID(Input_PatientID.Text);
            if ((result.ToArray()).Length > 0)
            {
                Patient_Name.Text = result.First().firstName;
                Last_Name.Text = result.First().lastName;
                Age.Text = result.First().age.ToString();
                Gender.Text = result.First().gender.ToString();
            }

        }
    }
}
