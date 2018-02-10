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

namespace Puzzle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void moveButton(Button centerBtn ,params Button[] btnArray)
        {
            for(int i = 0; i < btnArray.Length; i++)
            {
                if (btnArray[i].Content.ToString() == "")
                {
                    btnArray[i].Content = centerBtn.Content;
                    centerBtn.Content = "";
                    btnArray[i].Visibility = Visibility.Visible;
                    centerBtn.Visibility = Visibility.Hidden;
                }
            }
        }

        
        private void isWin()
        {
            if (
                btn1.Content.ToString() == "1"
                && btn2.Content.ToString() == "2"
                && btn3.Content.ToString() == "3"
                && btn4.Content.ToString() == "4"
                && btn5.Content.ToString() == "5"
                && btn6.Content.ToString() == "6"
                && btn7.Content.ToString() == "7"
                && btn8.Content.ToString() == "8"
                )
            {
                MessageBox.Show("شما برنده شدید");
                Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random randNum = new Random();
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8 ,9};
            Button[] btnArray = { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            int index1, index2, temp;
            int i, j;
            for (i = 0; i < 10; i++)
            {
                index1 = randNum.Next(9);
                index2 = randNum.Next(9);
                temp = numbers[index1];
                numbers[index1] = numbers[index2];
                numbers[index2] = temp;
            }

            for (i = 0 ; i < numbers.Length; i++)
            {
                btnArray[i].Content = numbers[i];
                if (numbers[i] == 9)
                {
                    btnArray[i].Content = "";
                    btnArray[i].Visibility = Visibility.Hidden;
                }
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            moveButton(btn1, btn2, btn4);
            isWin();
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            moveButton(btn8, btn9, btn7, btn5);
            isWin();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            moveButton(btn2, btn1, btn3, btn5);
            isWin();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            moveButton(btn3, btn2, btn6);
            isWin();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            moveButton(btn4, btn1, btn7, btn5);
            isWin();
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            moveButton(btn5, btn2, btn4, btn6, btn8);
            isWin();
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            moveButton(btn6, btn3, btn5, btn9);
            isWin();
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            moveButton(btn7, btn4, btn8);
            isWin();
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            moveButton(btn9, btn8, btn6);
            isWin();
        }
    }
}