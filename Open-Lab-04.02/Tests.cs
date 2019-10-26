using System;
using System.Collections;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Open_Lab_04._02
{
    [TestFixture]
    public class Tests
    {

        private Doubler doubler;
        private bool shouldStop;

        private const int RandStrMinSize = 10;
        private const int RandStrMaxSize = 10000;
        private const int RandSeed = 402402402;
        private const int RandTestCasesCount = 97;

        [OneTimeSetUp]
        public void Init()
        {
            doubler = new Doubler();
            shouldStop = false;
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure ||
                TestContext.CurrentContext.Result.Outcome == ResultState.Error)
                shouldStop = true;
        }

        [TestCase("String", "SSttrriinngg")]
        [TestCase("Hello World!", "HHeelllloo  WWoorrlldd!!")]
        [TestCase("1234!_ ", "11223344!!__  ")]
        public void DoubleCharTest(string str, string expected) =>
            Assert.That(doubler.DoubleChar(str), Is.EqualTo(expected));

        [TestCaseSource(nameof(GetRandom))]
        public void DoubleCharTestRandom(string str, string expected)
        {
            if (shouldStop)
                Assert.Ignore("Previous test failed!");

            Assert.That(doubler.DoubleChar(str), Is.EqualTo(expected));
        }

        private static IEnumerable GetRandom()
        {
            var rand = new Random(RandSeed);

            for (var i = 0; i < RandTestCasesCount; i++)
            {
                var oArr = new char[rand.Next(RandStrMinSize, RandStrMaxSize + 1)];
                var eArr = new char[oArr.Length * 2];

                for (var j = 0; j < oArr.Length; j++)
                {
                    var character = (char) rand.Next(' ', 'z' + 1);

                    oArr[j] = character;
                    eArr[j * 2] = character;
                    eArr[j * 2 + 1] = character;
                }

                yield return new TestCaseData(new string(oArr), new string(eArr));
            }
        }

    }
}
