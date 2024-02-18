using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
