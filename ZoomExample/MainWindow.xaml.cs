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

        public MainWindow()
        {
            InitializeComponent();

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

        void OnMouseMove1(object sender, MouseEventArgs e)
        {
            if (lastDragPoint.HasValue)
            {
                Point posNow = e.GetPosition(scrollViewer1);

                double dX = posNow.X - lastDragPoint.Value.X;
                double dY = posNow.Y - lastDragPoint.Value.Y;

                lastDragPoint = posNow;

                scrollViewer1.ScrollToHorizontalOffset(scrollViewer1.HorizontalOffset - dX);
                scrollViewer1.ScrollToVerticalOffset(scrollViewer1.VerticalOffset - dY);
            }
        }

        void OnMouseLeftButtonDown1(object sender, MouseButtonEventArgs e)
        {
            var mousePos = e.GetPosition(scrollViewer1);
            if (mousePos.X <= scrollViewer1.ViewportWidth && mousePos.Y < scrollViewer1.ViewportHeight) //make sure we still can use the scrollbars
            {
                scrollViewer1.Cursor = Cursors.SizeAll;
                lastDragPoint = mousePos;
                Mouse.Capture(scrollViewer1);
            }
        }

        void OnPreviewMouseWheel1(object sender, MouseWheelEventArgs e)
        {
            lastMousePositionOnTarget = Mouse.GetPosition(grid);

            if (e.Delta > 0)
            {
                //slider
            }
            if (e.Delta < 0)
            {
                //slider
            }

            e.Handled = true;
        }

        void OnMouseLeftButtonUp1(object sender, MouseButtonEventArgs e)
        {
            scrollViewer1.Cursor = Cursors.Arrow;
            scrollViewer1.ReleaseMouseCapture();
            lastDragPoint = null;
        }

        void OnSliderValueChanged1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            scaleTransform.ScaleX = e.NewValue;
            scaleTransform.ScaleY = e.NewValue;

            var centerOfViewport = new Point(scrollViewer1.ViewportWidth / 2, scrollViewer1.ViewportHeight / 2);
            lastCenterPositionOnTarget = scrollViewer1.TranslatePoint(centerOfViewport, grid);
        }

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
                    double dYInTargetPixels = targetNow.Value.Y - targetBefore.Value.Y;

                    double multiplicatorX = e.ExtentWidth / grid.Width;
                    double multiplicatorY = e.ExtentHeight / grid.Height;

                    double newOffsetX = scrollViewer1.HorizontalOffset - dXInTargetPixels * multiplicatorX;
                    double newOffsetY = scrollViewer1.VerticalOffset - dYInTargetPixels * multiplicatorY;

                    if (double.IsNaN(newOffsetX) || double.IsNaN(newOffsetY))
                    {
                        return;
                    }

                    scrollViewer1.ScrollToHorizontalOffset(newOffsetX);
                    scrollViewer1.ScrollToVerticalOffset(newOffsetY);
                }
            }
        }
        void OnMouseMove2(object sender, MouseEventArgs e)
        {
            if (lastDragPoint.HasValue)
            {
                Point posNow = e.GetPosition(scrollViewer2);

                double dX = posNow.X - lastDragPoint.Value.X;
                double dY = posNow.Y - lastDragPoint.Value.Y;

                lastDragPoint = posNow;

                scrollViewer2.ScrollToHorizontalOffset(scrollViewer2.HorizontalOffset - dX);
                scrollViewer2.ScrollToVerticalOffset(scrollViewer2.VerticalOffset - dY);
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
            lastMousePositionOnTarget = Mouse.GetPosition(grid);

            if (e.Delta > 0)
            {
                //slider
            }
            if (e.Delta < 0)
            {
                //slider
            }

            e.Handled = true;
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
            scaleTransform.ScaleY = e.NewValue;

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
                    double dYInTargetPixels = targetNow.Value.Y - targetBefore.Value.Y;

                    double multiplicatorX = e.ExtentWidth / grid.Width;
                    double multiplicatorY = e.ExtentHeight / grid.Height;

                    double newOffsetX = scrollViewer2.HorizontalOffset - dXInTargetPixels * multiplicatorX;
                    double newOffsetY = scrollViewer2.VerticalOffset - dYInTargetPixels * multiplicatorY;

                    if (double.IsNaN(newOffsetX) || double.IsNaN(newOffsetY))
                    {
                        return;
                    }

                    scrollViewer2.ScrollToHorizontalOffset(newOffsetX);
                    scrollViewer2.ScrollToVerticalOffset(newOffsetY);
                }
            }
        }

        void OnMouseMove3(object sender, MouseEventArgs e)
        {
            if (lastDragPoint.HasValue)
            {
                Point posNow = e.GetPosition(scrollViewer3);

                double dX = posNow.X - lastDragPoint.Value.X;
                double dY = posNow.Y - lastDragPoint.Value.Y;

                lastDragPoint = posNow;

                scrollViewer3.ScrollToHorizontalOffset(scrollViewer3.HorizontalOffset - dX);
                scrollViewer3.ScrollToVerticalOffset(scrollViewer3.VerticalOffset - dY);
            }
        }

        void OnMouseLeftButtonDown3(object sender, MouseButtonEventArgs e)
        {
            var mousePos = e.GetPosition(scrollViewer3);
            if (mousePos.X <= scrollViewer3.ViewportWidth && mousePos.Y < scrollViewer3.ViewportHeight) //make sure we still can use the scrollbars
            {
                scrollViewer3.Cursor = Cursors.SizeAll;
                lastDragPoint = mousePos;
                Mouse.Capture(scrollViewer3);
            }
        }

        void OnPreviewMouseWheel3(object sender, MouseWheelEventArgs e)
        {
            lastMousePositionOnTarget = Mouse.GetPosition(grid);

            if (e.Delta > 0)
            {
                //slider
            }
            if (e.Delta < 0)
            {
                //slider
            }

            e.Handled = true;
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
            scaleTransform.ScaleY = e.NewValue;

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
                    double dYInTargetPixels = targetNow.Value.Y - targetBefore.Value.Y;

                    double multiplicatorX = e.ExtentWidth / grid.Width;
                    double multiplicatorY = e.ExtentHeight / grid.Height;

                    double newOffsetX = scrollViewer3.HorizontalOffset - dXInTargetPixels * multiplicatorX;
                    double newOffsetY = scrollViewer3.VerticalOffset - dYInTargetPixels * multiplicatorY;

                    if (double.IsNaN(newOffsetX) || double.IsNaN(newOffsetY))
                    {
                        return;
                    }

                    scrollViewer3.ScrollToHorizontalOffset(newOffsetX);
                    scrollViewer3.ScrollToVerticalOffset(newOffsetY);
                }
            }
        }

        void OnMouseMove4(object sender, MouseEventArgs e)
        {
            if (lastDragPoint.HasValue)
            {
                Point posNow = e.GetPosition(scrollViewer4);

                double dX = posNow.X - lastDragPoint.Value.X;
                double dY = posNow.Y - lastDragPoint.Value.Y;

                lastDragPoint = posNow;

                scrollViewer4.ScrollToHorizontalOffset(scrollViewer4.HorizontalOffset - dX);
                scrollViewer4.ScrollToVerticalOffset(scrollViewer4.VerticalOffset - dY);
            }
        }

        void OnMouseLeftButtonDown4(object sender, MouseButtonEventArgs e)
        {
            var mousePos = e.GetPosition(scrollViewer4);
            if (mousePos.X <= scrollViewer4.ViewportWidth && mousePos.Y < scrollViewer4.ViewportHeight) //make sure we still can use the scrollbars
            {
                scrollViewer4.Cursor = Cursors.SizeAll;
                lastDragPoint = mousePos;
                Mouse.Capture(scrollViewer4);
            }
        }

        void OnPreviewMouseWheel4(object sender, MouseWheelEventArgs e)
        {
            lastMousePositionOnTarget = Mouse.GetPosition(grid);

            if (e.Delta > 0)
            {
                //slider
            }
            if (e.Delta < 0)
            {
                //slider
            }

            e.Handled = true;
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
            scaleTransform.ScaleY = e.NewValue;

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
                    double dYInTargetPixels = targetNow.Value.Y - targetBefore.Value.Y;

                    double multiplicatorX = e.ExtentWidth / grid.Width;
                    double multiplicatorY = e.ExtentHeight / grid.Height;

                    double newOffsetX = scrollViewer4.HorizontalOffset - dXInTargetPixels * multiplicatorX;
                    double newOffsetY = scrollViewer4.VerticalOffset - dYInTargetPixels * multiplicatorY;

                    if (double.IsNaN(newOffsetX) || double.IsNaN(newOffsetY))
                    {
                        return;
                    }

                    scrollViewer4.ScrollToHorizontalOffset(newOffsetX);
                    scrollViewer4.ScrollToVerticalOffset(newOffsetY);
                }
            }
        }
    }
}