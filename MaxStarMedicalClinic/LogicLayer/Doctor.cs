using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    class Doctor
    {
        private String id;
        private String firstName;
        private String lastName;
        private int salary;
        private char gender;

        public Doctor(String id, String firstName, String lastName, int salary, char gender)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.salary = salary;
            this.gender = gender;
        }
    }
}
