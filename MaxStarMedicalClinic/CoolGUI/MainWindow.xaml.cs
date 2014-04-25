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
        private Linq_DAL linq;
        private Manager m;
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
                
                DoctorScreen ds = new DoctorScreen();
                ds.Show();
                this.Close();
            }
            else
            {
                MessageBoxResult err = MessageBox.Show("Wrong username or password");
            }
        }
    }
}
