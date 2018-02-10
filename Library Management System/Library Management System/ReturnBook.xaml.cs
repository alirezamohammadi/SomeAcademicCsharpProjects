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
    /// Interaction logic for ReturnBook.xaml
    /// </summary>
    public partial class ReturnBook : Page
    {
        public Dictionary<string, Book> BookList;
        public Dictionary<string, Member> MemberList;
        public Member tempMember;
        public ReturnBook(Dictionary<string, Member> ML, Dictionary<string, Book> BL)
        {
            MemberList = ML;
            BookList = BL;
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
                btnSearchMember.IsEnabled = false;
                btnReturn.IsEnabled = true;
                List<string> tempLoaned=new List<string>();
                tempLoaned = tempMember.Loaned;
                for(int i=0;i<tempLoaned.Count;i++){
                    LiboBooks.Items.Add(tempLoaned[i] + "(" + BookList[tempLoaned[i]].Name + ")");
                }
            }

            else
            {
                MessageBox.Show("Member not found");
                txbMemberId.Focus();
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = new int();
                index = LiboBooks.SelectedIndex;
                BookList[tempMember.Loaned[index]].TotalNumber++;
                tempMember.Loaned.RemoveAt(index);
                LiboBooks.Items.RemoveAt(index);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Select a book first...");
            }
            
        }
    }
}
