using System.Collections.Generic;

namespace RoutingRIP
{
    class GraphNode
    {
        public string Name { get; set; }

        public List<NodeLink> Connections = new List<NodeLink>();
    }
}
