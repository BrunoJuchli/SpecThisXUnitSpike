using Xbehave;
using Xunit;

namespace XBehaveDemo
{
    public class XBehave
    {
        [Scenario]
        [Example(1, 2, 3)]
        [Example(2, 3, 5)]
        public void Addition(int x, int y, int expectedAnswer, Calculator calculator, int answer)
        {
            "Given the number {0}"
                .f(() => { });

            "And the number {1}"
                .f(() => { });

            "And a calculator"
                .f(() => calculator = new Calculator());

            "When I add the numbers together"
                .f(() => answer = calculator.Add(x, y));

            "Then the answer is {2}"
                .f(() => Assert.Equal(expectedAnswer, answer));
        }

        [Scenario]
        public void Addition2(int x, int y, int expectedAnswer, Calculator calculator, int answer)
        {
            "Given the number 2"
                .f(() => x = 2);

            "And the number {1}"
                .f(() => y = 3);

            "And a calculator"
                .f(() => calculator = new Calculator());

            "When I add the numbers together"
                .f(() => answer = calculator.Add(x, y));

            "Then the answer is 5"
                .f(() => Assert.Equal(5, answer));
        }
    }
}
