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
        private List<NetworkNode> _connectedNodes = new List<NetworkNode>();
        private Queue<NetworkNode> _pingQueue = new Queue<NetworkNode>();

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

        public void ConnectNode(NetworkNode node)
        {
            if (!_connectedNodes.Contains(node))
                _connectedNodes.Add(node);
        }

        public List<NetworkNode> GetConnectedNodes()
        {
            return _connectedNodes;
        }

        public void GotPinged(NetworkNode node)
        {
            if (!_isOffline)
            {
                Console.WriteLine(Name + " got pinged by " + node.Name);
                _pingQueue.Enqueue(node);
            }
        }

        public void Ping(NetworkNode node)
        {
            Console.WriteLine(Name + " is pinging " + node.Name);
            node.GotPinged(this);
        }

        public void PingAll()
        {
            if(!_isOffline)
                foreach(NetworkNode node in _connectedNodes)
                {
                    Console.WriteLine(Name + " is pinging " + node.Name);
                    node.GotPinged(this);
                }
        }

        public void PongAll()
        {
            _connectedNodes = _pingQueue.ToList();
            _pingQueue.Clear();
        }
    }
}
