
using ClientTest_AmitJadhav;
using NUnit.Framework;

namespace TestEvaluation_TestProject
{
    public class Tests
    {
        private Program _program = null;
        [SetUp]
        public void Setup()
        {
            _program = new Program();

        }

        [TestCase(1)]
        [TestCase(0)]
        [TestCase(2)]
        public void CoinProcess(int process)
        {
            _program.CoinProcess(process);
            Assert.Pass();
        }
    }
}