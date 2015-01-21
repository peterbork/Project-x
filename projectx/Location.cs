using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectx {
    class Location {
        public string SensorID { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime DateTime { get; set; }

        public Location(string sensorid, string lat, string lon, DateTime date) {
            this.SensorID = sensorid;
            this.Latitude = lat;
            this.Longitude = lon;
            this.DateTime = date;
        }
        public Location() { 
        
        }
    }
}
