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


namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for AdminScreen.xaml
    /// </summary>
    public partial class AdminScreen : Window
    {

        private IManager m;
        private String adminID;
        private ObservableCollection<BackEndLayer.Doctor> ocd;
        private ObservableCollection<BackEndLayer.Patient> ocp;

        public AdminScreen(IManager m, String adminID)
        {
            this.m = m;
            this.adminID = adminID;

            InitializeComponent();

            this.ocd = new ObservableCollection<BackEndLayer.Doctor>();
            this.ocp = new ObservableCollection<BackEndLayer.Patient>();

            UpdateOCD();
            UpdateOCP();

            this.data_apmaindoc.DataContext = ocd;
            this.data_pmaindoc.DataContext = ocd;

            this.dataGrid_patients.DataContext = ocp;
        }

        //add doctor
        private void addDoctor_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_menu.Content = "Add Doctor";
            HideAll();
            this.AddDoctor.Visibility = System.Windows.Visibility.Visible;
        }

        //edit doctor
        private void editDoctor_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_menu.Content = "Edit Doctor";
            HideAll();
            this.EditDoctor.Visibility = System.Windows.Visibility.Visible;
        }

        //fire doctor
        private void fireDoctor_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_menu.Content = "Fire Doctor";
            HideAll();
            this.FireDoctor.Visibility = System.Windows.Visibility.Visible;
        }

        //add patient
        private void addPatient_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_menu.Content = "Add Patient";
            HideAll();
            this.AddPatient.Visibility = System.Windows.Visibility.Visible;
        }

        //edit patient
        private void editPatient_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_menu.Content = "Edit Patient";
            HideAll();
            this.EditPatient.Visibility = System.Windows.Visibility.Visible;
        }

        //remove patient
        private void removePatient_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_menu.Content = "Remove Patient";
            HideAll();
            this.RemovePatient.Visibility = System.Windows.Visibility.Visible;
        }

        //all patients
        private void allPatients_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_menu.Content = "List of all Patients";
            HideAll();
            this.AllPatients.Visibility = System.Windows.Visibility.Visible;
        }

        private void addAdmin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_menu.Content = "Add Admin";
            HideAll();
            this.AddAdmin.Visibility = System.Windows.Visibility.Visible;
        }

        private void changePassword_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_menu.Content = "Change Password";
            HideAll();
            this.ChangePassword.Visibility = System.Windows.Visibility.Visible;
        }

        private void button_addDoctor_Click(object sender, RoutedEventArgs e)
        {
            String id = data_adoctorid.Text;
            String first = data_adfname.Text;
            String last = data_adlname.Text;
            String salary = data_adsalary.Text;
            char gender = (data_adgender.Text.Equals("Male") ? 'm' : 'f');
            if (!m.isLegalName(first) || !m.isLegalName(last) || !m.isLegalInt(salary, 2499) || m.DoctorAlreadyExists(id))
            {
                String error = "The following things need to be fixed:\n\n";
                if (m.DoctorAlreadyExists(id))
                    error += " Doctor is already in the system.\n";
                if (!m.isLegalName(first))
                    error += " First name is not legal. Names must start with Captial letter.\n";
                if (!m.isLegalName(last))
                    error += " Last name is not legal. Names must start with Captial letter.\n";
                if (!m.isLegalInt(salary, 2499))
                    error += " Salary is not legal. Minimum value is 2500.\n";
                MessageBoxResult err = MessageBox.Show(error);
            }
            else
            {
                BackEndLayer.Doctor d = new BackEndLayer.Doctor(id, first, last, int.Parse(salary), gender);
                m.AddDoctor(d);
                m.AddUser(id, id, 1);
                UpdateOCD();
                data_adoctorid.Text = "";
                data_adfname.Text = "";
                data_adlname.Text = "";
                data_adsalary.Text = "";
                data_adgender.Text = "";
                MessageBoxResult done = MessageBox.Show("The doctor is added successfully to the system database.");
            }
        }

        private void button_loadDoctor_Click(object sender, RoutedEventArgs e)
        {
            List<BackEndLayer.Doctor> d = m.SearchDoctorByID(data_doctorid.Text);
            if (d.Count > 0)
            {
                BackEndLayer.Doctor doc = d.First<BackEndLayer.Doctor>();
                data_doctorid.IsReadOnly = true;
                data_dfname.Text = doc.firstName;
                data_dlname.Text = doc.lastName;
                data_dsalary.Text = doc.salary + "";
                data_dgender.Text = ((doc.gender == 'm') ? "Male" : "Female");
            }
            else
            {
                MessageBoxResult err = MessageBox.Show("The doctor does not exists.");
            }
        }

        private void button_saveDoctor_Click(object sender, RoutedEventArgs e)
        {
            String first = data_dfname.Text;
            String last = data_dlname.Text;
            String salary = data_dsalary.Text;
            char gender = (data_dgender.Text.Equals("Male") ? 'm' : 'f');
            if (!m.isLegalName(first) || !m.isLegalName(last) || !m.isLegalInt(salary, 2499))
            {
                String error = "The following things need to be fixed:\n\n";
                if (!m.isLegalName(first))
                    error += " First name is not legal. Names must start with Captial letter.\n";
                if (!m.isLegalName(last))
                    error += " Last name is not legal. Names must start with Captial letter.\n";
                if (!m.isLegalInt(salary, 2499))
                    error += " Salary is not legal. Minimum value is 2500.\n";
                MessageBoxResult err = MessageBox.Show(error);
            }
            else
            {
                BackEndLayer.Doctor d = new BackEndLayer.Doctor(data_doctorid.Text, first, last, int.Parse(salary), gender);
                m.EditDoctor(data_doctorid.Text, d);
                UpdateOCD();
                data_doctorid.IsReadOnly = false;
                data_doctorid.Text = "";
                data_dfname.Text = "";
                data_dlname.Text = "";
                data_dsalary.Text = "";
                data_dgender.Text = "";
                MessageBoxResult done = MessageBox.Show("Done!");
            }
        }

        private void button_loadPatient_Click(object sender, RoutedEventArgs e)
        {
            List<BackEndLayer.Patient> p = m.SearchPatientByID(data_patientid.Text);
            if (p.Count > 0)
            {
                BackEndLayer.Patient pat = p.First<BackEndLayer.Patient>();
                data_patientid.IsReadOnly = true;
                data_pfname.Text = pat.firstName;
                data_plname.Text = pat.lastName;
                data_pmaindoc.Text = m.GetDoctorNameByID(pat.mainDoctor);
                data_page.Text = pat.age + "";
                data_pgender.Text = ((pat.gender == 'm') ? "Male" : "Female");
            }
            else
            {
                MessageBoxResult err = MessageBox.Show("The patient does not exists.");
            }
        }

        private void button_savePatient_Click(object sender, RoutedEventArgs e)
        {
            String first = data_pfname.Text;
            String last = data_plname.Text;
            String age = data_page.Text;
            String maindoc = m.GetDoctorIDByName(data_pmaindoc.Text);
            char gender = (data_dgender.Text.Equals("Male") ? 'm' : 'f');
            if (!m.isLegalName(first) || !m.isLegalName(last) || !m.DoctorAlreadyExists(maindoc) || !m.isLegalInt(age, 1))
            {
                String error = "The following things need to be fixed:\n\n";
                if (!m.isLegalName(first))
                    error += " First name is not legal. Names must start with Captial letter.\n";
                if (!m.isLegalName(last))
                    error += " Last name is not legal. Names must start with Captial letter.\n";
                if (!m.DoctorAlreadyExists(maindoc))
                    error += " Doctor does not in the system.\n";
                if (!m.isLegalInt(age, 1))
                    error += " Age is not legal. Must be integer bigger than 0.\n";
                MessageBoxResult err = MessageBox.Show(error);
            }
            else
            {
                BackEndLayer.Patient p = new BackEndLayer.Patient(data_patientid.Text, first, last, maindoc, int.Parse(age), gender);
                m.EditPatient(data_patientid.Text, p);
                UpdateOCP();
                data_patientid.IsReadOnly = false;
                data_patientid.Text = "";
                data_pfname.Text = "";
                data_plname.Text = "";
                data_pmaindoc.Text = "";
                data_page.Text = "";
                data_pgender.Text = "";
                UpdateOCP();
                MessageBoxResult done = MessageBox.Show("Done!");
            }
        }

        private void HideAll()
        {
            this.AddDoctor.Visibility = System.Windows.Visibility.Hidden;
            this.EditDoctor.Visibility = System.Windows.Visibility.Hidden;
            this.FireDoctor.Visibility = System.Windows.Visibility.Hidden;
            this.AddPatient.Visibility = System.Windows.Visibility.Hidden;
            this.EditPatient.Visibility = System.Windows.Visibility.Hidden;
            this.RemovePatient.Visibility = System.Windows.Visibility.Hidden;
            this.AllPatients.Visibility = System.Windows.Visibility.Hidden;
            this.AddAdmin.Visibility = System.Windows.Visibility.Hidden;
            this.ChangePassword.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoginScreen login = new LoginScreen(m);
            login.Show();

        }

        private void button_fireDoctor_Click(object sender, RoutedEventArgs e)
        {
            List<BackEndLayer.Doctor> d = m.SearchDoctorByID(data_firedoctorid.Text);
            if (d.Count > 0)
            {
                foreach (BackEndLayer.Doctor doc in d)
                    m.RemoveDoctorByID(doc.id);
                UpdateOCD();
                data_firedoctorid.Text = "";
                MessageBoxResult succ = MessageBox.Show("The doctor has been fired!");
            }
            else
            {
                MessageBoxResult err = MessageBox.Show("The doctor does not exists.");
            }
        }

        private void button_removePatient_Click(object sender, RoutedEventArgs e)
        {
            List<BackEndLayer.Patient> p = m.SearchPatientByID(data_removepatientid.Text);
            if (p.Count > 0)
            {
                foreach (BackEndLayer.Patient pat in p)
                    m.RemovePatientByID(pat.id);
                UpdateOCP();
                data_removepatientid.Text = "";
                MessageBoxResult succ = MessageBox.Show("The patient removed successfully.");
            }
            else
            {
                MessageBoxResult err = MessageBox.Show("The patient does not exists.");
            }
        }

        private void logo_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void button_addPatient_Click(object sender, RoutedEventArgs e)
        {
            String id = data_apatientid.Text;
            String first = data_apfname.Text;
            String last = data_aplname.Text;
            String age = data_apage.Text;
            String maindoc = m.GetDoctorIDByName(data_apmaindoc.Text);
            char gender = (data_apgender.Text.Equals("Male") ? 'm' : 'f');
            if (!m.isLegalName(first) || !m.isLegalName(last) || !m.isLegalInt(age, 1) || !m.DoctorAlreadyExists(maindoc) || m.PatientAlreadyExists(id))
            {
                String error = "The following things need to be fixed:\n\n";
                if (m.PatientAlreadyExists(id))
                    error += " Patient is already in the system.\n";
                if (!m.isLegalName(first))
                    error += " First name is not legal. Names must start with Captial letter.\n";
                if (!m.isLegalName(last))
                    error += " Last name is not legal. Names must start with Captial letter.\n";
                if (!m.DoctorAlreadyExists(maindoc))
                    error += " Doctor does not in the system.\n";
                if (!m.isLegalInt(age, 1))
                    error += " Age is not legal. Must be integer bigger than 0.\n";
                MessageBoxResult err = MessageBox.Show(error);
            }
            else
            {
                BackEndLayer.Patient p = new BackEndLayer.Patient(id, first, last, maindoc, int.Parse(age), gender);
                m.AddPatient(p);
                m.AddUser(id, id, 2);
                UpdateOCP();
                data_apatientid.Text = "";
                data_apfname.Text = "";
                data_aplname.Text = "";
                data_apmaindoc.Text = "";
                data_apage.Text = "";
                data_apgender.Text = "";
                MessageBoxResult done = MessageBox.Show("The patient is added successfully to the system database.");
            }
        }

        

        private void UpdateOCD()
        {
            ocd.Clear();

            foreach (BackEndLayer.Doctor d in m.GetAllDoctors())
            {
                ocd.Add(d);
            }
        }

        private void UpdateOCP()
        {
            ocp.Clear();

            foreach (BackEndLayer.Patient p in m.GetAllPatients())
            {
                ocp.Add(p);
            }
        }

        private void button_savePass_Click(object sender, RoutedEventArgs e)
        {
            if (m.validate(this.adminID, this.data_oldpass.Text))
            {
                m.ChangePassword(adminID, this.data_newpass.Text);
                this.data_newpass.Text = "";
                this.data_oldpass.Text = "";
                MessageBoxResult done = MessageBox.Show("Password changed successfully.");
            }
            else
            {
                MessageBoxResult error = MessageBox.Show("Old Password is incorrect.");
            }
        }

        private void button_saveAdmin_Click(object sender, RoutedEventArgs e)
        {
            String id = data_adminid.Text;
            String pass = data_adminpass.Text;
            if (!m.UserAlreadyExists(id))
            {
                m.AddUser(id, pass, 0);
                this.data_adminpass.Text = "";
                this.data_adminid.Text = "";
                MessageBoxResult error = MessageBox.Show("Admin created successfully.");
            }
            else
            {
                MessageBoxResult error = MessageBox.Show("User with that id already exists.");
            }
        }
    }
}
