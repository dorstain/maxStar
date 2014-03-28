using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BackEndLayer;

namespace LogicLayer
{
    public class _Doctor
    {
        private Linq_DAL L;

        public _Doctor(Linq_DAL L)
        {
            this.L = L; 
        }

        public List<Doctor> SearchDoctorByID(String id)
        {

            return L.SearchDoctorByID(id); 
        }
    }
}
