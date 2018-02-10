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
using LinkedListLibrary;

namespace DS_Project
{
    /// <summary>
    /// Interaction logic for Accounting.xaml
    /// </summary>
    public partial class Accounting : Page
    {
        private MyQueue femaleQ;
        private MyQueue maleQ;
        private bool status=true;
        public Accounting(MyQueue fQueue,MyQueue mQueue)
        {
            femaleQ = fQueue;
            maleQ = mQueue;
            InitializeComponent();
        }

        private void lsb_females_Loaded(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < femaleQ.Lenght; i++)
            {
                lsb_females.Items.Add(femaleQ[i]);
            }
        }

        private void lsb_males_Loaded(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < maleQ.Lenght; i++)
            {
                lsb_males.Items.Add(maleQ[i]);
            }
        }
        
        private void btn_exitFromQueue_Click(object sender, RoutedEventArgs e)
        {
            lsb_shoppingBag.Items.Clear();
            Person temp;
            if (status&&femaleQ.Lenght!=0)
            {
                temp = (Person)femaleQ.Dequeue();
                lsb_females.Items.RemoveAt(0);
                for(int i = temp.ShoppingBag.Length-1; i >= 0; i--)
                {
                    lsb_shoppingBag.Items.Add(temp.ShoppingBag[i]);
                }
                status = false;
                btn_exitFromQueue.Content = "صدور فاکتور(آقایان)";
                int price = 0;
                for (int i = 0; i < temp.ShoppingBag.Length; i++)
                {
                    Book tempBook = (Book)temp.ShoppingBag[i];
                    price += tempBook.Price;
                }
                lbl_factor.Content = "مجموع قیمت: " + price.ToString();
            }

            else if(!status&&maleQ.Lenght!=0)
            {

                temp = (Person)maleQ.Dequeue();
                lsb_males.Items.RemoveAt(0);
                for (int i = temp.ShoppingBag.Length - 1; i >= 0; i--)
                {
                    lsb_shoppingBag.Items.Add(temp.ShoppingBag[i]);
                }

                
                status = true;
                btn_exitFromQueue.Content = "صدور فاکتور(خانم ها)";
                int price = 0;
                for (int i = 0; i < temp.ShoppingBag.Length; i++)
                {
                    Book tempBook = (Book)temp.ShoppingBag[i];
                    price += tempBook.Price;
                }
                lbl_factor.Content = "مجموع قیمت: " + price.ToString();
            }
            if (femaleQ.Lenght == 0) status = false;
            else if (maleQ.Lenght == 0) status = true;
        }
    }
}
