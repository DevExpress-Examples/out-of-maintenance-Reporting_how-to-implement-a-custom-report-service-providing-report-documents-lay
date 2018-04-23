Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Data

Namespace HostApp
	Public Class SampleDataSet
		Inherits DataSet
		Public Sub New()
			MyBase.New()
			Dim table As New DataTable("table")

			DataSetName = "SampleDataSet"

			table.Columns.Add("ID", GetType(Int32))
			table.Columns.Add("MyDateTime", GetType(DateTime))
			table.Columns.Add("MyRow", GetType(String))
			table.Columns.Add("MyData", GetType(Double))
			table.Constraints.Add("IDPK", table.Columns("ID"), True)

			Tables.AddRange(New DataTable() { table })
		End Sub

		Public Shared Function CreateData() As SampleDataSet
			Dim ds As New SampleDataSet()
			Dim table As DataTable = ds.Tables("table")

			table.Rows.Add(New Object() { 0, DateTime.Today, "A", 103 })
			table.Rows.Add(New Object() { 1, DateTime.Today, "B", 200 })
			table.Rows.Add(New Object() { 2, DateTime.Today, "C", 446 })
			table.Rows.Add(New Object() { 3, DateTime.Today.AddDays(1), "A", 788 })
			table.Rows.Add(New Object() { 4, DateTime.Today.AddDays(1), "B", 787 })
			table.Rows.Add(New Object() { 5, DateTime.Today.AddDays(1), "C", 452 })
			table.Rows.Add(New Object() { 6, DateTime.Today.AddDays(2), "A", 152 })
			table.Rows.Add(New Object() { 7, DateTime.Today.AddDays(2), "B", 565 })
			table.Rows.Add(New Object() { 8, DateTime.Today.AddDays(2), "C", 612 })

			Return ds
		End Function

		#Region "Disable Serialization for Tables and Relations"
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Shadows ReadOnly Property Tables() As DataTableCollection
			Get
				Return MyBase.Tables
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Shadows ReadOnly Property Relations() As DataRelationCollection
			Get
				Return MyBase.Relations
			End Get
		End Property
		#End Region ' Disable Serialization for Tables and Relations
	End Class
End Namespace