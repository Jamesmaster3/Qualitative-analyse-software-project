using Project_InsightCode.Commands;
using Project_InsightCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project_InsightCode.ViewModel
{
    class AddTagViemodel
    {

        public ICommand AddTagCommand { get; set; }

        public string? Name { get; set; }

        public AddTagViemodel()
        {
            AddTagCommand = new RelayCommand(AddTag, CanAddTag);

        }

        private bool CanAddTag(object obj)
        {
            return true;
        }

        private void AddTag(object obj)
        {
            TagManager.AddTag(new Tag(Name)) ;
        }


    }
}
