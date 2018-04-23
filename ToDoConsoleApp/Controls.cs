using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoLibrary;

namespace ToDoConsoleApp
{
    public class Controls
    {
        private static string instructions = "Instructions";
        private static string allItems = "All";
        private static string createItem = "Create";
        private static string removeItem = "Remove";
        private static string changeStatus = "Change";
        private static string[] listChoices = ToDoItem.choices;

        public static void PrintList(string status)
        {
            List<ToDoItem> items = ToDoItem.Manager.GetItems(status);
            if (items.Count == 0)
            {
                Console.WriteLine("No items in the list");
            }
            else
            {
                foreach (ToDoItem item in items)
                {
                    Console.WriteLine(item);
                }
            }   
        }

        public static void PrintList()
        {
            List<ToDoItem> items = ToDoItem.Manager.GetItems();
            if (items.Count == 0)
            {
                Console.WriteLine("No items in the list");
            }
            else
            {
                foreach (ToDoItem item in items)
                {
                    Console.WriteLine(item);
                }
            }
            
        }

        public static void CreateItem()
        {
            Console.WriteLine("Enter content:");
            string content = Console.ReadLine();
            Console.WriteLine("Enter status (Choices: " + GetStatusChoicesString() + "):");
            string status = Console.ReadLine();
            try
            {
                ToDoItem item = ToDoItem.Manager.CreateItem(content, status);
                Console.WriteLine(string.Format("Successfully created item: {0}", item));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void RemoveItem()
        {
            Console.WriteLine("Enter item id:");
            string idxString = Console.ReadLine();
            int idx = 0;
            if (!(Int32.TryParse(idxString, out idx)))
            {
                Console.WriteLine("Entry isn't a number.");
                return;
            }
            try
            {
                ToDoItem.Manager.RemoveItem(idx);
                Console.WriteLine(string.Format("Successfully removed item ID# \"{0}\".", idx));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ChangeStatus()
        {
            Console.WriteLine("Enter item id:");
            string idxString = Console.ReadLine();
            int idx = 0;

            if (!(Int32.TryParse(idxString, out idx)))
            {
                Console.WriteLine("Entry isn't a number.");
                return;
            }

            try
            {
                ToDoItem item = ToDoItem.Manager.GetItem(idx);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            try
            {
                Console.WriteLine("Enter new status " + GetStatusChoicesString() + ":");
                string status = Console.ReadLine();
                ToDoItem.Manager.ChangeStatus(idx, status);
                Console.WriteLine(string.Format("Status of item ID# {0} has been successfully changed to \"{1}\".", idx, status));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        public static void PrintInstructions()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Print instructions: \"{0}\"", instructions));
            sb.AppendLine(string.Format("Print all items: \"{0}\"", allItems));
            sb.AppendLine(string.Format("Add item: \"{0}\"", createItem));
            sb.Append("Print list: ");
            sb.AppendLine(GetStatusChoicesString());
            sb.AppendLine(string.Format("Remove item: \"{0}\"", removeItem));
            sb.AppendLine(string.Format("Change status of an item: \"{0}\"", changeStatus));
            Console.WriteLine(sb.ToString());
        }

        public static string GetStatusChoicesString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < listChoices.Length; i++)
            {
                if (i < listChoices.Length - 1)
                {
                    sb.Append(string.Format("\"{0}\" or ", listChoices[i]));
                }
                else
                {
                    sb.Append(string.Format("\"{0}\"", listChoices[i]));
                }
            }
            return sb.ToString();
        }

        public static void Actions()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Enter command:");
            string input = Console.ReadLine();
            if (input == instructions)
            {
                PrintInstructions();
            }
            else if (input == allItems)
            {
                PrintList();
            }
            else if (input == createItem)
            {
                CreateItem();
            }
            else if (input == removeItem)
            {
                RemoveItem();
            }
            else if (input == changeStatus)
            {
                ChangeStatus();
            }
            else if (listChoices.Contains(input))
            {
                PrintList(input);
            }
            else
            {
                Console.WriteLine("Incorrect statement. Please type in \"Instructions\" to get list of commands.");
            }
        }

        public static void PrintWelcomeMessage()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Welcome to To-Do Console App");
            sb.AppendLine("Type into console one of the following commands to begin your work");
            Console.WriteLine(sb.ToString());
        }
    }
}
