using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BackEndLayer;


namespace LogicLayer
{
    public class _Treatments
    {
        private Linq_DAL L;

        public _Treatments(Linq_DAL L)
        {
            this.L = L;
        }
        public void addNewTreatment(Treatment treatment)
        {

            L.AddTreatment(treatment);
        }
        public void UpdateTreatmentByIdAndStartDate(Treatment treatment)
        {

            L.UpdateTreatmentByIdAndStartDate(treatment);
        }

        public void RemoveTreatmentByIdAndStartDate(Treatment treatment)
        {

            L.RemoveTreatmentByIdAndStartDate(treatment);
        }
        
        public void SearchTreatmentByID()
        {
            Console.Clear();
            printButifulTitle("Search patient treatments by id", true);

            Console.WriteLine("please enter patient id:");
            String id = Console.ReadLine();

            foreach (Treatment t in L.SearchTreatmentByID(id))
            {
                Console.WriteLine(" id: " + t.patientID + "\n startDate: " + t.dateOfStart + "\n endDate: " + t.dateOfFinish + "\n doctorId: " + t.createdByDoctor + "\n prognosis: " + t.prognosis + "\n prescription: " + t.prescriptions + "\n\n\n");

            }

        }






        //print all treatments  //code 30 debug purpse
        public void printAllTreatments()
        {
            Console.Clear();
            foreach (Treatment t in L.printAllTreatments())
            {
                Console.WriteLine(" id: " + t.patientID + "\n startDate: " + t.dateOfStart + "\n endDate: " + t.dateOfFinish + "\n doctorId: " + t.createdByDoctor + "\n prognosis: " + t.prognosis + "\n prescription: " + t.prescriptions + "\n\n\n");
            }

        }



        public void InitGetNewTreatment()
        {
            Console.Clear();
            Treatment TempTreatment = new Treatment();
            printButifulTitle("Add New Treatment");
            //get data from user
            Console.WriteLine("please enter patient id ");
            TempTreatment.patientID = Console.ReadLine();
            Console.WriteLine("please enter dateOfStart ");
            TempTreatment.dateOfStart = Console.ReadLine();
            Console.WriteLine("please enter dateOfFinish");
            TempTreatment.createdByDoctor = Console.ReadLine();
            Console.WriteLine("please enter doctor id ");
            TempTreatment.createdByDoctor = Console.ReadLine();
            Console.WriteLine("please enter prognosis ");
            TempTreatment.prognosis = Console.ReadLine();
            Console.WriteLine("please enter prescriptions ");
            TempTreatment.prescriptions = Console.ReadLine();
            Console.Clear();
            printButifulTitle("Action saved successfuly");
            addNewTreatment(TempTreatment);

        }


        public void InitEditModeForTreatment()
        {
            Console.Clear();
            printButifulTitle("Edit/Update Treatment", true);
            printButifulTitle("to skip reocrd type * ", false);
            Treatment TempTreatment = new Treatment();

            Console.WriteLine("please enter patient id ");
            TempTreatment.patientID = Console.ReadLine();
            Console.WriteLine("please enter dateOfStart ");
            TempTreatment.dateOfStart = Console.ReadLine();
            Console.WriteLine("please enter dateOfFinish");
            TempTreatment.dateOfFinish = Console.ReadLine();
            Console.WriteLine("please enter prognosis ");
            TempTreatment.prognosis = Console.ReadLine();
            Console.WriteLine("please enter prescriptions ");
            TempTreatment.prescriptions = Console.ReadLine();


            UpdateTreatmentByIdAndStartDate(TempTreatment);
            
        }

          public void InitRemoveModeForTreatment()
        {
            Console.Clear();
            printButifulTitle("Remove Treatment", true);
            Treatment TempTreatment = new Treatment();

            Console.WriteLine("please enter patient id ");
            TempTreatment.patientID = Console.ReadLine();
            Console.WriteLine("please enter dateOfStart ");
            TempTreatment.dateOfStart = Console.ReadLine();

            RemoveTreatmentByIdAndStartDate(TempTreatment);
            
        }      


















        public void printButifulTitle(String Title, Boolean cleanConsole = true)
        {
            String pad = "";
            if (Title.Count() < 17)
            {
                int padding = (17 - Title.Count()) / 2;
                for (int i = 0; i < padding; i++)
                    pad = pad + " ";
            }
            Title = pad + Title + pad;
            if (cleanConsole)
                Console.Clear();
            
            Console.WriteLine("############################################");
            Console.WriteLine("#            " + Title + "             ");
            Console.WriteLine("############################################");
        }



    }
}
