using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Patterns.Recursion
{
    /// <summary>
    /// Can a group of letter make a word
    /// Details the idea of finding the best option first.
    /// Optimisitic approach.
    /// </summary>
    public class WordBackTracker
    {
        #region Fields

        private static JObject dictionary;

        #endregion

        #region Properties

        public List<string> PossibleWords
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        public WordBackTracker()
        {
            // this can be copied from the Patterns project into your C: drive //
            dictionary = JObject.Parse(File.ReadAllText(@"c:\temp\dictionary.json"));

            this.PossibleWords = new List<string>();
        }

        public bool IsAnagram(string soFar, string rest)
        {
            if (string.IsNullOrEmpty(rest))
                return doesLexiconContain(soFar);
            else
            {
                for (int i = 0; i < rest.Length; i++)
                {
                    string next = soFar + rest[i];

                    string remaining = rest.Substring(0, i) + rest.Substring(i + 1);

                    if (IsAnagram(next, remaining))
                    {
                        PossibleWords.Add(next);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool doesLexiconContain(string possibleWord)
        {
            foreach (var word in dictionary)
            {
                if (word.Key.ToLower() == possibleWord.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        #endregion  
    }
}
