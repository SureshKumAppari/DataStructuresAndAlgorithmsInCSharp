using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    public class ValidWordAbbr
    {
        Dictionary<string, string> singles = null;
        HashSet<string> multies = null;

        public ValidWordAbbr(string[] dictionary)
        {
            this.singles = new Dictionary<string, string>();
            this.multies = new HashSet<string>();

            foreach (string word in dictionary)
            {
                string key = this.GetKey(word);
                if (this.multies.Contains(key)) continue;

                if (this.singles.ContainsKey(key))
                {
                    if (this.singles[key] != word)
                    {
                        // new word with same key -> move to multies
                        this.singles.Remove(key);
                        this.multies.Add(key);
                    }
                }
                else
                {
                    // new key -> add to singles with this word
                    this.singles.Add(key, word);
                }
            }
        }

        public bool IsUnique(string word)
        {
            string key = this.GetKey(word);
            return !this.multies.Contains(key) && (!this.singles.ContainsKey(key) || this.singles[key] == word);
        }

        private string GetKey(string word)
        {
            if (word == null || word.Length < 3) return word;
            return word[0] + (word.Length - 2).ToString() + word[word.Length - 1];
        }
    }
}
