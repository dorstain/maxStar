using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndLayer
{
    public class Treatment
    {
        public String patientID; //this is the patient id for next time i will see it!
        public String dateOfStart;
        public String dateOfFinish;
        public String createdByDoctor;
        public String prognosis;
        public String prescriptions;


        public Treatment()
        {
            this.patientID = null;
            this.dateOfStart = null;
            this.dateOfFinish = null;
            this.createdByDoctor = null;
            this.prognosis = null;
            this.prescriptions = null;
        }


        public Treatment(String patientID, String dateOfStart, String dateOfFinish, String createdByDoctor, String prognosis, String prescriptions){
            this.patientID = patientID;
            this.dateOfStart = dateOfStart;
            this.dateOfFinish = dateOfFinish;
            this.createdByDoctor = createdByDoctor;
            this.prognosis = prognosis;
            this.prescriptions = prescriptions;
        }

      


    }
}
