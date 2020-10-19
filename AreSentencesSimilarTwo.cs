using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    class AreSentencesSimilarTwoClass
    {
        public bool AreSentencesSimilarTwo(string[] words1, string[] words2, IList<IList<string>> pairs)
        {
            if (words1.Length != words2.Length) return false;
            var dict = new Dictionary<string, string>();
            foreach (var pair in pairs)
            {
                string word1 = pair[0], word2 = pair[1];
                string parent1 = GetParent(word1, dict), parent2 = GetParent(word2, dict);
                if (parent1 != parent2)
                    dict[parent1] = parent2;
            }

            for (int i = 0; i < words1.Length; i++)
            {
                string word1 = words1[i], word2 = words2[i];
                string parent1 = GetParent(word1, dict), parent2 = GetParent(word2, dict);
                if (parent1 != parent2)
                    return false;
            }
            return true;
        }

        private string GetParent(string key, Dictionary<string, string> dict)
        {
            if (!dict.ContainsKey(key)) dict[key] = key;
            if (dict[key] != key) dict[key] = GetParent(dict[key], dict);
            return dict[key];
        }
    }
}
