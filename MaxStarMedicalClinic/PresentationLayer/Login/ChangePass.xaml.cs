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

namespace PresentationLayer.Login
{
    /// <summary>
    /// Interaction logic for ChangePass.xaml
    /// </summary>
    public partial class ChangePass : Window
    {
        private IManager m;
        private String id;

        public ChangePass(IManager m, String id)
        {
            this.m = m;
            this.id = id;

            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            m.ChangePassword(id, this.data_pass.Text);
            switch (m.getUserRank(id))
            {
                case 1: //doctor
                    DoctorScreen ds = new DoctorScreen(m, id);
                    BackEndLayer.Doctor[] tDoc = (m.SearchDoctorByID(id)).ToArray();
                    if (tDoc.Length > 0)
                        ds.data_doctor.Content = "Dr. " + tDoc[0].getName();
                    ds.Show();
                    this.Hide();
                    break;

                case 2: //patient
                    PatientScreen ps = new PatientScreen(m, id);
                    ps.Show();
                    this.Hide();
                    break;

            }
        }


    }
}
