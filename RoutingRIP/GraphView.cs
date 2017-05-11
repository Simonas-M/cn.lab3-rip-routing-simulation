using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RoutingRIP
{
    public partial class GraphView : Form
    {
        private Network Network;
        GraphGenerator graphGen = new GraphGenerator();

        public GraphView(Network network)
        {
            Network = network;
            InitializeComponent();

            TxtNode.Text = "Enter node name";
            TxtNode.ForeColor = Color.Gray;
            TxtLinkFrom.Text = "From";
            TxtLinkFrom.ForeColor = Color.Gray;
            TxtLinkTo.Text = "To";
            TxtLinkTo.ForeColor = Color.Gray;
        }

        private void UpdateImage(Image image)
        {
            graphImage.Image = image;
            graphImage.Refresh();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            Network.Update();
            using (Image image = Image.FromStream(new MemoryStream(graphGen.GenerateGraph(Network.ToGraphVizString()))))
            {
                UpdateImage(image);
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
    }
}
