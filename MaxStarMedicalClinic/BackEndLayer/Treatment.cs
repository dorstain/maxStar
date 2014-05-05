using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndLayer
{
    public class Treatment :Mergeable
    {
        private String patientID { get; set;}
        public string ID
        {
            get { return patientID; }
            set { patientID = value; }
        }
        private String dateOfStart { get; set; }
        public string StartDate
        {
            get{ return dateOfStart; }
            set{ dateOfStart = value; }
        }
        private String dateOfFinish { get; set; }
        private String createdByDoctor { get; set; }
        public string Doctor
        {
            get { return createdByDoctor; }
            set { createdByDoctor = value; }
        }
        private String prognosis { get; set; }
        private String prescriptions { get; set; }

        public Treatment(String patientID, String dateOfStart, String dateOfFinish, String createdByDoctor, String prognosis, String prescriptions){
            this.patientID = patientID;
            this.dateOfStart = dateOfStart;
            this.dateOfFinish = dateOfFinish;
            this.createdByDoctor = createdByDoctor;
            this.prognosis = prognosis;
            this.prescriptions = prescriptions;
        }

        public String toString()
        {
            return " id: " + patientID + "\n date of start: " + dateOfStart + "\n date of finish: " + dateOfFinish + "\n created by doctor: " + createdByDoctor + "\n prognosis: " + prognosis + "\n prescriptions: " + prescriptions;
        }

        public void mergeInfo(Mergeable m)
        {
            if (m is Mergeable)
            {
                Treatment t = (Treatment)m;
                if (!t.dateOfFinish.Equals("-1"))
                {
                    dateOfFinish = t.dateOfFinish;
                }
                if (!t.createdByDoctor.Equals("-1"))
                {
                    createdByDoctor = t.createdByDoctor;
                }
                if (!t.prognosis.Equals("-1"))
                {
                    prognosis = t.prognosis;
                }
                if (!t.prescriptions.Equals("-1"))
                {
                    prescriptions = t.prescriptions;
                }
            }
        }
    }
}
