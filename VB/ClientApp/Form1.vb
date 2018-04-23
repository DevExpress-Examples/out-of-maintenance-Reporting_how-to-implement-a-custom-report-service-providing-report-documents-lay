Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrinting.Preview
Imports ClientApp.ReportServiceReference

Namespace ClientApp
	Partial Public Class Form1
		Inherits Form
		Private client As ReportServiceClient

		Public Sub New()
			InitializeComponent()

			client = New ReportServiceClient("NetTcpBinding_IReportService")
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			comboBox1.DataSource = client.GetReportNames()
		End Sub

		Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
			If comboBox1.SelectedValue Is Nothing Then
				MessageBox.Show("Please select a report.")
				Return
			End If

			Dim reportName As String = comboBox1.SelectedValue.ToString()
			Dim reportDocument() As Byte = Nothing

			If (Not reportName.Contains("Parametrized")) Then
				reportDocument = client.GetReportDocument(reportName)
			Else
				reportDocument = client.GetParametrizedReportDocument("HostApp.ParametrizedReport", New ReportParameterInfo() { New ReportParameterInfo() With {.Name = "parameter1", .Value = DateTime.Now} })
			End If

			Dim memoryStream As New MemoryStream(reportDocument)
			Dim preview As New PrintPreviewFormEx() With {.PrintingSystem = New PrintingSystem()}
			preview.PrintingSystem.LoadDocument(memoryStream)
			preview.ShowDialog()
		End Sub
	End Class
End Namespace