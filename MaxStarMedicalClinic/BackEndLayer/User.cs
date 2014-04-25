using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEndLayer
{
    public class User
    {
        public String id;
        public String password;
        public int rank; //0 - admin, 1 - doctor, 2 - patient

        public User(String id, String password, int rank)
        {
            this.id = id;
            this.password = password;
            this.rank = rank;
        }
    }
}
