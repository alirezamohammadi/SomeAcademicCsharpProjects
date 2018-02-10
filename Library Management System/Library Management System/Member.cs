using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Member
    {
        public string FirstName
        {
            set
            {
                firstName = value;
            }

            get
            {
                return firstName;
            }
        }

        public string LastName
        {
            set
            {
                lastName = value;
            }

            get
            {
                return lastName;
            }
        }

        public string NationalCode
        {
            set
            {
                nationalCode = value;
            }

            get
            {
                return nationalCode;
            }
        }


        public string Id
        {
            set
            {
                id = value;
            }

            get
            {
                return id;
            }
        }

        public DateTime RegisteryDate
        {
            set
            {
                registeryDate = value;
            }

            get
            {
                return registeryDate;
            }
        }

        public int Liability
        {
            set
            {
                liability = value;
            }

            get
            {
                return liability;
            }
        }

        public List<string> Loaned
        {
            set
            {
                loaned = value;
            }

            get
            {
                return loaned;
            }
        }

        private string firstName, lastName, nationalCode, id;
        private DateTime registeryDate;
        List<string> loaned = new List<string>();
        private int liability;
        
    }
}
