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
    /// <summary>
    /// Interaction logic for SearchBook.xaml
    /// </summary>
    public partial class SearchBook : Page
    {
        public Dictionary<string, Book> BookList;
        public SearchBook(Dictionary<string, Book> L)
        {
            BookList = L;
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            lblName.Content = ""; lblWriterName.Content = "";
            lblPublisher.Content = ""; lblPublicationYear.Content = "";
            lblTotalNumber.Content = "";

            bool a = MyFunctions.isTextBoxEmpty(txbId);
            if (!a)
                return;

            bool b = MyFunctions.checkTextBoxLenght(4, txbId);
            if (!b)
                return;

            bool c = MyFunctions.isTextBoxInt("Id must be an integeral value.", txbId);
            if (!c)
                return;

            if (BookList.ContainsKey(txbId.Text))
            {
                Book temp = BookList[txbId.Text];
                lblName.Content = "Name: " + temp.Name; lblWriterName.Content = "Writer Name: " + temp.Writer;
                lblPublisher.Content = "Publisher: " + temp.Publisher; 
                lblPublicationYear.Content = "Publication Year: " + temp.PublicationYear.ToString();
                lblTotalNumber.Content = "Total Number: " + temp.TotalNumber.ToString();
                lblRegistrationDate.Content = "Registration Date: " + temp.Registration.ToString();
               
            }
            else
            {
                MessageBox.Show("Book not found.");
            }
        }
    }
}
