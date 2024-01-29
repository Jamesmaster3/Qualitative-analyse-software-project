namespace Project_InsightCode
{
    public class TaggingSystem: TextFile // a tag inherits from the file class, meaning a tag is coupled to a file. 
        // The tags should be ordered in a database or array within an array of tag objects maybe?
    {
        private string _tagName;
        private string _tagText;
        private int _tagIndex;

        public TaggingSystem(string fileLocation, string tagName, string tagText, int tagIndex) : base(fileLocation)
        {
            _tagName = tagName;
            _tagText = tagText;
            _tagIndex = tagIndex;
        }

        public string tagName
        {
            get { return _tagName; }
            set { _tagName = value; }
        }

        public string tagText
        {
            get { return _tagText; }
            set { _tagText = value; }
        }

        public int tagIndex
        {
            get { return _tagIndex; }
            set { _tagIndex = value; }
        }

    }
}