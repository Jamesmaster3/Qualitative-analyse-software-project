using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace Project_InsightCode
{
    public class Tag
        // The tags should be ordered in a database or array within an array of tag objects maybe?
    {
        private string _tagName;
        private Dictionary<string, Tuple<int, int>> _tagInfo = new Dictionary<string, Tuple<int, int>>();

        public Tag(string tagName)
        {
            _tagName = tagName;
        }

        public string tagName 
        {
            get { return _tagName; }
            set { _tagName = value; }
        }

        public Dictionary<string, Tuple<int, int>> TagInfo
        {
            get { return _tagInfo; }
            set { _tagInfo = value; }
        }

        public void AddTextBackEnd(string text, int startpos, int endpos) 
        {
            _tagInfo.Add(text, Tuple.Create(startpos, endpos));
        }

    }
}