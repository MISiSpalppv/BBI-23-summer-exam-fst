using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Newtonsoft;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Variant_6
{
    public class Task4
    {
        public interface ISerializer
        {
            void Serialize(string path, object obj);
            object Deserialize(string path, Type type);
        }

        public class StatisticSerializer
        {
            public void CreateFolder(string path, string folderName)
            {
                string fullPath = Path.Combine(path, folderName);
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }
            }

            public void CreateFile(string path, string fileName)
            {
                string fullPath = Path.Combine(path, fileName);
                if (!File.Exists(fullPath))
                {
                    File.Create(fullPath).Dispose();
                }
            }

            public void CreateFolders(string path, string[] folderNames)
            {
                foreach (var folderName in folderNames)
                {
                    CreateFolder(path, folderName);
                }
            }

            public void CreateFiles(string path, string[] fileNames)
            {
                foreach (var fileName in fileNames)
                {
                    CreateFile(path, fileName);
                }
            }
        }

        public class JSONSerializer : StatisticSerializer, ISerializer
        {
            private Task3.Reverter myReverter;

            public Task3.Reverter MyReverter
            {
                get { return myReverter; }
                set { myReverter = value; }
            }

            public void Serialize(string path, object obj)
            {
                string json = JsonSerializer.Serialize(obj);
                File.WriteAllText(path, json);
            }

            public object Deserialize(string path, Type type)
            {
                string json = File.ReadAllText(path);
                return JsonSerializer.Deserialize(json, type);
            }
        }
    }
}
