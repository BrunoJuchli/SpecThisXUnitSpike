using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SpecThis
{
    public class SpecThisTestFramework : TestFramework
    {
        public SpecThisTestFramework(IMessageSink diagnosticMessageSink) : base(diagnosticMessageSink)
        {
            diagnosticMessageSink.OnMessage(new DiagnosticMessage("created spec this test framework"));
        }

        protected override ITestFrameworkDiscoverer CreateDiscoverer(IAssemblyInfo assemblyInfo)
        {
            return new SpecThisTestFrameworkDiscoverer(assemblyInfo, SourceInformationProvider, DiagnosticMessageSink);
        }

        protected override ITestFrameworkExecutor CreateExecutor(AssemblyName assemblyName)
        {
            return new XunitTestFrameworkExecutor(assemblyName, SourceInformationProvider, DiagnosticMessageSink);
        }
    }
}