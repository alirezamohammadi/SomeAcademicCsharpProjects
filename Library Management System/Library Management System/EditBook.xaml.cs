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
    /// Interaction logic for EditBook.xaml
    /// </summary>
    public partial class EditBook : Page
    {

        public Dictionary<string, Book> BookList;
        public EditBook(Dictionary<string,Book> L)
        {
            BookList = L;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
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

            if (BookList.ContainsKey(txbId.Text))
            {
                Book temp = BookList[txbId.Text];
                txbName.Text = temp.Name; txbWriterName.Text = temp.Writer;
                txbPublisher.Text = temp.Publisher; txbPublicationYear.Text = temp.PublicationYear.ToString();
                txbTotalNumber.Text = temp.TotalNumber.ToString(); dpRegistrationDate.Text = temp.Registration.ToString();
                btnOk.IsEnabled = false;
                btnEdit.IsEnabled = true;
                txbId.IsEnabled = false;
                txbName.IsEnabled = true; txbWriterName.IsEnabled = true;
                txbPublisher.IsEnabled = true; txbPublicationYear.IsEnabled = true; txbTotalNumber.IsEnabled = true;
                dpRegistrationDate.IsEnabled = true;

            }
            else
            {
                MessageBox.Show("Book not found.");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] txbArray = { txbName, txbWriterName, txbPublisher, txbPublicationYear, txbTotalNumber };
            bool a = MyFunctions.isTextBoxEmpty(txbArray);
            if (!a)
                return;
            bool b = MyFunctions.isTextBoxInt("Please Enter only integeral valuse in publication year and number", txbPublicationYear, txbTotalNumber);
            if (!b)
                return;
            bool c = MyFunctions.checkTextBoxLenght(4, txbPublicationYear);
            if (!c)
                return;

            bool d = MyFunctions.checkDatePickerValidation(dpRegistrationDate);
            if (!d)
                return;

            Book temp = new Book();
            temp.Name = txbName.Text;
            temp.Id = txbId.Text;
            temp.Writer = txbWriterName.Text;
            temp.Publisher = txbPublisher.Text;
            temp.PublicationYear = Convert.ToInt32(txbPublicationYear.Text);
            temp.TotalNumber = Convert.ToInt32(txbTotalNumber.Text);
            temp.Registration = (DateTime)dpRegistrationDate.SelectedDate;
            BookList[temp.Id] = temp;
            MessageBox.Show("Book successfully Edied.");
            txbName.Clear(); txbId.Clear(); txbWriterName.Clear(); txbPublisher.Clear();
            txbPublicationYear.Clear(); txbTotalNumber.Clear(); dpRegistrationDate.Text = "";
            btnOk.IsEnabled = true;
            btnEdit.IsEnabled = false;
            txbId.IsEnabled = true;
            txbName.IsEnabled = false; txbWriterName.IsEnabled = false;
            txbPublisher.IsEnabled = false; txbPublicationYear.IsEnabled = false; txbTotalNumber.IsEnabled = false;
            dpRegistrationDate.IsEnabled = false;

        }
    }
}
