using Microsoft.Win32;
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
        public MainWindow()
        {
            InitializeComponent();
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
            if (!string.IsNullOrWhiteSpace(tagName.Text) && !lstNames.Items.Contains(tagName.Text))
            // Test to make sure the input box is not empty and the name doesn't already exist
            {
                lstNames.Items.Add(tagName.Text);
                tagName.Clear();
            }
        }

        private void AddFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                /// This is nice if i only want the file name, but i actually want the whole file location and only show the file name
                /// lstNames.Items.Add(System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName));
                /// This is the full file text
                /// lstNames.Items.Add(File.ReadAllText(openFileDialog.FileName));
                /// And this the full file location
                lstNames.Items.Add(openFileDialog.FileName);
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