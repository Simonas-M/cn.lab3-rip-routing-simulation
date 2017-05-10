using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingRIP
{
    class GraphNodeLink
    {
        public GraphNode To { get; set; }

        public int Weight { get; set; }
    }
}
