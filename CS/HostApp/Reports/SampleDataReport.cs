using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace HostApp {
    public partial class SampleDataReport : DevExpress.XtraReports.UI.XtraReport {
        public SampleDataReport() {
            InitializeComponent();
        }

        private void SampleDataReport_DataSourceDemanded(object sender, EventArgs e) {
            this.DataSource = SampleDataSet.CreateData();
        }
    }
}