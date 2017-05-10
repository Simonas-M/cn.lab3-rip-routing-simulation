namespace RoutingRIP
{
    class NetworkNodeConnection
    {
        public int HopCount { get; set; }

        public NetworkNode Through { get; set; }

        public NetworkNode To { get; set; }
    }
}
