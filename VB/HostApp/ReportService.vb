Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Reflection
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Parameters

Namespace HostApp
	Public Class ReportService
		Implements IReportService
		Public Function GetReportNames() As String() Implements IReportService.GetReportNames
			Dim types() As Type = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
			Dim reportTypes As New List(Of String)()

			For i As Integer = 0 To types.Length - 1
				If GetType(XtraReport).IsAssignableFrom(types(i)) Then
					reportTypes.Add(types(i).FullName)
				End If
			Next i

			Return reportTypes.ToArray()
		End Function

		Public Function GetReportLayout(ByVal reportName As String) As Byte() Implements IReportService.GetReportLayout
			Dim report As XtraReport = CreateReportByName(reportName)
			Dim memoryStream As New MemoryStream()

			report.SaveLayout(memoryStream)

			Return memoryStream.ToArray()
		End Function

		Public Function GetReportDocument(ByVal reportName As String) As Byte() Implements IReportService.GetReportDocument
			Dim report As XtraReport = CreateReportByName(reportName)
			Dim memoryStream As New MemoryStream()

			' Disable report parameters' visibility to prevent the 'Parameters' dialog from popping up in the WCF host process
			For i As Integer = 0 To report.Parameters.Count - 1
				report.Parameters(i).Visible = False
			Next i

			report.CreateDocument()
			report.PrintingSystem.SaveDocument(memoryStream)

			Return memoryStream.ToArray()
		End Function

		Public Function GetParametrizedReportDocument(ByVal reportName As String, ByVal parameters() As ReportParameterInfo) As Byte() Implements IReportService.GetParametrizedReportDocument
			Dim report As XtraReport = CreateReportByName(reportName)
			Dim memoryStream As New MemoryStream()

			' Disable report parameters' visibility to prevent the 'Parameters' dialog from popping up in the WCF host process
			For i As Integer = 0 To report.Parameters.Count - 1
				report.Parameters(i).Visible = False
			Next i

			For i As Integer = 0 To parameters.Length - 1
				Dim repPar As Parameter = report.Parameters(parameters(i).Name)

				If repPar IsNot Nothing Then
					repPar.Value = parameters(i).Value
				End If
			Next i

			report.CreateDocument()
			report.PrintingSystem.SaveDocument(memoryStream)

			Return memoryStream.ToArray()
		End Function

		Private Function CreateReportByName(ByVal reportName As String) As XtraReport
			Return CType(Activator.CreateInstance(Nothing, reportName).Unwrap(), XtraReport)
		End Function
	End Class
End Namespace