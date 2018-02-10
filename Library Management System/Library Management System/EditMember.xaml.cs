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
    /// Interaction logic for EditMember.xaml
    /// </summary>
    public partial class EditMember : Page
    {
        public Dictionary<string, Member> MemberList;

        public EditMember(Dictionary<string, Member> L)
        {
            MemberList = L;
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] txbArray = { txbFirstName, txbLastName, txbNationalCode };
            bool a = MyFunctions.isTextBoxEmpty(txbArray);
            if (!a)
                return;

            bool b = MyFunctions.checkDatePickerValidation(dpRegistrationDate);
            if (!b)
                return;

            bool c = MyFunctions.checkTextBoxLenght(10, txbNationalCode);
            if (!c)
                return;

            bool d = MyFunctions.isTextBoxInt("Enter only integeral values in National Code.", txbNationalCode);
            if (!d)
                return;

            Member temp = new Member();
            temp.FirstName = txbFirstName.Text;
            temp.LastName = txbLastName.Text;
            temp.NationalCode = txbNationalCode.Text;
            temp.Id = txbId.Text;
            temp.RegisteryDate = (DateTime)dpRegistrationDate.SelectedDate;
            MemberList[txbId.Text] = temp;
            MessageBox.Show("Member successfully edited.");
            txbFirstName.Clear(); txbId.Clear(); txbLastName.Clear(); txbNationalCode.Clear();
            dpRegistrationDate.Text = "";
            btnOk.IsEnabled = true;
            btnEdit.IsEnabled = false;
            txbId.IsEnabled = true;
            txbLastName.IsEnabled = false; txbFirstName.IsEnabled = false;
            txbNationalCode.IsEnabled = false; dpRegistrationDate.IsEnabled = false;

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

            if (MemberList.ContainsKey(txbId.Text))
            {
                Member temp = MemberList[txbId.Text];
                txbFirstName.Text = temp.FirstName; txbLastName.Text = temp.LastName;
                txbNationalCode.Text = temp.NationalCode; dpRegistrationDate.Text = temp.RegisteryDate.ToString();
                btnOk.IsEnabled = false;
                btnEdit.IsEnabled = true;
                txbId.IsEnabled = false;
                txbFirstName.IsEnabled = true; txbLastName.IsEnabled = true;
                txbNationalCode.IsEnabled = true; dpRegistrationDate.IsEnabled = true;
            }

            else
            {
                MessageBox.Show("Member not found!");
            }
        }
    }
}
