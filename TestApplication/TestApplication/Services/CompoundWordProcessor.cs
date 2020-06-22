using System.Collections.Generic;
using TestApplication.Interfaces;
using TestApplication.DataStructure;
using TestApplication.Common;
using System.Threading.Tasks;

namespace TestApplication.Services
{
    public class CompoundWordProcessor : ICompoundWordProcessor
    {
        private readonly IParseService _parseService;
        private readonly IFileService<string> _fileService;

        public CompoundWordProcessor(IParseService parseService, IFileService<string> fileService)
        {
            _parseService = parseService;
            _fileService = fileService;
        }

        public async Task SplitWords()
        {
            var compoundWordsWithParts = new Dictionary<string, IEnumerable<string>>();

            var _dictionaryItems = await GetDictionaryItems();
            var trie = CreateTrie(_dictionaryItems);

            var inputWords = await ReadInputWordsFromFile();
            var transformedWords = _parseService.TransformInputData(inputWords);

            foreach (var word in transformedWords)
            {
                var composedWords = trie.FindCompoundWords(word);
                compoundWordsWithParts.Add(word, composedWords);
            }

            var transformedLines = _parseService.TransfromOutputData(compoundWordsWithParts);
            await WriteLinesToFile(transformedLines);
        }

        private async Task<IEnumerable<string>> GetDictionaryItems()
        {
            var dictionaryItems = await _fileService.ReadAsync(ConfigurationProvider.GetDictionaryPath());
            return dictionaryItems;
        }

        private async Task WriteLinesToFile(IEnumerable<string> lines)
        {
            await _fileService.WriteAsync(ConfigurationProvider.GetOutputPath(), lines);
        }

        private async Task<IEnumerable<string>> ReadInputWordsFromFile()
        {
            var inputWords = await _fileService.ReadAsync(ConfigurationProvider.GetInputFilePath());
            return inputWords;
        }

        private Trie CreateTrie(IEnumerable<string> dictionaryItems)
        {
            var trie = new Trie();
            trie.AddRange(dictionaryItems);
            return trie;
        }
    }
}
