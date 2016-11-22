using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BigramParser;

namespace BigramParserUnitTests
{
    [TestClass]
    public class BigramUnitTest
    {
        [TestMethod]
        public void TestCreateBigramList_VerifyOutputForOneWord()
        {
            IList<string> wordList = new List<string>() { "I" };

            BigramManager bigramManager = new BigramManager();
            IList<BigramManager.Bigram> bigrams = bigramManager.CreateBigramList(wordList);

            // a list of n size can produce n-1 bigrams
            Assert.AreEqual(wordList.Count - 1, bigrams.Count);
        }

        [TestMethod]
        public void TestCreateBigramList_VerifyOutputForEvenInput()
        {
            IList<string> wordList = new List<string>() { "I", "Went", "To", "the", "mall", "and"};

            BigramManager bigramManager = new BigramManager();
            IList<BigramManager.Bigram> bigrams = bigramManager.CreateBigramList(wordList);

            // a list of n size can produce n-1 bigrams
            Assert.AreEqual(wordList.Count - 1, bigrams.Count);            
            Assert.AreEqual(bigrams[0].FirstWord, "I");
            Assert.AreEqual(bigrams[0].SecondWord, "Went");
            Assert.AreEqual(bigrams[1].FirstWord, "Went");
            Assert.AreEqual(bigrams[1].SecondWord, "To");
            Assert.AreEqual(bigrams[2].FirstWord, "To");
            Assert.AreEqual(bigrams[2].SecondWord, "the");
            Assert.AreEqual(bigrams[3].FirstWord, "the");
            Assert.AreEqual(bigrams[3].SecondWord, "mall");
            Assert.AreEqual(bigrams[4].FirstWord, "mall");
            Assert.AreEqual(bigrams[4].SecondWord, "and");
        }

        [TestMethod]
        public void TestCreateBigramList_VerifyOutputForOddInput()
        {
            IList<string> wordList = new List<string>() { "I", "Went", "To", "the", "mall" };
            
            BigramManager bigramManager = new BigramManager();
            IList<BigramManager.Bigram> bigrams = bigramManager.CreateBigramList(wordList);

            // a list of n size can produce n-1 bigrams
            Assert.AreEqual(wordList.Count - 1, bigrams.Count);
            Assert.AreEqual(bigrams[0].FirstWord, "I");
            Assert.AreEqual(bigrams[0].SecondWord, "Went");
            Assert.AreEqual(bigrams[1].FirstWord, "Went");
            Assert.AreEqual(bigrams[1].SecondWord, "To");
            Assert.AreEqual(bigrams[2].FirstWord, "To");
            Assert.AreEqual(bigrams[2].SecondWord, "the");
            Assert.AreEqual(bigrams[3].FirstWord, "the");
            Assert.AreEqual(bigrams[3].SecondWord, "mall");
        }
    }
}
