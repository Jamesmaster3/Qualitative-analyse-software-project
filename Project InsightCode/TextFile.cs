using System.ComponentModel;
using System.IO;
using System.Text;

namespace Project_InsightCode
{
    public class TextFile :INotifyPropertyChanged
    {
        private string _fileName;
        private string _fileText;

        public TextFile(string fileLocation) // extract filename of the file and extract the file contents
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
            set 
            { 
                _fileName = value;
                OnPropertyChanged(nameof(FileName));
                
            }
        }

        public string FileText
        {
            get { return _fileText; }
            set
            {
                _fileText = value;
                OnPropertyChanged(nameof(FileText));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}