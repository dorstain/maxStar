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

namespace CoolGUI.Doctor
{
    /// <summary>
    /// Interaction logic for Treatments.xaml
    /// </summary>
    public partial class Treatments : Window
    {
        private Manager m;

        public Treatments(Manager m)
        {
            this.m = m;
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
        }


    }
}
