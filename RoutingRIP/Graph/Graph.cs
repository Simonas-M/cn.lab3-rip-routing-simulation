using Newtonsoft.Json;
using RoutingRIP.JSON;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingRIP
{
    class Graph
    {
        public List<GraphNode> Nodes = new List<GraphNode>();

        public Graph() { }

        public bool LoadFromJSON(string jsonString)
        {
            try
            {
                GraphJSON nodes = JsonConvert.DeserializeObject<GraphJSON>(jsonString);
                foreach(var node in nodes.NodeNames)
                {
                    Nodes.Add(new GraphNode { Name = node.Name });
                }
                foreach(var connection in nodes.Connections)
                {
                    GraphNode from = Nodes.Find(x => x.Name == connection.From);
                    GraphNode to = Nodes.Find(x => x.Name == connection.To);
                    from.Connections.Add(new GraphNodeLink { To = to, Weight = connection.Weight });
                    to.Connections.Add(new GraphNodeLink { To = from, Weight = connection.Weight });
                }
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public string ToGraphVizString()
        {
            List<Link> usedLinks = new List<Link>();
            StringBuilder graphviz = new StringBuilder();
            graphviz.Append("graph Nodes {");
            foreach(var node in Nodes)
            {
                foreach(var connection in node.Connections)
                {
                    if (!usedLinks.Exists(x => (x.From == connection.To.Name && x.To == node.Name)) )
                    {
                        graphviz.Append(Environment.NewLine + node.Name + "--" + connection.To.Name);
                        usedLinks.Add(new Link { From = node.Name, To = connection.To.Name });
                    }                    
                }
            }
            graphviz.Append('}');
            return graphviz.ToString();
        }
    }
}
