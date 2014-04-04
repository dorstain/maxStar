using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer;
using LogicLayer;
using DataAccessLayer;

namespace MainProg
{
    class Program
    {
        static void Main(string[] args)
        {
            Linq_DAL linq = new Linq_DAL();
            Manager m = new Manager(linq);
            PL pl = new PL(m);
            pl.Run();
        }
    }
}
