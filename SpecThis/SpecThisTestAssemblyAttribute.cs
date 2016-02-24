using System;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SpecThis
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    [TestFrameworkDiscoverer("SpecThis.SpecThisTestFrameworkTypeDiscoverer", "SpecThis")]
    public class SpecThisTestAssemblyAttribute : Attribute, ITestFrameworkAttribute
    {

    }

    public class SpecThisTestFrameworkTypeDiscoverer : ITestFrameworkTypeDiscoverer
    {
        public Type GetTestFrameworkType(IAttributeInfo attribute)
        {
            return typeof(SpecThisTestFramework);
        }
    }
}