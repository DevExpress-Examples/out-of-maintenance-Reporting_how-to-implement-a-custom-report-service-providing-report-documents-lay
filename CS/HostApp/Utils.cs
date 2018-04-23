using System;
using System.ServiceModel;

// http://www.codeproject.com/Articles/97204/Implementing-a-Basic-Hello-World-WCF-Service
// http://stackoverflow.com/questions/3051134/can-wcf-tcp-and-http-endpoints-have-the-same-port

namespace HostApp {
    public class ServiceHost<T> : ServiceHost {
        public ServiceHost()
            : base(typeof(T)) { }
        public ServiceHost(params string[] baseAddresses) :
            base(typeof(T), Convert(baseAddresses)) { }
        public ServiceHost(params Uri[] baseAddresses) :
            base(typeof(T), baseAddresses) { }
        static Uri[] Convert(string[] baseAddresses) {
            Converter<string, Uri> convert = delegate(string address) {
                return new Uri(address);
            };
            return Array.ConvertAll(baseAddresses, convert);
        }
    }
}