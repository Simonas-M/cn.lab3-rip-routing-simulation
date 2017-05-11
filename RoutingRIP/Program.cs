using System.IO;
using System.Drawing;

namespace RoutingRIP
{
    class Program
    {

        static void Main(string[] args)
        {
            StreamReader fileReader = new StreamReader(@"C:\Users\Simonas\VU_Programu_Sistemos\4.Ketvirtas semestras\Kompiuterių_tinklai\RoutingRIP\Nodes.txt");
            string jsonNodes = fileReader.ReadToEnd();

            //Graph graph = new Graph();
            //graph.LoadFromJSON(jsonNodes);

            GraphGenerator graphGen = new GraphGenerator();
            //string graphString = graph.ToGraphVizString();

            NetworkContainer network = new NetworkContainer(jsonNodes);
            string graphString = network.ToGraphVizString();

            GraphView form = new GraphView();
            form.Show();
            using (Image image = Image.FromStream(new MemoryStream(graphGen.GenerateGraph(graphString))))
            {
                form.UpdateImage(image);
                image.Save(@"C:\Users\Simonas\Desktop\output.png", System.Drawing.Imaging.ImageFormat.Png);
            }

            network.Update();
            network.Update();
            network.Update();
            network.Update();
            network.Update();
            network.TurnNodeFiveOffline(true);
            network.Update();
            network.Update();
            network.Update();
            network.Update();
            network.Update();
            network.Update();
            network.TurnNodeFiveOffline(false);
            network.Update();
            network.Update();
            network.Update();
            network.Update();
            network.Update();
            network.Update();
            graphString = network.ToGraphVizString();
            //System.Threading.Thread.Sleep(2000);

            using (Image image = Image.FromStream(new MemoryStream(graphGen.GenerateGraph(graphString))))
            {
                form.UpdateImage(image);
                image.Save(@"C:\Users\Simonas\Desktop\output.png", System.Drawing.Imaging.ImageFormat.Png);
            }
            System.Console.ReadLine();
        }
    }
}
