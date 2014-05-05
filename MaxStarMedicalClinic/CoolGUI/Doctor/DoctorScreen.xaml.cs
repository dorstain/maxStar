using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DoctorScreen.xaml
    /// </summary>
    public partial class DoctorScreen : Window
    {
        private Manager m;
        private String doctorID;

        public DoctorScreen(Manager m, String id)
        {
            this.m = m;
            this.doctorID = id;
            InitializeComponent();
        }

        private void go_Click(object sender, RoutedEventArgs e)
        {
            List<BackEndLayer.Patient> p = m.SearchPatientByID(this.data_patient.Text);
            if (p.Count > 0)
            {
                data_patient.IsReadOnly = true;
                BackEndLayer.Patient tPat = p.First<BackEndLayer.Patient>();
                this.data_presc.Clear();
                this.data_prog.Clear();
                this.dataBlock.Visibility = System.Windows.Visibility.Visible;
                this.data_name.Content = tPat.getName();
                this.data_age.Content = tPat.getAge();
                this.data_gender.Content = tPat.getGender();
            }
            else
            {
                MessageBoxResult err = MessageBox.Show("The patient does not exists.");
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            String start = this.startDatePicker.Text;
            String finish = this.finishDatePicker.Text;
            String prog = this.data_prog.Text;
            String presc = this.data_presc.Text;
            m.AddTreatment(new Treatment(data_patient.Text,start,finish,doctorID,prog,presc));

            data_patient.IsReadOnly = false;
            this.dataBlock.Visibility = System.Windows.Visibility.Hidden;
            this.startDatePicker.Text = "";
            this.finishDatePicker.Text = "";
            this.data_patient.Text = "";
        }

        private void treatment_Click(object sender, RoutedEventArgs e)
        {
            //init treatments screen
            Doctor.Treatments w1 = new Doctor.Treatments(m);

            var query = from t in m.GetAllTreatments()
                        where t.ID.Equals(this.data_patient.Text)
                        select t;
            
            ObservableCollection<Treatment> oct = new ObservableCollection<Treatment>();
            w1.dataTable.DataContext = oct;

            foreach (Treatment t in query)
            {
                oct.Add(t);
            }

            w1.Show();
        }

        private void logo_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        } 
    }
}
