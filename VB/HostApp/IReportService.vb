Imports Microsoft.VisualBasic
Imports System.ServiceModel
Imports System.Runtime.Serialization

Namespace HostApp
	<ServiceContract> _
	Public Interface IReportService
		<OperationContract> _
		Function GetReportNames() As String()
		<OperationContract> _
		Function GetReportLayout(ByVal reportName As String) As Byte()
		<OperationContract> _
		Function GetReportDocument(ByVal reportName As String) As Byte()
		<OperationContract> _
		Function GetParametrizedReportDocument(ByVal reportName As String, ByVal parameters() As ReportParameterInfo) As Byte()
	End Interface

	<DataContract> _
	Public Class ReportParameterInfo
		Private privateName As String
		<DataMember> _
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
		Private privateValue As Object
		<DataMember> _
		Public Property Value() As Object
			Get
				Return privateValue
			End Get
			Set(ByVal value As Object)
				privateValue = value
			End Set
		End Property
	End Class
End Namespace