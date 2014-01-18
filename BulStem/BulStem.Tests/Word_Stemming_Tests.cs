using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BulStem.Tests
{
    [TestClass]
    public class Word_Stemming_Tests
    {
        [TestMethod]
        public void Test_If_Level_1_Works_Simple()
        {
            var stemmer = new BulStem.Stemmer(StemmingLevel.Low);

            string word = "първи";
            string expected = "първ";

            string actual = stemmer.Stem(word);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Test_If_Level_1_Works()
        {
            var wordsToTest = new Dictionary<string, string>();
            wordsToTest.Add("първи", "първ");
            wordsToTest.Add("случай", "случа");
            wordsToTest.Add("българия", "българ");
            wordsToTest.Add("здравеопазването", "здравеопазван");
            wordsToTest.Add("точната", "точн");
            wordsToTest.Add("продължителен", "продължител");
            wordsToTest.Add("здравна", "здравн");
            wordsToTest.Add("известен", "изв");


            var stemmer = new BulStem.Stemmer(StemmingLevel.Low);
            foreach (var word in wordsToTest)
            {
                Assert.AreEqual(word.Value, stemmer.Stem(word.Key));
            }

        }

        [TestMethod]
        public void Test_If_Level_2_Works()
        {
            var wordsToTest = new Dictionary<string, string>();
            wordsToTest.Add("първи", "първи");
            wordsToTest.Add("случай", "случай");
            wordsToTest.Add("българия", "българ");
            wordsToTest.Add("здравеопазването", "здравеопазван");
            wordsToTest.Add("точната", "точна");
            wordsToTest.Add("продължителен", "продължител");
            wordsToTest.Add("здравна", "здравна");
            wordsToTest.Add("известен", "извест");

            var stemmer = new BulStem.Stemmer(StemmingLevel.Medium);
            foreach (var word in wordsToTest)
            {
                Assert.AreEqual(word.Value, stemmer.Stem(word.Key));
            }
        }

        [TestMethod]
        public void Test_If_Level_3_Works()
        {
            var wordsToTest = new Dictionary<string, string>();
            wordsToTest.Add("първи", "първи");
            wordsToTest.Add("случай", "случай");
            wordsToTest.Add("българия", "българи");
            wordsToTest.Add("здравеопазването", "здравеопазван");
            wordsToTest.Add("точната", "точнат");
            wordsToTest.Add("продължителен", "продължител");
            wordsToTest.Add("здравна", "здравна");
            wordsToTest.Add("известен", "извест");

            var stemmer = new BulStem.Stemmer(StemmingLevel.High);
            foreach (var word in wordsToTest)
            {
                Assert.AreEqual(word.Value, stemmer.Stem(word.Key));
            }
        }

    }
}
