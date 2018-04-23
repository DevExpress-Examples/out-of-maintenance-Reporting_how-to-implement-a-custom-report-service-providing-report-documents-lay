using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using ClientApp.ReportServiceReference;

namespace ClientApp {
    public partial class Form1 : Form {
        private ReportServiceClient client;

        public Form1() {
            InitializeComponent();

            client = new ReportServiceClient("NetTcpBinding_IReportService");
        }

        private void button1_Click(object sender, EventArgs e) {
            comboBox1.DataSource = client.GetReportNames();
        }

        private void button2_Click(object sender, EventArgs e) {
            if (comboBox1.SelectedValue == null) {
                MessageBox.Show("Please select a report.");
                return;
            }

            string reportName = comboBox1.SelectedValue.ToString();
            byte[] reportDocument = null;

            if (!reportName.Contains("Parametrized")) {
                reportDocument = client.GetReportDocument(reportName);
            }
            else {
                reportDocument = client.GetParametrizedReportDocument("HostApp.ParametrizedReport",
                    new ReportParameterInfo[] { 
                        new ReportParameterInfo() { Name = "parameter1", Value = DateTime.Now }
                    });
            }

            MemoryStream memoryStream = new MemoryStream(reportDocument);
            PrintPreviewFormEx preview = new PrintPreviewFormEx() { PrintingSystem = new PrintingSystem() };
            preview.PrintingSystem.LoadDocument(memoryStream);
            preview.ShowDialog();
        }
    }
}