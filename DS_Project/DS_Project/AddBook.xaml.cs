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
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Page
    {
        public CircularList Books;
        public AddBook(CircularList BooksList)
        {
            InitializeComponent();
            Books = BooksList;
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            string message;
            bool result = Functions.ValidateBook(txbBookName, txbWriterName, txbPublicationYear, txbPrice, out message);
            lblErrorMessage.Content = message;
            if (result)
            {
                Book temp = new Book();
                temp.BookName = txbBookName.Text;
                temp.WriterName = txbWriterName.Text;
                temp.PublicationYear = Convert.ToInt32(txbPublicationYear.Text);
                temp.Price = Convert.ToInt32(txbPrice.Text);
                Books.InsertAtBack(temp);
                MessageBox.Show("کتاب شما با موفقیت افزوده شد.");
                txbBookName.Clear();txbWriterName.Clear();txbPublicationYear.Clear();txbPrice.Clear();
            }
        }
    }
}
