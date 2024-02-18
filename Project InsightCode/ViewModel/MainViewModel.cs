using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Project_InsightCode;
using Project_InsightCode.Commands;
using Project_InsightCode.Models;
using Project_InsightCode.Views;

namespace Project_InsightCode.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TextFile> textFiles { get; set; } //collection of textfile objects
        public ObservableCollection<Tag> tags { get; set; }

        public ICommand ShowWindowCommand { get; set; }

        public MainViewModel()
        {
            textFiles = new ObservableCollection<TextFile>();
            tags = TagManager.GetTags();

            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);

        }

        private bool CanShowWindow(object obj)
        {
            return true;
            // you can implement here, when you do not want to show the window
        }

        private void ShowWindow(object obj)
        {
            var mainWindow = obj as Window;
            
            AddTagWindow InputTagWin = new AddTagWindow();
            InputTagWin.Owner = mainWindow;
            InputTagWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            InputTagWin.Show();
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
