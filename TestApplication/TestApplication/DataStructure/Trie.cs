using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApplication.DataStructure
{
    public class Trie
    {
        private Node root;
        private Stack<string> partsOfWords;
        private List<Stack<string>> combinationOfWords;

        public Trie()
        {
            root = new Node(string.Empty);
        }

        public void AddRange(IEnumerable<string> words)
        {
            if (words == null && words.Count() < 1)
                return;

            foreach (var word in words)
                Add(word);
        }

        public void Add(string word)
        {
            AddRecursive(root, word, string.Empty);
        }

        private void AddRecursive(Node node, string remainingString, string currentString)
        {
            if (remainingString.Length <= 0)
            {
                return;
            }

            char prefix = remainingString[0];
            string substring = remainingString.Substring(1);
            if (!node.SubNodes.ContainsKey(prefix))
            {
                node.SubNodes.Add(prefix, new Node(currentString + prefix));
            }

            if (substring.Length == 0)
            {
                node.SubNodes[prefix].IsWord = true;
                return;
            }
            else
            {
                AddRecursive(node.SubNodes[prefix], substring, currentString + prefix);
            }
        }

        public IEnumerable<string> FindCompoundWords(string searchString)
        {
            partsOfWords = new Stack<string>();
            combinationOfWords = new List<Stack<string>>();

            if (string.IsNullOrEmpty(searchString))
                return null;

            SearchRecursive(root, searchString);

            if (combinationOfWords.Count < 1)
                return new string[0];

            var maxCombination = combinationOfWords.OrderByDescending(c => c.Count).FirstOrDefault();

            return maxCombination.Reverse();
        }

        private bool SearchRecursive(Node node, string searchString)
        {
            if (searchString == string.Empty)
                return true;

            foreach (var search in searchString)
            {
                if (!node.SubNodes.ContainsKey(search))
                {
                    return false;
                }
                node = node.SubNodes[search];
                if (node.IsWord)
                {
                    partsOfWords.Push(node.Word);
                    var remainingString = searchString.Substring(node.Word.Length);

                    if (!SearchRecursive(root, remainingString) && partsOfWords.Count > 0)
                        partsOfWords.Pop();

                    if (string.IsNullOrEmpty(remainingString))
                    {
                        combinationOfWords.Add(partsOfWords);
                        partsOfWords = new Stack<string>();
                    }
                }
            }

            return false;
        }
    }
}
