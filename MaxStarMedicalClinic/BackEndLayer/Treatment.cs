using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndLayer
{
    public class Treatment :Mergeable
    {
        private String patientID;
        public string ID
        {
            get { return patientID; }
            set { patientID = value; }
        }
        private String dateOfStart;
        public string StartDate
        {
            get{ return dateOfStart; }
            set{ dateOfStart = value; }
        }
        private String dateOfFinish;
        private String createdByDoctor;
        public string Doctor
        {
            get { return createdByDoctor; }
            set { createdByDoctor = value; }
        }
        private String prognosis;
        private String prescriptions;

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
