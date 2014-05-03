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
    /// Interaction logic for PatientScreen.xaml
    /// </summary>
    public partial class PatientScreen : Window
    {

        public Manager m;


        public PatientScreen(Manager m)
        {
            this.m = m;
            InitializeComponent();
        }



        private void label5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_Menu.Content = "Make appoitment";
            this.pswd.Visibility = System.Windows.Visibility.Hidden;
            this.apt.Visibility = System.Windows.Visibility.Visible;
            this.Lp.Visibility = System.Windows.Visibility.Hidden;
        }

        private void label4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_Menu.Content = "Change Password";
            this.pswd.Visibility = System.Windows.Visibility.Visible;
            this.apt.Visibility = System.Windows.Visibility.Hidden;
            this.Lp.Visibility = System.Windows.Visibility.Hidden;
        }

        private void label33_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_Menu.Content = "Print Last Prescription";
            this.pswd.Visibility = System.Windows.Visibility.Hidden;
            this.apt.Visibility = System.Windows.Visibility.Hidden;
            this.Lp.Visibility = System.Windows.Visibility.Visible;
        }


        private void image1_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBoxResult err = MessageBox.Show("print hook");
        }





    
    


    }
}
