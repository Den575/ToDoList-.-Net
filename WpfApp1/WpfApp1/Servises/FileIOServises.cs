using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WpfApp1.Models;

namespace WpfApp1.Servises
{
    class FileIOServises
    {
        public FileIOServises(string path)
        {
            PATH = path;
        }
        private readonly string PATH;
        public BindingList<ToDoModels> LoadData()
        {
            var fileExsist = File.Exists(PATH);
            if (!fileExsist)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<ToDoModels>();
            }
            using(var readrer = File.OpenText(PATH))
            {
                var fileText = readrer.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ToDoModels>>(fileText);
            }
            
        }

        public void SavedData(object toDoDataList) {
            
            using(StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(toDoDataList);
                writer.Write(output);
            }

        }
    }
}
