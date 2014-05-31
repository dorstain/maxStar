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


namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for PatientScreen.xaml
    /// </summary>
    public partial class PatientScreen : Window
    {

        private IManager m;
        private String patient_id;

        public PatientScreen(IManager m, string id)
        {
            InitializeComponent();

            this.m = m;
            this.patient_id = id;
            this.dataGrid_treatmentHistory.DataContext = m.GetPatientTreatments(patient_id);
            this.dataGrid_visittHistory.DataContext = m.GetPatientVisits(patient_id);
            fdViewer.Document = CreateFlowDocument();

        }



        private void label5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_Menu.Content = "Make appoitment";
            this.pswd.Visibility = System.Windows.Visibility.Hidden;
            this.hsry.Visibility = System.Windows.Visibility.Visible;
            this.Lp.Visibility = System.Windows.Visibility.Hidden;
        }

        private void label4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_Menu.Content = "Change Password";
            this.pswd.Visibility = System.Windows.Visibility.Visible;
            this.hsry.Visibility = System.Windows.Visibility.Hidden;
            this.Lp.Visibility = System.Windows.Visibility.Hidden;
        }

        private void label33_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.label_Menu.Content = "Print Last Prescription";
            this.pswd.Visibility = System.Windows.Visibility.Hidden;
            this.hsry.Visibility = System.Windows.Visibility.Hidden;
            this.Lp.Visibility = System.Windows.Visibility.Visible;
        }


        private void image1_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBoxResult err = MessageBox.Show("print hook");
        }


        private void save_Password(object sender, RoutedEventArgs e)
        {
            User u = m.SearchByUserID(patient_id);
            if (passwordBox1.Password.Equals(u.password))
            {
                u.password = passwordBox2.Password;
                MessageBoxResult accept = MessageBox.Show("Password has been changed");
            }
            else
            {
                MessageBoxResult err = MessageBox.Show("Incorrent old password");
            }
        }

        private void print_Prescriptions(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            IDocumentPaginatorSource idpSource = fdViewer.Document;
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
        }

        private FlowDocument CreateFlowDocument()
        {
            FlowDocument doc = new FlowDocument();
            Paragraph p = new Paragraph(new Run("Treatment:"));
            p.FontSize = 24;
            p.Foreground = Brushes.Blue;
            doc.Blocks.Add(p);
            Patient pa = m.SearchPatientByID(patient_id).ElementAt(0);
            Treatment t = m.GetPatientLastTreatment(pa.id);
            if (t == null)
                return doc;
            p = new Paragraph(new Run("Patient: " + pa.firstName + " " + pa.lastName));
            p.FontSize = 14;
            p.TextAlignment = TextAlignment.Left;
            p.Foreground = Brushes.Black;
            doc.Blocks.Add(p);
            p = new Paragraph(new Run("ID: " + pa.id));
            p.FontSize = 14;
            p.TextAlignment = TextAlignment.Left;
            p.Foreground = Brushes.Black;
            doc.Blocks.Add(p);
            p = new Paragraph(new Run("Age: " + pa.age));
            p.FontSize = 14;
            p.TextAlignment = TextAlignment.Left;
            p.Foreground = Brushes.Black;
            doc.Blocks.Add(p);
            p = new Paragraph(new Run("Gender: " + pa.gender));
            p.FontSize = 14;
            p.TextAlignment = TextAlignment.Left;
            p.Foreground = Brushes.Black;
            doc.Blocks.Add(p);
            p = new Paragraph(new Run("Doctor: " + pa.mainDoctor));
            p.FontSize = 14;
            p.TextAlignment = TextAlignment.Left;
            p.Foreground = Brushes.Black;
            doc.Blocks.Add(p);
            p = new Paragraph(new Run("Start Date: " + t.dateOfStart + " " + "End Date: " + t.dateOfFinish));
            p.FontSize = 14;
            p.TextAlignment = TextAlignment.Left;
            p.Foreground = Brushes.Black;
            doc.Blocks.Add(p);
            p = new Paragraph(new Run("Prescriptions: " + t.prescriptions));
            p.FontSize = 14;
            p.TextAlignment = TextAlignment.Left;
            p.Foreground = Brushes.Black;
            doc.Blocks.Add(p);
            return doc;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoginScreen login = new LoginScreen(m);
            login.Show();
        }

    }
}
