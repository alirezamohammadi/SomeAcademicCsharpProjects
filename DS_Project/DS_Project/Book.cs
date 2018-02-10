using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LinkedListLibrary;

namespace DS_Project
{
    class Book
    {
        public string BookName
        {
            get { return bookName; }

            set
            {
                if (value.Length > 30)
                    bookName = value.Substring(0, 30);
                else
                    bookName = value;
            }
        }

        public string WriterName
        {
            set
            {
                if (value.Length > 30)
                    writerName = value.Substring(0, 30);
                else
                    writerName = value;
            }

            get { return writerName; }
            
        }

        public int PublicationYear
        {
            set
            {
                publicationYear = value;
            }

            get { return publicationYear; }
        }

        public int Price
        {
            get { return price; }

            set
            {
                price = value;
            }
        }

        public override string ToString()
        {
            return BookName + ", " + WriterName + ", " + PublicationYear.ToString() + ", " + Price.ToString();
        }

        private string bookName, writerName;
        int publicationYear, price;
        public void writeBooks2File()
        {
            StreamWriter sw = File.AppendText("bookFile.txt");
            sw.WriteLine(bookName);
            sw.WriteLine(writerName);
            sw.WriteLine(publicationYear);
            sw.WriteLine(price);
            sw.WriteLine("***********************");
            sw.Close();
        }
        public void writeSoldBooks2File()
        {
            StreamWriter sw = File.AppendText("soldBookFile.txt");
            sw.WriteLine(bookName);
            sw.WriteLine(writerName);
            sw.WriteLine(publicationYear);
            sw.WriteLine(price);
            sw.WriteLine("***********************");
            sw.Close();
        }
        
    }
}
