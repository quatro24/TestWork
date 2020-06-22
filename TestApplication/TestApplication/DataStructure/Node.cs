using System.Collections.Generic;

namespace TestApplication.DataStructure
{
    public class Node
    {
        private readonly Dictionary<char, Node> subNodes;
        private bool isWord;
        private readonly string word;

        public Node(string word)
        {
            subNodes = new Dictionary<char, Node>();
            isWord = false;
            this.word = word;
        }

        public Dictionary<char, Node> SubNodes { get { return subNodes; } }
        public bool IsWord { get { return isWord; } set { isWord = value; } }
        public string Word { get { return word; } }
    }
}
