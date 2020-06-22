using TestApplication.DataStructure;
using Xunit;

namespace TestApplication.Tests
{
    public class TrieTests
    {
        private string[] dictionary = new string[]
        {
            "long", "shore", "man", "upper", "class", "he",
            "address", "head", "dress", "k", "ranke", "ranken",
            "haus", "r"
        };

        private Trie CreatePrefixTree()
        {
            var trie = new Trie();
            trie.AddRange(dictionary);
            return trie;
        }

        [Theory]
        [InlineData("longshoreman", new string[] { "long", "shore", "man" })]
        [InlineData("long", new string[] { "long" })]
        [InlineData("longest", new string[0])]
        [InlineData("upperclassman", new string[] { "upper", "class", "man" })]
        [InlineData("headdress", new string[] { "he", "address" })]
        [InlineData("headdressa", new string[0])]
        [InlineData("headgdress", new string[0])]
        [InlineData("krankenhaus", new string[] { "k", "ranken", "haus" })]
        public void FindCompoundWord_Success(string inputWord, string[] expected)
        {
            // arrange
            var trie = CreatePrefixTree();

            // act
            var results = trie.FindCompoundWords(inputWord);

            //assert
            Assert.Equal(results, expected);
        }

    }
}
