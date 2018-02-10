using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;
using LinkedListLibrary;

namespace DS_Project
{
    
    
    class Functions
    {
        public static bool ValidateCustomer(TextBox fname, TextBox lname, RadioButton male, RadioButton female, out string message)
        {
            if (fname.Text == "")
            {
                message = "خطا: لطفا فیلد نام را پر کنید!";
                fname.Focus();
                fname.SelectAll();
                return false;
            }

            else if (lname.Text == "")
            {
                message = "خطا: لطفا فیلد نام خانوادگی را پر کنید!";
                lname.Focus();
                lname.SelectAll();
                return false;
            }

            else if(!(bool)male.IsChecked && !(bool)female.IsChecked)
            {
                message = "خطا: لطفا جنیست را انخاب کنید.";
                return false;
            }

            else
            {
                message = "";
                return true;
            }
        }

        public static bool IsInt(string value)
        {
            try
            {
                Convert.ToInt32(value);
            }

            catch (FormatException)
            {
                return false;
            }

            return true;
        }

        public static bool ValidateBook(TextBox name, TextBox writer, TextBox year, TextBox price, out string errorMessage)
        {
            if (name.Text == "")
            {
                name.Focus();
                errorMessage = "خطا: لطفا فیلد نام کتاب را پر کنید!";
                return false;
            }

            else if (writer.Text == "")
            {
                writer.Focus();
                errorMessage = "خطا: لطفا فیلد نام نویسنده را پر کنید!";
                return false;
            }

            else if (year.Text.Length != 4|| !IsInt(year.Text))
            {
                errorMessage = "خطا: سال انتشار باید از جنس عدد و 4 کاراکتر باشد.";
                year.Focus();
                year.SelectAll();
                return false;
            }
            
            else if (!IsInt(price.Text))
            {
                errorMessage = "خطا: قیمت باید از جنس عدد صحیح باشد.";
                price.Focus();
                price.SelectAll();
                return false;
            }

            else
            {
                errorMessage = "";
                return true;
            }
        }
        
        public static bool ValidateSearch(TextBox fName,TextBox lName,Label message)
        {
            if (fName.Text == "")
            {
                message.Content = "لطفا نام را وارد کنید.";
                fName.Focus();
                return false;
            }
            else if (lName.Text == "")
            {
                message.Content = "لطفا نام خانوادگی را وارد کنید.";
                lName.Focus();
                return false;
            }

            else return true;
        }        
        public static void writeBooks2File(CircularList books)
        {
            File.WriteAllText("bookFile.txt", String.Empty);//hame file ro pak mikone
            for(int i = 0; i < books.Lenght; i++)
            {
                Book temp = (Book)books[i];
                temp.writeBooks2File();
            }
        }
        public static void writeSoldBooks2File(TwoWayLinkedList soldBooks)
        {
            File.WriteAllText("soldBookFile.txt",string.Empty);
            for(int i = 0; i < soldBooks.Lenght; i++)
            {
                Book temp = (Book)soldBooks[i];
                temp.writeSoldBooks2File();
            }
        }
        public static void writeCustomer2File(MyQueue fQueue,MyQueue mQueue)
        {
            File.WriteAllText("customerFile.txt", string.Empty);
            for(int i = 0; i < fQueue.Lenght; i++)
            {
                Person temp = (Person)fQueue[i];
                temp.write2File();
            }
            for (int i = 0; i < mQueue.Lenght; i++)
            {
                Person temp = (Person)mQueue[i];
                temp.write2File();
            }
        }
        public static void readBooksFromFile(CircularList books)
        {
            StreamReader sr = new StreamReader("bookFile.txt");
            for(int i = 0; !sr.EndOfStream; i++)
            {
                Book temp = new Book();
                temp.BookName = sr.ReadLine();
                temp.WriterName = sr.ReadLine();
                temp.PublicationYear = Convert.ToInt32(sr.ReadLine());
                temp.Price = Convert.ToInt32(sr.ReadLine());
                books.InsertAtBack(temp);
                sr.ReadLine();//baraye rad kardane yek khat setare
            }
            sr.Close();
        }
        public static void readSoldBooksFromFile(TwoWayLinkedList soldBooks)
        {
            StreamReader sr = new StreamReader("soldBookFile.txt");
            for(int i = 0; !sr.EndOfStream; i++)
            {
                Book temp = new Book();
                temp.BookName = sr.ReadLine();
                temp.WriterName = sr.ReadLine();
                temp.PublicationYear = Convert.ToInt32(sr.ReadLine());
                temp.Price = Convert.ToInt32(sr.ReadLine());
                soldBooks.InsertAtBack(temp);
                sr.ReadLine();//baraye rad kardane yek khat setare
            }
            sr.Close();
        }
        public static void readCustomerFromFile(MyQueue femaleQ,MyQueue maleQ)
        {
            MyQueue tempQueue = new MyQueue();
            StreamReader sr = new StreamReader("customerFile.txt");
            for(int i = 0; !sr.EndOfStream; i++)
            {
                Person temp = new Person();
                temp.First_Name = sr.ReadLine();
                temp.Last_Name = sr.ReadLine();
                temp.Gender = Convert.ToBoolean(sr.ReadLine());
                int n = Convert.ToInt32(sr.ReadLine());
                for (int j = 0; j < n; j++) 
                {
                    Book tempBook = new Book();
                    tempBook.BookName = sr.ReadLine();
                    tempBook.WriterName = sr.ReadLine();
                    tempBook.PublicationYear = Convert.ToInt32(sr.ReadLine());
                    tempBook.Price = Convert.ToInt32(sr.ReadLine());
                    temp.ShoppingBag.pushBack(tempBook);
                }
                sr.ReadLine();
                tempQueue.Enqueue(temp);
            }
            for(int i = 0; i < tempQueue.Lenght; i++)
            {
                Person temp = (Person)tempQueue[i];
                if (temp.Gender) femaleQ.Enqueue(temp);
                else maleQ.Enqueue(temp);
            }
        }
    }
}
