using TechTalk.SpecFlow.Plugins;
using Wil.Testing.MsTest.SpecFlowPlugin;

[assembly: RuntimePlugin(typeof(InitializeMsTestEnvironmentPlugin))]

namespace Wil.Testing.MsTest.SpecFlowPlugin
{
    public class InitializeMsTestEnvironmentPlugin : IRuntimePlugin
    {
        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters)
            => TestInitializer.Initialize(new Assertions.Assert(), new Assertions.CollectionAssert());
    }
}
