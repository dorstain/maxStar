using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackEndLayer;

namespace DataAccessLayer
{
    public interface IDAL
    {

        void AddDoctor(Doctor d);

        List<Doctor> SearchDoctorByID(String id);

        bool RemoveDoctorByID(String id);

        void EditDoctor(String id, Doctor d);

        List<Patient> GetAllDoctorsPatients(String id);

        bool DoctorAlreadyExists(String id);

        String GetDoctorIDByName(String name);

        String GetDoctorNameByID(String id);

        List<Doctor> GetAllDoctors();

        void AddPatient(Patient p);

        bool RemovePatientByID(String id);

        List<Patient> SearchPatientByID(String id);

        void EditPatient(String id, Patient p);

        void ChangeDoctor(String id);

        bool PatientAlreadyExists(String id);

        List<Visit> GetPatientVisits(string id);

        List<Treatment> GetPatientTreatments(string id);

        List<Patient> GetAllPatients();

        void AddVisit(Visit v);

        bool VisitAlreadyExists(String id);

        List<Visit> SearchVisitByID(String visitID);

        bool RemoveVisitByID(String visitID);

        void EditVisit(String id, Visit visit);

        List<Visit> GetVisitsByDate(String s);

        void AddTreatment(Treatment t);

        void EditTreatmentByIdAndStartDate(String patientID, Treatment treatment);

        bool RemoveTreatmentByIdAndStartDate(String patientID, String start);

        List<Treatment> SearchTreatmentByID(String patientID);

        List<Treatment> GetAllTreatmentsByDoctorID(String patientID);

        List<Treatment> GetAllTreatments();

        bool validate(String user, String pass);

        int getUserRank(String user);

        User SearchUserByID(string id);

        void AddUser(String id, String pass, int rank);

        void ChangePassword(String id, String pass);

        bool UserAlreadyExists(String id);
    }
}
