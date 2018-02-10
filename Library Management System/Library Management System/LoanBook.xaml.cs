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
    /// Interaction logic for LoanBook.xaml
    /// </summary>
    public partial class LoanBook : Page
    {
        public Book tempBook;
        public Member tempMember;
        public Dictionary<string, Book> BookList;
        public Dictionary<string, Member> MemberList;
        public LoanBook(Dictionary<string, Member> ML, Dictionary<string, Book> BL)
        {
            BookList = BL;
            MemberList = ML;
            InitializeComponent();
        }

        private void btnSearchMember_Click(object sender, RoutedEventArgs e)
        {
            bool a = MyFunctions.isTextBoxEmpty(txbMemberId);
            if (!a)
                return;

            bool b = MyFunctions.checkTextBoxLenght(4, txbMemberId);
            if (!b)
                return;

            bool c = MyFunctions.isTextBoxInt("Please enteronly integeral values in MemberID textbox.", txbMemberId);
            if (!c)
                return;

            if (MemberList.ContainsKey(txbMemberId.Text))
            {
                tempMember = MemberList[txbMemberId.Text];
                txbMemberId.IsEnabled = false;
                txbBookId.IsEnabled = true;
                btnSearchMember.IsEnabled = false;
                btnLoan.IsEnabled = true;
            }

            else
            {
                MessageBox.Show("Member not found");
                txbMemberId.Focus();
            }
        }

        private void btnLoan_Click(object sender, RoutedEventArgs e)
        {
            bool a = MyFunctions.isTextBoxEmpty(txbBookId);
            if (!a)
                return;

            bool b = MyFunctions.checkTextBoxLenght(4, txbBookId);
            if (!b)
                return;

            bool c = MyFunctions.isTextBoxInt("Please enter only integeral values in BookID text box.",txbBookId);
            if (!c)
                return;

            if (BookList.ContainsKey(txbBookId.Text))
            {
                tempBook = BookList[txbBookId.Text];
                if (tempMember.Loaned.Count < 3)
                {
                    if (tempBook.TotalNumber != 0)
                    {
                        tempMember.Loaned.Add(txbBookId.Text);
                        tempBook.TotalNumber--;
                        MessageBox.Show(tempMember.FirstName + " borrowed " + tempBook.Name + ".");
                        txbMemberId.IsEnabled = true; txbBookId.IsEnabled = false;
                        btnLoan.IsEnabled = false; btnSearchMember.IsEnabled = true;
                        txbBookId.Clear(); txbMemberId.Clear();
                    }
                    else
                        MessageBox.Show("This book is not available in the library.");
                }

                else
                {
                    MessageBox.Show(MemberList[txbMemberId.Text].FirstName + " can't borrow book any more.");
                }
            }

            else
            {
                MessageBox.Show("Book not found.");
                txbBookId.Focus();
            }
        }
    }
}
