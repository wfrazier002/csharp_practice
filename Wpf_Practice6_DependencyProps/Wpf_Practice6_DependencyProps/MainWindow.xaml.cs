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

namespace Wpf_Practice6_DependencyProps {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        

        // here is an example of a dependancy prop that we create (an ex of one that is already created is teh one in button when mouse is hovered over it - it inc the size of teh font, and when the mouse is not hovering over it returns to default size)

        public int MyProperty { 
            get { return (int)GetValue(myDependancyProp); } 
            set { SetValue(myDependancyProp, value); }
        }
        // create a dependencyprop - needs a string ("My Prop"), what type it is (type int), what type it's owner is (type MainWindow since it's in the mainwindow class), and 
        public static readonly DependencyProperty myDependancyProp = DependencyProperty.Register("My Prop", typeof(int), typeof(MainWindow), new PropertyMetadata(0));

        public MainWindow() {
            InitializeComponent();
        }
    }
}
