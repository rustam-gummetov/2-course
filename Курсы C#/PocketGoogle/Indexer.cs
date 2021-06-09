using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle
{
    public class Indexer : IIndexer
    {
        public Dictionary<string, int> dictionary;
        public string[] words;

        public void Add(int id, string documentText)
        {
            words = documentText.Split(' ', '.', ',', '!', '?', ':', '-', '\r', '\n');
            foreach(var word in words)
            {
                if ()
            }
        }

        public List<int> GetIds(string word)
        {
            throw new NotImplementedException();
        }

        public List<int> GetPositions(int id, string word)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
