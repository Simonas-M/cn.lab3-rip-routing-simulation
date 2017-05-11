using System.IO;

namespace RoutingRIP
{
    class Program
    {

        static void Main(string[] args)
        {
            StreamReader fileReader = new StreamReader(@"C:\Users\Simonas\VU_Programu_Sistemos\4.Ketvirtas semestras\Kompiuterių_tinklai\RoutingRIP\Nodes.txt");
            string jsonNodes = fileReader.ReadToEnd();

            GraphView form = new GraphView(new Network(jsonNodes));
            form.ShowDialog();
        }
    }
}
