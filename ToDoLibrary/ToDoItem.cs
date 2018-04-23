using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoLibrary
{
    public class ToDoItem
    {
        public static ToDoItemManager Manager = new ToDoItemManager();
        public int Idx { get; set; }
        public string Content { get; set; }
        private string _status;
        public static string[] choices = new string[] { "To Do", "In Progress", "Done" };

        public override string ToString()
        {
            return string.Format("ID# {0}: {1} ({2})", Idx, Content, Status);
        }

        public string Status
        {
            get { return _status; }
            set
            {
                if (choices.Contains(value))
                {
                    _status = value;
                } else
                {
                    throw new Exception("Invalid status. We were unable to set the status.");
                }
            }
        }

        public ToDoItem(int idx, string content, string status)
        {
            Idx = idx;
            Content = content;
            Status = status;
        }
    }
}
