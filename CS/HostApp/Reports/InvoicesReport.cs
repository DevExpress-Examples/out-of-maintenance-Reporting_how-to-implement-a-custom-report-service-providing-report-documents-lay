using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace HostApp {
    public partial class InvoicesReport : DevExpress.XtraReports.UI.XtraReport {
        public InvoicesReport() {
            InitializeComponent();
        }

        private void InvoicesReport_DataSourceDemanded(object sender, EventArgs e) {
          List<Invoice> invoices = new List<Invoice>(10);

          invoices.Add(new Invoice(0, "Invoice1", 10.0m));
          invoices.Add(new Invoice(1, "Invoice2", 15.0m));
          invoices.Add(new Invoice(2, "Invoice3", 20.0m));

          this.DataSource = invoices;
        }
    }
}