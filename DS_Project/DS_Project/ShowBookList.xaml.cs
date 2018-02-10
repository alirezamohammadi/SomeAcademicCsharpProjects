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
using LinkedListLibrary;

namespace DS_Project
{
    /// <summary>
    /// Interaction logic for ShowBookList.xaml
    /// </summary>
    public partial class ShowBookList : Page
    {
        public CircularList Books;
        public ShowBookList(CircularList BooksList)
        {
            InitializeComponent();
            Books = BooksList;
        }

        private void btnRemoveBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = lsbBooksList.SelectedIndex;
                lsbBooksList.Items.RemoveAt(lsbBooksList.SelectedIndex);
                Books.RemoveAt(index);
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("لظفا یک کتاب انتخاب کنید.");
            }
        }

        private void btnRemoveBook_Loaded(object sender, RoutedEventArgs e)
        {
            for(int i=0; i< Books.Lenght; i++)
            {
                lsbBooksList.Items.Add(Books[i].ToString());
            }
        }
    }
}
