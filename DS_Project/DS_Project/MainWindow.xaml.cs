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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CircularList BooksList = new CircularList();
        MyQueue femaleQueue = new MyQueue();
        MyQueue maleQueue = new MyQueue();
        TwoWayLinkedList soldBooksList = new TwoWayLinkedList();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("آیا برای خروج از برنامه مطمئن هستید؟", "خروج...", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Functions.writeBooks2File(BooksList);
                Functions.writeSoldBooks2File(soldBooksList);
                Functions.writeCustomer2File(femaleQueue, maleQueue);
                Close();
            }
        }

        private void menuItem_AddBook_Click(object sender, RoutedEventArgs e)
        {
            AddBook addBook = new AddBook(BooksList);
            mainFram.Navigate(addBook);
        }

        private void menuItem_AboutUs_Click(object sender, RoutedEventArgs e)
        {
            AboutUs aboutUs = new AboutUs();
            mainFram.Navigate(aboutUs);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AboutUs aboutUs = new AboutUs();
            mainFram.Navigate(aboutUs);
        }

        private void ShowBooksList_Click(object sender, RoutedEventArgs e)
        {
            ShowBookList showBookList = new ShowBookList(BooksList);
            mainFram.Navigate(showBookList);
        }

        private void MenuItem_Reserve_Click(object sender, RoutedEventArgs e)
        {
            ReserveWaiting reserveWaiting = new ReserveWaiting(femaleQueue,maleQueue);
            mainFram.Navigate(reserveWaiting);
        }

        private void MenuItem_ShowQueue_Click(object sender, RoutedEventArgs e)
        {
            ShowQueue showQueue = new ShowQueue(femaleQueue, maleQueue);
            mainFram.Navigate(showQueue);
        }

        private void menuItem_shoppingBag_Click(object sender, RoutedEventArgs e)
        {
            ShopingBag shoppingBag = new ShopingBag(femaleQueue, maleQueue, BooksList, soldBooksList);
            mainFram.Navigate(shoppingBag);
        }

        private void menuItem_Accounting_Click(object sender, RoutedEventArgs e)
        {
            Accounting accounting = new Accounting(femaleQueue, maleQueue);
            mainFram.Navigate(accounting);
        }


        private void menuItem_SoldBooks_Click(object sender, RoutedEventArgs e)
        {
            SoldBooks soldBooks = new SoldBooks(soldBooksList);
            mainFram.Navigate(soldBooks);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Functions.readBooksFromFile(BooksList);
            Functions.readSoldBooksFromFile(soldBooksList);
            Functions.readCustomerFromFile(femaleQueue,maleQueue);
        }
    }
}
