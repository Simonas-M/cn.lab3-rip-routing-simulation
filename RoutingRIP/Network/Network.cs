using Newtonsoft.Json;
using RoutingRIP.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RoutingRIP
{
    public class Network
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

        public void AddNode(string name)
        {
            if (_nodes.Any(x => x.Name == name))
                throw new ArgumentException("Node with name " + name + " already exists.");
            _nodes.Add(new NetworkNode(name));
        }

        public void AddLink(string from, string to)
        {
            var nodeFrom = _nodes.SingleOrDefault(x => x.Name == from);
            var nodeTo = _nodes.SingleOrDefault(x => x.Name == to);
            if (nodeFrom == default(NetworkNode))
                throw new ArgumentException("There is no node named: " + from);
            if (nodeTo == default(NetworkNode))
                throw new ArgumentException("There is no node named: " + to);
            if (!nodeFrom.ConnectedNodes.Any(x => x.Through == null && x.To == nodeTo))
            {
                nodeFrom.ConnectNode(nodeTo);
                nodeTo.ConnectNode(nodeFrom);
            }
            else
                throw new ArgumentException("A link between " + from + " and " + to + " already exists.");
        }

        public void RemoveLink(string from, string to)
        {
            var nodeFrom = _nodes.SingleOrDefault(x => x.Name == from);
            var nodeTo = _nodes.SingleOrDefault(x => x.Name == to);
            if (nodeFrom == default(NetworkNode))
                throw new ArgumentException("There is no node named: " + from);
            if (nodeTo == default(NetworkNode))
                throw new ArgumentException("There is no node named: " + to);
            if (nodeFrom.ConnectedNodes.Any(x => x.Through == null && x.To == nodeTo))
            {
                nodeFrom.DisconnectNode(nodeTo);
                nodeTo.DisconnectNode(nodeFrom);
            }
            else
                throw new ArgumentException("No link between " + from + " and " + to + ".");
        }

        public void RemoveNode(string name)
        {
            if (!_nodes.Any(x => x.Name == name))
                throw new ArgumentException("Node with name " + name + " doesn't exists.");
            _nodes.Single(x => x.Name == name).ChangeMode(true);
            _nodes.RemoveAll(x => x.Name == name);
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
            graphviz.Append(Environment.NewLine + "ratio=\"1\"");
            graphviz.Append(Environment.NewLine + "dpi=\"100\"");
            graphviz.Append(Environment.NewLine + "size=\"5!\"");
            foreach (NetworkNode node in _nodes.Where(x => x.Pong()))
            {
                graphviz.Append(Environment.NewLine + node.Name);
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
            //var str = graphviz.ToString();
            return graphviz.ToString();
        }
    }
}
