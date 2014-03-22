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
        Point? lastCenterPositionOnTarget;
        Point? lastMousePositionOnTarget;
        Point? lastDragPoint;
        int numClicks = 0;
        System.DateTime timer;
        public Window1()
        {
            InitializeComponent();
            Notes.Text = mySettings.Default.Notes;
            scrollViewer1.ScrollChanged += OnScrollViewerScrollChanged1;
            scrollViewer1.MouseLeftButtonUp += OnMouseLeftButtonUp1;
            scrollViewer1.PreviewMouseLeftButtonUp += OnMouseLeftButtonUp1;
            scrollViewer1.PreviewMouseWheel += OnPreviewMouseWheel1;

            scrollViewer1.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown1;
            scrollViewer1.MouseMove += OnMouseMove1;
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
            noteRec.Visibility = System.Windows.Visibility.Visible;
        }

        private void RatingControl_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
        private void saveHandler(object sender, RoutedEventArgs e)
        {
            mySettings.Default.Notes = Notes.Text;
            mySettings.Default.Save();
        }
        private void showRecipe(object sender, RoutedEventArgs e)
        {
            recipeBox.Visibility = System.Windows.Visibility.Visible;
            recipeBox1.Visibility = System.Windows.Visibility.Visible;
            recipeBox2.Visibility = System.Windows.Visibility.Visible;
            recipeBox3.Visibility = System.Windows.Visibility.Visible;
            recipeBox4.Visibility = System.Windows.Visibility.Visible;
            recipeBox5.Visibility = System.Windows.Visibility.Visible;
            recipeBox6.Visibility = System.Windows.Visibility.Visible;
            recipeBox7.Visibility = System.Windows.Visibility.Visible;
            recipeBox8.Visibility = System.Windows.Visibility.Visible;
            recipeBox9.Visibility = System.Windows.Visibility.Visible;
            recipeBox10.Visibility = System.Windows.Visibility.Visible;
            recipeBox11.Visibility = System.Windows.Visibility.Visible;
            recipeBox12.Visibility = System.Windows.Visibility.Visible;
            recipeBox13.Visibility = System.Windows.Visibility.Visible;
            ingredientBox.Visibility = System.Windows.Visibility.Collapsed;
            ingredientBox1.Visibility = System.Windows.Visibility.Collapsed;
            ingredientBox2.Visibility = System.Windows.Visibility.Collapsed;
            ingredientBox3.Visibility = System.Windows.Visibility.Collapsed;
            ingredientBox4.Visibility = System.Windows.Visibility.Collapsed;
            reviewBox.Visibility = System.Windows.Visibility.Collapsed;
        }
        private void showIngredients(object sender, RoutedEventArgs e)
        {
            recipeBox.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox1.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox2.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox3.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox4.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox5.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox6.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox7.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox8.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox9.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox10.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox11.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox12.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox13.Visibility = System.Windows.Visibility.Collapsed;
            ingredientBox.Visibility = System.Windows.Visibility.Visible;
            ingredientBox1.Visibility = System.Windows.Visibility.Visible;
            ingredientBox2.Visibility = System.Windows.Visibility.Visible;
            ingredientBox3.Visibility = System.Windows.Visibility.Visible;
            ingredientBox4.Visibility = System.Windows.Visibility.Visible;
            reviewBox.Visibility = System.Windows.Visibility.Collapsed;
        }
        private void showReview(object sender, RoutedEventArgs e)
        {
            recipeBox.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox1.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox2.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox3.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox4.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox5.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox6.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox7.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox8.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox9.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox10.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox11.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox12.Visibility = System.Windows.Visibility.Collapsed;
            recipeBox13.Visibility = System.Windows.Visibility.Collapsed;
            ingredientBox.Visibility = System.Windows.Visibility.Collapsed;
            ingredientBox1.Visibility = System.Windows.Visibility.Collapsed;
            ingredientBox2.Visibility = System.Windows.Visibility.Collapsed;
            ingredientBox3.Visibility = System.Windows.Visibility.Collapsed;
            ingredientBox4.Visibility = System.Windows.Visibility.Collapsed;
            reviewBox.Visibility = System.Windows.Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void OnMouseMove1(object sender, MouseEventArgs e)
        {
            if (lastDragPoint.HasValue)
            {
                Point posNow = e.GetPosition(scrollViewer1);

                double dX = posNow.Y - lastDragPoint.Value.Y;

                lastDragPoint = posNow;

                scrollViewer1.ScrollToVerticalOffset(scrollViewer1.VerticalOffset - dX);
            }
        }

        void OnMouseLeftButtonDown1(object sender, MouseButtonEventArgs e)
        {
            timer = System.DateTime.Now;
            var mousePos = e.GetPosition(scrollViewer1);
            if (mousePos.Y <= scrollViewer1.ViewportHeight) //make sure we still can use the scrollbars
            {
                scrollViewer1.Cursor = Cursors.SizeAll;
                lastDragPoint = mousePos;
                Mouse.Capture(scrollViewer1);
            }
        }

        void OnPreviewMouseWheel1(object sender, MouseWheelEventArgs e)
        {
        }

        void OnMouseLeftButtonUp1(object sender, MouseButtonEventArgs e)
        {
            scrollViewer1.Cursor = Cursors.Arrow;
            scrollViewer1.ReleaseMouseCapture();
            lastDragPoint = null;
        }

        /*void OnSliderValueChanged1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            scaleTransform.ScaleX = e.NewValue;

            var centerOfViewport = new Point(scrollViewer1.ViewportWidth / 2, scrollViewer1.ViewportHeight / 2);
            lastCenterPositionOnTarget = scrollViewer1.TranslatePoint(centerOfViewport, grid);
        }*/

        void OnScrollViewerScrollChanged1(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange != 0 || e.ExtentWidthChange != 0)
            {
                Point? targetBefore = null;
                Point? targetNow = null;

                if (!lastMousePositionOnTarget.HasValue)
                {
                    if (lastCenterPositionOnTarget.HasValue)
                    {
                        var centerOfViewport = new Point(scrollViewer1.ViewportWidth / 2, scrollViewer1.ViewportHeight / 2);
                        Point centerOfTargetNow = scrollViewer1.TranslatePoint(centerOfViewport, grid);

                        targetBefore = lastCenterPositionOnTarget;
                        targetNow = centerOfTargetNow;
                    }
                }
                else
                {
                    targetBefore = lastMousePositionOnTarget;
                    targetNow = Mouse.GetPosition(grid);

                    lastMousePositionOnTarget = null;
                }

                if (targetBefore.HasValue)
                {
                    double dXInTargetPixels = targetNow.Value.Y - targetBefore.Value.Y;

                    double multiplicatorX = e.ExtentHeight / grid.Height;

                    double newOffsetX = scrollViewer1.VerticalOffset - dXInTargetPixels * multiplicatorX;

                    if (double.IsNaN(newOffsetX))
                    {
                        return;
                    }

                    scrollViewer1.ScrollToHorizontalOffset(newOffsetX);
                }
            }
        }

    }
}
