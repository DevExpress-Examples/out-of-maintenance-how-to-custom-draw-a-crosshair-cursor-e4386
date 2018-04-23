using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Charts;
using DevExpress.Xpf.Charts.Native;

namespace CrosshairCursorCustomDraw
{
    public partial class MainPage : UserControl
    {
        bool handleCustomDraw;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            handleCustomDraw = true;
            chartControl1.CustomDrawCrosshair += chartControl1_CustomDrawCrosshair;
        }
        private void chartControl1_CustomDrawCrosshair(object sender, CustomDrawCrosshairEventArgs e)
        {
            if (!handleCustomDraw) return;

            // Specify the crosshair argument line color and thickness.
            e.CrosshairLineElement.Brush = Brushes.Red;
            e.CrosshairLineElement.LineStyle.Thickness = 3;

            // Specify  the background  and font size for the crosshair argument label. 
            foreach (CrosshairAxisLabelElement axisLabelElement in e.CrosshairAxisLabelElements)
            {
                axisLabelElement.Background = Brushes.Blue;
                axisLabelElement.FontSize = 14;
            }

            foreach (CrosshairElement element in e.CrosshairElements)
            {
                // Specify the color and thickness for the crosshair value lines.                 
                element.LineElement.Brush = Brushes.Blue;
                element.LineElement.LineStyle.Thickness = 2;

                // Specify the  font size and background for the crosshair value labels.
                element.AxisLabelElement.FontSize = 14;
                element.AxisLabelElement.Background = Brushes.Red;

                // Specify the foreground and  font size for the crosshair  cursor label that shows series. 
                element.LabelElement.Foreground = Brushes.Red;
                element.LabelElement.FontSize = 14;

            }
        }
    }
}
