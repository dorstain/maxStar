﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndLayer
{
    public class Patient : Mergeable
    {
        public String id { get; set; }
        public String firstName{ get; set; }
        public String lastName{ get; set; }
        public String mainDoctor{ get; set; } //id of the doctor
        public char gender{ get; set; }
        public int age{ get; set; }

        public Patient(String id, String firstName, String lastName, String mainDoctor, int age, char gender){
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.mainDoctor = mainDoctor;
            this.age = age;
            this.gender = gender;
        }
        public Patient()
        {
            this.id = null;
            this.firstName = null;
            this.lastName = null;
            this.mainDoctor = null;
            this.age = 0;
            this.gender = 'm';
        }
        public String toString()
        {
            return " id: " + id + "\n name: " + firstName + " " + lastName + "\n gender: " + gender + "\n age: " + age;
        }

        public String getName()
        {
            return firstName + " " + lastName;
        }

        public String getAge()
        {
            return this.age+"";
        }

        public String getGender()
        {
            return ((gender == 'm') ? "Male" : "Female");
        }

        public void mergeInfo(Mergeable m)
        {
            if (m is Patient)
            {
                Patient p = (Patient)m;
                if (!p.firstName.Equals("-1"))
                {
                    firstName = p.firstName;
                }
                if (!p.lastName.Equals("-1"))
                {
                    lastName = p.lastName;
                }
                if (!p.mainDoctor.Equals("-1"))
                {
                    mainDoctor = p.mainDoctor;
                }
                if (p.age != -1)
                {
                    age = p.age;
                }
                if (p.gender != '1')
                {
                    gender = p.gender;
                }
            }
        }
    }
}
