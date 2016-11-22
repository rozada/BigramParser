using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BigramParser;

namespace BigramParserUnitTests
{
    [TestClass]
    public class FileReadingUnitTest
    {
        [TestMethod]
        public void TestCreateWordListFromFileText_VerifyOutput()
        {
            string fileText = "I went to the mall and then I went to \nthe store and then I went to the park. * I must remember to go to the GAS station.";

            IList<string> wordList = Program.CreateWordListFromFileText(fileText);

            Assert.IsTrue(wordList.Count == 28);

            Assert.AreEqual(wordList[0].ToUpper(), "I");
            Assert.AreEqual(wordList[1].ToUpper(), "WENT");
            Assert.AreEqual(wordList[2].ToUpper(), "TO");
            Assert.AreEqual(wordList[3].ToUpper(), "THE");
            Assert.AreEqual(wordList[4].ToUpper(), "MALL");
            Assert.AreEqual(wordList[5].ToUpper(), "AND");
            Assert.AreEqual(wordList[6].ToUpper(), "THEN");
            Assert.AreEqual(wordList[7].ToUpper(), "I");
            Assert.AreEqual(wordList[8].ToUpper(), "WENT");
            Assert.AreEqual(wordList[9].ToUpper(), "TO");
            Assert.AreEqual(wordList[10].ToUpper(), "THE");
            Assert.AreEqual(wordList[11].ToUpper(), "STORE");
            Assert.AreEqual(wordList[12].ToUpper(), "AND");
            Assert.AreEqual(wordList[13].ToUpper(), "THEN");
            Assert.AreEqual(wordList[14].ToUpper(), "I");
            Assert.AreEqual(wordList[15].ToUpper(), "WENT");
            Assert.AreEqual(wordList[16].ToUpper(), "TO");
            Assert.AreEqual(wordList[17].ToUpper(), "THE");
            Assert.AreEqual(wordList[18].ToUpper(), "PARK");
            Assert.AreEqual(wordList[19].ToUpper(), "I");
            Assert.AreEqual(wordList[20].ToUpper(), "MUST");
            Assert.AreEqual(wordList[21].ToUpper(), "REMEMBER");
            Assert.AreEqual(wordList[22].ToUpper(), "TO");
            Assert.AreEqual(wordList[23].ToUpper(), "GO");
            Assert.AreEqual(wordList[24].ToUpper(), "TO");
            Assert.AreEqual(wordList[25].ToUpper(), "THE");
            Assert.AreEqual(wordList[26].ToUpper(), "GAS");
            Assert.AreEqual(wordList[27].ToUpper(), "STATION");
        }
    }
}
