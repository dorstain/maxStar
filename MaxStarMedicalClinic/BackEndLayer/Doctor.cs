using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndLayer
{
    public class Doctor
    {
        public String id { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String name { get; set; }
        public int salary { get; set; }
        public char gender { get; set; }

        public Doctor(String id, String firstName, String lastName, int salary, char gender)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.salary = salary;
            this.gender = gender;
            this.name = firstName + " " + lastName;
        }

        public String toString()
        {
            return " id: " + id + "\n name: " + firstName + " " + lastName + "\n salary: " + salary + "\n gender: " + gender;
        }

        public String getName()
        {
            return name;
        }

        public void mergeInfo(Doctor d)
        {
            if (!d.firstName.Equals("-1"))
            {
                firstName = d.firstName;
            }
            if (!d.lastName.Equals("-1"))
            {
                lastName = d.lastName;
            }
            if (d.salary != -1)
            {
                salary = d.salary;
            }
            if (d.gender != '1')
            {
                gender = d.gender;
            }
        }
    }
}
