using System.IO;
using Newtonsoft.Json;

namespace Contacts
{
    public class Alphabet
    {
        public Alphabet(string file)
        {
            GetAlphabet = DeserializeAlphabet(file);
        }

        public string GetAlphabet { get; init; }

        private string DeserializeAlphabet(string file)
        {
            var alphabetFile = File.ReadAllText(file);
            var alphabet = JsonConvert.DeserializeObject<string>(alphabetFile);

            return alphabet;
        }
    }
}
