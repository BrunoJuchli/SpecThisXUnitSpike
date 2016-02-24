using FluentAssertions;
using Xunit;

namespace XBehaveDemo
{
    public class XUnit
    {
        private readonly Calculator testee;

        public XUnit()
        {
            this.testee = new Calculator();
        }

        [Fact]
        public void Add_MustReturnSum()
        {
            this.testee.Add(3, 5).Should().Be(8);
        }
    }
}