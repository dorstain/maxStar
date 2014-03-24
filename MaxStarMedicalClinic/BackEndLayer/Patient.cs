using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndLayer
{
    class Patient
    {
        private String id;
        private String firstName;
        private String lastName;
        private String mainDoctor; //id of the doctor
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
    }
}
