using System.ServiceModel;
using System.Runtime.Serialization;

namespace HostApp {
    [ServiceContract]
    public interface IReportService {
        [OperationContract]
        string[] GetReportNames();
        [OperationContract]
        byte[] GetReportLayout(string reportName);
        [OperationContract]
        byte[] GetReportDocument(string reportName);        
        [OperationContract]
        byte[] GetParametrizedReportDocument(string reportName, ReportParameterInfo[] parameters);
    }
    
    [DataContract]
    public class ReportParameterInfo {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public object Value { get; set; }
    }
}