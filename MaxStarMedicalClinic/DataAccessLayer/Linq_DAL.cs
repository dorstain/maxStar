using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEndLayer;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class Linq_DAL : IDAL
    {
        public List<Doctor> doctors;
        public List<Patient> patients;
        public List<Visit> visits;
        public List<Treatment> treatments;
        public List<User> users;

        public Linq_DAL()
        {


            //init doctors database
            doctors = new List<Doctor>();

            doctors.Add(new Doctor("111111111", "Moshe", "Cohen", 58000, 'm'));
            doctors.Add(new Doctor("111111112", "Yaniv", "Cohen", 12000, 'm'));
            doctors.Add(new Doctor("111111113", "Haim", "Cohen", 17500, 'm'));
            doctors.Add(new Doctor("111111114", "Miri", "Cohen", 29700, 'f'));
            doctors.Add(new Doctor("111111115", "Rachel", "Cohen", 129000, 'f'));
            doctors.Add(new Doctor("111111116", "Tomer", "Cohen", 9650, 'm'));
            doctors.Add(new Doctor("111111117", "Shiri", "Cohen", 47000, 'f'));
         
            //login
            doctors.Add(new Doctor("2", "David", "Cohen", 47000, 'm'));

            //init patients database
           /* patients2 = new List<Patient>();

            patients.Add(new Patient("123456789", "Tania", "Yanik", "2", 14, 'f'));
            patients.Add(new Patient("223456789", "Dor", "Bar", "111111111", 69, 'm'));
            patients.Add(new Patient("323456789", "Lior", "Mor", "111111112", 21, 'f'));
            patients.Add(new Patient("423456789", "Eden", "Levi", "111111111", 25, 'm'));
            patients.Add(new Patient("523456789", "Itay", "Ron", "111111113", 37, 'm'));
            patients.Add(new Patient("623456789", "Liad", "Dekel", "111111113", 41, 'm'));
            patients.Add(new Patient("723456789", "Or", "Pill", "111111111", 88, 'f'));
            patients.Add(new Patient("823456789", "Mor", "Becker", "111111114", 10, 'f'));
            patients.Add(new Patient("923456789", "Shoval", "Gag", "111111114", 17, 'm'));
            patients.Add(new Patient("103456789", "Yuval", "Baron", "111111114", 4, 'f'));
            patients.Add(new Patient("12", "Yuval", "Baron", "111111114", 4, 'f'));
            //logins
            patients.Add(new Patient("3", "Idan", "Haviv", "111111114", 33, 'm'));

            */
            //visits
            visits = new List<Visit>();

            visits.Add(new Visit("101", "18/03/2014", "111111111", "3", "Need to rest"));
            visits.Add(new Visit("102", "19/03/2014", "111111112", "3", "need to sleep"));
            visits.Add(new Visit("103", "18/03/2014", "111111113", "3", "need akamol"));
            visits.Add(new Visit("104", "04/03/2014", "111111117", "523456789", "need to jump over cliff"));
            visits.Add(new Visit("105", "05/03/2014", "111111116", "423456789", "need to eat meat"));
            visits.Add(new Visit("106", "06/03/2014", "111111113", "623456789", "need to shower every hour"));
            visits.Add(new Visit("107", "07/03/2014", "111111114", "223456789", "need to eat fruits"));

            //treatments
            treatments = new List<Treatment>();

            treatments.Add(new Treatment("3", "18/03/2014", "19/03/2014", "111111111", "hyper sdhkjfs", "2 akamol"));
            treatments.Add(new Treatment("3", "15/03/2014", "25/03/2014", "111111112", "hyper glycom", "2 hydra"));
            treatments.Add(new Treatment("123456789", "25/02/2013", "19/03/2014", "111111117", "hyper sdhkjfs", "2 akamol"));
            treatments.Add(new Treatment("223456789", "18/03/2010", "19/03/2012", "111111117", "hyper sdhkjfs", "2 akamol"));
            treatments.Add(new Treatment("323456789", "18/03/2014", "19/03/2014", "111111115", "hyper sdhkjfs", "2 akamol"));
            treatments.Add(new Treatment("323456789", "18/03/2013", "19/03/2014", "111111116", "hyper sdhkjfs", "2 akamol"));
            treatments.Add(new Treatment("623456789", "18/03/2013", "19/03/2013", "111111111", "hyper sdhkjfs", "2 akamol"));
            treatments.Add(new Treatment("723456789", "18/03/2012", "25/03/2012", "111111113", "hyper glycom", "2 hydra"));
            treatments.Add(new Treatment("723456789", "18/03/2009", "25/03/2011", "111111114", "hyper glycom", "2 hydra"));
            treatments.Add(new Treatment("823456789", "18/03/2014", "25/03/2014", "111111116", "hyper glycom", "2 hydra"));
            treatments.Add(new Treatment("923456789", "18/03/2005", "25/03/2014", "111111112", "hyper glycom", "2 hydra"));
            treatments.Add(new Treatment("103456789", "18/03/2014", "25/03/2014", "111111113", "hyper glycom", "2 hydra"));

            //users
            users = new List<User>();

            users.Add(new User("206295131", "ccccccbgbfh", 0));
            users.Add(new User("123456789", "ccccccbgbfh", 1));
            users.Add(new User("151515151", "ccccccbgbfh", 2));
            users.Add(new User("1", "p", 0));
            users.Add(new User("2", "p", 1));
            users.Add(new User("3", "p", 2));
            users.Add(new User("12", "12", 2));
        }


        public void runSql(String sql)
        {
            // ----------sql -------------

            string cs = @"server=37.142.52.107;user id=root;database=maxStar;persistsecurityinfo=True";

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Prepare();


                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

            }

        }

        /*
         * 0  - doctors
         * 1  - patients
         * 2  - visits
         * 3  - treatments
         * 4  - users
         */
        public List<Doctor> runSqlSelectDoctors(String sql, Object dataStracture)
        {
             string cs = @"server=37.142.52.107;user id=root;database=maxStar;persistsecurityinfo=True";

            MySqlConnection conn = null;
            MySqlDataReader rdr = null;

            String st = "";
            try 
            {
                conn = new MySqlConnection(cs);
                conn.Open();
        
                string stm = sql;
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();


                //create stracture
                doctors = new List<Doctor>();


                while (rdr.Read()) 
                {
                 doctors.Add(new Doctor(rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetChar(4)));
                }

                return doctors;
          

            } catch (MySqlException ex) 
            {
                Console.WriteLine("Error: {0}",  ex.ToString());

            } finally 
            {
                if (rdr != null) 
                {
                    rdr.Close();
                }

                if (conn != null) 
                {
                    conn.Close();
                }

            }
            return doctors;
        }





        //----------- DOCTOR METHODS -------------

        //add new doctor
        public void AddDoctor(Doctor d)
        {
            //old & busty
           // doctors.Add(d);

            //cool & awsome!
            String sql = "INSERT INTO doctors(id, firstName, lastName, salary, gender) VALUES('"+ d.id +"', '"+d.firstName+"', '"+d.lastName+"', '"+d.salary+"', '"+d.gender+"')";
            runSql(sql);

        }

        public List<Doctor> SearchDoctorByID(String id)
        {

           var result =  runSqlSelect("SELECT * FROM doctors WHERE id="+id, doctors);
           return result.ToList<Doctor>();

        }

        public bool RemoveDoctorByID(String id)
        {
            bool isRemoved = false;

            var result = from d in doctors
                         where d.id == id
                         select d;

            Doctor[] a = result.ToArray();

            for (int i = 0; i < a.Length; i++)
            {
                isRemoved = doctors.Remove(a[i]);
                String sql = "DELETE FROM doctors WHERE id="+id+" ";
                runSql(sql);
            }

            if (isRemoved)
            {
                ChangeDoctor(id);
            }

            return isRemoved;
        }

        public void EditDoctor(String id, Doctor d)
        {

            //cool & awsome!
            String sql = "UPDATE doctors SET  firstName = '" + d.firstName + "', lastName = '" + d.lastName + "', salary '" + d.salary + "' , gender '" + d.gender + "'  WHERE id='"+id+"'";
            runSql(sql);

        }

        public List<Patient> GetAllDoctorsPatients(String id)
        {
            var result = from p in patients
                         where p.mainDoctor.Equals(id)
                         select p;

            return result.ToList();
        }

        public bool DoctorAlreadyExists(String id)
        {
            var result = from d in doctors
                         where d.id.Equals(id)
                         select d;
            Doctor[] resultArray = result.ToArray<Doctor>();

            if (resultArray.Length == 0)
                return false;
            return true;
        }

        public String GetDoctorIDByName(String name)
        {
            var result = from d in doctors
                         where d.name.Equals(name)
                         select d;
            Doctor[] resultArray = result.ToArray<Doctor>();

            return resultArray[0].id;
        }

        public String GetDoctorNameByID(String id)
        {
            var result = from d in doctors
                         where d.id.Equals(id)
                         select d;
            Doctor[] resultArray = result.ToArray<Doctor>();

            return resultArray[0].name;
        }

        public List<Doctor> GetAllDoctors()
        {
            return doctors;
        }

        //----------- PATIENT METHODS -------------

        //add new patient
        public void AddPatient(Patient p)
        {
            patients.Add(p);
        }

        public bool RemovePatientByID(String id)
        {
            bool isRemoved = false;

            var result = from p in patients
                         where p.id == id
                         select p;

            Patient[] a = result.ToArray();

            for (int i = 0; i < a.Length; i++)
            {
                isRemoved = patients.Remove(a[i]);
            }

            return isRemoved;
        }

        public List<Patient> SearchPatientByID(String id)
        {
            var result = from p in patients
                         where p.id == id
                         select p;

            return result.ToList<Patient>();
        }

        public void EditPatient(String id, Patient p)
        {
            List<Patient> pat = SearchPatientByID(id);
            foreach (Patient c in pat)
            {
                c.mergeInfo(p);
            }
        }

        public void ChangeDoctor(String id)
        {
            var result = from p in patients
                         where p.mainDoctor.Equals(id)
                         select p;

            foreach (Patient p in result)
            {
                p.mergeInfo(new Patient("-1", "-1", "-1", doctors.First<Doctor>().id, -1, '1'));
            }

        }

        public bool PatientAlreadyExists(String id)
        {
            var result = from p in patients
                         where p.id.Equals(id)
                         select p;

            Patient[] resultArray = result.ToArray<Patient>();

            if (resultArray.Length == 0)
                return false;
            return true;
        }

        public List<Visit> GetPatientVisits(string id)
        {
            var result = from v in visits
                         where v.patientID.Equals(id)
                         select v;
            return result.ToList<Visit>();
        }

        public List<Treatment> GetPatientTreatments(string id)
        {
            var result = from t in treatments
                         where t.patientID.Equals(id)
                         select t;
            return result.ToList<Treatment>();
        }

        public List<Patient> GetAllPatients()
        {
            return patients;
        }

        //----------- VISIT METHODS -------------

        //add new visit
        public void AddVisit(Visit v)
        {
            visits.Add(v);
        }

        public bool VisitAlreadyExists(String id)
        {
            var result = from v in visits
                         where v.id.Equals(id)
                         select v;

            Visit[] resultArray = result.ToArray<Visit>();

            if (resultArray.Length == 0)
                return false;
            return true;
        }

        public List<Visit> SearchVisitByID(String visitID)
        {
            var result = from v in visits
                         where v.id.Equals(visitID)
                         select v;

            return result.ToList<Visit>();
        }

        public bool RemoveVisitByID(String visitID)
        {
            bool isRemoved = false;

            var result = from v in visits
                         where v.id.Equals(visitID)
                         select v;

            Visit[] a = result.ToArray();

            for (int i = 0; i < a.Length; i++)
            {
                isRemoved = visits.Remove(a[i]);
            }

            return isRemoved;
        }

        public void EditVisit(String id, Visit visit)
        {
            List<Visit> tmp = SearchVisitByID(id);
            foreach (Visit v in tmp)
            {
                v.mergeInfo(visit);
            }
        }

        public List<Visit> GetVisitsByDate(String s)
        {
            var result = from v in visits
                         where v.dateOfVisit.Equals(s)
                         select v;

            return result.ToList<Visit>();
        }

        //----------- TREATMENT METHODS -------------

        //add new treatment
        public void AddTreatment(Treatment t)
        {
            treatments.Add(t);
        }

        public void EditTreatmentByIdAndStartDate(String patientID, Treatment treatment)
        {
            var result = from t in SearchTreatmentByID(patientID)
                         where t.dateOfStart.Equals(treatment.dateOfStart)
                         select t;

            List<Treatment> tre = result.ToList<Treatment>();

            foreach (Treatment t in tre)
            {
                t.mergeInfo(treatment);
            }
        }

        public bool RemoveTreatmentByIdAndStartDate(String patientID, String start)
        {
            bool removed = false;

            var result = from t in treatments
                         where t.patientID.Equals(patientID) && t.dateOfStart.Equals(start)
                         select t;

            Treatment[] a = result.ToArray<Treatment>();

            foreach (Treatment t in a)
            {
                removed = treatments.Remove(t);
            }

            return removed;
        }

        public List<Treatment> SearchTreatmentByID(String patientID)
        {
            var result = from t in treatments
                         where t.patientID.Equals(patientID)
                         select t;

            return result.ToList<Treatment>();
        }

        public List<Treatment> GetAllTreatmentsByDoctorID(String patientID)
        {
            var result = from t in treatments
                         where t.createdByDoctor.Equals(patientID)
                         select t;

            return result.ToList<Treatment>();
        }

        public List<Treatment> GetAllTreatments()
        {
            var result = from t in treatments
                         select t;

            return result.ToList<Treatment>();
        }

        //----------- USERS METHODS -------------

        public bool validate(String user, String pass)
        {
            var result = from u in users
                         where u.id.Equals(user) && u.password.Equals(pass)
                         select u;

            return ((result.ToArray()).Length > 0); //found matching user
        }

        //return user rank
        public int getUserRank(String user)
        {
            var result = from u in users
                         where u.id.Equals(user)
                         select u;

            return ((result.ToList<User>()).First()).rank; //found matching user
        }

        public User SearchUserByID(string id)
        {
            var result = from u in users
                         where u.id.Equals(id)
                         select u;
            return result.ElementAt(0);
        }

        public void AddUser(String id, String pass, int rank)
        {
            users.Add(new User(id, pass, rank));
        }

        public void ChangePassword(String id, String pass)
        {
            var user = from u in users
                       where u.id.Equals(id)
                       select u;

            foreach (User usr in user)
            {
                usr.password = pass;
            }

        }

        public bool UserAlreadyExists(String id)
        {
            var user = from u in users
                       where u.id.Equals(id)
                       select u;

            List<User> usr = user.ToList<User>();

            return usr.Count != 0;
        }
    }
}
