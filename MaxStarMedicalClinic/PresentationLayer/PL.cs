using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public class PL
    {
        public String GetNextCase(int type)
        {

            return "What would you like to manage?" +
                                "\n\r 1. Add" +
                                "\n\r 2. Remove" +
                                "\n\r 3. Modify" +
                                "\n\r 4. Search";
        }

        public void run()
        {
            Console.WriteLine("Please choose what to do:"+
                                "\n\r 1. Manage Doctors"+
                                "\n\r 2. Manage Patients"+
                                "\n\r 3. Manage Treatments"+
                                "\n\r 0. Exit"
                                );
            String s=Console.ReadLine();

            switch (s)
            {
                //doctors
                case "1":
                    Console.WriteLine(GetNextCase(1));
                break;
                //patients
                case "2":

                break;
                //visits
                case "3":

                break;
                //treatments
                case "4":

                break;
                case "0":
                System.Environment.Exit(0);
                break;


                default:
                run();
                break;
            }
            Console.ReadLine();
        }
    }
}
