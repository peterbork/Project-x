using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectx {
    class Person {

        public string CprNr { get; set; }
        public string Name { get; set; }

        public Person(string CprNr, string Name) {
            this.CprNr = CprNr;
            this.Name = Name;
        }
    }
}
