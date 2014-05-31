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

namespace PresentationLayer.Doctor
{
    /// <summary>
    /// Interaction logic for Treatments.xaml
    /// </summary>
    public partial class Treatments : Window
    {
        private IManager m;

        public Treatments(IManager m)
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
