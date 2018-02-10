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

namespace DS_Project
{
    /// <summary>
    /// Interaction logic for ReserveWaiting.xaml
    /// </summary>
    public partial class ReserveWaiting : Page
    {
        MyQueue femaleQueue;
        MyQueue maleQueue;
        public ReserveWaiting(MyQueue female,MyQueue male)
        {
            femaleQueue = female;
            maleQueue = male;
            InitializeComponent();
            
        }

        private void btnReserve_Click(object sender, RoutedEventArgs e)
        {
            string message;
            bool result = Functions.ValidateCustomer(txbCustomerFName, txbCustomerLName, rdbMale, rdbFemale, out message);
            lblMessage.Content = message;

            if (result)
            {
                Person person = new Person();
                person.First_Name = txbCustomerFName.Text;
                person.Last_Name = txbCustomerLName.Text;
                if ((bool)rdbFemale.IsChecked)
                {
                    person.Gender = true;
                    femaleQueue.Enqueue(person);
                }
                else {
                    person.Gender = false;
                    maleQueue.Enqueue(person);
                }
                lblQueueCount.Content = "تعداد افراد منتظر در صف: " + (maleQueue.Lenght + femaleQueue.Lenght).ToString();
                MessageBox.Show("نوبت شما با موفقیت رزرو شد.");
                txbCustomerFName.Clear();txbCustomerLName.Clear();rdbFemale.IsChecked = false;rdbMale.IsChecked = false;
            }
        }

        private void pageReserve_Loaded(object sender, RoutedEventArgs e)
        {
            lblQueueCount.Content += (maleQueue.Lenght + femaleQueue.Lenght).ToString();
        }
    }
}
