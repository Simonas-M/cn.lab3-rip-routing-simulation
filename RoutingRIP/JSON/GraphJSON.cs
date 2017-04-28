using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingRIP.JSON
{
    class GraphJSON
    {
        public Node[] NodeNames { get; set; }

        public Link[] Connections { get; set; }
    }
}
