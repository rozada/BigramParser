using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace BigramParser
{
    /// <summary>
    /// This program may be run from the command line by specifying and input file as the first and only parameter
    /// </summary>
    public class Program
    {      

        static void Main(string[] args)
        {
            try
            {   // Open file with streamreader
                using (StreamReader sr = new StreamReader(args[0]))
                {
                    string fileText = sr.ReadToEnd();

                    // read the file
                    IList<string> wordList = CreateWordListFromFileText(fileText);

                    // bigrams
                    BigramManager bigramManager = new BigramManager();
                    bigramManager.CreateBigramList(wordList);
                    bigramManager.DisplayBigrams();

                    // histogram
                    Histogram histogram = new Histogram();
                    histogram.PopulateHistogram(bigramManager.Bigrams);
                    histogram.DisplayHistogram();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }            
        }

        public static IList<string> CreateWordListFromFileText(string fileText)
        {
            // Remove unwanted characters
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            fileText = rgx.Replace(fileText, "");

            // separate words out based on the appearance of empty spaces
            string[] words = fileText.Split(' ');
            IList<string> wordList = new List<string>();
            // this handles the removal of "empty words" created from double spaces
            foreach (var w in words)
            {
                if (w != string.Empty && w != " ")
                {
                    wordList.Add(w);
                }
            }

            return wordList;
        }
    }
}
