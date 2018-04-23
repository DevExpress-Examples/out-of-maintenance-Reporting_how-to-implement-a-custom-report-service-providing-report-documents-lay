using System;
using System.ServiceModel;

namespace HostApp {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("***** Console Based Report Service *****");

            using (ServiceHost<ReportService> serviceHost = new ServiceHost<ReportService>()) {
                serviceHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press the Enter key to terminate the service.");
                Console.ReadLine();
            }
        }
    }
}