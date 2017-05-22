using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoutingRIP
{
    public partial class GraphView : Form
    {
        private Network Network;
        GraphGenerator graphGen = new GraphGenerator();
        RoutingTableView tableView = new RoutingTableView();
        private bool Initialize = true;

        public GraphView(Network network)
        {
            Network = network;
            InitializeComponent();

            tableView.FormClosing += (sender, e) =>
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                    ((RoutingTableView)sender).Hide();
                    BtnTable_Click(sender, e);
                }
            };

            TxtNode.Text = "Enter node name";
            TxtNode.ForeColor = Color.Gray;
            TxtLinkFrom.Text = "From";
            TxtLinkFrom.ForeColor = Color.Gray;
            TxtLinkTo.Text = "To";
            TxtLinkTo.ForeColor = Color.Gray;
            TxtTable.Text = "Node name";
            TxtTable.ForeColor = Color.Gray;

            StartUpdate();

        }

        private void StartUpdate()
        {
            new Task(() =>
            {
                while(true)
                {
                    Network.Update();
                    Thread.Sleep(2000);
                }                

            }).Start();
        }

        private void UpdateImage(Image image)
        {
            graphImage.Image = image;
            graphImage.Refresh();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            //if(!Initialize)
            //    Network.Update();
            using (Image image = Image.FromStream(new MemoryStream(graphGen.GenerateGraph(Network.ToGraphVizString()))))
            {
                UpdateImage(image);
            }
            //if (Initialize)
            //    Initialize = false;
        }

        private void GraphUpdated(object sender, EventArgs e)
        {
            if (!tableView.Visible)
                return;
            try { tableView.Connections = Network.GetRoutingTable(TxtTable.Text); }
            catch (ArgumentException ex)
            {
                TxtTable.Enabled = true;
                BtnTable.Text = "Show routing table";
                tableView.Hide();
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAddNode_Click(object sender, EventArgs e)
        {
            if (TxtNode.Text != "Enter node name")
            {
                try { Network.AddNode(TxtNode.Text); }
                catch (ArgumentException ex) { MessageBox.Show(ex.Message); }
            }
            else
                MessageBox.Show("Enter a node name first.");
        }

        private void BtnDeleteNode_Click(object sender, EventArgs e)
        {
            if (TxtNode.Text != "Enter node name")
            {
                try { Network.RemoveNode(TxtNode.Text); }
                catch (ArgumentException ex) { MessageBox.Show(ex.Message); }
            }
            else
                MessageBox.Show("Enter a node name first.");
        }

        private void BtnAddLink_Click(object sender, EventArgs e)
        {
            if (TxtLinkFrom.Text == "From" || TxtLinkTo.Text == "To")
            {
                MessageBox.Show("Enter nodes \"to\" and \"from\".");
                return;
            }
            if (TxtLinkFrom.Text == TxtLinkTo.Text)
            {
                MessageBox.Show("To form a link nodes must be different");
                return;
            }
            try { Network.AddLink(TxtLinkFrom.Text, TxtLinkTo.Text); }
            catch (ArgumentException ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnDeleteLink_Click(object sender, EventArgs e)
        {
            if (TxtLinkFrom.Text == "From" || TxtLinkTo.Text == "To")
            {
                MessageBox.Show("Enter nodes \"to\" and \"from\".");
                return;
            }
            if (TxtLinkFrom.Text == TxtLinkTo.Text)
            {
                MessageBox.Show("To form a link nodes must be different");
                return;
            }
            try { Network.RemoveLink(TxtLinkFrom.Text, TxtLinkTo.Text); }
            catch (ArgumentException ex) { MessageBox.Show(ex.Message); }
        }

        private void TxtNode_MouseClick(object sender, MouseEventArgs e)
        {
            if (TxtNode.Text == "Enter node name")
            {
                TxtNode.Text = "";
                TxtNode.ForeColor = Color.Black;
            }
        }

        private void TxtNode_Leave(object sender, EventArgs e)
        {
            if (TxtNode.Text == "")
            {
                TxtNode.Text = "Enter node name";
                TxtNode.ForeColor = Color.Gray;
            }
        }

        private void TxtLinkFrom_MouseClick(object sender, MouseEventArgs e)
        {
            if (TxtLinkFrom.Text == "From")
            {
                TxtLinkFrom.Text = "";
                TxtLinkFrom.ForeColor = Color.Black;
            }
        }

        private void TxtLinkFrom_Leave(object sender, EventArgs e)
        {
            if (TxtLinkFrom.Text == "")
            {
                TxtLinkFrom.Text = "From";
                TxtLinkFrom.ForeColor = Color.Gray;
            }
        }

        private void TxtLinkTo_MouseClick(object sender, MouseEventArgs e)
        {
            if (TxtLinkTo.Text == "To")
            {
                TxtLinkTo.Text = "";
                TxtLinkTo.ForeColor = Color.Black;
            }
        }

        private void TxtLinkTo_Leave(object sender, EventArgs e)
        {
            if (TxtLinkTo.Text == "")
            {
                TxtLinkTo.Text = "To";
                TxtLinkTo.ForeColor = Color.Gray;
            }
        }

        private void TxtTable_MouseClick(object sender, MouseEventArgs e)
        {
            if (TxtTable.Text == "Node name")
            {
                TxtTable.Text = "";
                TxtTable.ForeColor = Color.Black;
            }
        }

        private void TxtTable_Leave(object sender, EventArgs e)
        {
            if (TxtTable.Text == "")
            {
                TxtTable.Text = "Node name";
                TxtTable.ForeColor = Color.Gray;
            }
        }

        private void BtnTable_Click(object sender, EventArgs e)
        {
            if (TxtTable.Text == "Node name")
            {
                MessageBox.Show("Enter a node name first.");
                return;
            }
            if (!Network.Exists(TxtTable.Text))
            {
                MessageBox.Show("Node with name " + TxtTable.Text + " doesn't exist.");
                return;
            }

            if(BtnTable.Text == "Show routing table")
            {
                try { tableView.Connections = Network.GetRoutingTable(TxtTable.Text); }
                catch (ArgumentException ex) { MessageBox.Show(ex.Message); return; }

                TxtTable.Enabled = false;
                BtnTable.Text = "Hide routing table";

                tableView.Text = TxtTable.Text;           
                tableView.Show();
            }
            else
            {
                TxtTable.Enabled = true;
                BtnTable.Text = "Show routing table";
                tableView.Hide();
            }            
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            try { Network.SendData("PC1", "PC3", "Labas!"); }
            catch (ArgumentException ex) { MessageBox.Show(ex.Message); }
            catch (InvalidOperationException ex) { MessageBox.Show(ex.Message); }
        }
    }
}
