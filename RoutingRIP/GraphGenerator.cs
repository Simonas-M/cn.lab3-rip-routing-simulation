using GraphVizWrapper;
using GraphVizWrapper.Commands;
using GraphVizWrapper.Queries;

namespace RoutingRIP
{
    class GraphGenerator
    {
        GetStartProcessQuery getStartProcessQuery = new GetStartProcessQuery();
        GetProcessStartInfoQuery getProcessStartInfoQuery = new GetProcessStartInfoQuery();
        RegisterLayoutPluginCommand registerLayoutPluginCommand;
        GraphGeneration wrapper;

        public GraphGenerator()
        {
            registerLayoutPluginCommand = new RegisterLayoutPluginCommand(getProcessStartInfoQuery, getStartProcessQuery);
            wrapper = new GraphGeneration(getStartProcessQuery,
                                          getProcessStartInfoQuery,
                                          registerLayoutPluginCommand);
        }

        public byte[] GenerateGraph(string graphVizString)
        {
            return  wrapper.GenerateGraph(graphVizString, Enums.GraphReturnType.Png);
        }
    }
}
