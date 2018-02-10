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

namespace DS_Project
{
    /// <summary>
    /// Interaction logic for ShowQueue.xaml
    /// </summary>
    public partial class ShowQueue : Page
    {
        MyQueue femaleQ;
        MyQueue maleQ;
        public ShowQueue(MyQueue female,MyQueue male)
        {
            femaleQ = female;
            maleQ = male;
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < femaleQ.Lenght; i++)
            {
                lsbFeamle.Items.Add(femaleQ[i].ToString());
            }

            for (int i = 0; i < maleQ.Lenght; i++)
            {
                lsbMale.Items.Add(maleQ[i].ToString());
            }
        }

        private void btnDeleteFemale_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = lsbFeamle.SelectedIndex;
                lsbFeamle.Items.RemoveAt(lsbFeamle.SelectedIndex);
                femaleQ.RemoveAt(index);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("فرد مورد نظر خود را انتخاب کنید");
            }
        }

        private void btnDeleteMale_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = lsbMale.SelectedIndex;
                lsbMale.Items.RemoveAt(lsbMale.SelectedIndex);
                maleQ.RemoveAt(index);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("فرد مورد نظر خود را انتخاب کنید");
            }
        }
    }
}
