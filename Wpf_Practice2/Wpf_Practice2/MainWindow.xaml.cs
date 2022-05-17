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

namespace Wpf_Practice2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            // manual coding rather than using xaml:
            // this will show how to do the same thing as the button coded via xaml using c# instead
            Grid theGrid = new Grid();
            this.Content = theGrid;
            Button aBtn = new Button();
            aBtn.FontSize = 26;
            aBtn.Height = 100;
            aBtn.Width = 300;
            // need a wrap panel to place content w/n
            WrapPanel wrapPanel = new WrapPanel();
            TextBlock textBlock1 = new TextBlock();
            TextBlock textBlock2 = new TextBlock();
            TextBlock textBlock3 = new TextBlock();
            textBlock1.Text = "multi line";
            textBlock2.Text = "multi line";
            textBlock3.Text = "multi line";
            textBlock1.Foreground = Brushes.Crimson;
            textBlock2.Foreground = Brushes.DarkGoldenrod;
            textBlock3.Foreground = Brushes.DarkViolet;
            wrapPanel.Children.Add(textBlock1);
            wrapPanel.Children.Add(textBlock2);
            wrapPanel.Children.Add(textBlock3);
            aBtn.Content = wrapPanel;
            theGrid.Children.Add(aBtn);
        }
    }
}
