using System.IO;

namespace RoutingRIP
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader fileReader = new StreamReader(@"..\..\..\Nodes.txt");
            string jsonNodes = fileReader.ReadToEnd();

            GraphView form = new GraphView(new Network(jsonNodes));
            form.ShowDialog();
        }
    }
}
