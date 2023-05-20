using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using System.Xml.Linq;
using учет_бюджета4.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace учет_бюджета4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    ///     

public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();

            //data.DisplayDateStart = new DateTime(2023, 01, 01);
            //data.DisplayDateEnd = new DateTime(2023, 03, 20);
            
            //List<string> Type = new List<string> { "Еда", "Одежда" };
            //combobox.ItemsSource = Type;
            
            //Type.Add("");
          
        }
         public void Button_Clicknewtype(object sender, RoutedEventArgs e)
        {             

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}



/*    public partial class NewWindow : Window
    { 
       
        public NewWindow()
        {
            InitializeComponent();
        }


        public string Name
        {
            get { return text1.Text; }
            set { Name = value; }
        }

        public void Button_Clicknewtype1(object sender, RoutedEventArgs e)
        {

            string type = null;
            text1.Text = type;


            Close();
        }  

    }*/






