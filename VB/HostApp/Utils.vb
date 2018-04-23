Imports Microsoft.VisualBasic
Imports System
Imports System.ServiceModel

' http://www.codeproject.com/Articles/97204/Implementing-a-Basic-Hello-World-WCF-Service
' http://stackoverflow.com/questions/3051134/can-wcf-tcp-and-http-endpoints-have-the-same-port

Namespace HostApp
	Public Class ServiceHost(Of T)
		Inherits ServiceHost
		Public Sub New()
			MyBase.New(GetType(T))
		End Sub
		Public Sub New(ParamArray ByVal baseAddresses() As String)
			MyBase.New(GetType(T), Convert(baseAddresses))
		End Sub
		Public Sub New(ParamArray ByVal baseAddresses() As Uri)
			MyBase.New(GetType(T), baseAddresses)
		End Sub
		Private Shared Function Convert(ByVal baseAddresses() As String) As Uri()
'INSTANT VB NOTE: The local variable convert was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
			Dim convert_Renamed As Converter(Of String, Uri) = Function(address As String) New Uri(address)
			Return Array.ConvertAll(baseAddresses, convert_Renamed)
		End Function
	End Class
End Namespace