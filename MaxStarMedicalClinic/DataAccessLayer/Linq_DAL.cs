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
            doctors.Add(new Doctor("111111112", "Yaniv", "Cohen", 58000, 'm'));
            doctors.Add(new Doctor("111111113", "Haim", "Cohen", 58000, 'm'));
            doctors.Add(new Doctor("111111114", "Miri", "Cohen", 58000, 'f'));
            doctors.Add(new Doctor("111111115", "Rachel", "Cohen", 58000, 'f'));
            doctors.Add(new Doctor("111111116", "Muhamad", "Cohen", 58000, 'm'));
            doctors.Add(new Doctor("111111117", "Shiri", "Cohen", 58000, 'f'));

            //init patients database
            patients = new List<Patient>();

            patients.Add(new Patient("1","Tania","Yanik","111111111",14,'f'));
            patients.Add(new Patient("2", "Dor", "Bar", "111111111", 69, 'm'));


            //visits
            visits = new List<Visit>();

            visits.Add(new Visit("101", "18/03/2014", "111111111", "1", "Need to rest"));
            visits.Add(new Visit("102", "19/03/2014", "111111112", "2", "need to sleep"));
            visits.Add(new Visit("103", "18/03/2014", "111111113", "1", "need akamol"));

            //treatments
            treatments = new List<Treatment>();

            treatments.Add(new Treatment("1", "18/03/2014", "19/03/2014", "111111111", "hyper sdhkjfs", "2 akamol"));
            treatments.Add(new Treatment("2", "18/03/2014", "25/03/2014", "111111111", "hyper glycom", "2 hydra"));
        }

        //add new doctor
        public void AddDoctor(Doctor d)
        {
            doctors.Add(d);
        }

        //add new patient
        public void AddPatient(Patient p)
        {
            patients.Add(p);
        }

        //add new visit
        public void AddVisit(Visit v)
        {
            visits.Add(v);
        }


        public List<Doctor> SearchDoctorByID(String id)
        {
            var result = from d in doctors
                         where d.ID == id
                         select d;

            return result.ToList<Doctor>();
        }


        /* ####################TREATMENT ######################*/

        //add new treatment
         public void AddTreatment(Treatment t)
        {
            treatments.Add(t);
        }

        //edit treatment
        // you can not change the start date and the patient id 
         // you can change nly the dateOfFinish or prescription or the prognosis
         public void UpdateTreatmentByIdAndStartDate(Treatment treatment)
        {
            int changed = 0;
            var result = from t in treatments
                         select t;

            foreach (Treatment t in result.ToList<Treatment>())
            {
                if (t.patientID == treatment.patientID && t.dateOfStart == treatment.dateOfStart)
                {
                    changed++;
                    //update dateOfFisnish
                    t.dateOfFinish = (treatment.dateOfFinish != "*") ? treatment.dateOfFinish : t.dateOfFinish;
                    //update prognosis
                    t.prognosis = (treatment.prognosis != "*") ? treatment.prognosis : t.prognosis;
                    //update prescriptions
                    t.prescriptions = (treatment.prescriptions != "*") ? treatment.prescriptions : t.prescriptions;

                    Console.Clear();
                    Console.WriteLine("############################################################");
                    Console.WriteLine("###########         Record Updated!!!          #############");
                    Console.WriteLine("############################################################\n");

                    break;
                }
                
            }
            if (changed == 0)
            {
                Console.Clear();
                Console.WriteLine("############################################################");
                Console.WriteLine("###########    The treatment was not found     #############");
                Console.WriteLine("############################################################");
            }



        }

        //remove treatment
         public void RemoveTreatmentByIdAndStartDate(Treatment treatment)
        {
            int changed = 0;
            var result = from t in treatments
                         select t;

            foreach (Treatment t in result.ToList<Treatment>())
            {
                if (t.patientID == treatment.patientID && t.dateOfStart == treatment.dateOfStart)
                {
                    changed++;

                    treatments.RemoveAt(changed+1);
                    Console.Clear();
                    Console.WriteLine("############################################################");
                    Console.WriteLine("###########         Record Removed!!!          #############");
                    Console.WriteLine("############################################################\n");

                    break;
                }
                
            }
            if (changed == 0)
            {
                Console.Clear();
                Console.WriteLine("############################################################");
                Console.WriteLine("###########    The treatment was not found     #############");
                Console.WriteLine("############################################################");
            }



        }
        



        //search by id
          public List<Treatment> SearchTreatmentByID(string id)
        {
            var result = from t in treatments
                         where t.patientID == id.ToString()
                         select t;

            return result.ToList<Treatment>();
        }
          public List<Treatment> printAllTreatments()
        {
            var result = from t in treatments
                         select t;

            return result.ToList<Treatment>();
        }
    }
}
