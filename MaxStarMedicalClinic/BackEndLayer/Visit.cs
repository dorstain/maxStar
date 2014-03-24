using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndLayer
{
    class Visit
    {
        private String visitID;
        private String dateOfVisit;
        private String assignedDoctor;
        private String patientID;
        private String doctorNotes;
        private String treatmentsMade;

        public Visit(String visitID, String dateOfVisit, String assignedDoctor, String patientID, String doctorNotes, String treatmentsMade)
        {
            this.visitID = visitID;
            this.dateOfVisit = dateOfVisit;
            this.assignedDoctor = assignedDoctor;
            this.patientID = patientID;
            this.doctorNotes = doctorNotes;
            this.treatmentsMade = treatmentsMade;
        }

        
    }
}
