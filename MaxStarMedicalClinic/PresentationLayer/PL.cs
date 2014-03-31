using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEndLayer;
using LogicLayer;

namespace PresentationLayer
{
    public class PL
    {
        private Manager m;

        public PL(Manager m)
        {
            this.m = m;
            Console.SetWindowSize(100, 35);
        }

        public String Menu(char c)
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t Welcome to Max Star Medical Clinic! \n " +
                              "\n\r --- Please choose what to manage: ---\n" +
                              "\n\r  1. Doctors" +
                              "\n\r  2. Patients" +
                              "\n\r  3. Visits" +
                              "\n\r  4. Treatments" +
                              "\n\n\r  0. Exit \n");

            if (c == ' ')
            {

                return SubMenu(Console.ReadKey().KeyChar);
            }
            return SubMenu(c);
        }
        public String SubMenu(char c){
            Console.Clear();
            switch (c)
            {
                case '1':
                    Console.WriteLine("\n\r -------- Manage Doctors: --------\n" +
                                "\n\r  1. Add" +
                                "\n\r  2. Edit" +
                                "\n\r  3. Remove" +
                                "\n\r  4. Search" +
                                "\n\r  5. Get all doctors" +
                                "\n\r  6. Get all doctor's patients" +
                                "\n\n\r  9. Back" +
                                "\n\r  0. Exit \n");
                    break;
                case '2':
                    Console.WriteLine("\n\r -------- Manage Patients: --------\n" +
                                "\n\r  1. Add" +
                                "\n\r  2. Edit" +
                                "\n\r  3. Remove" +
                                "\n\r  4. Search" +
                                "\n\r  5. Get all patients" +
                                "\n\n\r  9. Back" +
                                "\n\r  0. Exit \n");
                    break;
                case '3':
                    Console.WriteLine("\n\r -------- Manage Visits: --------\n" +
                                "\n\r  1. Add" +
                                "\n\r  2. Edit" +
                                "\n\r  3. Remove" +
                                "\n\r  4. Search" +
                                "\n\r  5. Get all visits by date" +
                                "\n\n\r  9. Back" +
                                "\n\r  0. Exit \n");
                    break;
                case '4':
                    Console.WriteLine("\n\r -------- Manage Treatments: --------\n" +
                                "\n\r  1. Add" +
                                "\n\r  2. Edit" +
                                "\n\r  3. Remove" +
                                "\n\r  4. Search" +
                                "\n\r  5. Get all treatments made by doctor" +
                                "\n\r  6. Get all treatments" +
                                "\n\n\r  9. Back" +
                                "\n\r  0. Exit \n");
                    break;
                case '0':
                    System.Environment.Exit(0);
                    break;
                default:
                    Run();
                    break;
            }

            Char cmd = Console.ReadKey().KeyChar;
            if (cmd == '9')
                return "9";
            else if (cmd == '0')
                return "0";
            return c+""+cmd;
        }

        public void Run(char c = ' ')
        {
            String s = Menu(c);
            Console.WriteLine();
            Console.Clear();
            switch (s)
            {
                //doctors
                case "11":
                    //###### create doctor #######
                    m.AddDoctor(AddDoctor());
                    break;
                case "12":
                    //###### edit doctor #######
                    Doctor newDoc = EditDoctor();
                    m.EditDoctor(newDoc.ID, newDoc);
                    break;
                case "13":
                    //###### delete doctor #######
                    Console.Write("Please enter the doctor's id that you want to remove: ");
                    String id = Console.ReadLine();
                    if (m.RemoveDoctorByID(id))
                    {
                        Console.WriteLine("\nDoctor removed successfully");
                    }
                    else
                    {
                        Console.WriteLine("\nNo doctor match found");
                    }
                    break;
                case "14":
                    //###### search doctor #######
                    Console.Write("Please enter the doctor's id that you want to search: ");
                    id = Console.ReadLine();
                    Console.Clear(); 
                    foreach (Doctor d in m.SearchDoctorByID(id))
                    {
                        Console.WriteLine("\n***********************\n");
                        Console.WriteLine(d.toString());
                    }
                    break;
                case "15":
                    //###### get all doctors #######
                    Console.Clear();
                    foreach (Doctor d in m.GetAllDoctors())
                    {
                        Console.WriteLine("\n***********************\n");
                        Console.WriteLine(d.toString());
                    }
                    break;
                case "16":
                    //###### get all doctor's patients #######
                    Console.Write("Please enter the doctor's id to get his patients: ");
                    id = Console.ReadLine();
                    Console.Clear(); 
                    foreach (Patient p in m.GetAllDoctorsPatients(id))
                    {
                        Console.WriteLine("\n***********************\n");
                        Console.WriteLine(p.toString());
                    }
                    break;
                //patients
                case "21":
                    //###### create patient #######
                    m.AddPatient(AddPatient());
                    break;
                case "22":
                    //###### edit patient #######
                    Patient newP = EditPatient();
                    m.EditPatient(newP.ID, newP);
                    break;
                case "23":
                    //###### remove patient #######
                    Console.Write("Please enter the patient's id that you want to remove: ");
                    id = Console.ReadLine();
                    if (m.RemovePatientByID(id))
                    {
                        Console.WriteLine("\nPatient removed successfully");
                    }
                    else
                    {
                        Console.WriteLine("\nNo patient match found");
                    }
                    break;
                case "24":
                    //###### search patient #######
                    Console.Write("Please enter the patient's id that you want to search: ");
                    id = Console.ReadLine();
                    Console.Clear(); 
                    foreach (Patient p in m.SearchPatientByID(id))
                    {
                        Console.WriteLine("\n***********************\n");
                        Console.WriteLine(p.toString());
                    }
                    break;
                case "25":
                    //###### get all patients #######
                    Console.Clear();
                    foreach (Patient p in m.GetAllPatients())
                    {
                        Console.WriteLine("\n***********************\n");
                        Console.WriteLine(p.toString());
                    }
                    break;
                //visits
                case "31":
                    //###### create visit #######
                    m.AddVisit(AddVisit());
                    break;
                case "32":
                    //###### edit visit #######
                    Visit newVis = EditVisit();
                    m.EditVisit(newVis.ID, newVis);
                    break;
                case "33":
                    //###### remove visit #######
                    Console.Write("Please enter the visit's id that you want to remove: ");
                    id = Console.ReadLine();
                    if (m.RemoveVisitByID(id))
                    {
                        Console.WriteLine("\nVisit has been removed successfully");
                    }
                    else
                    {
                        Console.WriteLine("\nNo Visit was founded");
                    }
                    break;
                case "34":
                    //###### search visit #######
                    Console.Write("Please enter the visit's id that you want to search: ");
                    id = Console.ReadLine();
                    Console.Clear();
                    foreach (Visit v in m.SearchVisitByID(id))
                    {
                        Console.WriteLine("\n***********************\n");
                        Console.WriteLine(v.toString());
                    }
                    break;
                case "35":
                    //###### get all visits by id #######
                    Console.Write("Please enter the date of the visits that you want to get (DD/MM/YYYY): ");
                    String date = Console.ReadLine();
                    while (!m.isLegalDate(date))
                    {
                        Console.WriteLine("Date is illegal, try again or enter '-1' to exit");
                        date = Console.ReadLine();
                        if(date.Equals("-1")){
                            Run('3');
                        }
                    }
                    Console.Clear();
                    foreach (Visit v in m.GetVisitsByDate(date))
                    {
                        Console.WriteLine("\n***********************\n");
                        Console.WriteLine(v.toString());
                    }
                    break;
                //treatments
                case "41":
                    //###### create treatment #######
                    m.AddTreatment(AddTreatment());
                    break;
                case "42":
                    //###### edit treatment #######
                    Treatment newT = EditTreatment();
                    m.EditTreatmentByIdAndStartDate(newT.ID, newT);
                    break;
                case "43":
                    //###### remove treatment #######
                    Console.Write("Please enter the patients's id whose treatment you want to remove: ");
                    id = Console.ReadLine();
                    Console.Write("Please enter the treatment's start date that you want to remove: ");
                    String start = Console.ReadLine();
                    if (m.RemoveTreatmentByIdAndStartDate(id,start))
                    {
                        Console.WriteLine("\nTreatment removed successfully");
                    }
                    else
                    {
                        Console.WriteLine("\nNo treatment match found");
                    }
                    break;
                case "44":
                    //###### get all patient's treatments #######
                    Console.Write("Please enter the patient's id to get his treatments: ");
                    id = Console.ReadLine();
                    Console.Clear(); 
                    foreach (Treatment t in m.SearchTreatmentByID(id))
                    {
                        Console.WriteLine("\n***********************\n");
                        Console.WriteLine(t.toString());
                    }
                    break;
                case "45":
                    //###### get all doctor's treatments #######
                    Console.Write("Please enter the doctor's id to get treatments he created: ");
                    id = Console.ReadLine();
                    Console.Clear();
                    foreach (Treatment t in m.GetAllTreatmentsByDoctorID(id))
                    {
                        Console.WriteLine("\n***********************\n");
                        Console.WriteLine(t.toString());
                    }
                    break;
                case "46":
                    //###### get all treatments #######
                    Console.Clear();
                    foreach (Treatment t in m.GetAllTreatments())
                    {
                        Console.WriteLine("\n***********************\n");
                        Console.WriteLine(t.toString());
                    }
                    break;
                case "9":
                    //###### back #######
                    Run();
                    break;
                case "0":
                    //###### exit #######
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nWrong command, please try again.");
                    break;
            }
            Continue();
            Run();
        }

        //add doctor
        public Doctor AddDoctor()
        {
            Console.WriteLine("\nCreating new doctor:\n");
            Console.Write("Please enter the doctor's id ('-1' to exit): ");
            String id = Console.ReadLine();
            while (m.DoctorAlreadyExists(id) || id.Length != 9 || id.Equals("-1"))
            {
                if (id.Equals("-1"))
                {
                    Run('1');
                }
                if (m.DoctorAlreadyExists(id))
                    Console.WriteLine("The doctor exists, try again.");
                else
                    Console.WriteLine("Illegal id, try again.");
                id = Console.ReadLine();
            }
            Console.Write("Please enter the doctor's first name: ");
            String first = Console.ReadLine();
            while (!m.isLegalName(first))
            {
                Console.WriteLine("Illegal name, try again.");
                first = Console.ReadLine();
            }
            Console.Write("Please enter the doctor's last name: ");
            String last = Console.ReadLine();
            while (!m.isLegalName(last))
            {
                Console.WriteLine("Illegal name, try again.");
                last = Console.ReadLine();
            }
            Console.Write("Please enter the doctor's salary: ");
            String salary = Console.ReadLine();
            int n;
            while (!int.TryParse(salary,out n) || int.Parse(salary) < 1000)
            {
                Console.WriteLine("Illegal salary. Minimum salary is 1000, try again.");
                salary = Console.ReadLine();
            }
            Console.Write("Please enter the doctor's gender (m/f): ");
            String gender = Console.ReadLine();
            while (!gender.Equals("m") && !gender.Equals("f"))
            {
                Console.WriteLine("only 'm' for male and 'f' for female is allowed, try again.");
                gender = Console.ReadLine();
            }
            return new Doctor(id, first, last, int.Parse(salary), char.Parse(gender));
        }

        public Doctor EditDoctor()
        {
            Console.WriteLine("\nEditing doctor:\n");
            Console.WriteLine("Enter the doctor's id that you want to edit and the details you want to change.");
            Console.WriteLine("if you don't want to change the detail, insert '-1'.\n");
            Console.Write("Please enter the doctor's id ('-1' to exit): ");
            String id = Console.ReadLine();
            while(!m.DoctorAlreadyExists(id) || id.Equals("-1"))
            {
                if (id.Equals("-1"))
                {
                    Run('1');
                }
                Console.WriteLine("The doctor does not exists, try again.");
                id = Console.ReadLine();
            }
            Console.Write("Please enter the doctor's first name: ");
            String first = Console.ReadLine();
            while (!m.isLegalName(first) && !first.Equals("-1"))
            {
                Console.WriteLine("Illegal name, try again.");
                first = Console.ReadLine();
            }
            Console.Write("Please enter the doctor's last name: ");
            String last = Console.ReadLine();
            while (!m.isLegalName(last) && !last.Equals("-1"))
            {
                Console.WriteLine("Illegal name, try again.");
                last = Console.ReadLine();
            }
            Console.Write("Please enter the doctor's salary: ");
            String salary = Console.ReadLine();
            int n;
            while ((!int.TryParse(salary, out n) || int.Parse(salary) < 1000) && !salary.Equals("-1"))
            {
                Console.WriteLine("Illegal salary. Minimum salary is 1000, try again.");
                salary = Console.ReadLine();
            } 
            Console.Write("Please enter the doctor's gender (m/f): ");
            String gender = Console.ReadLine();
            while (!gender.Equals("m") && !gender.Equals("f") && !gender.Equals("-1"))
            {
                Console.WriteLine("only 'm' for male and 'f' for female is allowed, try again.");
                gender = Console.ReadLine();
            }
            return new Doctor(id, first, last, int.Parse(salary), (gender.Equals("-1")) ? '1' : char.Parse(gender));
        }

        //add patient
        public Patient AddPatient()
        {
            Console.WriteLine("\nCreating new patient:\n");
            Console.Write("Please enter the patient's id ('-1' to exit): ");
            String id = Console.ReadLine();
            while (m.PatientAlreadyExists(id) || id.Length != 9 || id.Equals("-1"))
            {
                if (id.Equals("-1"))
                {
                    Run('2');
                }
                if (m.PatientAlreadyExists(id))
                    Console.WriteLine("The patient exists, try again.");
                else
                    Console.WriteLine("Illegal id, try again.");
                id = Console.ReadLine();
            }
            Console.Write("Please enter the patient's first name: ");
            String first = Console.ReadLine();
            while (!m.isLegalName(first))
            {
                Console.WriteLine("Illegal name, try again.");
                first = Console.ReadLine();
            }
            Console.Write("Please enter the patient's last name: ");
            String last = Console.ReadLine();
            while (!m.isLegalName(last))
            {
                Console.WriteLine("Illegal name, try again.");
                last = Console.ReadLine();
            }
            Console.Write("Please enter the patient's main doctor id: ");
            String doctor = Console.ReadLine();
            while (!m.DoctorAlreadyExists(doctor))
            {
                Console.WriteLine("Doctor does not exist, try again.");
                doctor = Console.ReadLine();
            }
            Console.Write("Please enter the patient's age: ");
            String age = Console.ReadLine();
            int n;
            while (!int.TryParse(age, out n) || int.Parse(age) < 1)
            {
                Console.WriteLine("Illegal age. Age must be bigger than 1, try again.");
                age = Console.ReadLine();
            }
            Console.Write("Please enter the patient's gender (m/f): ");
            String gender = Console.ReadLine();
            while (!gender.Equals("m") && !gender.Equals("f"))
            {
                Console.WriteLine("only 'm' for male and 'f' for female is allowed, try again.");
                gender = Console.ReadLine();
            }
            return new Patient(id, first, last, doctor, int.Parse(age), char.Parse(gender));
        }

        //edit patient
        public Patient EditPatient()
        {
            Console.WriteLine("\nEditing patient:\n");
            Console.WriteLine("Enter the patient's id that you want to edit and the details you want to change.");
            Console.WriteLine("if you don't want to change the detail, insert '-1'.\n");
            Console.Write("Please enter the patient's id ('-1' to exit): ");
            String id = Console.ReadLine();
            while (!m.PatientAlreadyExists(id) || id.Equals("-1"))
            {
                if (id.Equals("-1"))
                {
                    Run('2');
                }
                Console.WriteLine("The patient does not exists, try again.");
                id = Console.ReadLine();
            }
            Console.Write("Please enter the patient's first name: ");
            String first = Console.ReadLine();
            while (!m.isLegalName(first) && !first.Equals("-1"))
            {
                Console.WriteLine("Illegal name, try again.");
                first = Console.ReadLine();
            }
            Console.Write("Please enter the patient's last name: ");
            String last = Console.ReadLine();
            while (!m.isLegalName(last) && !last.Equals("-1"))
            {
                Console.WriteLine("Illegal name, try again.");
                last = Console.ReadLine();
            }
            Console.Write("Please enter the patient's main doctor id: ");
            String doctor = Console.ReadLine();
            while (!m.DoctorAlreadyExists(doctor) && !doctor.Equals("-1"))
            {
                Console.WriteLine("Doctor does not exist or illegal id, try again.");
                doctor = Console.ReadLine();
            }
            Console.Write("Please enter the patient's age: ");
            String age = Console.ReadLine();
            int n;
            while ((!int.TryParse(age,out n) || int.Parse(age) < 1) && !age.Equals("-1"))
            {
                Console.WriteLine("Illegal age. Age must be bigger than 1, try again.");
                age = Console.ReadLine();
            }
            Console.Write("Please enter the patient's gender (m/f): ");
            String gender = Console.ReadLine();
            while (!gender.Equals("m") && !gender.Equals("f") && !gender.Equals("-1"))
            {
                Console.WriteLine("only 'm' for male and 'f' for female is allowed, try again.");
                gender = Console.ReadLine();
            }
            return new Patient(id, first, last, doctor, int.Parse(age), (gender.Equals("-1")) ? '1' : char.Parse(gender));
        }

        //add visit
        public Visit AddVisit()
        {
            Console.WriteLine("\nCreating new visit:\n");
            Console.Write("Please enter the 3-digits visit's id ('-1' to exit): ");
            String id = Console.ReadLine();
            while (m.VisitAlreadyExists(id) || id.Length != 3 || id.Equals("-1"))
            {
                if (id.Equals("-1"))
                {
                    Run('3');
                }
                if (m.VisitAlreadyExists(id))
                    Console.WriteLine("The visit exists, try again.");
                else
                    Console.WriteLine("Illegal id, try again.");
                id = Console.ReadLine();
            }
            Console.Write("Please enter the date of visit (DD/MM/YYYY): ");
            String date = Console.ReadLine();
            while (!m.isLegalDate(date))
            {
                Console.WriteLine("Illegal date, try again.");
                date = Console.ReadLine();
            }
            Console.Write("Please enter the id of the assigned doctor: ");
            String doctor = Console.ReadLine();
            while (!m.DoctorAlreadyExists(doctor) || doctor.Length!=9)
            {
                Console.WriteLine("Doctor does not exist or id is Illegal, try again.");
                doctor = Console.ReadLine();
            }
            Console.Write("Please enter the id of the patient: ");
            String patient = Console.ReadLine();
            while (!m.PatientAlreadyExists(patient) || patient.Length!=9)
            {
                Console.WriteLine("Patient does not exist or id is Illegal, try again.");
                patient = Console.ReadLine();
            }
            Console.Write("Please enter the doctor's notes: ");
            String notes = Console.ReadLine();
            return new Visit(id, date, doctor, patient, notes);
        }

        //edit visit
        public Visit EditVisit()
        {
            Console.WriteLine("\nEditing visit:\n");
            Console.WriteLine("Enter the visit's id and the details you want to change.");
            Console.WriteLine("if you don't want to change the detail, insert '-1'.\n");
            Console.Write("Please enter the 3-digits visit's id ('-1' to exit): ");
            String id = Console.ReadLine();
            while (!m.VisitAlreadyExists(id) || id.Length != 3 || id.Equals("-1"))
            {
                if (id.Equals("-1"))
                {
                    Run('3');
                }
                if (id.Length!=3)
                    Console.WriteLine("Illegal id, try again.");
                else
                    Console.WriteLine("The visit does not exists, try again.");
                id = Console.ReadLine();
            }
            Console.Write("Please enter the date of visit (DD/MM/YYYY): ");
            String date = Console.ReadLine();
            while (!m.isLegalDate(date) && !date.Equals("-1"))
            {
                Console.WriteLine("Illegal date, try again.");
                date = Console.ReadLine();
            }
            Console.Write("Please enter the id of the assigned doctor: ");
            String doctor = Console.ReadLine();
            while ((!m.DoctorAlreadyExists(doctor) || doctor.Length != 9) && !doctor.Equals("-1"))
            {
                Console.WriteLine("Doctor does not exist or id is illegal, try again.");
                doctor = Console.ReadLine();
            }
            Console.Write("Please enter the id of the patient: ");
            String patient = Console.ReadLine();
            while ((!m.PatientAlreadyExists(patient) || patient.Length!=9) && !patient.Equals("-1"))
            {
                Console.WriteLine("Patient does not exist or id is illegal, try again.");
                patient = Console.ReadLine();
            }
            Console.Write("Please enter the doctor's notes: ");
            String notes = Console.ReadLine();
            return new Visit(id, date, doctor, patient, notes);
        }

        //add treatment
        public Treatment AddTreatment()
        {
            Console.WriteLine("\nAdding treatment:\n");
            Console.Write("Please enter the patient's id ('-1' to exit): ");
            String id = Console.ReadLine();
            while (!m.PatientAlreadyExists(id) || id.Equals("-1"))
            {
                if (id.Equals("-1"))
                {
                    Run('4');
                }
                Console.WriteLine("The patient does not exists, try again.");
                id = Console.ReadLine();
            }
            Console.Write("Please enter the treatment's date of start (DD/MM/YYYY): ");
            String start = Console.ReadLine();
            while (!m.isLegalDate(start))
            {
                Console.WriteLine("Illegal date, try again.");
                start = Console.ReadLine();
            }
            Console.Write("Please enter the treatment's date of finish (DD/MM/YYYY): ");
            String end = Console.ReadLine();
            while (!m.isLegalDate(end))
            {
                Console.WriteLine("Illegal date, try again.");
                end = Console.ReadLine();
            }
            Console.Write("Please enter the id of the doctor who created the treatment: ");
            String doctor = Console.ReadLine();
            while (!m.DoctorAlreadyExists(doctor) || doctor.Length!=9)
            {
                Console.WriteLine("Doctor does not exist or illegal id, try again.");
                doctor = Console.ReadLine();
            }
            Console.Write("Please enter the treatment's prognosis: ");
            String prog = Console.ReadLine();
            Console.Write("Please enter the treatment's prescriptions: ");
            String presc = Console.ReadLine();
            return new Treatment(id, start, end, doctor, prog, presc);
        }

        //edit treatment
        public Treatment EditTreatment()
        {
            Console.WriteLine("\nEditing treatment:\n");
            Console.WriteLine("Enter the patient's id and the date of start of the treatment you want to edit and the details you want to change.");
            Console.WriteLine("if you don't want to change the detail, insert '-1'.\n");
            Console.Write("Please enter the patient's id ('-1' to exit): ");
            String id = Console.ReadLine();
            while (!m.PatientAlreadyExists(id) || id.Equals("-1"))
            {
                if (id.Equals("-1"))
                {
                    Run('4');
                }
                Console.WriteLine("The patient does not exists, try again.");
                id = Console.ReadLine();
            }
            Console.Write("Please enter the treatment's date of start (DD/MM/YYYY): ");
            String start = Console.ReadLine();
            while (!m.isLegalDate(start) && !start.Equals("-1"))
            {
                Console.WriteLine("Illegal date, try again.");
                start = Console.ReadLine();
            }
            Console.Write("Please enter the treatment's date of finish (DD/MM/YYYY): ");
            String end = Console.ReadLine();
            while (!m.isLegalDate(end) && !end.Equals("-1"))
            {
                Console.WriteLine("Illegal date, try again.");
                end = Console.ReadLine();
            }
            Console.Write("Please enter the id of the doctor who created the treatment: ");
            String doctor = Console.ReadLine();
            while ((!m.DoctorAlreadyExists(doctor) || doctor.Length != 9) && !doctor.Equals("-1"))
            {
                Console.WriteLine("Doctor does not exist or id is illegal, try again.");
                doctor = Console.ReadLine();
            }
            Console.Write("Please enter the treatment's prognosis: ");
            String prog = Console.ReadLine();
            Console.Write("Please enter the treatment's prescriptions: ");
            String presc = Console.ReadLine();
            return new Treatment(id, start, end, doctor, prog, presc);
        }

        public void Continue()
        {
            Console.WriteLine("\n***********************\n");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
