using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;

namespace HostApp {
    public class ReportService : IReportService {
        public string[] GetReportNames() {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            List<string> reportTypes = new List<string>();

            for (int i = 0; i < types.Length; i++) {
                if (typeof(XtraReport).IsAssignableFrom(types[i]))
                    reportTypes.Add(types[i].FullName);
            }

            return reportTypes.ToArray();
        }

        public byte[] GetReportLayout(string reportName) {
            XtraReport report = CreateReportByName(reportName);
            MemoryStream memoryStream = new MemoryStream();

            report.SaveLayout(memoryStream);

            return memoryStream.ToArray();
        }

        public byte[] GetReportDocument(string reportName) {
            XtraReport report = CreateReportByName(reportName);
            MemoryStream memoryStream = new MemoryStream();

            // Disable report parameters' visibility to prevent the 'Parameters' dialog from popping up in the WCF host process
            for (int i = 0; i < report.Parameters.Count; i++) {
                report.Parameters[i].Visible = false;
            }

            report.CreateDocument();
            report.PrintingSystem.SaveDocument(memoryStream);

            return memoryStream.ToArray();
        }

        public byte[] GetParametrizedReportDocument(string reportName, ReportParameterInfo[] parameters) {
            XtraReport report = CreateReportByName(reportName);
            MemoryStream memoryStream = new MemoryStream();

            // Disable report parameters' visibility to prevent the 'Parameters' dialog from popping up in the WCF host process
            for (int i = 0; i < report.Parameters.Count; i++) {
                report.Parameters[i].Visible = false;
            }

            for (int i = 0; i < parameters.Length; i++) {
                Parameter repPar = report.Parameters[parameters[i].Name];
                
                if (repPar != null)
                    repPar.Value = parameters[i].Value;
            }

            report.CreateDocument();
            report.PrintingSystem.SaveDocument(memoryStream);

            return memoryStream.ToArray();
        }

        private XtraReport CreateReportByName(string reportName) {
            return (XtraReport)Activator.CreateInstance(null, reportName).Unwrap();
        }
    }
}