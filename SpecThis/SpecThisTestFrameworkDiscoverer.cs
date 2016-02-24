using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SpecThis
{
    public class SpecThisTestFrameworkDiscoverer : TestFrameworkDiscoverer
    {
        public SpecThisTestFrameworkDiscoverer(IAssemblyInfo assemblyInfo, ISourceInformationProvider sourceProvider, IMessageSink diagnosticMessageSink, IXunitTestCollectionFactory collectionFactory = null)
            : base(assemblyInfo, sourceProvider, diagnosticMessageSink)
        {
            IAttributeInfo collectionBehaviorAttribute = assemblyInfo.GetCustomAttributes(typeof(CollectionBehaviorAttribute)).SingleOrDefault<IAttributeInfo>();
            bool flag = collectionBehaviorAttribute != null && collectionBehaviorAttribute.GetNamedArgument<bool>("DisableTestParallelization");
            string configurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            TestAssembly testAssembly = new TestAssembly(assemblyInfo, configurationFile);
            this.TestCollectionFactory = collectionFactory ?? ExtensibilityPointFactory.GetXunitTestCollectionFactory(diagnosticMessageSink, collectionBehaviorAttribute, (ITestAssembly)testAssembly);
            this.TestFrameworkDisplayName = string.Format("{0} [{1}, {2}]", XunitTestFrameworkDiscoverer.DisplayName, this.TestCollectionFactory.DisplayName, flag ? "non-parallel" : "parallel");
        }

        public IXunitTestCollectionFactory TestCollectionFactory { get; private set; }

        protected override ITestClass CreateTestClass(ITypeInfo @class)
        {
            return new TestClass(this.TestCollectionFactory.Get(@class), @class);
        }

        protected override bool FindTestsForType(ITestClass testClass, bool includeSourceInformation, IMessageBus messageBus, ITestFrameworkDiscoveryOptions discoveryOptions)
        {
            // todo here we should implement something different than XunitTestFrameworkDiscoverer.FindTestsForType
            // todo: how can we tell R# RUnner that there's actually a test in the test class without adding a method attribute?
            throw new System.NotImplementedException();
        }
    }
}