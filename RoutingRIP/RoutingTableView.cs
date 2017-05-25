using System.Collections.Generic;
using System.Windows.Forms;

namespace RoutingRIP
{
    public partial class RoutingTableView : Form
    {
        private IEnumerable<NetworkNodeConnection> _connections;
        public IEnumerable<NetworkNodeConnection> Connections
        {
            get
            {
                return _connections;
            }
            set
            {
                _connections = value;
                UpdateTable();
            }
        }

        public RoutingTableView()
        {
            InitializeComponent();
            TopMost = true;
        }

        private void UpdateTable()
        {
            RTable.Rows.Clear();
            foreach (var connection in Connections)
            {
                RTable.Rows.Add(connection.HopCount, connection.To.Name, connection.Through == null ? "-" : connection.Through.Name);
            }
        }
    }
}
