using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DS_Project
{
    public class Person
    {
        private string first_name;
        private string last_name;
        private bool gender;
        private MyStack shoppingBag = new MyStack();

        public string First_Name
        {
            get
            {
                return first_name;
            }

            set
            {
                first_name = value;
            }
        }
        public string Last_Name
        {
            get
            {
                return last_name;
            }

            set
            {
                last_name = value;
            }
        }
        public bool Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }
        public MyStack ShoppingBag
        {
            get
            {
                return shoppingBag;
            }
            set
            {
                shoppingBag = value;
            }
        }

        public override string ToString()
        {
            string retval = first_name + ", " + Last_Name + ", ";
            if (gender)
                retval += "خانم";
            else
                retval += "آقا";
            return retval;
        }
        public void write2File()
        {
            StreamWriter sw = File.AppendText("customerFile.txt");
            sw.WriteLine(first_name);
            sw.WriteLine(last_name);
            sw.WriteLine(gender);
            sw.WriteLine(shoppingBag.Length);
            for(int i = 0; i < shoppingBag.Length; i++)
            {
                Book temp = (Book)shoppingBag[i];
                sw.WriteLine(temp.BookName);
                sw.WriteLine(temp.WriterName);
                sw.WriteLine(temp.PublicationYear);
                sw.WriteLine(temp.Price);
            }
            sw.WriteLine("********************************");
            sw.Close();
        }

    }
    
}
