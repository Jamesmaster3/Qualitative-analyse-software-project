using System.IO;
using System.Text;

namespace Project_InsightCode
{
    public class TextFile
    {
        private string _fileName;
        private string _fileText;

        public TextFile(string fileLocation)
        {
            _fileName = System.IO.Path.GetFileName(fileLocation);
            using(StreamReader streamReader = new StreamReader(fileLocation, Encoding.UTF8))
{
                _fileText = streamReader.ReadToEnd();
            };
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public string FileText
        {
            get { return _fileText; }
            set { _fileText = value; }
        }
    }
}