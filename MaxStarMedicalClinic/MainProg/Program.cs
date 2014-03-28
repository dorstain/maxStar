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
            _Doctor d = new _Doctor(linq);
            PL p = new PL(d);

            // this should init all 4 of them together  PL p = new PL(d, p, v, t);
            //the method InitTreatMent is temp
            // dont forget!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            _Treatments t = new _Treatments(linq);
            p.InitTreatMent(t);

            p.run();
        }
    }
}
