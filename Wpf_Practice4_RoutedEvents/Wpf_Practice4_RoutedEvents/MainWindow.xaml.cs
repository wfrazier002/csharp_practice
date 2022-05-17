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

namespace Wpf_Practice4_RoutedEvents {

    // notes for events in C#/Wpf:
    // https://stackoverflow.com/questions/16736444/difference-between-bubbling-and-tunneling-events?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
    // Routed events - WPF mechanisms to handle events
    // Direct routed events - handled by the item itself. e.g. click 

    // Bubbling Event - Bubbling happens when the event is not handled by the element 
    // ( say a textbox) and the event "bubbles" its way up the UI containers which hold it. 
    // For example, let's say you have a window that contains a panel and inside that panel 
    // you have a grid and inside the grid you have a textbox. If the event is not handled by the textbox, 
    // then it moves, is passed or "bubbles" up to the grid level (as the grid contains the textbox),
    // if it is not handled at that level then the event bubbles further up the "tree" (known as a visual tree) 
    // to the panel where it may or may not be handled. This process continues until it is handled or the event 
    // "escapes" the top most element.
    // Examples of a bubbling event would be something like a MouseButtonDown event. Or a Keydown event.

    /// Tunneling Event
    /// Tunneling is the opposite of Bubbling.So instead of an event going "up" the visual tree, 
    /// the event travels down the visual tree toward the element that is considered the source.
    /// The standard WPF naming definition of a tunneling event is that they all start with "preview"
    /// for example previewdownkey and previewmousebuttondown. You can catch them on their way to the "target"
    /// element and handle it. An example for this might be perhaps you have some controls inside 
    /// a grid control and for some reason you have decided that no control within that grid will 
    /// be allowed to have the letter "t" reach it.

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        // this is a direct event
        private void Button_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("button was clicked - this is a direct event");
        }

        // this is a bubbling event - isn't handled in button, so goes up the tree (if a child can't do it, then the parent does; if they can't, their parent can; etc...)
        private void Button_MouseUp_1(object sender, MouseButtonEventArgs e) {
            MessageBox.Show("right mouse button was clicked/unclicked (went back up after being released) - this is a bubbling event");
            // this one works only for right mouse clicks (even tho it wasn't programed for the right mouse btn)
        }

        // this is a tunneling event - 
        private void Button_PreviewMouseUp(object sender, MouseButtonEventArgs e) {
            MessageBox.Show("mouse button was clicked/unclicked (went back up after being released) - this is a tunneling event");
            // this one works for both right and left mouse clicks
        }

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            MessageBox.Show("left mouse button was clicked down  - this is a tunneling event");
        }

        private void Button_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e) {
            MessageBox.Show("right mouse button was clicked/unclicked (went back up after being released) - this is a tunneling event");
        }
    }
}
