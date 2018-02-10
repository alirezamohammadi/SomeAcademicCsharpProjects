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
    /// Interaction logic for SoldBooks.xaml
    /// </summary>
    public partial class SoldBooks : Page
    {
        private TwoWayLinkedList soldBooks;
        public SoldBooks(TwoWayLinkedList books)
        {
            soldBooks = books;
            InitializeComponent();
        }

        private void listBox_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < soldBooks.Lenght; i++)
            {
                lsb_soldBooks.Items.Add(soldBooks[i]);
            }
        }
    }
}
