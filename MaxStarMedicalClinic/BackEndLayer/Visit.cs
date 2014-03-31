using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndLayer
{
    public class Visit : Mergeable
    {
        private String visitID;
        public String ID
        {
            get { return visitID; }
            set { visitID = value; }
        }
        private String dateOfVisit;
        public String Date
        {
            get { return dateOfVisit; }
            set { dateOfVisit = value; }
        }
        private String assignedDoctor;
        private String patientID;
        private String doctorNotes;
        //private String treatmentsMade;    DEPRACATED no need for this

        public Visit(String visitID, String dateOfVisit, String assignedDoctor, String patientID, String doctorNotes)
        {
            this.visitID = visitID;
            this.dateOfVisit = dateOfVisit;
            this.assignedDoctor = assignedDoctor;
            this.patientID = patientID;
            this.doctorNotes = doctorNotes;
        }

        public String toString()
        {
            return " id: " + visitID + "\n date of visit: " + dateOfVisit + "\n assigned doctor: " + assignedDoctor + "\n patient's id: " + patientID + "\n doctor notes: " + doctorNotes;
        }

        public void mergeInfo(Mergeable m)
        {
            if (m is Visit)
            {
                Visit v = (Visit)m;
                if (!v.visitID.Equals("-1"))
                {
                    visitID = v.visitID;
                }
                if (!v.dateOfVisit.Equals("-1"))
                {
                    dateOfVisit = v.dateOfVisit;
                }
                if (!v.assignedDoctor.Equals("-1"))
                {
                    assignedDoctor = v.assignedDoctor;
                }
                if (!v.patientID.Equals("-1"))
                {
                    patientID = v.patientID;
                }
                if (!v.doctorNotes.Equals("-1"))
                {
                    doctorNotes = v.doctorNotes;
                }
            }
        }
    }
}