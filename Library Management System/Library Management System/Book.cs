using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Book
    {
        public string Name
        {
            set
            {
                name = value;
            }

            get
            {
                return name;
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

        public string Writer
        {
            set
            {
                writer = value;
            }

            get
            {
                return writer;
            }
        }

        public string Publisher
        {
            set
            {
                publisher = value;
            }

            get
            {
                return publisher;
            }
        }

        public int PublicationYear
        {
            set
            {
                publicationYear = value;
            }

            get
            {
                return publicationYear;
            }
        }

        public int TotalNumber
        {
            set
            {
                totalNumber = value;
            }

            get
            {
                return totalNumber;
            }
        }

        public int AvailableNumber
        {
            set
            {
                availableNumber = value;
            }

            get
            {
                return availableNumber;
            }
        }

        public DateTime Registration
        {
            set
            {
                registration = value;
            }

            get
            {
                return registration;
            }
        }

        private string name, id, writer, publisher;
        int publicationYear, totalNumber, availableNumber;
        private DateTime registration;

    }
}
