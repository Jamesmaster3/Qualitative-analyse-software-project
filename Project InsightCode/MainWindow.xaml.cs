using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_InsightCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<TextFile> textFiles = new ObservableCollection<TextFile>();
        public MainWindow()
        {
            InitializeComponent();
            lstNames.ItemsSource = textFiles;

        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e) // Have to find out what this is for later
        {
            { };
        }

        private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonAddTag_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tagName.txtLimitedInput.Text) && !lstNames.Items.Contains(tagName.txtLimitedInput.Text))
            // Test to make sure the input box is not empty and the name doesn't already exist
            {
                tagList.Items.Add(tagName.txtLimitedInput.Text);
                tagName.txtLimitedInput.Clear();
            }
        }

        private void AddFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            openFileDialog.Filter = "Text files (*.txt;*.docx)|*.txt;.docx|All files (*.*)|*.*";
            openFileDialog.Multiselect = true;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filepath in openFileDialog.FileNames) // dit klopt nu want nu vraag ik eigenlijk twee keer hetzelfde
                    try{
                        textFiles.Add(new TextFile(filepath));
                    }
                    catch (Exception ee) {
                        MessageBox.Show(ee.Message);
                    }
            }
        }
    }
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand("Exit", "Exit", typeof(CustomCommands), new InputGestureCollection()
            {
                new KeyGesture(Key.F4, ModifierKeys.Alt)
            }
            );
    }
}