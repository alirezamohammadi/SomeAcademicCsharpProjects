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
    /// Interaction logic for RemoveBook.xaml
    /// </summary>
    public partial class RemoveBook : Page
    {
        public Dictionary<string, Book> BookList;
        public RemoveBook(Dictionary<string, Book> L)
        {
            BookList = L;
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            bool a = MyFunctions.isTextBoxEmpty(txbId);
            if (!a)
                return;

            bool b = MyFunctions.checkTextBoxLenght(4, txbId);
            if (!b)
                return;

            bool c = MyFunctions.isTextBoxInt("Id must be an integeral value.", txbId);
            if (!c)
                return;

            lblName.Content = ""; lblWriterName.Content = "";
            lblPublisher.Content = ""; lblPublicationYear.Content = "";
            lblTotalNumber.Content = "";
            if (BookList.ContainsKey(txbId.Text))
            {
                Book temp = BookList[txbId.Text];
                lblName.Content = "Name: " + temp.Name; lblWriterName.Content = "Writer Name: " + temp.Writer;
                lblPublisher.Content = "Publisher: " + temp.Publisher; 
                lblPublicationYear.Content = "Publication Year: " + temp.PublicationYear.ToString();
                lblTotalNumber.Content = "Total Number: " + temp.TotalNumber.ToString();
                lblRegistrationDate.Content = "Registration Date: " + temp.Registration.ToString();
                btnSearch.IsEnabled = false;
                btnRemove.IsEnabled = true;
                txbId.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Book not found.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ckbConfirmation.IsChecked == true)
            {
                BookList.Remove(txbId.Text);
                MessageBox.Show("Book removed successfully.");
                lblName.Content = ""; lblWriterName.Content = "";
                lblPublisher.Content = ""; lblPublicationYear.Content = "";
                lblTotalNumber.Content = ""; txbId.Text = ""; lblRegistrationDate.Content = "";
                btnSearch.IsEnabled = true;
                txbId.IsEnabled = true;
                ckbConfirmation.IsChecked = false;
                btnRemove.IsEnabled = false;
            }
            else
                MessageBox.Show("Please confirm remove first");
        }
    }
}
