using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingRIP.JSON
{
    class Link
    {
        public string From { get; set; }

        public string To { get; set; }

        public int Weight { get; set; }
    }
}
