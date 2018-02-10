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
    /// Interaction logic for SearchMember.xaml
    /// </summary>
    public partial class SearchMember : Page
    {
        public Dictionary<string, Member> MemberList;
        public SearchMember(Dictionary<string, Member> L)
        {
            MemberList = L;
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            lblFirstName.Content = ""; lblLastName.Content = "";
            lblNationalCode.Content = ""; lblRegistrationDate.Content = "";
            lblLiability.Content = "";

            bool a = MyFunctions.isTextBoxEmpty(txbId);
            if (!a)
                return;

            bool b = MyFunctions.checkTextBoxLenght(4, txbId);
            if (!b)
                return;

            bool c = MyFunctions.isTextBoxInt("Id must be an integeral value.", txbId);
            if (!c)
                return;

            lblFirstName.Content = ""; lblLastName.Content = "";
            lblNationalCode.Content = "";
            if (MemberList.ContainsKey(txbId.Text))
            {
                Member temp = MemberList[txbId.Text];
                lblFirstName.Content = "First Name: " + temp.FirstName; lblLastName.Content = "Last Name: " + temp.LastName;
                lblNationalCode.Content = "National Cide: " + temp.NationalCode;
                lblRegistrationDate.Content = "Registration Date: " + temp.RegisteryDate.ToString();
                lblLiability.Content = "Liability : " + temp.Liability.ToString();
            }
            else
            {
                MessageBox.Show("Member not found.");
            }
        }
    }
}
