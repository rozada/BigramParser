using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigramParser
{
    public class Histogram
    {
        public class BigramWithCount
        {
            public string FirstWord;
            public string SecondWord;
            public int Count;
        }

        public IList<BigramWithCount> BigramsWithCounts {  get; set;}

        public void PopulateHistogram(IList<BigramManager.Bigram> bigrams)
        {
            BigramsWithCounts = new List<BigramWithCount>();
            foreach (var b in bigrams)
            {
                BigramWithCount foumdBigramWithCount = null;
                foreach (var bwc in BigramsWithCounts)
                {
                    if (bwc.FirstWord.ToUpper() == b.FirstWord.ToUpper() && bwc.SecondWord.ToUpper() == b.SecondWord.ToUpper())
                    {
                        // could increase count here, but it's probably better practice to do it outside the loop
                        foumdBigramWithCount = bwc;
                        break;
                    }
                }
                if (foumdBigramWithCount != null)
                {
                    foumdBigramWithCount.Count++;
                }
                else
                {
                    BigramsWithCounts.Add(new BigramWithCount { FirstWord = b.FirstWord, SecondWord = b.SecondWord, Count = 1 });
                }                
            }            
        }

        public void DisplayHistogram()
        {
            Console.WriteLine("*** Histogram ***");
            Console.WriteLine();
            foreach (var bwc in BigramsWithCounts)
            {
                Console.WriteLine(bwc.FirstWord + ' ' + bwc.SecondWord + ' ' + bwc.Count);
            }

            Console.WriteLine();
            Console.WriteLine("**************");
        }
    }
}
