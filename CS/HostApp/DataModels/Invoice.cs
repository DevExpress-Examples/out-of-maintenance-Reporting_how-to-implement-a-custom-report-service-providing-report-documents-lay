using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostApp {
    public class Invoice {
        private int id;

        public int Id {
            get { return id; }
            set { id = value; }
        }
        private string description;

        public string Description {
            get { return description; }
            set { description = value; }
        }
        private decimal price;

        public decimal Price {
            get { return price; }
            set { price = value; }
        }

        public Invoice(int id, string description, decimal price) {
            this.Id = id;
            this.Description = description;
            this.Price = price;
        }
    }
}
