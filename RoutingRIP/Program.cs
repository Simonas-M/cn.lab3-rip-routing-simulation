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

            Graph graph = new Graph();
            graph.LoadFromJSON(jsonNodes);

            GraphGenerator graphGen = new GraphGenerator();
            string graphString = graph.ToGraphVizString();

            using (Image image = Image.FromStream(new MemoryStream(graphGen.GenerateGraph(graphString))) )
            {
                image.Save(@"C:\Users\Simonas\Desktop\output.png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
