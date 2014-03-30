﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndLayer
{
    public class Patient
    {
        private String id;
        public String ID
        {
            get{ return id; }
            set{ id = value; }
        }
        private String firstName;
        private String lastName;
        private String mainDoctor; //id of the doctor
        public String MainDoctor
        {
            get { return mainDoctor; }
            set { mainDoctor = value; }
        }
        private char gender;
        private int age;

        public Patient(String id, String firstName, String lastName, String mainDoctor, int age, char gender){
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.mainDoctor = mainDoctor;
            this.age = age;
            this.gender = gender;
        }

        public String toString()
        {
            return " id: " + id + "\n name: " + firstName + " " + lastName + "\n gender: " + gender + "\n age: " + age;
        }

        public void mergeInfo(Patient p)
        {
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
