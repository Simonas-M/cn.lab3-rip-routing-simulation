using System;
using System.Collections.Generic;
using System.Linq;

namespace RoutingRIP
{
    class NetworkNode
    {
        public string Name;
        public Guid Id;
        private bool _isOffline = false;
        private List<NetworkNodeConnection> _connectedNodes = new List<NetworkNodeConnection>();
        //private Dictionary<NetworkNodeConnection, int> _failingNodes = new Dictionary<NetworkNodeConnection, int>();

        public NetworkNode(string name, bool IsOffline = false)
        {
            Name = name;
            Id = Guid.NewGuid();
            _isOffline = IsOffline;
        }

        public void ChangeMode(bool mode)
        {
            _isOffline = mode;
        }

        public bool Pong()
        {
            return !_isOffline;
        }

        public void ConnectNode(NetworkNode node)
        {
            if (!_connectedNodes.Any(x => x.HopCount == 1 && x.To == node))
                _connectedNodes.Add(new NetworkNodeConnection {HopCount = 1, To = node });
        }

        public List<NetworkNodeConnection> GetConnectedNodes()
        {
            return _connectedNodes;
        }

        public void GotPinged(NetworkNode pinger, List<NetworkNodeConnection> pingerNodes)
        {
            if (_isOffline)
                return;

            Console.WriteLine(Name + " got pinged by " + pinger.Name);

            if(!_connectedNodes.Any(x => x.To == pinger))
                ConnectNode(pinger);

            foreach (var node in pingerNodes)
            {
                if (node.To == this || node.Through == this)
                    continue;
                if (_connectedNodes.Any(x => x.To == node.To && x.HopCount > node.HopCount + 1))
                {
                    var myNode = _connectedNodes.SingleOrDefault(x => x.To == node.To);
                    myNode.HopCount = node.HopCount + 1;
                    myNode.Through = pinger;
                }
                if(!_connectedNodes.Any(x => x.To == node.To))
                    _connectedNodes.Add(new NetworkNodeConnection { HopCount = node.HopCount + 1, To = node.To, Through = pinger });
            }
            //foreach(var node in _connectedNodes)
            //{
            //    if (!pingerNodes.Any(x => x.To == node.To || node.To == pinger))
            //    {
            //        if (!_failingNodes.ContainsKey(node))
            //            _failingNodes.Add(node, 1);
            //        else
            //            _failingNodes[node]++;
            //        Console.WriteLine("failing node: from" + Name + " to " + node.To.Name);
            //    }
            //    else
            //    {
            //        if (_failingNodes.ContainsKey(node))
            //            _failingNodes.Remove(node);
            //        Console.WriteLine("not failing after all: from" + Name + " to " + node.To.Name);
            //    }
            //}
        }

        public void UnreachableNodeDetected(NetworkNode reporter, NetworkNode unreachableNode)
        {
            if (!_connectedNodes.Any(x => x.To == unreachableNode || x.Through == unreachableNode))
                return;//Jei nera kelio kuris eina i unreachable arba per unreachable tai gryztama
            else
            {
                var badNode = _connectedNodes.Where(x => x.To == unreachableNode).SingleOrDefault();
                if(!Equals(badNode, default(NetworkNode)))
                    _connectedNodes.Remove(badNode);//Jei yra toks kelias kuris veda i unreachable tai ji istrina
                badNode = _connectedNodes.Where(x => x.Through == unreachableNode).SingleOrDefault();
                if (!Equals(badNode, default(NetworkNode)))
                {
                    _connectedNodes.Remove(badNode);//Jei yra toks kelias kuris eina per unreachable tai ji istrina ir paskelbia visiem kaimynam
                    foreach (var node in _connectedNodes.Where(x => x.HopCount == 1 && x.To != badNode.To))
                    {
                        node.To.UnreachableNodeDetected(this, badNode.To);
                    }
                }
            }
            foreach (var node in _connectedNodes.Where(x => x.HopCount == 1 && x.To != unreachableNode && x.To != reporter).ToList())
            {
                node.To.UnreachableNodeDetected(this, unreachableNode);
            }
        }

        public void Ping(NetworkNode neighborNode)
        {
            Console.WriteLine(Name + " is pinging " + neighborNode.Name);
            if(neighborNode.Pong())
                neighborNode.GotPinged(this, _connectedNodes);
            else
            {
                _connectedNodes.Remove(_connectedNodes.Where(x => x.To == neighborNode).Single());
                Console.WriteLine(Name + " deleted " + neighborNode.Name);
                var connectedNodes = _connectedNodes.Where(x => x.HopCount == 1 && x.To != neighborNode).ToList();
                foreach (var node in connectedNodes)
                {
                    node.To.UnreachableNodeDetected(this, neighborNode);
                }
            }                
        }

        public void PingAll()
        {
            if (_isOffline)
                return;

            foreach (NetworkNodeConnection node in _connectedNodes.Where(x => x.HopCount == 1).ToList())
            {
                Ping(node.To);
            }
        }
    }
}
