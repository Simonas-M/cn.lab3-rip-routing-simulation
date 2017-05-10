using System.Collections.Generic;

namespace RoutingRIP
{
    class GraphNode
    {
        public string Name { get; set; }

        public List<GraphNodeLink> Connections = new List<GraphNodeLink>();
    }
}
