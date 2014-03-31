using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEndLayer;

namespace DataAccessLayer
{
    public class Linq_DAL
    {
        public List<Doctor> doctors;
        public List<Patient> patients;
        public List<Visit> visits;
        public List<Treatment> treatments;

        public Linq_DAL()
        {
            //init doctors database
            doctors = new List<Doctor>();

            doctors.Add(new Doctor("111111111","Moshe","Cohen",58000,'m'));
            doctors.Add(new Doctor("111111112", "Yaniv", "Cohen", 12000, 'm'));
            doctors.Add(new Doctor("111111113", "Haim", "Cohen", 17500, 'm'));
            doctors.Add(new Doctor("111111114", "Miri", "Cohen", 29700, 'f'));
            doctors.Add(new Doctor("111111115", "Rachel", "Cohen", 129000, 'f'));
            doctors.Add(new Doctor("111111116", "Muhamad", "Cohen", 9650, 'm'));
            doctors.Add(new Doctor("111111117", "Shiri", "Cohen", 47000, 'f'));

            //init patients database
            patients = new List<Patient>();

            patients.Add(new Patient("123456789","Tania","Yanik","111111111",14,'f'));
            patients.Add(new Patient("223456789", "Dor", "Bar", "111111111", 69, 'm'));
            patients.Add(new Patient("323456789", "Lior", "Mor", "111111112", 21, 'f'));
            patients.Add(new Patient("423456789", "Eden", "Levi", "111111111", 25, 'm'));
            patients.Add(new Patient("523456789", "Itay", "Ron", "111111113", 37, 'm'));
            patients.Add(new Patient("623456789", "Liad", "Dekel", "111111113", 41, 'm'));
            patients.Add(new Patient("723456789", "Or", "Pill", "111111111", 88, 'f'));
            patients.Add(new Patient("823456789", "Mor", "Becker", "111111114", 10, 'f'));
            patients.Add(new Patient("923456789", "Shoval", "Gag", "111111114", 17, 'm'));
            patients.Add(new Patient("103456789", "Yuval", "Baron", "111111114", 4, 'f'));


            //visits
            visits = new List<Visit>();

            visits.Add(new Visit("101", "18/03/2014", "111111111", "123456789", "Need to rest"));
            visits.Add(new Visit("102", "19/03/2014", "111111112", "523456789", "need to sleep"));
            visits.Add(new Visit("103", "18/03/2014", "111111113", "103456789", "need akamol"));
            visits.Add(new Visit("104", "04/03/2014", "111111117", "523456789", "need to jump over cliff"));
            visits.Add(new Visit("105", "05/03/2014", "111111116", "423456789", "need to eat meat"));
            visits.Add(new Visit("106", "06/03/2014", "111111113", "623456789", "need to shower every hour"));
            visits.Add(new Visit("107", "07/03/2014", "111111114", "223456789", "need to eat fruits"));

            //treatments
            treatments = new List<Treatment>();

            treatments.Add(new Treatment("123456789", "18/03/2014", "19/03/2014", "111111111", "hyper sdhkjfs", "2 akamol"));
            treatments.Add(new Treatment("123456789", "15/03/2014", "25/03/2014", "111111112", "hyper glycom", "2 hydra"));
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
        }

        //----------- DOCTOR METHODS -------------

        //add new doctor
        public void AddDoctor(Doctor d)
        {
            doctors.Add(d);
        }

        public List<Doctor> SearchDoctorByID(String id)
        {
            var result = from d in doctors
                         where d.ID == id
                         select d;

            return result.ToList<Doctor>();
        }

        public bool RemoveDoctorByID(String id)
        {
            bool isRemoved=false;

            var result = from d in doctors
                         where d.ID == id
                         select d;

            Doctor[] a = result.ToArray();

            for(int i=0;i<a.Length; i++){
                isRemoved = doctors.Remove(a[i]);
            }

            if (isRemoved)
            {
                ChangeDoctor(id);
            }

            return isRemoved;
        }

        public void EditDoctor(String id, Doctor d)
        {
            List<Doctor> doc = SearchDoctorByID(id);
            foreach (Doctor c in doc)
            {
                c.mergeInfo(d);
            }
        }

        public List<Patient> GetAllDoctorsPatients(String id)
        {
            var result = from p in patients
                         where p.MainDoctor.Equals(id)
                         select p;

            return result.ToList();
        }

        public bool DoctorAlreadyExists(String id)
        {
            var result = from d in doctors
                         where d.ID.Equals(id)
                         select d;
            Doctor[] resultArray = result.ToArray<Doctor>();

            if (resultArray.Length == 0)
                return false;
            return true;
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
                         where p.ID == id
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
                         where p.ID == id
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
                         where p.MainDoctor.Equals(id)
                         select p;

            foreach (Patient p in result)
            {
                p.mergeInfo(new Patient("-1", "-1", "-1", doctors.First<Doctor>().ID, -1, '1'));
            }

        }

        public bool PatientAlreadyExists(String id)
        {
            var result = from p in patients
                         where p.ID.Equals(id)
                         select p;
            
            Patient[] resultArray = result.ToArray<Patient>();

            if (resultArray.Length == 0)
                return false;
            return true;
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
                         where v.ID.Equals(id)
                         select v;

            Visit[] resultArray = result.ToArray<Visit>();

            if (resultArray.Length == 0)
                return false;
            return true;
        }

        public List<Visit> SearchVisitByID(String visitID)
        {
            var result = from v in visits
                         where v.ID == visitID
                         select v;

            return result.ToList<Visit>();
        }

        public bool RemoveVisitByID(String visitID)
        {
            bool isRemoved = false;

            var result = from v in visits
                         where v.ID == visitID
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
                         where v.Date.Equals(s)
                         select v;

            return result.ToList<Visit>();
        }

        //----------- TREATMENT METHODS -------------

        //add new treatment
        public void AddTreatment(Treatment t)
        {
            treatments.Add(t);
        }

        public void EditTreatmentByIdAndStartDate(String id, Treatment treatment)
        {
            var result = from t in SearchTreatmentByID(id)
                         where t.StartDate.Equals(treatment.StartDate)
                         select t;

            List<Treatment> tre = result.ToList<Treatment>();

            foreach (Treatment t in tre)
            {
                t.mergeInfo(treatment);
            }
        }

        public bool RemoveTreatmentByIdAndStartDate(String id, String start)
        {
            bool removed = false;

            var result = from t in treatments
                         where t.ID.Equals(id) && t.StartDate.Equals(start)
                         select t;

            Treatment[] a = result.ToArray<Treatment>();

            foreach (Treatment t in a)
            {
                removed = treatments.Remove(t);
            }

            return removed;
        }

        public List<Treatment> SearchTreatmentByID(String id)
        {
            var result = from t in treatments
                         where t.ID.Equals(id)
                         select t;

            return result.ToList<Treatment>();
        }

        public List<Treatment> GetAllTreatmentsByDoctorID(String id)
        {
            var result = from t in treatments
                         where t.Doctor.Equals(id)
                         select t;

            return result.ToList<Treatment>();
        }

        public List<Treatment> GetAllTreatments()
        {
            var result = from t in treatments
                         select t;

            return result.ToList<Treatment>();
        }

    }
}
