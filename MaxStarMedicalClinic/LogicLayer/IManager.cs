using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackEndLayer;

namespace LogicLayer
{
    public interface IManager
    {
        List<Doctor> SearchDoctorByID(String id);

        void EditDoctor(String id, Doctor d);

        bool RemoveDoctorByID(String id);

        void AddDoctor(Doctor d);

        List<Doctor> GetAllDoctors();

        List<Patient> GetAllDoctorsPatients(String id);

        bool DoctorAlreadyExists(String id);

        String GetDoctorIDByName(String name);

        String GetDoctorNameByID(String id);

        List<Patient> SearchPatientByID(String id);

        void EditPatient(String id, Patient p);

        bool RemovePatientByID(String id);

        void AddPatient(Patient p);

        List<Patient> GetAllPatients();

        bool PatientAlreadyExists(string id);

        List<Visit> GetPatientVisits(string id);

        List<Treatment> GetPatientTreatments(string id);

        Treatment GetPatientLastTreatment(string id);

        bool VisitAlreadyExists(String id);

        List<Visit> SearchVisitByID(String id);

        void EditVisit(String id, Visit v);

        bool RemoveVisitByID(String id);

        void AddVisit(Visit v);

        List<Visit> GetVisitsByDate(String s);

        void AddTreatment(Treatment treatment);

        void EditTreatmentByIdAndStartDate(String id, Treatment treatment);

        bool RemoveTreatmentByIdAndStartDate(String id, String start);

        List<Treatment> SearchTreatmentByID(String id);

        List<Treatment> GetAllTreatments();

        List<Treatment> GetAllTreatmentsByDoctorID(String id);

        bool validate(String user, String pass);

        int getUserRank(String user);

        User SearchByUserID(string id);

        void AddUser(String id, String pass, int rank);

        void ChangePassword(String id, String pass);

        bool UserAlreadyExists(String id);

        bool isLegalName(String s);

        bool isLegalInt(String s, int limit);
    }
}
