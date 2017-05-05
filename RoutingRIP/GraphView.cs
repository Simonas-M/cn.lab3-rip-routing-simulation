using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoutingRIP
{
    public partial class GraphView : Form
    {
        public GraphView()
        {
            InitializeComponent();
        }
        
        public void UpdateImage(Image image)
        {
            centedImage.Image = image;
            centedImage.Refresh();
        }
    }
}
