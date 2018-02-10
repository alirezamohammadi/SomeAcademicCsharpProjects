using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library_Management_System
{
    class MyFunctions
    {
        public static bool isTextBoxInt(string message,params TextBox[] txbArray)
        {
            for (int i = 0; i < txbArray.Length; i++)
            {
                try
                {
                    long temp;
                    temp = Convert.ToInt64(txbArray[i].Text);
                    if (temp < 0)
                    {
                        MessageBox.Show("Please Enter Positive Values!!!");
                        return false;
                    }
                }

                catch (OverflowException)
                {
                    MessageBox.Show("WOW...!!! Text box overflow...");
                    return false;
                }

                catch (FormatException)
                {
                    MessageBox.Show(message);
                    txbArray[i].Focus();
                    return false;
                }
            }
            
            return true;
        }

        public static bool checkDatePickerValidation(DatePicker dp)
        {
            try
            {
                DateTime temp = (DateTime)dp.SelectedDate;
            }

            catch (InvalidOperationException)
            {
                MessageBox.Show("Date you entered not valid...");
                dp.Focus();
                return false;
            }

            return true;

        }

        public static bool isTextBoxEmpty(params TextBox[] txbArray)
        {
            for (int i = 0; i < txbArray.Length; i++)
            {
                if (txbArray[i].Text == "")
                {
                    MessageBox.Show("Please complete fields.");
                    txbArray[i].Focus();
                    return false;
                }
            }
            return true;
        }

        public static bool checkTextBoxLenght(int len, params TextBox[] txbArray)
        {
            for (int i = 0; i < txbArray.Length; i++)
            {
                if (txbArray[i].Text.Length != len)
                {
                    MessageBox.Show("Please enter " + len.ToString() + "characters.");
                    txbArray[i].Focus();
                    return false;
                }
            }

            return true;
        }

    }



}
