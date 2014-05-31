using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndLayer
{
    public class Visit : Mergeable
    {
        public String id { get; set; }
        public String dateOfVisit { get; set; }
        public String assignedDoctor { get; set; }
        public String patientID { get; set; }
        public String doctorNotes { get; set; }
        //private String treatmentsMade;    DEPRACATED no need for this

        public Visit(String id, String dateOfVisit, String assignedDoctor, String patientID, String doctorNotes)
        {
            this.id = id;
            this.dateOfVisit = dateOfVisit;
            this.assignedDoctor = assignedDoctor;
            this.patientID = patientID;
            this.doctorNotes = doctorNotes;
        }

        public String toString()
        {
            return " id: " + id + "\n date of visit: " + dateOfVisit + "\n assigned doctor: " + assignedDoctor + "\n patient's id: " + patientID + "\n doctor notes: " + doctorNotes;
        }

        public void mergeInfo(Mergeable m)
        {
            if (m is Visit)
            {
                Visit v = (Visit)m;
                if (!v.id.Equals("-1"))
                {
                    id = v.id;
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