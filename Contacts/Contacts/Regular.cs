using System.IO;
using Newtonsoft.Json;

namespace Contacts
{
    public class Regular
    {
        public Regular(string file)
        {
            GetRegular = DeserializeAlphabet(file);
        }

        public string GetRegular { get; init; }

        private string DeserializeAlphabet(string file)
        {
            var alphabetFile = File.ReadAllText(file);
            var alphabet = JsonConvert.DeserializeObject<string>(alphabetFile);

            return alphabet;
        }
    }
}
