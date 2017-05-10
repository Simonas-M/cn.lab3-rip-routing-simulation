using Newtonsoft.Json;
using RoutingRIP.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RoutingRIP
{
    class NetworkContainer
    {
        private List<NetworkNode> _nodes = new List<NetworkNode>();

        public NetworkContainer(string jsonString)
        {
            try
            {
                GraphJSON nodes = JsonConvert.DeserializeObject<GraphJSON>(jsonString);
                foreach (var node in nodes.NodeNames)
                {
                    _nodes.Add(new NetworkNode(node.Name));
                }
                foreach (var connection in nodes.Connections)
                {
                    NetworkNode from = _nodes.Find(x => x.Name == connection.From);
                    NetworkNode to = _nodes.Find(x => x.Name == connection.To);
                    from.ConnectNode(to);
                    to.ConnectNode(from);
                }
                Console.WriteLine();
            }
            catch (Exception)
            {
                return;
            }
        }

        public void TurnNodeFiveOffline()
        {
            _nodes[4].ChangeMode(true);
        }

        public void Update()
        {
            foreach (NetworkNode node in _nodes)
            {
                node.PingAll();
            }
        }

        public string ToGraphVizString()
        {
            List<Link> usedLinks = new List<Link>();
            StringBuilder graphviz = new StringBuilder();
            graphviz.Append("graph Nodes {");
            foreach (NetworkNode node in _nodes.Where(x => x.Pong()))
            {
                foreach (NetworkNodeConnection connection in node.GetConnectedNodes().Where(x => x.Through == null))
                {
                    if (!usedLinks.Exists(x => (x.From == connection.To.Name && x.To == node.Name)))
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
