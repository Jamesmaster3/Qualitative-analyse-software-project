using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_InsightCode.Models
{
    class TagManager
    {
        public static ObservableCollection<Tag> _TagDatabase = new ObservableCollection<Tag>();

        public static ObservableCollection<Tag> GetTags()
        {
            return _TagDatabase;
        }

        public static void AddTag(Tag tag)
        {
            _TagDatabase.Add(tag);
        }

        public static void AddTagText(string tagTarget, string tagtext, int startpos, int endpos)
        {
            Tag targetObject = _TagDatabase.FirstOrDefault(obj => obj.tagName == tagTarget);

            if (targetObject != null)
            {
                // Object found, do something with it
                // For example:
                targetObject.AddTextBackEnd(tagtext, startpos, endpos);
                MessageBox.Show("Succes");
            }
            else
            {
                // Object not found
                MessageBox.Show("Tag not found");
            }
            
        }
    }
}
