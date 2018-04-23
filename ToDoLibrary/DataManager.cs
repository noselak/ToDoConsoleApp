using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ToDoLibrary
{
    public class DataManager
    {
        private static string jsonFilePath = Path.Combine(Environment.CurrentDirectory, @"data\", "data.json");

        public static void LoadInitialData()
        {
            string json = File.ReadAllText(jsonFilePath);
            List<Dictionary<string, object>> items = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);

            if (items != null)
            {
                foreach (Dictionary<string, object> item in items)
                {
                    int idx = (int)(long)item["Idx"];
                    string content = (string)item["Content"];
                    string status = (string)item["Status"];
                    ToDoItem.Manager.AddFromJson(idx, content, status);
                }
            }
            
        }

        public static void SaveListToJson()
        {
            string json = JsonConvert.SerializeObject(ToDoItem.Manager.GetItems());
            File.WriteAllText(jsonFilePath, json);
        }
    }
}
