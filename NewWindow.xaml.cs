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
using System.Windows.Shapes;

namespace учет_бюджета4
{

    public partial class NewWindow : Window
    {

        public NewWindow()
        {
            InitializeComponent();
        }

        /*     internal  class Name
             {
                 string name;
             }*/


        /*        public string Name
                {
                    get { return name = text1.Text; }
                    set { Name = value; }
                }*/

        public void text1_TextChanged(object sender, TextChangedEventArgs e)
        {
            string name = text1.Text;

        }

        public void Button_Clicknewtype1(object sender, RoutedEventArgs e)
        {
            
            Close();
        }
   

    }
}
