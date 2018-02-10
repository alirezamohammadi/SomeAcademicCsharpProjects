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
    /// Interaction logic for AddMember.xaml
    /// </summary>
    public partial class AddMember : Page
    {
        public Dictionary<string, Member> MemberList;
        public AddMember(Dictionary<string, Member> L)
        {
            MemberList = L;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] txbArray = { txbId,txbFirstName,txbLastName, txbNationalCode};
            bool a = MyFunctions.isTextBoxEmpty(txbArray);
            if (!a)
                return;

            bool b = MyFunctions.isTextBoxInt("Please Enter only integeral valuse in ID & National Code.",txbId,txbNationalCode);
            if (!b)
                return;

            bool c = MyFunctions.checkTextBoxLenght(4, txbId);
            if (!c)
                return;
            
            bool d = MyFunctions.checkDatePickerValidation(dpRegistrationDate);
            if (!d)
                return;

            bool f = MyFunctions.checkTextBoxLenght(10, txbNationalCode);
            if (!f)
                return;

            if (!MemberList.ContainsKey(txbId.Text))
            {
                Member temp = new Member();
                temp.FirstName = txbFirstName.Text;
                temp.LastName = txbLastName.Text;
                temp.NationalCode = txbNationalCode.Text;
                temp.Id = txbId.Text;
                temp.RegisteryDate = (DateTime)dpRegistrationDate.SelectedDate;
                MemberList.Add(txbId.Text, temp);
                MessageBox.Show("Member successfully added.");
            }
            else
            {
                MessageBox.Show("This ID is already used.");
                txbId.Clear();
                txbId.Focus();
                return;
            }
            txbFirstName.Clear(); txbId.Clear(); txbLastName.Clear();
            dpRegistrationDate.Text = ""; txbNationalCode.Clear();
            
        }
    }
}
