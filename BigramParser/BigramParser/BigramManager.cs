using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigramParser
{
    public class BigramManager
    {
        public class Bigram
        { 
            public string FirstWord { get; set; }
            public string SecondWord { get; set; }
        }

        public IList<Bigram> Bigrams { get; private set; }

        public IList<Bigram> CreateBigramList(IList<string> wordList)
        {
            Bigrams = new List<Bigram>();
            Bigram bigram = new Bigram();
            bigram.FirstWord = wordList[0];
            foreach (var w in wordList.ToList().GetRange(1, wordList.Count() - 1))
            {
                bigram.SecondWord = w;
                Bigrams.Add(bigram);

                bigram = new Bigram();
                bigram.FirstWord = Bigrams.Last().SecondWord;
            }

            return Bigrams;
        }

        public void DisplayBigrams()
        {
            Console.WriteLine("*** Bigrams ***");
            Console.WriteLine();

            foreach (var b in Bigrams)
            {
                Console.WriteLine(b.FirstWord + ' ' + b.SecondWord);
            }

            Console.WriteLine();
            Console.WriteLine("**************");
        }
    }
}
