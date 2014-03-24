using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public class PL
    {
        public void run()
        {
            Console.WriteLine("Please choose what to do:"+
                "\n\r 1. Manage Doctors"+
                "\n\r 2. Manage Patients"+
                "\n\r 3. Manage Treatments");
            String s=Console.ReadLine();
            Console.WriteLine("What would you like to manage?" +
                    "\n\r 1. Add" +
                    "\n\r 2. Remove" +
                    "\n\r 3. Modify" +
                    "\n\r 4. Search");
            s = s+Console.ReadLine();
            switch (s)
            {
                case "11": ; break;
                case "12": ; break;
                case "13": ; break;
                case "14": ; break;
                case "21": Console.WriteLine("bhasdsa") ; break;
                case "22": ; break;
                case "23": ; break;
                case "24": ; break;
                case "31": ; break;
                case "32": ; break;
                case "33": ; break;
                case "34": ; break;
                default: ; break;
            }
            Console.ReadLine();
        }
    }
}
