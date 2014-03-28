using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEndLayer;
using LogicLayer;

namespace PresentationLayer
{
    public class PL
    {
       private _Doctor doc;

       private _Treatments treat;

       public PL(_Doctor doc)
       {
           this.doc = doc;
       }


       public void InitTreatMent(_Treatments treat)
       {
           this.treat = treat;
       }


        public void run()
        {

            Console.WriteLine("Please choose what to do:"+
                                "\n\n\r ------------- Manage Doctors: -------------" +
                                "\n\r 11. Add" +
                                "\n\r 12. Edit" +
                                "\n\r 13. Remove" +
                                "\n\r 14. Search" +
                                "\n\r ------------- Manage Patients: -------------" +
                                "\n\r 21. Add" +
                                "\n\r 22. Edit" +
                                "\n\r 23. Remove" +
                                "\n\r 24. Search" +
                                "\n\r ------------- Manage Treatments: -------------" +
                                "\n\r 31. Add" +
                                "\n\r 32. Edit" +
                                "\n\r 33. Remove" +
                                "\n\r 34. Search" +
                                "\n\n\r  0. Exit");

            String s=Console.ReadLine();

            switch (s)
            {
                //doctors
                case "11":

                break;
                case "12":
                break;
                case "13":
                break;
                case "14":
                        Console.WriteLine("please enter doctor id");
                        foreach (Doctor d in doc.SearchDoctorByID(Console.ReadLine()))
                        {
                            Console.WriteLine("id: " + d.ID + ", name: " + d.firstName + ", gender: " + d.gender + ", salary: " + d.salary);
                        }
                        Console.WriteLine();
                break;
                //patients
                case "21":
                break;
                case "22":
                break;
                case "23":
                break;
                case "24":
                break;
                //visits
                /*case "21":
                break;
                case "22":
                break;
                case "23":
                break;
                case "24":
                break;*/
                //treatments



                case "30":
                //#######################################
                //#     print all treatments(debug)     #
                //#######################################
                        treat.printAllTreatments();
                        //back to menu
                        run();

                break;
                case "31": 
                        //#########################
                        //#     add treatment     #
                        //#########################
                        //init get data proccess
                         treat.InitGetNewTreatment();
                        //back to menu
                        run();
                        
                break;
                case "32":
                        //#########################
                        //#     edit treatment    #
                        //#########################
                          treat.InitEditModeForTreatment();
                          //back to menu
                          run();

                break;
                case "33":
                        //#########################
                        //#     remove treatment  #
                        //#########################
                        treat.InitRemoveModeForTreatment();
                        //back to menu
                        run();

                break;
                case "34":
                        //#########################
                        //#     remove treatment  #
                        //#########################
                        treat.SearchTreatmentByID();
                         //back to menu
                        Console.WriteLine("<Enter> to continue");
                        Console.ReadLine();
                        Console.Clear();
                        run();
                    
                break;

                case "0":
                System.Environment.Exit(0);
                break;

                default:
                run();
                break;
            }
            Console.WriteLine();
            run();
        }
    }
}
