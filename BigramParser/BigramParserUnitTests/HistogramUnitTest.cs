using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BigramParser;
using System.Linq;

namespace BigramParserUnitTests
{
    [TestClass]
    public class HistogramUnitTest
    {
        [TestMethod]
        public void TestPopulateHistogram_VerifyOutput()
        {
            IList<BigramManager.Bigram> bigrams = new List<BigramManager.Bigram>();
            bigrams.Add(new BigramManager.Bigram { FirstWord = "The", SecondWord = "quick" });
            bigrams.Add(new BigramManager.Bigram { FirstWord = "quick", SecondWord = "brown" });
            bigrams.Add(new BigramManager.Bigram { FirstWord = "brown", SecondWord = "fox" });
            bigrams.Add(new BigramManager.Bigram { FirstWord = "fox", SecondWord = "and" });
            bigrams.Add(new BigramManager.Bigram { FirstWord = "and", SecondWord = "the" });
            bigrams.Add(new BigramManager.Bigram { FirstWord = "the", SecondWord = "quick" });
            bigrams.Add(new BigramManager.Bigram { FirstWord = "quick", SecondWord = "blue" });
            bigrams.Add(new BigramManager.Bigram { FirstWord = "blue", SecondWord = "hare" });

            Histogram histogram = new Histogram();
            histogram.PopulateHistogram(bigrams);            
            Assert.AreEqual(histogram.BigramsWithCounts.Count, 7);  // we know that this input should produce 7 items
            Assert.AreEqual(histogram.BigramsWithCounts.Where(bwc => bwc.FirstWord.ToUpper() == "THE" && bwc.SecondWord.ToUpper() == "QUICK").ToList().Count, 1);
            Assert.IsTrue(histogram.BigramsWithCounts.ToList().Exists(bwc => bwc.Count == 2 && bwc.FirstWord.ToUpper() == "THE" && bwc.SecondWord.ToUpper() == "QUICK"));
        }
        
    }
}
