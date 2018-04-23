Imports Microsoft.VisualBasic
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.Charts
Imports DevExpress.Xpf.Charts.Native

Namespace CrosshairCursorCustomDraw
	Partial Public Class MainPage
		Inherits UserControl
		Private handleCustomDraw As Boolean

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			handleCustomDraw = True
			AddHandler chartControl1.CustomDrawCrosshair, AddressOf chartControl1_CustomDrawCrosshair
		End Sub
		Private Sub chartControl1_CustomDrawCrosshair(ByVal sender As Object, ByVal e As CustomDrawCrosshairEventArgs)
			If (Not handleCustomDraw) Then
				Return
			End If

			' Specify the crosshair argument line color and thickness.
			e.CrosshairLineElement.Brush = Brushes.Red
			e.CrosshairLineElement.LineStyle.Thickness = 3

			' Specify  the background  and font size for the crosshair argument label. 
			For Each axisLabelElement As CrosshairAxisLabelElement In e.CrosshairAxisLabelElements
				axisLabelElement.Background = Brushes.Blue
				axisLabelElement.FontSize = 14
			Next axisLabelElement

			For Each element As CrosshairElement In e.CrosshairElements
				' Specify the color and thickness for the crosshair value lines.                 
				element.LineElement.Brush = Brushes.Blue
				element.LineElement.LineStyle.Thickness = 2

				' Specify the  font size and background for the crosshair value labels.
				element.AxisLabelElement.FontSize = 14
				element.AxisLabelElement.Background = Brushes.Red

				' Specify the foreground and  font size for the crosshair  cursor label that shows series. 
				element.LabelElement.Foreground = Brushes.Red
				element.LabelElement.FontSize = 14

			Next element
		End Sub
	End Class
End Namespace
