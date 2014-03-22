using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ZoomExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point? lastCenterPositionOnTarget;
        Point? lastMousePositionOnTarget;
        Point? lastDragPoint;
        int numClicks = 0;
        System.DateTime timer;
        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Media.SolidColorBrush partiallyTransparentSolidColorBrush = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.LightBlue);
            partiallyTransparentSolidColorBrush.Opacity = 1.0;
            //scrollViewer.Background = partiallyTransparentSolidColorBrush;
            System.Windows.Media.ImageBrush myBrush = new System.Windows.Media.ImageBrush();
            //myBrush.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new System.Uri(@"Resources/background2.jpg", System.UriKind.Relative));
            //scrollViewer.Background = myBrush;
            //partiallyTransparentSolidColorBrush = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.);
            //partiallyTransparentSolidColorBrush.Opacity = 0.3;
            //leftStackPanel.Background = partiallyTransparentSolidColorBrush;
            //badStackPanel.Background = partiallyTransparentSolidColorBrush;
            //scrollViewer2.Background = partiallyTransparentSolidColorBrush;
            //scrollViewer3.Background = partiallyTransparentSolidColorBrush;
            //scrollViewer4.Background = partiallyTransparentSolidColorBrush;
            cook.Click += cook_Click;
            noThx.Click += noThx_Click;
            scrollViewer1.ScrollChanged += OnScrollViewerScrollChanged1;
            scrollViewer1.MouseLeftButtonUp += OnMouseLeftButtonUp1;
            scrollViewer1.PreviewMouseLeftButtonUp += OnMouseLeftButtonUp1;
            scrollViewer1.PreviewMouseWheel += OnPreviewMouseWheel1;

            scrollViewer1.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown1;
            scrollViewer1.MouseMove += OnMouseMove1;

            scrollViewer2.ScrollChanged += OnScrollViewerScrollChanged2;
            scrollViewer2.MouseLeftButtonUp += OnMouseLeftButtonUp2;
            scrollViewer2.PreviewMouseLeftButtonUp += OnMouseLeftButtonUp2;
            scrollViewer2.PreviewMouseWheel += OnPreviewMouseWheel2;

            scrollViewer2.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown2;
            scrollViewer2.MouseMove += OnMouseMove2;

            scrollViewer3.ScrollChanged += OnScrollViewerScrollChanged3;
            scrollViewer3.MouseLeftButtonUp += OnMouseLeftButtonUp3;
            scrollViewer3.PreviewMouseLeftButtonUp += OnMouseLeftButtonUp3;
            scrollViewer3.PreviewMouseWheel += OnPreviewMouseWheel3;

            scrollViewer3.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown3;
            scrollViewer3.MouseMove += OnMouseMove3;

            scrollViewer4.ScrollChanged += OnScrollViewerScrollChanged4;
            scrollViewer4.MouseLeftButtonUp += OnMouseLeftButtonUp4;
            scrollViewer4.PreviewMouseLeftButtonUp += OnMouseLeftButtonUp4;
            scrollViewer4.PreviewMouseWheel += OnPreviewMouseWheel4;

            scrollViewer4.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown4;
            scrollViewer4.MouseMove += OnMouseMove4;
        }

        void noThx_Click(object sender, RoutedEventArgs e)
        {
            badStackPanel.Visibility = System.Windows.Visibility.Hidden;
            border.Visibility = System.Windows.Visibility.Hidden;  
        }

        void cook_Click(object sender, RoutedEventArgs e)
        {
            badStackPanel.Visibility = System.Windows.Visibility.Hidden;
            border.Visibility = System.Windows.Visibility.Hidden;  
            Window1 win = new Window1();
            win.ShowDialog();
        }

        void OnMouseMove1(object sender, MouseEventArgs e)
        {
            if (lastDragPoint.HasValue)
            {
                Point posNow = e.GetPosition(scrollViewer1);

                double dX = posNow.X - lastDragPoint.Value.X;

                lastDragPoint = posNow;

                scrollViewer1.ScrollToHorizontalOffset(scrollViewer1.HorizontalOffset - dX);
            }
        }

        void OnMouseLeftButtonDown1(object sender, MouseButtonEventArgs e)
        {
            timer = System.DateTime.Now;
            var mousePos = e.GetPosition(scrollViewer1);
            if (mousePos.X <= scrollViewer1.ViewportWidth) //make sure we still can use the scrollbars
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
                    double dXInTargetPixels = targetNow.Value.X - targetBefore.Value.X;

                    double multiplicatorX = e.ExtentWidth / grid.Width;

                    double newOffsetX = scrollViewer1.HorizontalOffset - dXInTargetPixels * multiplicatorX;

                    if (double.IsNaN(newOffsetX))
                    {
                        return;
                    }

                    scrollViewer1.ScrollToHorizontalOffset(newOffsetX);
                }
            }
        }
        void OnMouseMove2(object sender, MouseEventArgs e)
        {
            if (lastDragPoint.HasValue)
            {
                Point posNow = e.GetPosition(scrollViewer2);

                double dX = posNow.X - lastDragPoint.Value.X;

                lastDragPoint = posNow;

                scrollViewer2.ScrollToHorizontalOffset(scrollViewer2.HorizontalOffset - dX);
            }
        }

        void OnMouseLeftButtonDown2(object sender, MouseButtonEventArgs e)
        {
            var mousePos = e.GetPosition(scrollViewer2);
            if (mousePos.X <= scrollViewer2.ViewportWidth && mousePos.Y < scrollViewer2.ViewportHeight) //make sure we still can use the scrollbars
            {
                scrollViewer2.Cursor = Cursors.SizeAll;
                lastDragPoint = mousePos;
                Mouse.Capture(scrollViewer2);
            }
        }

        void OnPreviewMouseWheel2(object sender, MouseWheelEventArgs e)
        {
        }

        void OnMouseLeftButtonUp2(object sender, MouseButtonEventArgs e)
        {
            scrollViewer2.Cursor = Cursors.Arrow;
            scrollViewer2.ReleaseMouseCapture();
            lastDragPoint = null;
        }

        void OnSliderValueChanged2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            scaleTransform.ScaleX = e.NewValue;

            var centerOfViewport = new Point(scrollViewer2.ViewportWidth / 2, scrollViewer2.ViewportHeight / 2);
            lastCenterPositionOnTarget = scrollViewer2.TranslatePoint(centerOfViewport, grid);
        }

        void OnScrollViewerScrollChanged2(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange != 0 || e.ExtentWidthChange != 0)
            {
                Point? targetBefore = null;
                Point? targetNow = null;

                if (!lastMousePositionOnTarget.HasValue)
                {
                    if (lastCenterPositionOnTarget.HasValue)
                    {
                        var centerOfViewport = new Point(scrollViewer2.ViewportWidth / 2, scrollViewer2.ViewportHeight / 2);
                        Point centerOfTargetNow = scrollViewer2.TranslatePoint(centerOfViewport, grid);

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
                    double dXInTargetPixels = targetNow.Value.X - targetBefore.Value.X;

                    double multiplicatorX = e.ExtentWidth / grid.Width;

                    double newOffsetX = scrollViewer2.HorizontalOffset - dXInTargetPixels * multiplicatorX;

                    if (double.IsNaN(newOffsetX))
                    {
                        return;
                    }

                    scrollViewer2.ScrollToHorizontalOffset(newOffsetX);
                }
            }
        }

        void OnMouseMove3(object sender, MouseEventArgs e)
        {
            if (lastDragPoint.HasValue)
            {
                Point posNow = e.GetPosition(scrollViewer3);

                double dX = posNow.X - lastDragPoint.Value.X;

                lastDragPoint = posNow;

                scrollViewer3.ScrollToHorizontalOffset(scrollViewer3.HorizontalOffset - dX);
            }
        }

        void OnMouseLeftButtonDown3(object sender, MouseButtonEventArgs e)
        {
            var mousePos = e.GetPosition(scrollViewer3);
            if (mousePos.X <= scrollViewer3.ViewportWidth) //make sure we still can use the scrollbars
            {
                scrollViewer3.Cursor = Cursors.SizeAll;
                lastDragPoint = mousePos;
                Mouse.Capture(scrollViewer3);
            }
        }

        void OnPreviewMouseWheel3(object sender, MouseWheelEventArgs e)
        {
        }

        void OnMouseLeftButtonUp3(object sender, MouseButtonEventArgs e)
        {
            scrollViewer3.Cursor = Cursors.Arrow;
            scrollViewer3.ReleaseMouseCapture();
            lastDragPoint = null;
        }

        void OnSliderValueChanged3(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            scaleTransform.ScaleX = e.NewValue;

            var centerOfViewport = new Point(scrollViewer3.ViewportWidth / 2, scrollViewer3.ViewportHeight / 2);
            lastCenterPositionOnTarget = scrollViewer3.TranslatePoint(centerOfViewport, grid);
        }

        void OnScrollViewerScrollChanged3(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange != 0 || e.ExtentWidthChange != 0)
            {
                Point? targetBefore = null;
                Point? targetNow = null;

                if (!lastMousePositionOnTarget.HasValue)
                {
                    if (lastCenterPositionOnTarget.HasValue)
                    {
                        var centerOfViewport = new Point(scrollViewer3.ViewportWidth / 2, scrollViewer3.ViewportHeight / 2);
                        Point centerOfTargetNow = scrollViewer3.TranslatePoint(centerOfViewport, grid);

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
                    double dXInTargetPixels = targetNow.Value.X - targetBefore.Value.X;

                    double multiplicatorX = e.ExtentWidth / grid.Width;

                    double newOffsetX = scrollViewer3.HorizontalOffset - dXInTargetPixels * multiplicatorX;

                    if (double.IsNaN(newOffsetX))
                    {
                        return;
                    }

                    scrollViewer3.ScrollToHorizontalOffset(newOffsetX);
                }
            }
        }

        void OnMouseMove4(object sender, MouseEventArgs e)
        {
            if (lastDragPoint.HasValue)
            {
                Point posNow = e.GetPosition(scrollViewer4);

                double dX = posNow.X - lastDragPoint.Value.X;

                lastDragPoint = posNow;

                scrollViewer4.ScrollToHorizontalOffset(scrollViewer4.HorizontalOffset - dX);
            }
        }

        void OnMouseLeftButtonDown4(object sender, MouseButtonEventArgs e)
        {
            var mousePos = e.GetPosition(scrollViewer4);
            if (mousePos.X <= scrollViewer4.ViewportWidth) //make sure we still can use the scrollbars
            {
                scrollViewer4.Cursor = Cursors.SizeAll;
                lastDragPoint = mousePos;
                Mouse.Capture(scrollViewer4);
            }
        }

        void OnPreviewMouseWheel4(object sender, MouseWheelEventArgs e)
        {
        }

        void OnMouseLeftButtonUp4(object sender, MouseButtonEventArgs e)
        {
            scrollViewer4.Cursor = Cursors.Arrow;
            scrollViewer4.ReleaseMouseCapture();
            lastDragPoint = null;
        }

        void OnSliderValueChanged4(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            scaleTransform.ScaleX = e.NewValue;

            var centerOfViewport = new Point(scrollViewer4.ViewportWidth / 2, scrollViewer4.ViewportHeight / 2);
            lastCenterPositionOnTarget = scrollViewer4.TranslatePoint(centerOfViewport, grid);
        }

        void OnScrollViewerScrollChanged4(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange != 0 || e.ExtentWidthChange != 0)
            {
                Point? targetBefore = null;
                Point? targetNow = null;

                if (!lastMousePositionOnTarget.HasValue)
                {
                    if (lastCenterPositionOnTarget.HasValue)
                    {
                        var centerOfViewport = new Point(scrollViewer4.ViewportWidth / 2, scrollViewer4.ViewportHeight / 2);
                        Point centerOfTargetNow = scrollViewer4.TranslatePoint(centerOfViewport, grid);

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
                    double dXInTargetPixels = targetNow.Value.X - targetBefore.Value.X;

                    double multiplicatorX = e.ExtentWidth / grid.Width;

                    double newOffsetX = scrollViewer4.HorizontalOffset - dXInTargetPixels * multiplicatorX;

                    if (double.IsNaN(newOffsetX))
                    {
                        return;
                    }

                    scrollViewer4.ScrollToHorizontalOffset(newOffsetX);
                }
            }
        }

        private void btn11_Click(object sender, RoutedEventArgs e)
        {
            //numClicks = numClicks + 1;
            //if (numClicks == 2)
            //{
                System.DateTime timeout = System.DateTime.Now;
                if ((timeout - timer).TotalSeconds < 0.5)
                {
                    //System.Console.WriteLine("BUTTON PUSHED");
                    badStackPanel.Visibility = System.Windows.Visibility.Visible;
                    border.Visibility = System.Windows.Visibility.Visible;
                   // Window1 win = new Window1();
                    //win.ShowDialog();
                    numClicks = 0;
                }
                else
                {
                    numClicks = 0;
                }
            //}
            //else
            //{
              //  timer = System.DateTime.Now;
            //}
        }
    }

}