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
        protected Linq_DAL linq;
        protected Manager m;

        public MainWindow()
        {
            linq = new Linq_DAL();
            m = new Manager(linq);
            InitializeComponent();  
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            int l = m.validate(input_id.Text, input_pass.Text);
            switch (l)
            {
                case 0:
                    this.Close();
                    break;
                case 1:
                    Doctor.DoctorMain dm = new Doctor.DoctorMain();
                    dm.Show();
                    this.Close();
                    break;
                case 2:
                    this.Close();
                    break;
                default:
                    MessageBoxResult err = MessageBox.Show("Wrong username or password");
                    break;
            }
        }
    }
}
