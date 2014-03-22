using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ZoomExample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Notes.Text = mySettings.Default.Notes;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void noteHandler(object sender, RoutedEventArgs e)
        {
            Notes.Visibility = System.Windows.Visibility.Visible;
        }

        private void RatingControl_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
        private void saveHandler(object sender, RoutedEventArgs e)
        {
            mySettings.Default.Notes = Notes.Text;
            mySettings.Default.Save();
        }
       

    }
}
