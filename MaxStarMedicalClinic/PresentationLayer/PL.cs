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

        public String Menu()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t Welcome to Max Star Medical Clinic! \n " +
                              "\n\r --- Please choose what to manage: ---\n" +
                              "\n\r  1. Doctors" +
                              "\n\r  2. Patients" +
                              "\n\r  3. Visits" +
                              "\n\r  4. Treatments" +
                              "\n\n\r  0. Exit \n");

            char c = Console.ReadKey().KeyChar;  
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

        public void Run()
        {
            String s = Menu();
            Console.WriteLine();
            Console.Clear();
            switch (s)
            {
                //doctors
                case "11":
                    //###### create doctor #######
                    try
                    {
                        m.AddDoctor(CreateOrEditDoctor(1)); //create
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("One or more of the details you entered is illegal, please try again");
                    }
                    break;
                case "12":
                    //###### edit doctor #######
                    try{
                        Doctor newDoc = CreateOrEditDoctor(2); //edit
                        m.EditDoctor(newDoc.ID, newDoc);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("One or more of the details you entered is illegal, please try again");
                    }
                    break;
                case "13":
                    //###### delete doctor #######
                    Console.Write("Please enter the doctor's id that you want to remove: ");
                    String id = Console.ReadLine();
                    Console.Clear(); 
                    if (m.RemoveDoctorByID(id))
                    {
                        Console.WriteLine("Doctor removed successfully");
                    }
                    else
                    {
                        Console.WriteLine("No doctor match found");
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
                    try
                    {
                        m.AddPatient(CreateOrEditPatient(1)); //create
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("One or more of the details you entered is illegal, please try again.");
                    }
                    break;
                case "22":
                    //###### edit patient #######
                    try{
                        Patient newP = CreateOrEditPatient(2); //edit
                        m.EditPatient(newP.ID, newP);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("One or more of the details you entered is illegal, please try again");
                    }
                    break;
                case "23":
                    //###### remove patient #######
                    Console.Write("Please enter the patient's id that you want to remove: ");
                    id = Console.ReadLine();
                    Console.Clear(); 
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
                    try
                    {
                        m.AddVisit(CreateOrEditVisit(1)); //create
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("One or more of the details you entered is illegal, try again");
                    }
                    break;
                case "32":
                    //###### edit visit #######
                    try
                    {
                    Visit newVis = CreateOrEditVisit(2); //edit
                    m.EditVisit(newVis.ID, newVis);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("One or more of the details you entered is illegal, try again");
                    }
                    break;
                case "33":
                    //###### remove visit #######
                    Console.Write("Please enter the visit's id that you want to remove: ");
                    id = Console.ReadLine();
                    Console.Clear();
                    if (m.RemoveVisitByID(id))
                    {
                        Console.WriteLine("Visit has been removed successfully");
                    }
                    else
                    {
                        Console.WriteLine("No Visit was founded");
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
                    Console.Clear();
                    if (!m.isLegalDate(date))
                        Console.WriteLine("Date is illegal");
                    foreach (Visit v in m.GetVisitsByDate(date))
                    {
                        Console.WriteLine("\n***********************\n");
                        Console.WriteLine(v.toString());
                    }
                    break;
                //treatments
                case "41":
                    //###### create treatment #######
                    try
                    {
                        m.AddTreatment(CreateOrEditTreatment(1)); //create
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("One or more of the details you entered is illegal, please try again.");
                    }
                    break;
                case "42":
                    //###### edit treatment #######
                    try{
                        Treatment newT = CreateOrEditTreatment(2); //edit
                        m.EditTreatmentByIdAndStartDate(newT.ID, newT);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("One or more of the details you entered is illegal, please try again");
                    }
                    break;
                case "43":
                    //###### remove treatment #######
                    Console.Write("Please enter the patients's id whose treatment you want to remove: ");
                    id = Console.ReadLine();
                    Console.Write("Please enter the treatment's start date that you want to remove: ");
                    String start = Console.ReadLine();
                    Console.Clear(); 
                    if (m.RemoveTreatmentByIdAndStartDate(id,start))
                    {
                        Console.WriteLine("Treatment removed successfully");
                    }
                    else
                    {
                        Console.WriteLine("No treatment match found");
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
                    //###### create all doctor's treatments #######
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
                    Console.Clear();
                    Console.WriteLine("\nWrong command, please try again");
                    break;
            }
            Console.WriteLine("\n***********************\n");
            Continue();
            Run();
        }


        public Doctor CreateOrEditDoctor(int x)
        {
            if (x == 1) //create new
            {
                Console.WriteLine("Creating new doctor:\n");
            }
            else //edit
            {
                Console.WriteLine("Editing doctor:\n");
                Console.WriteLine("Enter the doctor's id that you want to edit and the details you want to change.");
                Console.WriteLine("if you don't want to change the detail, insert '-1'.\n");
            }
            Console.Write("Please enter the doctor's id: ");
            String id;
            do{
                id = Console.ReadLine();
                if (id.Equals("-1")){
                    Console.WriteLine("wrong id. try again.");
                    Run();
                    //continue;
                }
                if (x != 1 && !m.DoctorAlreadyExists(id))
                    Console.WriteLine("The doctor doesn't exists. try again.");
            }
            while(x !=1 && !m.DoctorAlreadyExists(id));
            Console.Write("Please enter the doctor's first name: ");
            String first = Console.ReadLine();
            Console.Write("Please enter the doctor's last name: ");
            String last = Console.ReadLine();
            Console.Write("Please enter the doctor's salary: ");
            String salary = Console.ReadLine();
            Console.Write("Please enter the doctor's gender (m/f): ");
            String gender = Console.ReadLine();
            if ((id.Length != 9 && !id.Equals("-1")) || (int.Parse(salary) < 0 && !salary.Equals("-1"))
                || (!gender.Equals("m") && !gender.Equals("f") && !gender.Equals("-1"))
                || (!m.isLegalName(first) && !first.Equals("-1")) || (!m.isLegalName(last) && !last.Equals("-1")))
            {
                throw new Exception();
            }    
            return new Doctor(id, first, last, int.Parse(salary), (gender.Equals("-1")) ? '1' : char.Parse(gender));
        }

        public Patient CreateOrEditPatient(int x)
        {
            if (x == 1) //create
            {
                Console.WriteLine("Creating new patient:\n");
            }
            else //edit
            {
                Console.WriteLine("Editing patient:\n");
                Console.WriteLine("Enter the patient's id that you want to edit and the details you want to change.");
                Console.WriteLine("if you don't want to change the detail, insert '-1'.\n");
            }
            Console.Write("Please enter the patient's id: ");
            String id;
            do
            {
                id = Console.ReadLine();
                if (id.Equals("-1"))
                {
                    Console.WriteLine("wrong id. try again.");
                    continue;
                }
                if (x != 1 && !m.PatientAlreadyExists(id))
                    Console.WriteLine("The patient doesn't exists. try again.");
            }
            while (x != 1 && !m.PatientAlreadyExists(id));
            Console.Write("Please enter the patient's first name: ");
            String first = Console.ReadLine();
            Console.Write("Please enter the patient's last name: ");
            String last = Console.ReadLine();
            Console.Write("Please enter the patient's main doctor id: ");
            String doctorID = Console.ReadLine();
            if (!doctorID.Equals("-1") && !m.DoctorAlreadyExists(doctorID))
            {
                Console.WriteLine("\nThe doctor does not exists\n");
                throw new Exception();
            }
            Console.Write("Please enter the patient's age: ");
            String age = Console.ReadLine();
            Console.Write("Please enter the patient's gender (m/f): ");
            String gender = Console.ReadLine();
            if ((id.Length != 9 && !id.Equals("-1")) || (int.Parse(age) < 0 && !age.Equals("-1")) ||
                (!gender.Equals("m") && !gender.Equals("f") && !gender.Equals("-1"))
                || (!m.isLegalName(first) && !first.Equals("-1")) || (!m.isLegalName(last) && !last.Equals("-1")))
            {
                throw new Exception();
            }
            return new Patient(id, first, last, doctorID, int.Parse(age), (gender.Equals("-1")) ? '1' : char.Parse(gender));
        }

        public Treatment CreateOrEditTreatment(int x)
        {
            if (x == 1)
            {
                Console.WriteLine("Creating new treatment:\n");
            }
            else
            {
                Console.WriteLine("Editing treatment:\n");
                Console.WriteLine("Enter the patient's id and the date of start of the treatment you want to edit and the details you want to change.");
                Console.WriteLine("if you don't want to change the detail, insert '-1'.\n");
            }
            Console.Write("Please enter the patient's id: ");
            String id;
            do
            {
                id = Console.ReadLine();
                if (id.Equals("-1"))
                {
                    Console.WriteLine("wrong id. try again.");
                    break;
                }
                if (x != 1 && !m.PatientAlreadyExists(id))
                    Console.WriteLine("The doctor doesn't exists. try again.");
            }
            while (x != 1 && !m.PatientAlreadyExists(id));
            Console.Write("Please enter the date of start (DD/MM/YYYY): ");
            String start = Console.ReadLine();
            Console.Write("Please enter the date of finish (DD/MM/YYYY): ");
            String finish = Console.ReadLine();
            Console.Write("Please enter the doctor's id: ");
            String doctorID = Console.ReadLine();
            if (!doctorID.Equals("-1") && !m.DoctorAlreadyExists(doctorID))
            {
                Console.WriteLine("\nThe doctor does not exists\n");
                throw new Exception();
            }
            Console.Write("Please enter the patient's prognosis: ");
            String prog = Console.ReadLine();
            Console.Write("Please enter the patient's prescriptions: ");
            String presc = Console.ReadLine();
            if ( !m.isLegalDate(start) || !m.isLegalDate(finish) || (id.Length != 9 && !id.Equals("-1")))
            {
                throw new Exception();
            }
            return new Treatment(id, start, finish, doctorID, prog, presc);
        }

        public Visit CreateOrEditVisit(int x)
        {
            if (x == 1)
            {
                Console.WriteLine("Creating new visit:");
            }
            else
            {
                Console.WriteLine("Editing visit:");
                Console.WriteLine("Enter the visit's id that you want to edit and the details you want to change.");
                Console.WriteLine("if you don't want to change the detail, insert '-1'.");
            }
            Console.WriteLine("Please enter the visit's id:");
            String id = Console.ReadLine();
            if (!m.VisitAlreadyExists(id))
            {
                Console.WriteLine("\nThe visit does not exists\n");
                throw new Exception();
            }
            Console.WriteLine("Please enter the date of the visit:");
            String date = Console.ReadLine();
            Console.WriteLine("Please enter the assigned Doctor id:");
            String doctorID = Console.ReadLine();
            if (!doctorID.Equals("-1") && !m.DoctorAlreadyExists(doctorID))
            {
                Console.WriteLine("\nThe doctor does not exists\n");
                throw new Exception();
            }
            Console.WriteLine("Please enter the patient's id:");
            String patientID = Console.ReadLine();
            if (!patientID.Equals("-1") && !m.PatientAlreadyExists(patientID))
            {
                Console.WriteLine("\nThe patient does not exists\n");
                throw new Exception();
            }
            Console.WriteLine("Please enter the doctor's notes:");
            String notes = Console.ReadLine();
            if (id.Length != 3 || (!m.isLegalDate(date) && !date.Equals("-1")))
            {
                throw new Exception();
            }
            return new Visit(id, date, doctorID, patientID, notes);
        }

        public void Continue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
