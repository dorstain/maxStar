using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndLayer
{
    class Treatment
    {
        private String patientID;
        private String dateOfStart;
        private String dateOfFinish;
        private String createdByDoctor;
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
    }
}
