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
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Page
    {
        public Dictionary<string, Book> BookList;
        public AddBook(Dictionary<string,Book> L)
        {
            BookList = L;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] txbArray = { txbName, txbId, txbWriterName, txbPublisher, txbPublicationYear, txbTotalNumber};
            bool a = MyFunctions.isTextBoxEmpty(txbArray);
            if (!a)
                return;

            bool b = MyFunctions.isTextBoxInt("Please Enter only integeral valuse in Id ,publication year and number",txbId,txbPublicationYear,txbTotalNumber);
            if (!b)
                return;

            bool c = MyFunctions.checkTextBoxLenght(4, txbId, txbPublicationYear);
            if (!c)
                return;

            bool d = MyFunctions.checkDatePickerValidation(dpRegistrationDate);
            if (!d)
                return;

            if (!BookList.ContainsKey(txbId.Text))
            {
                Book temp = new Book();
                temp.Name = txbName.Text;
                temp.Id = txbId.Text;
                temp.Writer = txbWriterName.Text;
                temp.Publisher = txbPublisher.Text;
                temp.PublicationYear = Convert.ToInt32(txbPublicationYear.Text);
                temp.TotalNumber = Convert.ToInt32(txbTotalNumber.Text);
                temp.Registration = (DateTime)dpRegistrationDate.SelectedDate;
                BookList.Add(txbId.Text, temp);
                MessageBox.Show("Book successfully added.");
                    
            }
            else
            {
                MessageBox.Show("This id is already used.");
                txbId.Clear();
                txbId.Focus();
                return;
            }
            txbName.Clear(); txbId.Clear(); txbWriterName.Clear(); txbPublisher.Clear();
            txbPublicationYear.Clear(); txbTotalNumber.Clear(); dpRegistrationDate.Text = "";
            
        }
    }
}
