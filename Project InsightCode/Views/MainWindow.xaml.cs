﻿using Microsoft.Win32;
using Project_InsightCode.Models;
using Project_InsightCode.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Resources;
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
            MainViewModel mainViewModel = new MainViewModel();
            this.DataContext = mainViewModel;

        }

        private void ButtonAddTag_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tagName.txtLimitedInput.Text) && !lstNames.Items.Contains(tagName.txtLimitedInput.Text))
            // Test to make sure the input box is not empty and the name doesn't already exist
            {
                TagManager.AddTag(new Tag(tagName.txtLimitedInput.Text));
                tagName.txtLimitedInput.Clear();
            }
        }

        private void AddFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            openFileDialog.Filter = "Text files (*.txt; *.docx)|*.txt; *.docx";
            openFileDialog.Multiselect = true;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                var viewModel = DataContext as MainViewModel;
                foreach (string filepath in openFileDialog.FileNames)
                    try{
                        viewModel?.textFiles.Add(new TextFile(filepath));
                        // Adds an istance of the TextFile class to the observable collection textFiles
                    }
                    catch (FileNotFoundException ex) {
                        MessageBox.Show("File not found");
                        Console.WriteLine(ex.Message);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Error loading file");
                        Console.WriteLine(ex.Message);
                    }
            }
        }

        private void DeleteFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTag_Click(object sender, RoutedEventArgs e)
        {
            // create a tag that inherits the parent fileLocation (current working file) and that stores tagtext, index and tagname
            // Tags should be callable in a list and searchable for file and tag name
            
            string text = editorView.Selection.Text;

            TagManager.AddTagText("Test", text, 1, 3);
        }

        private void fileExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e) // Have to find out what this is for later
        {
            { };
        }

    }
}