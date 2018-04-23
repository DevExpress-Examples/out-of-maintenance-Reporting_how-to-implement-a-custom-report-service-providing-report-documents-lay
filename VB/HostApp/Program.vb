Imports Microsoft.VisualBasic
Imports System
Imports System.ServiceModel

Namespace HostApp
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			Console.WriteLine("***** Console Based Report Service *****")

			Using serviceHost As New ServiceHost(Of ReportService)()
				serviceHost.Open()
				Console.WriteLine("The service is ready.")
				Console.WriteLine("Press the Enter key to terminate the service.")
				Console.ReadLine()
			End Using
		End Sub
	End Class
End Namespace