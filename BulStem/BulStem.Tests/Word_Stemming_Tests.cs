using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace BulStem.Tests
{
    [TestClass]
    public class Word_Stemming_Tests
    {
        [TestMethod]
        public void Test_If_Stemming_With_Level_1_Works_Simple()
        {
            var stemmer = new BulStem.Stemmer(StemmingLevel.Low);

            string word = "първи";
            string expected = "първ";

            string actual = stemmer.Stem(word);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sample_For_Github_Default()
        {
            //default initialization (level Low)
            var stemmer = new BulStem.Stemmer();

            string stemLevel1 = stemmer.Stem("оставката");
            string expected = "остав";

            Assert.AreEqual(expected, stemLevel1);
        }

        [TestMethod]
        public void Sample_For_Github_Init_Level2()
        {
            //initialization with level (level Medium)
            var stemmer = new BulStem.Stemmer(StemmingLevel.Medium);

            string stemLevel2 = stemmer.Stem("оставката");
            string expected = "оставк";

            Assert.AreEqual(expected, stemLevel2);
        }

        [TestMethod]
        public void Sample_For_Github_Init_Set_Level3()
        {
            //default initialization and later level set (level High)
            var stemmer = new BulStem.Stemmer();
            stemmer.SetLevel(StemmingLevel.High);

            string stemLevel3 = stemmer.Stem("оставката");
            string expected = "оставк";

            Assert.AreEqual(expected, stemLevel3);
        }


        [TestMethod]
        public void Test_If_Stemming_With_Level_1_Works()
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
        public void Test_If_Stemming_With_Level_2_Works()
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
        public void Test_If_Stemming_With_Level_3_Works()
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
