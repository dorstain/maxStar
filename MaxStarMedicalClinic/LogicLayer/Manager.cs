using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackEndLayer;
using DataAccessLayer;

namespace LogicLayer
{
    public class Manager
    {
        private Linq_DAL db;

        public Manager(Linq_DAL db)
        {
            this.db = db; 
        }

        // --------------- Doctor Methods -----------------

        public List<Doctor> SearchDoctorByID(String id)
        {
            return db.SearchDoctorByID(id); 
        }

        public void EditDoctor(String id, Doctor d)
        {
            db.EditDoctor(id, d);
        }

        public bool RemoveDoctorByID(String id)
        {
            return db.RemoveDoctorByID(id);
        }

        public void AddDoctor(Doctor d)
        {
            db.AddDoctor(d);
        }

        public List<Doctor> GetAllDoctors()
        {
            return db.doctors;
        }

        public List<Patient> GetAllDoctorsPatients(String id)
        {
            return db.GetAllDoctorsPatients(id);
        }

        public bool DoctorAlreadyExists(String id)
        {
            return db.DoctorAlreadyExists(id);
        }

        public String GetDoctorIDByName(String name)
        {
            return db.GetDoctorIDByName(name);
        }

        public String GetDoctorNameByID(String id)
        {
            return db.GetDoctorNameByID(id);
        }

        // --------------- Patient Methods -----------------

        public List<Patient> SearchPatientByID(String id)
        {
            return db.SearchPatientByID(id);
        }

        public void EditPatient(String id, Patient p)
        {
            db.EditPatient(id, p);
        }

        public bool RemovePatientByID(String id)
        {
            return db.RemovePatientByID(id);
        }

        public void AddPatient(Patient p)
        {
            db.AddPatient(p);
        }

        public List<Patient> GetAllPatients()
        {
            return db.patients;
        }

        public bool PatientAlreadyExists(String id)
        {
            return db.PatientAlreadyExists(id);
        }

        // --------------- Visit Methods -----------------

        public bool VisitAlreadyExists(String id)
        {
            return db.VisitAlreadyExists(id);
        }

        public List<Visit> SearchVisitByID(String id)
        {
            return db.SearchVisitByID(id);
        }

        public void EditVisit(String id, Visit v)
        {
            db.EditVisit(id, v);
        }

        public bool RemoveVisitByID(String id)
        {
            return db.RemoveVisitByID(id);
        }

        public void AddVisit(Visit v)
        {
            db.AddVisit(v);
        }

        public List<Visit> GetVisitsByDate(String s)
        {
            return db.GetVisitsByDate(s);
        }

        // --------------- Treatment Methods -----------------

        public void AddTreatment(Treatment treatment)
        {

            db.AddTreatment(treatment);
        }

        public void EditTreatmentByIdAndStartDate(String id, Treatment treatment)
        {

            db.EditTreatmentByIdAndStartDate(id, treatment);
        }

        public bool RemoveTreatmentByIdAndStartDate(String id, String start)
        {

            return db.RemoveTreatmentByIdAndStartDate(id, start);
        }

        public List<Treatment> SearchTreatmentByID(String id)
        {
            return db.SearchTreatmentByID(id);
        }

        public List<Treatment> GetAllTreatments()
        {
            return db.GetAllTreatments();
        }

        public List<Treatment> GetAllTreatmentsByDoctorID(String id)
        {
            return db.GetAllTreatmentsByDoctorID(id);
        }

        // --------------- User Methods -----------------

        public bool validate(String user, String pass)
        {
            return db.validate(user, pass);
        }

        public List<User> getUserRank(String user)
        {
            return db.getUserRank(user);
        }
        // --------------- General Methods -----------------

        public bool isLegalName(String s)
        {
            String first = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            String other = "abcdefghijklmnopqrstuvwxyz-";
            if (s.Equals("") || first.IndexOf(s[0]) < 0)
                return false;
            for (int i = 1; i < s.Length; i++)
            {
                if ((first+other).IndexOf(s[i]) < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool isLegalInt(String s, int limit)
        {
            try
            {
                int tmp = int.Parse(s);
                if (tmp < limit)
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool isLegalDate(String s)
        {
            bool ans = true;
            String[] date = s.Split('/');
            if (date.Length != 3)
                ans = false;
            else
            {
                int day = int.Parse(date[0]);
                int month = int.Parse(date[1]);
                String year = date[2];
                if (day < 1 || day > 31 || month < 1 || month > 12 || year.Length != 4)
                {
                    ans = false;
                }
            }
            return ans;
        }
    }
}
