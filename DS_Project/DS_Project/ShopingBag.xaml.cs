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
    /// Interaction logic for ShopingBag.xaml
    /// </summary>
    public partial class ShopingBag : Page
    {
        MyQueue femaleQueue;
        MyQueue maleQueue;
        CircularList books;
        Person FoundPerson;
        TwoWayLinkedList soldBooks;
       
        public ShopingBag(MyQueue femaleQ,MyQueue maleQ,CircularList Books,TwoWayLinkedList soldB)
        {
            femaleQueue = femaleQ;
            maleQueue = maleQ;
            books = Books;
            soldBooks = soldB;
            InitializeComponent();
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            listBox_boughtBooks.Items.Clear();
            bool result = Functions.ValidateSearch(txb_fName, txb_lName, lbl_message);
            bool isFound = false;
            if (result)
            {
                lbl_message.Content = "";
                Person temp;
                for (int i = 0; i < femaleQueue.Lenght; i++)
                {
                    temp = (Person)femaleQueue[i];
                    if (txb_fName.Text == temp.First_Name && txb_lName.Text == temp.Last_Name)
                    {
                        FoundPerson = (Person)femaleQueue[i];
                        isFound=true;
                        lbl_shoppingBagPerson.Content = "سبد خرید خانم " + txb_fName.Text + " " + txb_lName.Text + ":";
                    }
                }

                for (int i = 0; i < maleQueue.Lenght; i++)
                {
                    temp = (Person)maleQueue[i];
                    if (txb_fName.Text == temp.First_Name && txb_lName.Text == temp.Last_Name)
                    {
                        FoundPerson = (Person)maleQueue[i];
                        isFound = true;
                        lbl_shoppingBagPerson.Content = "سبد خرید آقای " + txb_fName.Text + " " + txb_lName.Text + ":";

                    }
                }
                
                if (isFound)
                {
                    for(int i = FoundPerson.ShoppingBag.Length - 1; i >= 0; i--)
                    {
                        listBox_boughtBooks.Items.Add(FoundPerson.ShoppingBag[i]);
                    }
                    btn_buy.IsEnabled = true;
                }

                else
                {
                    btn_buy.IsEnabled = false;
                    lbl_message.Content = "مشتری مورد نظر یافت نشد.";
                    txb_fName.SelectAll();
                    txb_fName.Focus();
                }

            }
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < books.Lenght; i++)
            {
                listBox_books.Items.Add(books[i]);
            }
        }

        private void btn_buy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = new int();
                index = listBox_books.SelectedIndex;
                listBox_boughtBooks.Items.Add(listBox_books.Items.GetItemAt(listBox_books.SelectedIndex));
                listBox_books.Items.RemoveAt(listBox_books.SelectedIndex);
                Book temp = (Book)books.RemoveAt(listBox_books.SelectedIndex);
                FoundPerson.ShoppingBag.pushBack(temp);
                soldBooks.InsertAtBack(temp);
            }

            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("لطفا یک کتاب انتخاب کنید.");
            }



        }
    }
}
