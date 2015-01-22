using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectx {
    class Sensor {
        public string Id { get; set; }
        public string CprNr { get; set; }
        public string Model { get; set; }
        public DateTime BatteryLastChanged { get; set; }

        public Sensor(string model, string cprnr, string id, DateTime batterylastchanged) {
            this.Id = id;
            this.CprNr = cprnr;
            this.Model = model;
            this.BatteryLastChanged = batterylastchanged;
        }

        public Sensor() {

        }
    }
}
