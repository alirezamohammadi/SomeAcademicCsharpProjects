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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Dictionary<string, Book> BookList;
        public Dictionary<string, Member> MemberList;
        public MainWindow()
        {
            InitializeComponent();
            BookList = new Dictionary<string, Book>();
            MemberList = new Dictionary<string, Member>();
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            lblWelcome.Visibility = Visibility.Hidden;
            AddBook AddBookPage = new AddBook(BookList);
            frmMain.Navigate(AddBookPage);
        }

        private void btnEditBook_Click(object sender, RoutedEventArgs e)
        {
            lblWelcome.Visibility = Visibility.Hidden;
            EditBook EditBookPage = new EditBook(BookList);
            frmMain.Navigate(EditBookPage);
        }

        private void btnSearchBook_Click(object sender, RoutedEventArgs e)
        {
            lblWelcome.Visibility = Visibility.Hidden;
            SearchBook SearchBookPage = new SearchBook(BookList);
            frmMain.Navigate(SearchBookPage);
        }

        private void btnRemoveBook_Click(object sender, RoutedEventArgs e)
        {
            lblWelcome.Visibility = Visibility.Hidden;
            RemoveBook RemoveBookPage = new RemoveBook(BookList);
            frmMain.Navigate(RemoveBookPage);
        }

        private void btnAddMember_Click(object sender, RoutedEventArgs e)
        {
            lblWelcome.Visibility = Visibility.Hidden;
            AddMember AddMemberPage = new AddMember(MemberList);
            frmMain.Navigate(AddMemberPage);
        }

        private void btnEditMember_Click(object sender, RoutedEventArgs e)
        {
            lblWelcome.Visibility = Visibility.Hidden;
            EditMember EditMemberPage = new EditMember(MemberList);
            frmMain.Navigate(EditMemberPage);
        }

        private void btnRemoveMember_Click(object sender, RoutedEventArgs e)
        {
            lblWelcome.Visibility = Visibility.Hidden;
            RemoveMember RemoveMemberPage = new RemoveMember(MemberList);
            frmMain.Navigate(RemoveMemberPage);
        }

        private void btnSearchMember_Click(object sender, RoutedEventArgs e)
        {
            lblWelcome.Visibility = Visibility.Hidden;
            SearchMember SearchMemberPage = new SearchMember(MemberList);
            frmMain.Navigate(SearchMemberPage);
        }
       
        private void btnLoanBook_Click(object sender, RoutedEventArgs e)
        {
            lblWelcome.Visibility = Visibility.Hidden;
            LoanBook LoanBookPage = new LoanBook(MemberList, BookList);
            frmMain.Navigate(LoanBookPage);
        }

        private void btnReturnBook_Click(object sender, RoutedEventArgs e)
        {
            lblWelcome.Visibility = Visibility.Hidden;
            ReturnBook ReturnBookPage = new ReturnBook(MemberList, BookList);
            frmMain.Navigate(ReturnBookPage);
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            About AboutWin = new About();
            AboutWin.Show();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            winMain.Close();
        }

    }
}
