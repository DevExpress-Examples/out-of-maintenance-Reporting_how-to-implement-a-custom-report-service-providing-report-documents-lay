Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports DevExpress.XtraReports.UI
Imports System.Collections.Generic

Namespace HostApp
	Partial Public Class InvoicesReport
		Inherits DevExpress.XtraReports.UI.XtraReport
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub InvoicesReport_DataSourceDemanded(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.DataSourceDemanded
		  Dim invoices As New List(Of Invoice)(10)

		  invoices.Add(New Invoice(0, "Invoice1", 10.0D))
		  invoices.Add(New Invoice(1, "Invoice2", 15.0D))
		  invoices.Add(New Invoice(2, "Invoice3", 20.0D))

		  Me.DataSource = invoices
		End Sub
	End Class
End Namespace