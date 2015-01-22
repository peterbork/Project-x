using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectx
{
    class Temperatur
    {
        public string SensorID { get; set; }
        public int SensorValueInOhm { get; set; }
        public DateTime MeasuredAtDateTime { get; set; }

        public Temperatur(string sensorid, int sensorvalue, DateTime measured){
            this.SensorID = sensorid;
            this.SensorValueInOhm = sensorvalue;
            this.MeasuredAtDateTime = measured;
        }

        public Temperatur(){

        }
    }
}
