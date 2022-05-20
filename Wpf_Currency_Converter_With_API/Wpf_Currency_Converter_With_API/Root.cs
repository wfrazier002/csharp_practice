using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Currency_Converter_With_API {
    public class Root {
        public Rate rates { get; set; }
        public long timestamp;
        public string license;
    }
}
