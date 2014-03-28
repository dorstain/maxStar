using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndLayer
{
    public class Doctor
    {
        private String id;
        public String firstName;
        public String lastName;
        public int salary;
        public char gender;

        public Doctor(String id, String firstName, String lastName, int salary, char gender)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.salary = salary;
            this.gender = gender;
        }

        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }
}
