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
    /// Interaction logic for AdminScreen.xaml
    /// </summary>
    public partial class AdminScreen : Window
    {

        public Manager m;


        public AdminScreen(Manager m)
        {
            this.m = m;
            InitializeComponent();
        }

        //edit doctor
        private void label4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_Menu.Content = "Edit Doctor";
            this.editDoctor.Visibility = System.Windows.Visibility.Visible;
            this.editPatient.Visibility = System.Windows.Visibility.Hidden;
            this.ListPatients.Visibility = System.Windows.Visibility.Hidden;
            this.FireDoctor.Visibility = System.Windows.Visibility.Hidden;
        }
        //edit patient
        private void label5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_Menu.Content = "Edit Patient";
            this.editDoctor.Visibility = System.Windows.Visibility.Hidden;
            this.editPatient.Visibility = System.Windows.Visibility.Visible;
            this.ListPatients.Visibility = System.Windows.Visibility.Hidden;
            this.FireDoctor.Visibility = System.Windows.Visibility.Hidden;
        }
        //list patients
        private void label8_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_Menu.Content = "List Patients";
            this.editDoctor.Visibility = System.Windows.Visibility.Hidden;
            this.editPatient.Visibility = System.Windows.Visibility.Hidden;
            this.ListPatients.Visibility = System.Windows.Visibility.Visible;
            this.FireDoctor.Visibility = System.Windows.Visibility.Hidden;
        }
        //fire a doctor
        private void label9_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_Menu.Content = "Fire A Doctor";
            this.editDoctor.Visibility = System.Windows.Visibility.Hidden;
            this.editPatient.Visibility = System.Windows.Visibility.Hidden;
            this.ListPatients.Visibility = System.Windows.Visibility.Hidden;
            this.FireDoctor.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
