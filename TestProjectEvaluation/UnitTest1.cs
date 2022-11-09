using ClientTest_AmitJadhav;
using NUnit.Framework;

namespace TestProjectEvaluation
{
    public class Tests
    {
        private Program program;
        [SetUp]
        public void Setup()
        {
            this.program = new Program();
        }

        [Test]
        public void Test1()
        {
            program.CoinMechanism(program, 2.5, 0);
            Assert.Pass();
        }
    }
}