using Newtonsoft.Json;
using RoutingRIP.JSON;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RoutingRIP
{
    class Network
    {
        private List<NetworkNode> _nodes = new List<NetworkNode>();

        public Network(string jsonString)
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

        public void Update()
        {
            foreach (NetworkNode node in _nodes)
            {
                node.PingAll();
            }
            Thread.Sleep(1000);
            foreach (NetworkNode node in _nodes)
            {
                node.PongAll();
            }
            _nodes[7].ChangeMode(true);
        }

        public string ToGraphVizString()
        {
            List<Link> usedLinks = new List<Link>();
            StringBuilder graphviz = new StringBuilder();
            graphviz.Append("graph Nodes {");
            foreach (NetworkNode node in _nodes)
            {
                foreach (NetworkNode connection in node.GetConnectedNodes())
                {
                    if (!usedLinks.Exists(x => (x.From == connection.Name && x.To == node.Name)))
                    {
                        graphviz.Append(Environment.NewLine + node.Name + "--" + connection.Name);
                        usedLinks.Add(new Link { From = node.Name, To = connection.Name });
                    }
                }
            }
            graphviz.Append('}');
            return graphviz.ToString();
        }
    }
}
