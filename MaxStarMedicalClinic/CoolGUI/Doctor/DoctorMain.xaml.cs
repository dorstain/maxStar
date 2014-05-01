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
using DataAccessLayer;

namespace CoolGUI.Doctor
{
    /// <summary>
    /// Interaction logic for DoctorMain.xaml
    /// </summary>
    public partial class DoctorMain : MainWindow 
    {

        public DoctorMain()
        {
            InitializeComponent();
        }

        public void Click_Add(Object o, RoutedEventArgs e)
        {
            Add a = new Add();
            a.Show();
            this.Close();
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        
    }
}
