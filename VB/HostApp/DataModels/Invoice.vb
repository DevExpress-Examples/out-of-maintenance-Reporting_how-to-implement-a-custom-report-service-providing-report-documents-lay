Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace HostApp
	Public Class Invoice
		Private id_Renamed As Integer

		Public Property Id() As Integer
			Get
				Return id_Renamed
			End Get
			Set(ByVal value As Integer)
				id_Renamed = value
			End Set
		End Property
		Private description_Renamed As String

		Public Property Description() As String
			Get
				Return description_Renamed
			End Get
			Set(ByVal value As String)
				description_Renamed = value
			End Set
		End Property
		Private price_Renamed As Decimal

		Public Property Price() As Decimal
			Get
				Return price_Renamed
			End Get
			Set(ByVal value As Decimal)
				price_Renamed = value
			End Set
		End Property

		Public Sub New(ByVal id As Integer, ByVal description As String, ByVal price As Decimal)
			Me.Id = id
			Me.Description = description
			Me.Price = price
		End Sub
	End Class
End Namespace
