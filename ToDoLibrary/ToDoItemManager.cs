using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ToDoLibrary
{
    public class ToDoItemManager
    {
        private List<ToDoItem> ToDoItems;

        public ToDoItemManager()
        {
            ToDoItems = new List<ToDoItem>();
        }

        public ToDoItem CreateItem(string content, string status)
        {
            int idx = GenerateId();
            ToDoItem newItem = new ToDoItem(idx, content, status);
            ToDoItems.Add(newItem);
            DataManager.SaveListToJson();
            return newItem;
        }

        public void AddFromJson(int idx, string content, string status)
        {
            ToDoItem item = new ToDoItem(idx, content, status);
            ToDoItems.Add(item);
        }

        public void RemoveItem(int idx)
        {
            ToDoItem itemToRemove = GetItem(idx);
            ToDoItems.Remove(itemToRemove);
            DataManager.SaveListToJson();
        }

        public ToDoItem ChangeStatus(int idx, string status)
        {
            ToDoItem itemToUpdate = GetItem(idx);
            if (itemToUpdate.Status == status)
            {
                throw new Exception("Status change failed. This status has already been assigned.");
            }
            itemToUpdate.Status = status;
            DataManager.SaveListToJson();
            return itemToUpdate;
        }

        public List<ToDoItem> GetItems(string status)
        {
            return ToDoItems.Where(r => r.Status == status).ToList();
        }

        public List<ToDoItem> GetItems()
        {
            return ToDoItems;
        }

        public ToDoItem GetItem(int idx)
        {
            return ToDoItems.Single(r => r.Idx == idx);
        }

        public int GenerateId()
        {
            try
            {
                int max_id = ToDoItems.Max(r => r.Idx);
                return max_id + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
